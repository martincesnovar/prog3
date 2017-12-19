namespace _8_StudentiObrazec
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1_spol = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_ime = new System.Windows.Forms.TextBox();
            this.textBox_priimek = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimePicker1_Datum = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.listBox2_podrobnosti = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Studenti = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.Studenti.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.DataSource = this.listBox1.CustomTabOffsets;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(105, 31);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(213, 108);
            this.listBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Spol";
            // 
            // comboBox1_spol
            // 
            this.comboBox1_spol.FormattingEnabled = true;
            this.comboBox1_spol.Items.AddRange(new object[] {
            "Ženska",
            "Moški"});
            this.comboBox1_spol.Location = new System.Drawing.Point(196, 131);
            this.comboBox1_spol.Name = "comboBox1_spol";
            this.comboBox1_spol.Size = new System.Drawing.Size(121, 21);
            this.comboBox1_spol.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(82, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ime";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(69, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Priimek";
            // 
            // textBox_ime
            // 
            this.textBox_ime.Location = new System.Drawing.Point(196, 40);
            this.textBox_ime.Name = "textBox_ime";
            this.textBox_ime.Size = new System.Drawing.Size(320, 20);
            this.textBox_ime.TabIndex = 5;
            // 
            // textBox_priimek
            // 
            this.textBox_priimek.Location = new System.Drawing.Point(196, 83);
            this.textBox_priimek.Name = "textBox_priimek";
            this.textBox_priimek.Size = new System.Drawing.Size(320, 20);
            this.textBox_priimek.TabIndex = 6;
            this.textBox_priimek.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(196, 255);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 22);
            this.button1.TabIndex = 7;
            this.button1.Text = "Dodaj študenta";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dateTimePicker1_Datum
            // 
            this.dateTimePicker1_Datum.Location = new System.Drawing.Point(196, 181);
            this.dateTimePicker1_Datum.Name = "dateTimePicker1_Datum";
            this.dateTimePicker1_Datum.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1_Datum.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Datum rojstva";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // listBox2_podrobnosti
            // 
            this.listBox2_podrobnosti.DataSource = this.listBox2_podrobnosti.CustomTabOffsets;
            this.listBox2_podrobnosti.FormattingEnabled = true;
            this.listBox2_podrobnosti.Location = new System.Drawing.Point(105, 154);
            this.listBox2_podrobnosti.Name = "listBox2_podrobnosti";
            this.listBox2_podrobnosti.Size = new System.Drawing.Size(266, 186);
            this.listBox2_podrobnosti.TabIndex = 10;
            this.listBox2_podrobnosti.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "študenti";
            // 
            // Studenti
            // 
            this.Studenti.Controls.Add(this.tabPage1);
            this.Studenti.Controls.Add(this.tabPage2);
            this.Studenti.Location = new System.Drawing.Point(0, 1);
            this.Studenti.Name = "Studenti";
            this.Studenti.SelectedIndex = 0;
            this.Studenti.Size = new System.Drawing.Size(628, 456);
            this.Studenti.TabIndex = 12;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listBox1);
            this.tabPage1.Controls.Add(this.listBox2_podrobnosti);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(620, 430);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Študenti";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.textBox_ime);
            this.tabPage2.Controls.Add(this.textBox_priimek);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.dateTimePicker1_Datum);
            this.tabPage2.Controls.Add(this.comboBox1_spol);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(620, 430);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Dodaj študenta";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 457);
            this.Controls.Add(this.Studenti);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Studenti.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1_spol;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_ime;
        private System.Windows.Forms.TextBox textBox_priimek;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1_Datum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBox2_podrobnosti;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabControl Studenti;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}

