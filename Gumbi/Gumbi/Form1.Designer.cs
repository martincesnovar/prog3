namespace Gumbi
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
            this.gumb = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // gumb
            // 
            this.gumb.Location = new System.Drawing.Point(105, 115);
            this.gumb.Name = "gumb";
            this.gumb.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gumb.Size = new System.Drawing.Size(75, 23);
            this.gumb.TabIndex = 0;
            this.gumb.Text = "Izmuzljivi gumb";
            this.gumb.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.gumb.UseVisualStyleBackColor = true;
            this.gumb.Click += new System.EventHandler(this.gumb_Click);
            this.gumb.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gumb_MouseClick);
            this.gumb.MouseEnter += new System.EventHandler(this.gumb_Click);
            this.gumb.MouseHover += new System.EventHandler(this.gumb_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.gumb);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button gumb;
    }
}

