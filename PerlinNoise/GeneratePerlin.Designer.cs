
namespace PerlinNoise
{
    partial class GeneratePerlin
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
            this.canvas = new System.Windows.Forms.PictureBox();
            this.generatePerlinButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.canvas.Location = new System.Drawing.Point(12, 12);
            this.canvas.Margin = new System.Windows.Forms.Padding(0);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(1230, 922);
            this.canvas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            // 
            // generatePerlinButton
            // 
            this.generatePerlinButton.Location = new System.Drawing.Point(12, 12);
            this.generatePerlinButton.Name = "generatePerlinButton";
            this.generatePerlinButton.Size = new System.Drawing.Size(140, 64);
            this.generatePerlinButton.TabIndex = 1;
            this.generatePerlinButton.Text = "Generate";
            this.generatePerlinButton.UseVisualStyleBackColor = true;
            this.generatePerlinButton.Click += new System.EventHandler(this.generatePerlinButton_Click);
            // 
            // GeneratePerlin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1251, 943);
            this.Controls.Add(this.generatePerlinButton);
            this.Controls.Add(this.canvas);
            this.Name = "GeneratePerlin";
            this.Text = "GeneratePerlin";
            this.Load += new System.EventHandler(this.GeneratePerlin_Load);
            this.Resize += new System.EventHandler(this.GeneratePerlin_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.Button generatePerlinButton;
    }
}