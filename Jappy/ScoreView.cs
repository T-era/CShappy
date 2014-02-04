using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;

namespace Jappy
{
    using Fields;
    using Items;

    public class ScoreView : UserControl
    {
        private int scoreVal;
        private TextBox score;
        private Label _label;

        public ScoreView() 
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.Selectable, false);
        }
        internal void OnScoreChange(int val)
        {
            if (val != scoreVal)
            {
                scoreVal = val;
                this.Invalidate();
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            score.Text = scoreVal.ToString();
            base.OnPaint(e);
        }

        private void InitializeComponent()
        {
            this._label = new System.Windows.Forms.Label();
            this.score = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // _label
            // 
            this._label.AutoSize = true;
            this._label.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._label.ForeColor = System.Drawing.Color.White;
            this._label.Location = new System.Drawing.Point(3, 8);
            this._label.Name = "_label";
            this._label.Size = new System.Drawing.Size(71, 19);
            this._label.TabIndex = 0;
            this._label.Text = "Score:";
            // 
            // score
            // 
            this.score.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.score.BackColor = System.Drawing.Color.Black;
            this.score.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.score.ForeColor = System.Drawing.Color.White;
            this.score.Location = new System.Drawing.Point(80, 2);
            this.score.Name = "score";
            this.score.ReadOnly = true;
            this.score.Size = new System.Drawing.Size(137, 31);
            this.score.TabIndex = 1;
            this.score.TabStop = false;
            this.score.Text = "1234567";
            this.score.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.score.BorderStyle = System.Windows.Forms.BorderStyle.None;
            // 
            // ScoreView
            // 
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.score);
            this.Controls.Add(this._label);
            this.Font = new System.Drawing.Font("Cambria", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "ScoreView";
            this.Size = new System.Drawing.Size(220, 29);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
