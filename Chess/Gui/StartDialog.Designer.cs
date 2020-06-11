namespace Chess
{
    partial class StartDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartDialog));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.white_TextBox = new System.Windows.Forms.TextBox();
            this.black_TextBox = new System.Windows.Forms.TextBox();
            this.play_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Perpetua Titling MT", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Chocolate;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(415, 47);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome to chess";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Perpetua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Chocolate;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Location = new System.Drawing.Point(12, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "WHITE player\'s name:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Perpetua", 12F);
            this.label3.ForeColor = System.Drawing.Color.Chocolate;
            this.label3.Location = new System.Drawing.Point(14, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(179, 30);
            this.label3.TabIndex = 2;
            this.label3.Text = "BLACK player\'s name:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // white_TextBox
            // 
            this.white_TextBox.Font = new System.Drawing.Font("Perpetua", 12F);
            this.white_TextBox.ForeColor = System.Drawing.Color.Chocolate;
            this.white_TextBox.Location = new System.Drawing.Point(218, 82);
            this.white_TextBox.Name = "white_TextBox";
            this.white_TextBox.Size = new System.Drawing.Size(142, 26);
            this.white_TextBox.TabIndex = 3;
            // 
            // black_TextBox
            // 
            this.black_TextBox.Font = new System.Drawing.Font("Perpetua", 12F);
            this.black_TextBox.ForeColor = System.Drawing.Color.Chocolate;
            this.black_TextBox.Location = new System.Drawing.Point(218, 121);
            this.black_TextBox.Name = "black_TextBox";
            this.black_TextBox.Size = new System.Drawing.Size(142, 26);
            this.black_TextBox.TabIndex = 4;
            // 
            // play_Button
            // 
            this.play_Button.Font = new System.Drawing.Font("Perpetua Titling MT", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.play_Button.ForeColor = System.Drawing.Color.Chocolate;
            this.play_Button.Location = new System.Drawing.Point(133, 190);
            this.play_Button.Name = "play_Button";
            this.play_Button.Size = new System.Drawing.Size(173, 37);
            this.play_Button.TabIndex = 5;
            this.play_Button.Text = "PLAY";
            this.play_Button.UseVisualStyleBackColor = true;
            this.play_Button.Click += new System.EventHandler(this.play_Button_Click);
            // 
            // StartDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(46)))), ((int)(((byte)(43)))));
            this.ClientSize = new System.Drawing.Size(439, 239);
            this.Controls.Add(this.play_Button);
            this.Controls.Add(this.black_TextBox);
            this.Controls.Add(this.white_TextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StartDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Welcome";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox white_TextBox;
        private System.Windows.Forms.TextBox black_TextBox;
        private System.Windows.Forms.Button play_Button;
    }
}