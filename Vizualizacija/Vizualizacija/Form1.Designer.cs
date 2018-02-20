namespace Vizualizacija
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
            this.vstavi = new System.Windows.Forms.Button();
            this.isci = new System.Windows.Forms.Button();
            this.zbrisi = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // vstavi
            // 
            this.vstavi.Location = new System.Drawing.Point(12, 5);
            this.vstavi.Name = "vstavi";
            this.vstavi.Size = new System.Drawing.Size(75, 23);
            this.vstavi.TabIndex = 0;
            this.vstavi.Text = "Vstavi";
            this.vstavi.UseVisualStyleBackColor = true;
            this.vstavi.Click += new System.EventHandler(this.vstavi_Click);
            // 
            // isci
            // 
            this.isci.Location = new System.Drawing.Point(93, 5);
            this.isci.Name = "isci";
            this.isci.Size = new System.Drawing.Size(75, 23);
            this.isci.TabIndex = 1;
            this.isci.Text = "Isci";
            this.isci.UseVisualStyleBackColor = true;
            this.isci.Click += new System.EventHandler(this.isci_Click);
            // 
            // zbrisi
            // 
            this.zbrisi.Location = new System.Drawing.Point(174, 5);
            this.zbrisi.Name = "zbrisi";
            this.zbrisi.Size = new System.Drawing.Size(75, 23);
            this.zbrisi.TabIndex = 2;
            this.zbrisi.Text = "Zbrisi";
            this.zbrisi.UseVisualStyleBackColor = true;
            this.zbrisi.Click += new System.EventHandler(this.zbrisi_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 34);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(606, 475);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(265, 7);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(75, 20);
            this.textBox.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 521);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.zbrisi);
            this.Controls.Add(this.isci);
            this.Controls.Add(this.vstavi);
            this.Name = "Form1";
            this.Text = "Dvojiška drevesa";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button vstavi;
        private System.Windows.Forms.Button isci;
        private System.Windows.Forms.Button zbrisi;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox;
    }
}

