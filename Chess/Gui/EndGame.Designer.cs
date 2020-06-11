namespace Chess
{
    partial class EndGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EndGame));
            this.newGame_Button = new System.Windows.Forms.Button();
            this.main_Label = new System.Windows.Forms.Label();
            this.exit_Button = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // newGame_Button
            // 
            this.newGame_Button.BackColor = System.Drawing.Color.Black;
            this.newGame_Button.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.newGame_Button.FlatAppearance.BorderSize = 0;
            this.newGame_Button.Font = new System.Drawing.Font("Perpetua Titling MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newGame_Button.ForeColor = System.Drawing.Color.Sienna;
            this.newGame_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.newGame_Button.Location = new System.Drawing.Point(3, 3);
            this.newGame_Button.Name = "newGame_Button";
            this.newGame_Button.Size = new System.Drawing.Size(221, 39);
            this.newGame_Button.TabIndex = 9;
            this.newGame_Button.Text = "New game";
            this.newGame_Button.UseVisualStyleBackColor = true;
            this.newGame_Button.Click += new System.EventHandler(this.newGame_Button_Click);
            // 
            // main_Label
            // 
            this.main_Label.Font = new System.Drawing.Font("Perpetua", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.main_Label.ForeColor = System.Drawing.Color.Chocolate;
            this.main_Label.Location = new System.Drawing.Point(12, 46);
            this.main_Label.Name = "main_Label";
            this.main_Label.Size = new System.Drawing.Size(454, 40);
            this.main_Label.TabIndex = 11;
            this.main_Label.Text = "label2";
            this.main_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // exit_Button
            // 
            this.exit_Button.BackColor = System.Drawing.Color.Black;
            this.exit_Button.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.exit_Button.FlatAppearance.BorderSize = 0;
            this.exit_Button.Font = new System.Drawing.Font("Perpetua Titling MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exit_Button.ForeColor = System.Drawing.Color.Sienna;
            this.exit_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.exit_Button.Location = new System.Drawing.Point(230, 3);
            this.exit_Button.Name = "exit_Button";
            this.exit_Button.Size = new System.Drawing.Size(221, 39);
            this.exit_Button.TabIndex = 12;
            this.exit_Button.Text = "Exit";
            this.exit_Button.UseVisualStyleBackColor = true;
            this.exit_Button.Click += new System.EventHandler(this.exit_Button_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.newGame_Button);
            this.flowLayoutPanel1.Controls.Add(this.exit_Button);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 137);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(454, 46);
            this.flowLayoutPanel1.TabIndex = 13;
            // 
            // EndGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(46)))), ((int)(((byte)(43)))));
            this.ClientSize = new System.Drawing.Size(478, 196);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.main_Label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EndGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "End Game";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button newGame_Button;
        private System.Windows.Forms.Label main_Label;
        private System.Windows.Forms.Button exit_Button;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}