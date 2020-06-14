namespace BubbleTrouble
{
    partial class BubbleTrouble
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BubbleTrouble));
            this.pbNewGame = new System.Windows.Forms.PictureBox();
            this.pbShowControls = new System.Windows.Forms.PictureBox();
            this.BallTimer = new System.Windows.Forms.Timer(this.components);
            this.TimeRemainingLevel = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pbNewGame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbShowControls)).BeginInit();
            this.SuspendLayout();
            // 
            // pbNewGame
            // 
            this.pbNewGame.BackColor = System.Drawing.Color.Transparent;
            this.pbNewGame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbNewGame.Image = global::BubbleTrouble.Properties.Resources.newGameBtn;
            this.pbNewGame.Location = new System.Drawing.Point(116, 255);
            this.pbNewGame.Name = "pbNewGame";
            this.pbNewGame.Size = new System.Drawing.Size(206, 54);
            this.pbNewGame.TabIndex = 0;
            this.pbNewGame.TabStop = false;
            this.pbNewGame.Click += new System.EventHandler(this.PbNewGame_Click);
            this.pbNewGame.MouseLeave += new System.EventHandler(this.PbNewGame_MouseLeave);
            this.pbNewGame.MouseHover += new System.EventHandler(this.PbNewGame_MouseHover);
            // 
            // pbShowControls
            // 
            this.pbShowControls.BackColor = System.Drawing.Color.Transparent;
            this.pbShowControls.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbShowControls.Image = global::BubbleTrouble.Properties.Resources.showControlsBtn2;
            this.pbShowControls.Location = new System.Drawing.Point(116, 326);
            this.pbShowControls.Name = "pbShowControls";
            this.pbShowControls.Size = new System.Drawing.Size(206, 54);
            this.pbShowControls.TabIndex = 1;
            this.pbShowControls.TabStop = false;
            this.pbShowControls.Click += new System.EventHandler(this.PbShowControls_Click);
            this.pbShowControls.MouseLeave += new System.EventHandler(this.PbShowControls_MouseLeave);
            this.pbShowControls.MouseHover += new System.EventHandler(this.PbShowControls_MouseHover);
            // 
            // BallTimer
            // 
            this.BallTimer.Tick += new System.EventHandler(this.BallTimer_Tick);
            // 
            // TimeRemainingLevel
            // 
            this.TimeRemainingLevel.Location = new System.Drawing.Point(0, 0);
            this.TimeRemainingLevel.Name = "TimeRemainingLevel";
            this.TimeRemainingLevel.Size = new System.Drawing.Size(823, 26);
            this.TimeRemainingLevel.TabIndex = 2;
            // 
            // BubbleTrouble
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(824, 580);
            this.Controls.Add(this.TimeRemainingLevel);
            this.Controls.Add(this.pbShowControls);
            this.Controls.Add(this.pbNewGame);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BubbleTrouble";
            this.Text = "Bubble Trouble";
            this.Load += new System.EventHandler(this.BubbleTrouble_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.BubbleTrouble_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BubbleTrouble_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.BubbleTrouble_KeyUp);
            this.Resize += new System.EventHandler(this.BubbleTrouble_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pbNewGame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbShowControls)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbNewGame;
        private System.Windows.Forms.PictureBox pbShowControls;
        private System.Windows.Forms.Timer BallTimer;
        private System.Windows.Forms.ProgressBar TimeRemainingLevel;
    }
}

