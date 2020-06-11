namespace Chess
{
    partial class Promotion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Promotion));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.queen_PictureBox = new System.Windows.Forms.PictureBox();
            this.rook_PictureBox = new System.Windows.Forms.PictureBox();
            this.bishop_PictureBox = new System.Windows.Forms.PictureBox();
            this.knight_PictureBox = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.queen_PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rook_PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bishop_PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.knight_PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.queen_PictureBox);
            this.flowLayoutPanel1.Controls.Add(this.rook_PictureBox);
            this.flowLayoutPanel1.Controls.Add(this.bishop_PictureBox);
            this.flowLayoutPanel1.Controls.Add(this.knight_PictureBox);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 44);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(440, 112);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(440, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Choose figure to promote";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // queen_PictureBox
            // 
            this.queen_PictureBox.Location = new System.Drawing.Point(15, 15);
            this.queen_PictureBox.Margin = new System.Windows.Forms.Padding(15);
            this.queen_PictureBox.Name = "queen_PictureBox";
            this.queen_PictureBox.Size = new System.Drawing.Size(80, 80);
            this.queen_PictureBox.TabIndex = 0;
            this.queen_PictureBox.TabStop = false;
            // 
            // rook_PictureBox
            // 
            this.rook_PictureBox.Location = new System.Drawing.Point(125, 15);
            this.rook_PictureBox.Margin = new System.Windows.Forms.Padding(15);
            this.rook_PictureBox.Name = "rook_PictureBox";
            this.rook_PictureBox.Size = new System.Drawing.Size(80, 80);
            this.rook_PictureBox.TabIndex = 1;
            this.rook_PictureBox.TabStop = false;
            // 
            // bishop_PictureBox
            // 
            this.bishop_PictureBox.Location = new System.Drawing.Point(235, 15);
            this.bishop_PictureBox.Margin = new System.Windows.Forms.Padding(15);
            this.bishop_PictureBox.Name = "bishop_PictureBox";
            this.bishop_PictureBox.Size = new System.Drawing.Size(80, 80);
            this.bishop_PictureBox.TabIndex = 2;
            this.bishop_PictureBox.TabStop = false;
            // 
            // knight_PictureBox
            // 
            this.knight_PictureBox.Location = new System.Drawing.Point(345, 15);
            this.knight_PictureBox.Margin = new System.Windows.Forms.Padding(15);
            this.knight_PictureBox.Name = "knight_PictureBox";
            this.knight_PictureBox.Size = new System.Drawing.Size(80, 80);
            this.knight_PictureBox.TabIndex = 3;
            this.knight_PictureBox.TabStop = false;
            // 
            // Promotion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 180);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Promotion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Promotion";
            this.Load += new System.EventHandler(this.Promotion_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.queen_PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rook_PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bishop_PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.knight_PictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox queen_PictureBox;
        private System.Windows.Forms.PictureBox rook_PictureBox;
        private System.Windows.Forms.PictureBox bishop_PictureBox;
        private System.Windows.Forms.PictureBox knight_PictureBox;
    }
}