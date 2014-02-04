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
        private static readonly IStage[] Stages = new IStage[] {
            new SimpleStage(),
            new SimpleStage2(),
            new DatStage("Jappy.StageDat.Pyramid1.dat"),
            new DatStage("Jappy.StageDat.Cave.dat"),
            new DatStage("Jappy.StageDat.Bridges.dat"),
            new DatStage("Jappy.StageDat.Pyramid2.dat"),
            new DatStage("Jappy.StageDat.GridLike.dat"),
            new DatStage("Jappy.StageDat.Guillotine.dat"),
            new DatStage("Jappy.StageDat.Stairs.dat"),
            new DatStage("Jappy.StageDat.RainyDay.dat"),
            new DatStage("Jappy.StageDat.Well.dat"),
            new GunManStage(),
        };
        private readonly Context context;
        private readonly Field field = new Field();

        public Form1()
        {
            InitializeComponent();
            this.context = new Context(field);
            this.panel1.Context = this.context;
            this.context.Animation += stockView1.Animation;
            this.context.OnRemainChange += stockView1.OnStockChange;
            field.mushroomChanged += mushroomView1.OnInPocketChange;
            field.scoreChanged += scoreView1.OnScoreChange;
            for (int i = 0; i < Stages.Length; i++)
            {
                IStage stage = Stages[i];
                ToolStripItem tsi = new ToolStripMenuItem(
                    "Stage" + (i+1),
                    null,
                    (o, e) =>
                    {
                        field.SetStage(stage);
                        context.Restart(false);
                    });
                stageToolStripMenuItem.DropDownItems.Add(tsi);
            }
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
