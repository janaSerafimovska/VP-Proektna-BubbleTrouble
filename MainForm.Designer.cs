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
            this.pbHelp = new System.Windows.Forms.PictureBox();
            this.pbScore = new System.Windows.Forms.PictureBox();
            this.lblScore = new System.Windows.Forms.Label();
            this.pbLevel = new System.Windows.Forms.PictureBox();
            this.lblLevelNumber = new System.Windows.Forms.Label();
            this.ReadyTimer = new System.Windows.Forms.Timer(this.components);
            this.lblCoundown = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbNewGame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbShowControls)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // pbNewGame
            // 
            this.pbNewGame.BackColor = System.Drawing.Color.Transparent;
            this.pbNewGame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbNewGame.Image = global::BubbleTrouble.Properties.Resources.newGameBtn;
            resources.ApplyResources(this.pbNewGame, "pbNewGame");
            this.pbNewGame.Name = "pbNewGame";
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
            resources.ApplyResources(this.pbShowControls, "pbShowControls");
            this.pbShowControls.Name = "pbShowControls";
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
            resources.ApplyResources(this.TimeRemainingLevel, "TimeRemainingLevel");
            this.TimeRemainingLevel.Name = "TimeRemainingLevel";
            // 
            // pbHelp
            // 
            this.pbHelp.BackColor = System.Drawing.Color.Transparent;
            this.pbHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.pbHelp, "pbHelp");
            this.pbHelp.Image = global::BubbleTrouble.Properties.Resources.questionImg;
            this.pbHelp.Name = "pbHelp";
            this.pbHelp.TabStop = false;
            this.pbHelp.Click += new System.EventHandler(this.PbHelp_Click);
            // 
            // pbScore
            // 
            this.pbScore.BackColor = System.Drawing.Color.Transparent;
            this.pbScore.Image = global::BubbleTrouble.Properties.Resources.score;
            resources.ApplyResources(this.pbScore, "pbScore");
            this.pbScore.Name = "pbScore";
            this.pbScore.TabStop = false;
            // 
            // lblScore
            // 
            resources.ApplyResources(this.lblScore, "lblScore");
            this.lblScore.BackColor = System.Drawing.Color.Transparent;
            this.lblScore.Name = "lblScore";
            // 
            // pbLevel
            // 
            this.pbLevel.BackColor = System.Drawing.Color.Transparent;
            this.pbLevel.Image = global::BubbleTrouble.Properties.Resources.lvl;
            resources.ApplyResources(this.pbLevel, "pbLevel");
            this.pbLevel.Name = "pbLevel";
            this.pbLevel.TabStop = false;
            // 
            // lblLevelNumber
            // 
            resources.ApplyResources(this.lblLevelNumber, "lblLevelNumber");
            this.lblLevelNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblLevelNumber.Name = "lblLevelNumber";
            // 
            // ReadyTimer
            // 
            this.ReadyTimer.Interval = 1000;
            this.ReadyTimer.Tick += new System.EventHandler(this.ReadyTimer_Tick);
            // 
            // lblCoundown
            // 
            resources.ApplyResources(this.lblCoundown, "lblCoundown");
            this.lblCoundown.BackColor = System.Drawing.Color.Transparent;
            this.lblCoundown.Name = "lblCoundown";
            // 
            // BubbleTrouble
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblCoundown);
            this.Controls.Add(this.lblLevelNumber);
            this.Controls.Add(this.pbLevel);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.pbScore);
            this.Controls.Add(this.pbHelp);
            this.Controls.Add(this.TimeRemainingLevel);
            this.Controls.Add(this.pbShowControls);
            this.Controls.Add(this.pbNewGame);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BubbleTrouble";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.BubbleTrouble_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.BubbleTrouble_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.BubbleTrouble_KeyUp);
            this.Resize += new System.EventHandler(this.BubbleTrouble_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pbNewGame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbShowControls)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLevel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbNewGame;
        private System.Windows.Forms.PictureBox pbShowControls;
        private System.Windows.Forms.Timer BallTimer;
        private System.Windows.Forms.ProgressBar TimeRemainingLevel;
        private System.Windows.Forms.PictureBox pbHelp;
        private System.Windows.Forms.PictureBox pbScore;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.PictureBox pbLevel;
        private System.Windows.Forms.Label lblLevelNumber;
        private System.Windows.Forms.Timer ReadyTimer;
        private System.Windows.Forms.Label lblCoundown;
    }
}

