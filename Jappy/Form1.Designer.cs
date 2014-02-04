namespace Jappy
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new Jappy.GameView();
            this.mushroomView1 = new Jappy.MushroomView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.systemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scoreView1 = new Jappy.ScoreView();
            this.stockView1 = new Jappy.StockView();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(20, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(640, 400);
            this.panel1.TabIndex = 0;
            // 
            // mushroomView1
            // 
            this.mushroomView1.BackColor = System.Drawing.Color.Black;
            this.mushroomView1.Location = new System.Drawing.Point(226, 470);
            this.mushroomView1.Name = "mushroomView1";
            this.mushroomView1.Size = new System.Drawing.Size(200, 20);
            this.mushroomView1.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.systemToolStripMenuItem,
            this.stageToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(680, 26);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // systemToolStripMenuItem
            // 
            this.systemToolStripMenuItem.Name = "systemToolStripMenuItem";
            this.systemToolStripMenuItem.Size = new System.Drawing.Size(75, 22);
            this.systemToolStripMenuItem.Text = "(&S)ystem";
            // 
            // stageToolStripMenuItem
            // 
            this.stageToolStripMenuItem.Name = "stageToolStripMenuItem";
            this.stageToolStripMenuItem.Size = new System.Drawing.Size(64, 22);
            this.stageToolStripMenuItem.Text = "St(&a)ge";
            // 
            // scoreView1
            // 
            this.scoreView1.BackColor = System.Drawing.Color.Black;
            this.scoreView1.Font = new System.Drawing.Font("Cambria", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreView1.ForeColor = System.Drawing.Color.White;
            this.scoreView1.Location = new System.Drawing.Point(440, 461);
            this.scoreView1.Name = "scoreView1";
            this.scoreView1.Size = new System.Drawing.Size(220, 29);
            this.scoreView1.TabIndex = 0;
            // 
            // stockView1
            // 
            this.stockView1.BackColor = System.Drawing.Color.Black;
            this.stockView1.Location = new System.Drawing.Point(20, 450);
            this.stockView1.Name = "stockView1";
            this.stockView1.Size = new System.Drawing.Size(200, 40);
            this.stockView1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 498);
            this.Controls.Add(this.stockView1);
            this.Controls.Add(this.scoreView1);
            this.Controls.Add(this.mushroomView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GameView panel1;
        private MushroomView mushroomView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem systemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stageToolStripMenuItem;
        private ScoreView scoreView1;
        private StockView stockView1;

    }
}

