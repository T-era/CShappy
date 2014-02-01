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
        internal Field Field { private set; get; }
        internal int Score { private set; get; }
        internal bool AnimationFlag { private set; get; }

        private System.Threading.Timer timer;
        internal Context()
        {
            OnChange += () => { };
        }
        internal void SetStage(Field stage)
        {
            Field = stage;
            OnChange();
            timer = new System.Threading.Timer(Step, null, 0, CLOCK_SIZE);
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
            bool alive = true;
            MoveFlyingMush();
            alive = alive && Fall();
            alive = alive && MoveChars();
            Animation();
            OnChange();
            if (!alive
                || Cleared())
                timer.Dispose();
        }

        private void MoveFlyingMush()
        {
            Field.ForEach((item) =>
            {
                if (item is FlyingMush)
                {
                    FlyingMush fm = (FlyingMush)item;
                    if (fm.IsRand())
                    {
                        Field.Remove(fm);
                        if (Field[fm.Position] is Mush)
                        { }
                        else
                        {
                            Field.Add(new Mush(Field) { X = fm.X, Y = fm.Y });
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

                        Item crush = Field.At(newX, newY);
                        if (crush == null)
                        {
                            fm.X = newX;
                            fm.Y = newY;
                        }
                        else
                        {
                            if (crush is Enemy)
                            {
                                Field.Remove(fm);
                                ((Enemy)crush).Sleep();
                            }
                            else if (crush is Block
                                || crush is Stone)
                            {
                                Field.Remove(fm);
                                Field.Add(new Mush(Field) { X = oldX, Y = oldY });
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
            Field.FallableForEach((item) =>
            {
                if (item is Mush) {
                    Item under = Field.At(item.X, item.Y + item.Height);
                    if (under == null || under is Mush || under is FlyingMush || under is Enemy || under is Me) {
                        item.Y ++;
                        if (under is Enemy) {
                            ((Enemy)under).Sleep();
                            Field.Remove(item);
                        } else if (under is Me) {
                            Field.MushInPocket ++;
                            Field.Remove(item);
                        }
                        else if (under is Mush)
                        {
                            Field.Remove(under);
                        }
                    }
                }
                else if (item is Stone )
                {
                    Item under1 = Field.At(item.X, item.Y + item.Height);
                    Item under2 = Field.At(item.X + 1, item.Y + item.Height);
                    if (under1 == under2) under2 = null;
                    if ((under1 == null || under1 is Mush || under1 is Enemy || under1 is Me)
                        && (under2 == null || under2 is Mush || under2 is Enemy || under2 is Me))
                    {
                        bool cancelFall = false;
                        foreach (var under in new[] { under1, under2 })
                        {
                            if (under is Mush)
                            {
                                Field.Remove(under);
                            }
                            else if (under is Enemy)
                            {
                                ((Enemy)under).Crush(Field);
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
                Field.EnemyForEach((item) =>
                {
                    alive = alive && item.Move(Field);
                });
            }
            return alive;
        }
        private bool MoveMe()
        {
            Keys? pushed = control.PullStack();
            if (pushed != null)
            {
                Me me = null;
                Field.ForEach((item) =>
                {
                    if (item is Me)
                    {
                        me = (Me)item;
                    }
                });

                Keys key = pushed.Value;
                if (key == Keys.Space
                    && Field.MushInPocket > 0)
                {
                    Field.MushInPocket--;
                    if (me.Direction == Direction.Up)
                        Field.Add(new FlyingMush(Field, me.Direction, me.X, me.Y - 1));
                    else if (me.Direction == Direction.Down)
                        Field.Add(new FlyingMush(Field, me.Direction, me.X, me.Y + 2));
                    else if (me.Direction == Direction.Left)
                        Field.Add(new FlyingMush(Field, me.Direction, me.X - 1, me.Y));
                    else if (me.Direction == Direction.Right)
                        Field.Add(new FlyingMush(Field, me.Direction, me.X + 2, me.Y));
                    return true;
                }
                else
                {
                    if (key == Keys.Up)
                    {
                        return Move.Up.Go(Field, me.Position);
                    }
                    else if (key == Keys.Down)
                    {
                        return Move.Down.Go(Field, me.Position);
                    }
                    else if (key == Keys.Right)
                    {
                        return Move.Right.Go(Field, me.Position);
                    }
                    else if (key == Keys.Left)
                    {
                        return Move.Left.Go(Field, me.Position);
                    }
                }
            }
            return true;
        }

        private bool Cleared()
        {
            return Field.IsCleared();
        }
    }
}
