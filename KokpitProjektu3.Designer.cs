namespace Projekt3_Plutka62026
{
    partial class KokpitProjektu3
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
            this.btnLab3 = new System.Windows.Forms.Button();
            this.btnProjektIndywidualny3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLab3
            // 
            this.btnLab3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnLab3.Location = new System.Drawing.Point(34, 172);
            this.btnLab3.Name = "btnLab3";
            this.btnLab3.Size = new System.Drawing.Size(290, 100);
            this.btnLab3.TabIndex = 0;
            this.btnLab3.Text = "Laboratorium Nr3\r\n(Kreślenie krzywych geometrycznych)";
            this.btnLab3.UseVisualStyleBackColor = true;
            this.btnLab3.Click += new System.EventHandler(this.btnLab3_Click);
            // 
            // btnProjektIndywidualny3
            // 
            this.btnProjektIndywidualny3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnProjektIndywidualny3.Location = new System.Drawing.Point(426, 172);
            this.btnProjektIndywidualny3.Name = "btnProjektIndywidualny3";
            this.btnProjektIndywidualny3.Size = new System.Drawing.Size(307, 100);
            this.btnProjektIndywidualny3.TabIndex = 1;
            this.btnProjektIndywidualny3.Text = "Projekt Indywidualny Nr3\r\n(Kreślenie figur i lini geometrycznych)";
            this.btnProjektIndywidualny3.UseVisualStyleBackColor = true;
            this.btnProjektIndywidualny3.Click += new System.EventHandler(this.btnProjektIndywidualny3_Click);
            // 
            // KokpitProjektu3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnProjektIndywidualny3);
            this.Controls.Add(this.btnLab3);
            this.Name = "KokpitProjektu3";
            this.Text = "Kokpit Projektu Nr 3";
            this.Load += new System.EventHandler(this.KokpitProjektu3_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLab3;
        private System.Windows.Forms.Button btnProjektIndywidualny3;
    }
}

