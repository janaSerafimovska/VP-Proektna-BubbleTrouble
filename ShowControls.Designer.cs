namespace BubbleTrouble
{
    partial class ShowControls
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowControls));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pbControls = new System.Windows.Forms.PictureBox();
            this.pbRightKey = new System.Windows.Forms.PictureBox();
            this.pbSpaceButton = new System.Windows.Forms.PictureBox();
            this.pbLeftKey = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbControls)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRightKey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSpaceButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeftKey)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 451);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(566, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "Left arrow - makes your little devil guy move left";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 480);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(600, 29);
            this.label3.TabIndex = 5;
            this.label3.Text = "Right arrow - makes your little devil guy move right";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 509);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(425, 29);
            this.label4.TabIndex = 6;
            this.label4.Text = "Spacebar - shoots those darn balls!";
            // 
            // pbControls
            // 
            this.pbControls.Image = global::BubbleTrouble.Properties.Resources.controls;
            this.pbControls.Location = new System.Drawing.Point(302, -38);
            this.pbControls.Name = "pbControls";
            this.pbControls.Size = new System.Drawing.Size(521, 217);
            this.pbControls.TabIndex = 10;
            this.pbControls.TabStop = false;
            // 
            // pbRightKey
            // 
            this.pbRightKey.Image = global::BubbleTrouble.Properties.Resources.rightKeyImg;
            this.pbRightKey.Location = new System.Drawing.Point(846, 145);
            this.pbRightKey.Name = "pbRightKey";
            this.pbRightKey.Size = new System.Drawing.Size(193, 223);
            this.pbRightKey.TabIndex = 9;
            this.pbRightKey.TabStop = false;
            // 
            // pbSpaceButton
            // 
            this.pbSpaceButton.Image = global::BubbleTrouble.Properties.Resources.spaceKeyImg1;
            this.pbSpaceButton.Location = new System.Drawing.Point(425, 239);
            this.pbSpaceButton.Name = "pbSpaceButton";
            this.pbSpaceButton.Size = new System.Drawing.Size(430, 180);
            this.pbSpaceButton.TabIndex = 8;
            this.pbSpaceButton.TabStop = false;
            // 
            // pbLeftKey
            // 
            this.pbLeftKey.Image = global::BubbleTrouble.Properties.Resources.leftKeyImg1;
            this.pbLeftKey.Location = new System.Drawing.Point(154, 149);
            this.pbLeftKey.Name = "pbLeftKey";
            this.pbLeftKey.Size = new System.Drawing.Size(250, 219);
            this.pbLeftKey.TabIndex = 7;
            this.pbLeftKey.TabStop = false;
            // 
            // ShowControls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1178, 544);
            this.Controls.Add(this.pbControls);
            this.Controls.Add(this.pbRightKey);
            this.Controls.Add(this.pbSpaceButton);
            this.Controls.Add(this.pbLeftKey);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShowControls";
            this.Text = "Controls";
            ((System.ComponentModel.ISupportInitialize)(this.pbControls)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRightKey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSpaceButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeftKey)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pbLeftKey;
        private System.Windows.Forms.PictureBox pbSpaceButton;
        private System.Windows.Forms.PictureBox pbRightKey;
        private System.Windows.Forms.PictureBox pbControls;
    }
}