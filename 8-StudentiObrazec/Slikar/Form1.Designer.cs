using System.Drawing;

namespace Slikar
{
    partial class Form1
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
            this.okvirZaSlike = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.okvirZaSlike)).BeginInit();
            this.SuspendLayout();
            // 
            // okvirZaSlike
            // 
            this.okvirZaSlike.Cursor = System.Windows.Forms.Cursors.Cross;
            this.okvirZaSlike.Dock = System.Windows.Forms.DockStyle.Fill;
            this.okvirZaSlike.Location = new System.Drawing.Point(0, 0);
            this.okvirZaSlike.Name = "okvirZaSlike";
            this.okvirZaSlike.Size = new System.Drawing.Size(468, 442);
            this.okvirZaSlike.TabIndex = 0;
            this.okvirZaSlike.TabStop = false;
            this.okvirZaSlike.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.okvirZaSlike_DvojniKlikMiske);
            this.okvirZaSlike.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PritiskMiske);
            this.okvirZaSlike.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PremikMiske);
            this.okvirZaSlike.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DvigMiske);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 442);
            this.Controls.Add(this.okvirZaSlike);
            this.Name = "Form1";
            this.Text = "Form1";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PritiskMiske);
            ((System.ComponentModel.ISupportInitialize)(this.okvirZaSlike)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox okvirZaSlike;
    }
}

