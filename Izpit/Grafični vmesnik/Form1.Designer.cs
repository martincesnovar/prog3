namespace WindowsFormsApp1
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
            this.components = new System.ComponentModel.Container();
            this.ponastavi = new System.Windows.Forms.Button();
            this.izpisovalnik = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // ponastavi
            // 
            this.ponastavi.Location = new System.Drawing.Point(103, 189);
            this.ponastavi.Name = "ponastavi";
            this.ponastavi.Size = new System.Drawing.Size(75, 23);
            this.ponastavi.TabIndex = 0;
            this.ponastavi.Text = "Ponastavi";
            this.ponastavi.UseVisualStyleBackColor = true;
            this.ponastavi.Click += new System.EventHandler(this.ponastavi_Click);
            // 
            // izpisovalnik
            // 
            this.izpisovalnik.AutoSize = true;
            this.izpisovalnik.Location = new System.Drawing.Point(100, 47);
            this.izpisovalnik.Name = "izpisovalnik";
            this.izpisovalnik.Size = new System.Drawing.Size(19, 13);
            this.izpisovalnik.TabIndex = 1;
            this.izpisovalnik.Text = "10";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.izpisovalnik_VisibleChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 248);
            this.Controls.Add(this.izpisovalnik);
            this.Controls.Add(this.ponastavi);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ponastavi;
        private System.Windows.Forms.Label izpisovalnik;
        private System.Windows.Forms.Timer timer1;
    }
}

