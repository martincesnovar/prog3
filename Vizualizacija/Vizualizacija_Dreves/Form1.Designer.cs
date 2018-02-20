namespace Vizualizacija_Dreves
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
            this.gumb_ustvari = new System.Windows.Forms.Button();
            this.GumbIsci = new System.Windows.Forms.Button();
            this.GumbOdstrani = new System.Windows.Forms.Button();
            this.iskalnik = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gumb_dodaj = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.prikazovalnik2 = new System.Windows.Forms.Label();
            this.prikazovalnik1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gumb_ustvari
            // 
            this.gumb_ustvari.Location = new System.Drawing.Point(352, 3);
            this.gumb_ustvari.Name = "gumb_ustvari";
            this.gumb_ustvari.Size = new System.Drawing.Size(75, 23);
            this.gumb_ustvari.TabIndex = 0;
            this.gumb_ustvari.Text = "Ustvari";
            this.gumb_ustvari.UseVisualStyleBackColor = true;
            this.gumb_ustvari.Visible = false;
            this.gumb_ustvari.Click += new System.EventHandler(this.gumb_ustvari_Click);
            // 
            // GumbIsci
            // 
            this.GumbIsci.Location = new System.Drawing.Point(84, 3);
            this.GumbIsci.Name = "GumbIsci";
            this.GumbIsci.Size = new System.Drawing.Size(75, 23);
            this.GumbIsci.TabIndex = 1;
            this.GumbIsci.Text = "Isci";
            this.GumbIsci.UseVisualStyleBackColor = true;
            this.GumbIsci.Click += new System.EventHandler(this.GumbIsci_Click);
            // 
            // GumbOdstrani
            // 
            this.GumbOdstrani.Location = new System.Drawing.Point(165, 3);
            this.GumbOdstrani.Name = "GumbOdstrani";
            this.GumbOdstrani.Size = new System.Drawing.Size(75, 23);
            this.GumbOdstrani.TabIndex = 2;
            this.GumbOdstrani.Text = "Odstrani";
            this.GumbOdstrani.UseVisualStyleBackColor = true;
            this.GumbOdstrani.Click += new System.EventHandler(this.GumbOdstrani_Click);
            // 
            // iskalnik
            // 
            this.iskalnik.Location = new System.Drawing.Point(246, 3);
            this.iskalnik.Name = "iskalnik";
            this.iskalnik.Size = new System.Drawing.Size(100, 20);
            this.iskalnik.TabIndex = 3;
            this.iskalnik.KeyDown += new System.Windows.Forms.KeyEventHandler(this.iskalnik_KeyDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(0, 50);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(695, 516);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // gumb_dodaj
            // 
            this.gumb_dodaj.Location = new System.Drawing.Point(3, 3);
            this.gumb_dodaj.Name = "gumb_dodaj";
            this.gumb_dodaj.Size = new System.Drawing.Size(75, 23);
            this.gumb_dodaj.TabIndex = 5;
            this.gumb_dodaj.Text = "Dodaj";
            this.gumb_dodaj.UseVisualStyleBackColor = true;
            this.gumb_dodaj.Click += new System.EventHandler(this.gumb_dodaj_Click);
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.prikazovalnik2);
            this.panel1.Controls.Add(this.prikazovalnik1);
            this.panel1.Controls.Add(this.gumb_dodaj);
            this.panel1.Controls.Add(this.GumbIsci);
            this.panel1.Controls.Add(this.gumb_ustvari);
            this.panel1.Controls.Add(this.iskalnik);
            this.panel1.Controls.Add(this.GumbOdstrani);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(671, 37);
            this.panel1.TabIndex = 6;
            // 
            // prikazovalnik2
            // 
            this.prikazovalnik2.AutoSize = true;
            this.prikazovalnik2.Location = new System.Drawing.Point(546, 8);
            this.prikazovalnik2.Name = "prikazovalnik2";
            this.prikazovalnik2.Size = new System.Drawing.Size(35, 13);
            this.prikazovalnik2.TabIndex = 7;
            this.prikazovalnik2.Text = "label2";
            // 
            // prikazovalnik1
            // 
            this.prikazovalnik1.AutoSize = true;
            this.prikazovalnik1.Location = new System.Drawing.Point(505, 8);
            this.prikazovalnik1.Name = "prikazovalnik1";
            this.prikazovalnik1.Size = new System.Drawing.Size(35, 13);
            this.prikazovalnik1.TabIndex = 6;
            this.prikazovalnik1.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 516);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button gumb_ustvari;
        private System.Windows.Forms.Button GumbIsci;
        private System.Windows.Forms.Button GumbOdstrani;
        private System.Windows.Forms.TextBox iskalnik;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button gumb_dodaj;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label prikazovalnik2;
        private System.Windows.Forms.Label prikazovalnik1;
    }
}

