namespace Projekt3_Plutka62026
{
    partial class Laboratorium3
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
            this.pbRysownica = new System.Windows.Forms.PictureBox();
            this.gbWybieranieKrzywych = new System.Windows.Forms.GroupBox();
            this.lblPoziomRekurencji = new System.Windows.Forms.Label();
            this.numUDPoziomRekurencji = new System.Windows.Forms.NumericUpDown();
            this.rdbTrójkątSierpińskiego = new System.Windows.Forms.RadioButton();
            this.btnKolorWypełnienia = new System.Windows.Forms.Button();
            this.numUD_LiczbaKątów = new System.Windows.Forms.NumericUpDown();
            this.lblLiczbaKątów = new System.Windows.Forms.Label();
            this.rdbWielokątWypełniony = new System.Windows.Forms.RadioButton();
            this.rdbWielokątForemny = new System.Windows.Forms.RadioButton();
            this.rdbLiniaKreślonaMyszką = new System.Windows.Forms.RadioButton();
            this.rdbLiniaProsta = new System.Windows.Forms.RadioButton();
            this.rdbPunkt = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.pbRysownica)).BeginInit();
            this.gbWybieranieKrzywych.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUDPoziomRekurencji)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_LiczbaKątów)).BeginInit();
            this.SuspendLayout();
            // 
            // pbRysownica
            // 
            this.pbRysownica.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pbRysownica.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbRysownica.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbRysownica.Location = new System.Drawing.Point(3, 59);
            this.pbRysownica.Name = "pbRysownica";
            this.pbRysownica.Size = new System.Drawing.Size(662, 523);
            this.pbRysownica.TabIndex = 0;
            this.pbRysownica.TabStop = false;
            this.pbRysownica.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbRysownica_MouseDown);
            this.pbRysownica.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbRysownica_MouseMove);
            this.pbRysownica.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbRysownica_MouseUp);
            // 
            // gbWybieranieKrzywych
            // 
            this.gbWybieranieKrzywych.Controls.Add(this.lblPoziomRekurencji);
            this.gbWybieranieKrzywych.Controls.Add(this.numUDPoziomRekurencji);
            this.gbWybieranieKrzywych.Controls.Add(this.rdbTrójkątSierpińskiego);
            this.gbWybieranieKrzywych.Controls.Add(this.btnKolorWypełnienia);
            this.gbWybieranieKrzywych.Controls.Add(this.numUD_LiczbaKątów);
            this.gbWybieranieKrzywych.Controls.Add(this.lblLiczbaKątów);
            this.gbWybieranieKrzywych.Controls.Add(this.rdbWielokątWypełniony);
            this.gbWybieranieKrzywych.Controls.Add(this.rdbWielokątForemny);
            this.gbWybieranieKrzywych.Controls.Add(this.rdbLiniaKreślonaMyszką);
            this.gbWybieranieKrzywych.Controls.Add(this.rdbLiniaProsta);
            this.gbWybieranieKrzywych.Controls.Add(this.rdbPunkt);
            this.gbWybieranieKrzywych.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gbWybieranieKrzywych.Location = new System.Drawing.Point(671, 29);
            this.gbWybieranieKrzywych.Name = "gbWybieranieKrzywych";
            this.gbWybieranieKrzywych.Size = new System.Drawing.Size(218, 553);
            this.gbWybieranieKrzywych.TabIndex = 1;
            this.gbWybieranieKrzywych.TabStop = false;
            this.gbWybieranieKrzywych.Text = "Wybierz odpowiednią kontrolkę  RadioButton";
            this.gbWybieranieKrzywych.Enter += new System.EventHandler(this.gbWybieranieKrzywych_Enter);
            // 
            // lblPoziomRekurencji
            // 
            this.lblPoziomRekurencji.AutoSize = true;
            this.lblPoziomRekurencji.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblPoziomRekurencji.Location = new System.Drawing.Point(103, 337);
            this.lblPoziomRekurencji.Name = "lblPoziomRekurencji";
            this.lblPoziomRekurencji.Size = new System.Drawing.Size(104, 15);
            this.lblPoziomRekurencji.TabIndex = 10;
            this.lblPoziomRekurencji.Text = "Poziom Rekurencji";
            this.lblPoziomRekurencji.Visible = false;
            // 
            // numUDPoziomRekurencji
            // 
            this.numUDPoziomRekurencji.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.numUDPoziomRekurencji.Location = new System.Drawing.Point(130, 357);
            this.numUDPoziomRekurencji.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numUDPoziomRekurencji.Name = "numUDPoziomRekurencji";
            this.numUDPoziomRekurencji.Size = new System.Drawing.Size(53, 22);
            this.numUDPoziomRekurencji.TabIndex = 9;
            this.numUDPoziomRekurencji.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numUDPoziomRekurencji.Visible = false;
            // 
            // rdbTrójkątSierpińskiego
            // 
            this.rdbTrójkątSierpińskiego.AutoSize = true;
            this.rdbTrójkątSierpińskiego.Location = new System.Drawing.Point(7, 337);
            this.rdbTrójkątSierpińskiego.Name = "rdbTrójkątSierpińskiego";
            this.rdbTrójkątSierpińskiego.Size = new System.Drawing.Size(103, 38);
            this.rdbTrójkątSierpińskiego.TabIndex = 8;
            this.rdbTrójkątSierpińskiego.TabStop = true;
            this.rdbTrójkątSierpińskiego.Text = "Trójkąt \r\nSierpińskiego";
            this.rdbTrójkątSierpińskiego.UseVisualStyleBackColor = true;
            this.rdbTrójkątSierpińskiego.CheckedChanged += new System.EventHandler(this.rdbTrójkątSierpińskiego_CheckedChanged);
            // 
            // btnKolorWypełnienia
            // 
            this.btnKolorWypełnienia.Location = new System.Drawing.Point(111, 246);
            this.btnKolorWypełnienia.Name = "btnKolorWypełnienia";
            this.btnKolorWypełnienia.Size = new System.Drawing.Size(107, 50);
            this.btnKolorWypełnienia.TabIndex = 7;
            this.btnKolorWypełnienia.Text = "Kolor \r\nWypełnienia";
            this.btnKolorWypełnienia.UseVisualStyleBackColor = true;
            this.btnKolorWypełnienia.Visible = false;
            this.btnKolorWypełnienia.Click += new System.EventHandler(this.btnKolorWypełnienia_Click);
            // 
            // numUD_LiczbaKątów
            // 
            this.numUD_LiczbaKątów.Location = new System.Drawing.Point(120, 171);
            this.numUD_LiczbaKątów.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numUD_LiczbaKątów.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numUD_LiczbaKątów.Name = "numUD_LiczbaKątów";
            this.numUD_LiczbaKątów.Size = new System.Drawing.Size(63, 25);
            this.numUD_LiczbaKątów.TabIndex = 6;
            this.numUD_LiczbaKątów.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numUD_LiczbaKątów.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numUD_LiczbaKątów.Visible = false;
            // 
            // lblLiczbaKątów
            // 
            this.lblLiczbaKątów.AutoSize = true;
            this.lblLiczbaKątów.Location = new System.Drawing.Point(112, 151);
            this.lblLiczbaKątów.Name = "lblLiczbaKątów";
            this.lblLiczbaKątów.Size = new System.Drawing.Size(91, 17);
            this.lblLiczbaKątów.TabIndex = 5;
            this.lblLiczbaKątów.Text = "Liczba Kątów";
            this.lblLiczbaKątów.Visible = false;
            // 
            // rdbWielokątWypełniony
            // 
            this.rdbWielokątWypełniony.AutoSize = true;
            this.rdbWielokątWypełniony.Location = new System.Drawing.Point(7, 252);
            this.rdbWielokątWypełniony.Name = "rdbWielokątWypełniony";
            this.rdbWielokątWypełniony.Size = new System.Drawing.Size(94, 38);
            this.rdbWielokątWypełniony.TabIndex = 4;
            this.rdbWielokątWypełniony.Text = "Wielokąt \r\nWypełniony";
            this.rdbWielokątWypełniony.UseVisualStyleBackColor = true;
            this.rdbWielokątWypełniony.CheckedChanged += new System.EventHandler(this.rdbWielokątWypełniony_CheckedChanged);
            // 
            // rdbWielokątForemny
            // 
            this.rdbWielokątForemny.AutoSize = true;
            this.rdbWielokątForemny.Location = new System.Drawing.Point(7, 169);
            this.rdbWielokątForemny.Name = "rdbWielokątForemny";
            this.rdbWielokątForemny.Size = new System.Drawing.Size(81, 38);
            this.rdbWielokątForemny.TabIndex = 3;
            this.rdbWielokątForemny.Text = "Wielokąt \r\nForemny";
            this.rdbWielokątForemny.UseVisualStyleBackColor = true;
            this.rdbWielokątForemny.CheckedChanged += new System.EventHandler(this.rdbWielokątForemny_CheckedChanged);
            // 
            // rdbLiniaKreślonaMyszką
            // 
            this.rdbLiniaKreślonaMyszką.AutoSize = true;
            this.rdbLiniaKreślonaMyszką.Location = new System.Drawing.Point(7, 112);
            this.rdbLiniaKreślonaMyszką.Name = "rdbLiniaKreślonaMyszką";
            this.rdbLiniaKreślonaMyszką.Size = new System.Drawing.Size(162, 21);
            this.rdbLiniaKreślonaMyszką.TabIndex = 2;
            this.rdbLiniaKreślonaMyszką.Text = "Linia Kreślona Myszką";
            this.rdbLiniaKreślonaMyszką.UseVisualStyleBackColor = true;
            // 
            // rdbLiniaProsta
            // 
            this.rdbLiniaProsta.AutoSize = true;
            this.rdbLiniaProsta.Location = new System.Drawing.Point(7, 84);
            this.rdbLiniaProsta.Name = "rdbLiniaProsta";
            this.rdbLiniaProsta.Size = new System.Drawing.Size(97, 21);
            this.rdbLiniaProsta.TabIndex = 1;
            this.rdbLiniaProsta.Text = "Linia Prosta";
            this.rdbLiniaProsta.UseVisualStyleBackColor = true;
            // 
            // rdbPunkt
            // 
            this.rdbPunkt.AutoSize = true;
            this.rdbPunkt.Checked = true;
            this.rdbPunkt.Location = new System.Drawing.Point(7, 56);
            this.rdbPunkt.Name = "rdbPunkt";
            this.rdbPunkt.Size = new System.Drawing.Size(60, 21);
            this.rdbPunkt.TabIndex = 0;
            this.rdbPunkt.TabStop = true;
            this.rdbPunkt.Text = "Punkt";
            this.rdbPunkt.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(331, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Współrzędne (x i y aktualnego położenia myszy):";
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblX.Location = new System.Drawing.Point(399, 9);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(23, 22);
            this.lblX.TabIndex = 3;
            this.lblX.Text = "X";
            this.lblX.Click += new System.EventHandler(this.lblX_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(378, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 22);
            this.label3.TabIndex = 4;
            this.label3.Text = ":";
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblY.Location = new System.Drawing.Point(492, 9);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(23, 22);
            this.lblY.TabIndex = 5;
            this.lblY.Text = "Y";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(471, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 22);
            this.label4.TabIndex = 6;
            this.label4.Text = ":";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(349, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 22);
            this.label2.TabIndex = 7;
            this.label2.Text = "X";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(442, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 22);
            this.label5.TabIndex = 8;
            this.label5.Text = "Y";
            // 
            // Laboratorium3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 594);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblY);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblX);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbWybieranieKrzywych);
            this.Controls.Add(this.pbRysownica);
            this.Name = "Laboratorium3";
            this.Text = "Laboratorium3";
            ((System.ComponentModel.ISupportInitialize)(this.pbRysownica)).EndInit();
            this.gbWybieranieKrzywych.ResumeLayout(false);
            this.gbWybieranieKrzywych.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUDPoziomRekurencji)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_LiczbaKątów)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbRysownica;
        private System.Windows.Forms.GroupBox gbWybieranieKrzywych;
        private System.Windows.Forms.RadioButton rdbPunkt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rdbLiniaProsta;
        private System.Windows.Forms.RadioButton rdbLiniaKreślonaMyszką;
        private System.Windows.Forms.NumericUpDown numUD_LiczbaKątów;
        private System.Windows.Forms.Label lblLiczbaKątów;
        private System.Windows.Forms.RadioButton rdbWielokątWypełniony;
        private System.Windows.Forms.RadioButton rdbWielokątForemny;
        private System.Windows.Forms.Button btnKolorWypełnienia;
        private System.Windows.Forms.Label lblPoziomRekurencji;
        private System.Windows.Forms.NumericUpDown numUDPoziomRekurencji;
        private System.Windows.Forms.RadioButton rdbTrójkątSierpińskiego;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}