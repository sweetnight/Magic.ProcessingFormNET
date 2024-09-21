
namespace Magic
{
    partial class ProcessingFormNET
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProcessingFormNET));
            this.PesanLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ActivationLoadingImage = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ActivationLoadingImage)).BeginInit();
            this.SuspendLayout();
            // 
            // PesanLabel
            // 
            this.PesanLabel.Location = new System.Drawing.Point(0, 53);
            this.PesanLabel.Name = "PesanLabel";
            this.PesanLabel.Size = new System.Drawing.Size(300, 20);
            this.PesanLabel.TabIndex = 6;
            this.PesanLabel.Text = "Sedang menyimpan...";
            this.PesanLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ActivationLoadingImage);
            this.panel1.Controls.Add(this.PesanLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 100);
            this.panel1.TabIndex = 7;
            // 
            // ActivationLoadingImage
            // 
            this.ActivationLoadingImage.Image = ((System.Drawing.Image)(resources.GetObject("ActivationLoadingImage.Image")));
            this.ActivationLoadingImage.InitialImage = null;
            this.ActivationLoadingImage.Location = new System.Drawing.Point(140, 30);
            this.ActivationLoadingImage.Name = "ActivationLoadingImage";
            this.ActivationLoadingImage.Size = new System.Drawing.Size(20, 20);
            this.ActivationLoadingImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ActivationLoadingImage.TabIndex = 10;
            this.ActivationLoadingImage.TabStop = false;
            // 
            // ProcessingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(300, 100);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProcessingForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Silakan tunggu...";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ActivationLoadingImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox ActivationLoadingImage;
        public System.Windows.Forms.Label PesanLabel;
    }
}