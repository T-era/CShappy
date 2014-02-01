using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

using Jappy.Items;
using Jappy.Control;

namespace Jappy
{
    using Fields;
    using MoveMotion;

    class Context
    {
        private const int CLOCK_SIZE = 240;
        internal event Action OnChange;

        internal readonly KeyboardControl control = new KeyboardControl();
        private readonly Field field;
        internal Field Field { get { return field; } }
        internal int Score { private set; get; }
        internal bool AnimationFlag { private set; get; }

        private bool suspended;
        private System.Threading.Timer timer;
        internal Context(Field field)
        {
            Score = 0;
            OnChange += () => { };
            this.field = field;
            timer = new System.Threading.Timer(Step, null, 0, CLOCK_SIZE);
        }

        internal void Restart(bool decrementMe)
        {
            // TODO dec
            suspended = false;
        }

        internal void PushKey(Keys keyCode)
        {
            control.PushKey(keyCode);
        }
        internal void ReleaseKey(KeyEventArgs key)
        {
            control.ReleaseKey(key);
        }
        internal void Step(object nullObj)
        {
            if (!suspended)
            {
                bool alive = true;
                MoveFlyingMush();
                alive = alive && Fall();
                alive = alive && MoveChars();
                Animation();
                OnChange();
                if (!alive
                    || Cleared())
                    suspended = true;
            }
        }

        private void MoveFlyingMush()
        {
            field.ForEach((item) =>
            {
                if (item is FlyingMush)
                {
                    FlyingMush fm = (FlyingMush)item;
                    if (fm.IsRand())
                    {
                        field.Remove(fm);
                        if (field[fm.Position] is Mush)
                        { }
                        else
                        {
                            field.Add(new Mush(field) { X = fm.X, Y = fm.Y });
                        }
                    }
                    else
                    {
                        int oldX = fm.X;
                        int oldY = fm.Y;
                        int newX = oldX;
                        int newY = oldY;
                        if (fm.Direction == Direction.Up)
                            newY--;
                        else if (fm.Direction == Direction.Down)
                            newY++;
                        else if (fm.Direction == Direction.Left)
                            newX--;
                        else if (fm.Direction == Direction.Right)
                            newX++;

                        Item crush = field.At(newX, newY);
                        if (crush == null)
                        {
                            fm.X = newX;
                            fm.Y = newY;
                        }
                        else
                        {
                            if (crush is Enemy)
                            {
                                field.Remove(fm);
                                ((Enemy)crush).Sleep();
                            }
                            else if (crush is Block
                                || crush is Stone)
                            {
                                field.Remove(fm);
                                field.Add(new Mush(field) { X = oldX, Y = oldY });
                            }
                            else if (crush is Mush)
                            {
                                fm.X = newX;
                                fm.Y = newY;
                                // お手玉状態だとあり得る。
                            }
                            else
                            {
                                throw new Exception("??" + crush);
                            }
                        }
                    }
                }
            });
        }
        private void Animation() { AnimationFlag = !AnimationFlag; }
        private bool Fall()
        {
            bool alive = true;
            field.FallableForEach((item) =>
            {
                if (item is Mush) {
                    Item under = field.At(item.X, item.Y + item.Height);
                    if (under == null || under is Mush || under is FlyingMush || under is Enemy || under is Me) {
                        item.Y ++;
                        if (under is Enemy) {
                            ((Enemy)under).Sleep();
                            field.Remove(item);
                        } else if (under is Me) {
                            field.MushInPocket ++;
                            field.Remove(item);
                        }
                        else if (under is Mush)
                        {
                            field.Remove(under);
                        }
                    }
                }
                else if (item is Stone )
                {
                    Item under1 = field.At(item.X, item.Y + item.Height);
                    Item under2 = field.At(item.X + 1, item.Y + item.Height);
                    if (under1 == under2) under2 = null;
                    if ((under1 == null || under1 is Mush || under1 is Enemy || under1 is Me)
                        && (under2 == null || under2 is Mush || under2 is Enemy || under2 is Me))
                    {
                        bool cancelFall = false;
                        foreach (var under in new[] { under1, under2 })
                        {
                            if (under is Mush)
                            {
                                field.Remove(under);
                            }
                            else if (under is Enemy)
                            {
                                ((Enemy)under).Crush(field);
                                cancelFall = true;
                            }
                            else if (under is Me)
                            {
                                // TODO ((Me)under).Crush();
                                alive = false;
                                cancelFall = true;
                            }
                        }
                        if (!cancelFall)
                        {
                            item.Y++;
                        }
                    }
                }
            });
            return alive;
        }
        private bool MoveChars()
        {
            bool alive = true;
            alive = alive && MoveMe();

            if (alive)
            {
                field.EnemyForEach((item) =>
                {
                    alive = alive && item.Move(field);
                });
            }
            return alive;
        }
        private bool MoveMe()
        {
            Keys? pushed = control.PullStack();
            if (pushed != null)
            {
                Me me = field.Me;

                Keys key = pushed.Value;
                if (key == Keys.Space
                    && field.MushInPocket > 0)
                {
                    int mushX;
                    int mushY;
                    if (me.Direction == Direction.Up)
                    {
                        mushX = me.X;
                        mushY = me.Y - 1;
                    }
                    else if (me.Direction == Direction.Down)
                    {
                        mushX = me.X;
                        mushY = me.Y + 2;
                    }
                    else if (me.Direction == Direction.Left)
                    {
                        mushX = me.X - 1;
                        mushY = me.Y;
                    }
                    else if (me.Direction == Direction.Right)
                    {
                        mushX = me.X + 2;
                        mushY = me.Y;
                    }
                    else throw new Exception("ありえーぬ");
                    field.MushInPocket--;
                    field.Add(new FlyingMush(field, me.Direction, mushX, mushY));
                    return true;
                }
                else
                {
                    if (key == Keys.Up)
                    {
                        return Move.Up.Go(field, me.Position);
                    }
                    else if (key == Keys.Down)
                    {
                        return Move.Down.Go(field, me.Position);
                    }
                    else if (key == Keys.Right)
                    {
                        return Move.Right.Go(field, me.Position);
                    }
                    else if (key == Keys.Left)
                    {
                        return Move.Left.Go(field, me.Position);
                    }
                }
            }
            return true;
        }

        private bool Cleared()
        {
            return field.IsCleared();
        }
    }
}
