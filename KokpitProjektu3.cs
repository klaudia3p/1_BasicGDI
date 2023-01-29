using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt3_Plutka62026
{
    public partial class KokpitProjektu3 : Form
    {
        public KokpitProjektu3()
        {
            InitializeComponent();
        }

        private void KokpitProjektu3_Load(object sender, EventArgs e)
        {

        }

        private void btnLab3_Click(object sender, EventArgs e)
        {
            //sprawdzenie czy egzemplarz formularza został juz wczesniej utworzony
            foreach(Form Formularz in Application.OpenForms)
                if (Formularz.Name == "Laboratorium3")
                {
                    //ukrycie biezacego formularza 
                    this.Hide();
                    //odsloniecie znalezionego  egzemplarza formularza
                    Formularz.Show();
                    //zakonczenie obslugi zdarzenia click
                    return;
                }
            //egzemplarz formularza nie byl jeszcze utworzony
            //utworzenie egzemplarza formularza 
            Laboratorium3 FormularzLaboratoryjny = new Laboratorium3();
            //ukrycie biezacego formularza 
            this.Hide();
            //odsloniecie znalezionego  egzemplarza formularza
            FormularzLaboratoryjny.Show();
            //zakonczenie obslugi zdarzenia click
        }

        private void btnProjektIndywidualny3_Click(object sender, EventArgs e)
        {
            foreach (Form Formularz in Application.OpenForms)
                if (Formularz.Name == "ProjektIndywidualny3")
                {
                    this.Hide();
                    Formularz.Show();
                    return;
                }
            ProjektIndywidualny3 FormularzLaboratoryjny = new ProjektIndywidualny3();
            this.Hide();
            FormularzLaboratoryjny.Show();
        }
    }
}
