namespace Test
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this._7seg4 = new Wysw7seg._7seg();
            this._7seg3 = new Wysw7seg._7seg();
            this._7seg2 = new Wysw7seg._7seg();
            this._7seg1 = new Wysw7seg._7seg();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(246, 192);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(71, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Wyświetl";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(123, 194);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(113, 20);
            this.textBox1.TabIndex = 5;
            // 
            // _7seg4
            // 
            this._7seg4.BackColor = System.Drawing.Color.Black;
            this._7seg4.isOn = true;
            this._7seg4.Location = new System.Drawing.Point(323, 12);
            this._7seg4.Name = "_7seg4";
            this._7seg4.Nr = 0;
            this._7seg4.Size = new System.Drawing.Size(94, 150);
            this._7seg4.TabIndex = 4;
            // 
            // _7seg3
            // 
            this._7seg3.BackColor = System.Drawing.Color.Black;
            this._7seg3.isOn = false;
            this._7seg3.Location = new System.Drawing.Point(223, 12);
            this._7seg3.Name = "_7seg3";
            this._7seg3.Nr = 0;
            this._7seg3.Size = new System.Drawing.Size(94, 150);
            this._7seg3.TabIndex = 3;
            // 
            // _7seg2
            // 
            this._7seg2.BackColor = System.Drawing.Color.Black;
            this._7seg2.isOn = false;
            this._7seg2.Location = new System.Drawing.Point(123, 12);
            this._7seg2.Name = "_7seg2";
            this._7seg2.Nr = 0;
            this._7seg2.Size = new System.Drawing.Size(94, 150);
            this._7seg2.TabIndex = 2;
            // 
            // _7seg1
            // 
            this._7seg1.BackColor = System.Drawing.Color.Black;
            this._7seg1.isOn = false;
            this._7seg1.Location = new System.Drawing.Point(23, 12);
            this._7seg1.Name = "_7seg1";
            this._7seg1.Nr = 0;
            this._7seg1.Size = new System.Drawing.Size(94, 150);
            this._7seg1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 241);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this._7seg4);
            this.Controls.Add(this._7seg3);
            this.Controls.Add(this._7seg2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this._7seg1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Wysw7seg._7seg _7seg1;
        private System.Windows.Forms.Button button1;
        private Wysw7seg._7seg _7seg2;
        private Wysw7seg._7seg _7seg3;
        private Wysw7seg._7seg _7seg4;
        private System.Windows.Forms.TextBox textBox1;
    }
}

