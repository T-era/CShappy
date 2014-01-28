using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jappy
{
    using Fields;
    using Fields.Stages;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Field f = new Field(new TestStage2());
            panel1.Field = f;
            f.mushroomChanged += mushroomView1.OnInPocketChange;
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            for (var y = 0; y < this.Size.Height; y += GameView.BLOCK_SIZE)
            {
                for (var x = 0; x < this.Size.Width; x += GameView.BLOCK_SIZE)
                {
                    e.Graphics.DrawImage(Items.Block.image, x, y);
                }
            }
        }
    }
}
