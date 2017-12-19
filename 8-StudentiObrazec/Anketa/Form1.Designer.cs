namespace Anketa
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.gumb_naprej = new System.Windows.Forms.Button();
            this.gumb_nazaj = new System.Windows.Forms.Button();
            this.gumb_preklici = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(788, 459);
            this.panel1.TabIndex = 0;
            // 
            // gumb_naprej
            // 
            this.gumb_naprej.Location = new System.Drawing.Point(582, 495);
            this.gumb_naprej.Name = "gumb_naprej";
            this.gumb_naprej.Size = new System.Drawing.Size(75, 23);
            this.gumb_naprej.TabIndex = 0;
            this.gumb_naprej.Text = "naprej";
            this.gumb_naprej.UseVisualStyleBackColor = true;
            // 
            // gumb_nazaj
            // 
            this.gumb_nazaj.Location = new System.Drawing.Point(501, 495);
            this.gumb_nazaj.Name = "gumb_nazaj";
            this.gumb_nazaj.Size = new System.Drawing.Size(75, 23);
            this.gumb_nazaj.TabIndex = 1;
            this.gumb_nazaj.Text = "nazaj";
            this.gumb_nazaj.UseVisualStyleBackColor = true;
            // 
            // gumb_preklici
            // 
            this.gumb_preklici.Location = new System.Drawing.Point(663, 495);
            this.gumb_preklici.Name = "gumb_preklici";
            this.gumb_preklici.Size = new System.Drawing.Size(75, 23);
            this.gumb_preklici.TabIndex = 2;
            this.gumb_preklici.Text = "Prekliči";
            this.gumb_preklici.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 530);
            this.Controls.Add(this.gumb_preklici);
            this.Controls.Add(this.gumb_nazaj);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gumb_naprej);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button gumb_naprej;
        private System.Windows.Forms.Button gumb_nazaj;
        private System.Windows.Forms.Button gumb_preklici;
    }
}

