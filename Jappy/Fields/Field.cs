using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jappy.Fields
{
    using Items;
    using Stages;

    public class Field
    {
        public const int WIDTH = 32;
        public const int HEIGHT = 20;
        private readonly Items.Block OUTLINE;

        private IList<Item> all = new List<Item>();
        private readonly IList<Item> fallable = new List<Item>();
        private readonly IList<Enemy> enemies = new List<Enemy>();
        private readonly IDictionary<ColoredStone, ColoredBlock> goals = new Dictionary<ColoredStone, ColoredBlock>();

        internal Me Me { get; private set; }

        private int mushInPocket;
        internal int MushInPocket
        {
            set
            {
                mushInPocket = value;
                mushroomChanged(mushInPocket);
            }
            get { return mushInPocket; }
        }
        private int score;
        internal int Score
        {
            set
            {
                score = value;
                scoreChanged(score);
            }
            get { return score; }
        }
        internal event Action<int> mushroomChanged;
        internal event Action<int> scoreChanged;

        public Item this[Position p] { get { return At(p.X, p.Y); } }

        public Field() {
            OUTLINE = new Items.Block(this);
        }

        internal void SetStage(IStage stage) {
            IList<Item> items = stage.GetItems(this);
            mushInPocket = 0;
            all.Clear();
            fallable.Clear();
            enemies.Clear();
            goals.Clear();
            Me = null;

            foreach (Item item in items)
            {
                if (item is Me) Me = (Me)item;
                if (item is Mush || item is Stone) fallable.Add(item);
                if (item is Enemy) enemies.Add((Enemy)item);
                if (item is ColoredStone)
                    goals[(ColoredStone)item] = items
                        .Where(t => t is ColoredBlock)
                        .Where(t => ((ColoredBlock)t).Color == ((ColoredStone)item).Color)
                        .Select(t => (ColoredBlock)t)
                        .Single();
            }
            all = items;
        }
        public void ForEach(Action<Item> f)
        {
            foreach (var item in new List<Item>(all))
            {
                f(item);
            }
        }
        public void FallableForEach(Action<Item> f)
        {
            foreach (var item in new List<Item>(fallable))
            {
                f(item);
            }
        }
        internal void EnemyForEach(Action<Enemy> f)
        {
            foreach (var enemy in new List<Enemy>(enemies))
            {
                f(enemy);
            }
        }
        public Item At(int x, int y)
        {
            if (x < 0 || y < 0
                || x >= WIDTH || y >= HEIGHT)
                return OUTLINE;
            return all.Where(t => 0 <= y - t.Y && y - t.Y < t.Height)
                .Where(t => 0 <= x - t.X && x - t.X < t.Width)
                .SingleOrDefault();
        }
        public void Add(Item item)
        {
            all.Add(item);
            if (item is Mush || item is Stone) fallable.Add(item);
            if (item is Enemy) enemies.Add((Enemy)item);
        }
        public void Remove(Item item)
        {
            all.Remove(item);
            fallable.Remove(item);
            if (item is Enemy) enemies.Remove((Enemy)item);
        }
        internal bool IsCleared()
        {
            if (goals.Count != 0)
            {
                foreach (var kv in goals)
                {
                    ColoredStone stone = kv.Key;
                    ColoredBlock block = kv.Value;
                    if (stone.X != block.X
                        || stone.Y != block.Y - 2) return false;

                }
                return true;
            }
            return false;
        }
    }
}
