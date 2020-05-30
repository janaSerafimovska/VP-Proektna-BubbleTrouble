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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BubbleTrouble));
            this.pbNewGame = new System.Windows.Forms.PictureBox();
            this.pbShowControls = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbNewGame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbShowControls)).BeginInit();
            this.SuspendLayout();
            // 
            // pbNewGame
            // 
            this.pbNewGame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbNewGame.Location = new System.Drawing.Point(116, 255);
            this.pbNewGame.Name = "pbNewGame";
            this.pbNewGame.Size = new System.Drawing.Size(206, 54);
            this.pbNewGame.TabIndex = 0;
            this.pbNewGame.TabStop = false;
            this.pbNewGame.Click += new System.EventHandler(this.PbNewGame_Click);
            // 
            // pbShowControls
            // 
            this.pbShowControls.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbShowControls.Location = new System.Drawing.Point(116, 326);
            this.pbShowControls.Name = "pbShowControls";
            this.pbShowControls.Size = new System.Drawing.Size(206, 54);
            this.pbShowControls.TabIndex = 1;
            this.pbShowControls.TabStop = false;
            // 
            // BubbleTrouble
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BubbleTrouble.Properties.Resources.Background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(824, 580);
            this.Controls.Add(this.pbShowControls);
            this.Controls.Add(this.pbNewGame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BubbleTrouble";
            this.Text = "Bubble Trouble";
            this.Load += new System.EventHandler(this.BubbleTrouble_Load);
            this.Resize += new System.EventHandler(this.BubbleTrouble_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pbNewGame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbShowControls)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbNewGame;
        private System.Windows.Forms.PictureBox pbShowControls;
    }
}

