using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//dodanoie przestrzeni dla nazw porrzeb grafiki 2d
using System.Drawing.Drawing2D;
using System.Data.SqlClient;

namespace Projekt3_Plutka62026
{
    public partial class Laboratorium3 : Form
    {
        //deklaracje stalych dla potrzeb kreslenia krzywych geometrycznych
        const ushort PromienPunktu = 2;
        //deklaracja zmiennych referencyjnych narzedzi graficznych
        Graphics Rysownica;
        Pen Pióro;
        SolidBrush Pędzel;
        //dekalracja zmiennej dla przechowywania lokalizacji "poczatku" kreslonej krzywej
        Point Punkt = Point.Empty;


        public Laboratorium3()
        {
            InitializeComponent();
            //podpiecie Bitmap do kontrolki PictureBox
            pbRysownica.Image = new Bitmap(pbRysownica.Width, pbRysownica.Height);
            //utworzenie egzemplarza powierzchni graficznej na bitmapie
            Rysownica = Graphics.FromImage(pbRysownica.Image);

            //utworzenie egzemplarza piora
            Pióro = new Pen(Color.Red, 1.7F);
            //ustawienie niezbednych atrybutow
            Pióro.DashStyle = DashStyle.Dash;
            Pióro.StartCap = LineCap.Round;
            Pióro.EndCap = LineCap.Round;

            //utworzenie egzemplarza pedzla
            Pędzel = new SolidBrush(Color.Blue);

        }

        private void gbWybieranieKrzywych_Enter(object sender, EventArgs e)
        {

        }

        private void lblX_Click(object sender, EventArgs e)
        {

        }

        private void pbRysownica_MouseDown(object sender, MouseEventArgs e)
        {
            //wizualizacja
            lblX.Text = e.Location.X.ToString();
            lblY.Text = e.Location.Y.ToString();
            //sprawdzenie czy zdarzenie mouse down zostało wywolane naciniecie leweego przycisku myszy
            if (e.Button == MouseButtons.Left)
                //tak, to zapamietamy wspolrzedne polozenia myszy
                Punkt = e.Location;

        }

        private void pbRysownica_MouseUp(object sender, MouseEventArgs e)
        {
            //obsluga wykreslenia krzywej geometrycznej
            lblX.Text = e.Location.X.ToString();
            lblY.Text = e.Location.Y.ToString();
            //wyznaczenie polozenia i rozmiarow prostokata w ktorym bedzie kreslona figura geo
            int LewyGórnyNarożnikX = (Punkt.X > e.Location.X) ? e.Location.X : Punkt.X;
            int LewyGórnyNarożnikY = (Punkt.Y > e.Location.Y) ? e.Location.Y : Punkt.Y;
            int Szerokość = Math.Abs(Punkt.X - e.Location.X);
            int Wysokość = Math.Abs(Punkt.Y - e.Location.Y);


            //sprawdzenie czy zdarzenie mouse down zostało wywolane zwolnieniem leweego przycisku myszy
            if (e.Button == MouseButtons.Left)
            //tak, wykreslamy krzywa
            {
                //czy kontrolka RadoiButton dla punktu jest zaznaczona
                if (rdbPunkt.Checked)
                    //wykreslamy 
                    Rysownica.FillEllipse(Pędzel,
                        Punkt.X - PromienPunktu,
                        Punkt.Y - PromienPunktu,
                        2 * PromienPunktu,
                        2 * PromienPunktu);
                //czy kontrolka radiobutton dla lini prostej jest zaznacznoca
                if (rdbLiniaProsta.Checked)
                    //tak, to wykreslamy linie prosta
                    Rysownica.DrawLine(Pióro,
                        Punkt.X,
                        Punkt.Y,
                        e.Location.X,
                        e.Location.Y);
                //czy kontrolka radiobutton dla lini kreslonej mysza jest zaznaczona
                if (rdbLiniaKreślonaMyszką.Checked)
                    //tak. to wykreslamy ostatni maly odc lini kreslonej mysza
                    Rysownica.DrawLine(Pióro,
                        Punkt.X,
                        Punkt.Y,
                        e.Location.X,
                        e.Location.Y);
                //czy jest wielokat foremny
                if (rdbWielokątForemny.Checked)
                {
                    //deklaracje uzupelniajace
                    ushort StopieńWielokąta = (ushort)numUD_LiczbaKątów.Value;
                    int R = Szerokość;
                    double KątPołożeniaPierwszegoWierzchołka = 0.0;
                    double KątMiędzyWierzchołkamiWielokąta = 360.0 / StopieńWielokąta;
                    //deklaracja tablicy dla przechowania wspolrzednych wierzcholkow wielokoata
                    Point[] WierzchołkiWielokąta = new Point[StopieńWielokąta];
                    //wyznaczenie wspołrzędnych wierzcholkow wielokata i wpisanie ich do tablicy WierzcholkiWielkokata
                    for (int i = 0; i < StopieńWielokąta; i++)
                    {
                        //stosujemy  wzor na równanie parametryczne okregu
                        WierzchołkiWielokąta[i].X = LewyGórnyNarożnikX +
                          (int)(R * Math.Cos(Math.PI * (KątPołożeniaPierwszegoWierzchołka +
                            i * KątMiędzyWierzchołkamiWielokąta) / 180));

                        WierzchołkiWielokąta[i].Y = LewyGórnyNarożnikY +
                          (int)(R * Math.Sin(Math.PI * (KątPołożeniaPierwszegoWierzchołka +
                            i * KątMiędzyWierzchołkamiWielokąta) / 180));

                    }
                    //wykreslenie wielokata
                    Rysownica.DrawPolygon(Pióro, WierzchołkiWielokąta);

                }
                if (rdbWielokątWypełniony.Checked)
                {
                    //deklaracje uzupelniajace
                    ushort StopieńWielokąta = (ushort)numUD_LiczbaKątów.Value;
                    int R = Szerokość;
                    double KątPołożeniaPierwszegoWierzchołka = 0.0;
                    double KątMiędzyWierzchołkamiWielokąta = 360.0 / StopieńWielokąta;
                    //deklaracja tablicy dla przechowania wspolrzednych wierzcholkow wielokoata
                    Point[] WierzchołkiWielokąta = new Point[StopieńWielokąta];
                    //wyznaczenie wspołrzędnych wierzcholkow wielokata i wpisanie ich do tablicy WierzcholkiWielkokata
                    for (int i = 0; i < StopieńWielokąta; i++)
                    {
                        //stosujemy  wzor na równanie parametryczne okregu
                        WierzchołkiWielokąta[i].X = LewyGórnyNarożnikX +
                          (int)(R * Math.Cos(Math.PI * (KątPołożeniaPierwszegoWierzchołka +
                            i * KątMiędzyWierzchołkamiWielokąta) / 180));

                        WierzchołkiWielokąta[i].Y = LewyGórnyNarożnikY +
                          (int)(R * Math.Sin(Math.PI * (KątPołożeniaPierwszegoWierzchołka +
                            i * KątMiędzyWierzchołkamiWielokąta) / 180));

                    }
                    //wykreslenie wielokata
                    //Rysownica.DrawPolygon(Pióro, WierzchołkiWielokąta);
                    //wykreslenie (wymalowanie) wielokata wypelnionego

                    //ustawienie koloru wypelnienia wielokata
                    Pędzel.Color = btnKolorWypełnienia.BackColor;
                    Rysownica.FillPolygon(Pędzel, WierzchołkiWielokąta);


                }
                if (rdbTrójkątSierpińskiego.Checked)
                {
                    //deklaracje pomocnicze i pobranie danych z formularza
                    int PoziomRekurencji = (int)numUDPoziomRekurencji.Value;
                    Color KolorWypełnienia = btnKolorWypełnienia.BackColor;
                    //wyznaczenie wspolrzednych wierzh=cholkow trojkata (tego najweikszego)
                    Point WierzchołekGórny = new Point(
                        LewyGórnyNarożnikX + Szerokość / 2,
                        LewyGórnyNarożnikY);

                    Point WierzchołekLewyDolny = new Point(
                        LewyGórnyNarożnikX,
                        LewyGórnyNarożnikY + Wysokość);

                    Point WierzchołekPrawyDolny = new Point(
                        LewyGórnyNarożnikX + Szerokość,
                        LewyGórnyNarożnikY + Wysokość);
                    //wywolanie rekurencyjnej metody kreslenia trojkata sierpinskiego
                    WykreślTrójkątSierpińskkiego(Rysownica, PoziomRekurencji, KolorWypełnienia, WierzchołekGórny, WierzchołekLewyDolny, WierzchołekPrawyDolny);

                }
                //if (rdbDywanSierpińskiego.Checked)
                //{
                //    //deklaracje pomocnicze i pobranie danych z formularza
                //    int PoziomRekurencji = (int)numUDPoziomRekurencji.Value;
                //    Color KolorWypełnienia = btnKolorWypełnienia.BackColor;
                //    //wyznaczenie wspolrzednych wierzh=cholkow trojkata (tego najweikszego)
                //    Point WierzchołekGórny = new Point(
                //        LewyGórnyNarożnikX + Szerokość / 2,
                //        LewyGórnyNarożnikY);

                //    Point WierzchołekLewyDolny = new Point(
                //        LewyGórnyNarożnikX,
                //        LewyGórnyNarożnikY + Wysokość);

                //    Point WierzchołekPrawyDolny = new Point(
                //        LewyGórnyNarożnikX + Szerokość,
                //        LewyGórnyNarożnikY + Wysokość);
                //    //wywolanie rekurencyjnej metody kreslenia trojkata sierpinskiego
                //    WykreślTrójkątSierpińskkiego(Rysownica, PoziomRekurencji, KolorWypełnienia, WierzchołekGórny, WierzchołekLewyDolny, WierzchołekPrawyDolny);

                //}
            }
            //odswiezenie powierzchnia graficznej w kontrolce PictureBox
            pbRysownica.Refresh();
        }

        private void pbRysownica_MouseMove(object sender, MouseEventArgs e)
        {
            //obsluga wykreslenia krzywej geometrycznej
            lblX.Text = e.Location.X.ToString();
            lblY.Text = e.Location.Y.ToString();
            //sprawdzenie czy zdarzenie mouse down zostało wywolane zwolnieniem leweego przycisku myszy
            if (e.Button == MouseButtons.Left)
            //tak, wykreslamy krzywa
            {
                //czy kontrolka radiobutton dla lini kreslonej mysza  jest zaznaczona
                if (rdbLiniaKreślonaMyszką.Checked)
                //tak, to kreslimy maly odcinek lini prostej i przesuwamy punkt na koniec wykreslonego od
                {
                    //wykreslamu maly odc
                    Rysownica.DrawLine(Pióro,
                       Punkt.X,
                       Punkt.Y,
                       e.Location.X,
                       e.Location.Y);
                    //przesuwamy zmienna punkt na koniec 
                    Punkt = e.Location;
                }
                //odswiezenie powierzchnia graficznej w kontrolce PictureBox
                pbRysownica.Refresh();
            }
        }

        private void rdbWielokątForemny_CheckedChanged(object sender, EventArgs e)
        {
            //rozpoznanie wejscia do metody obslugi zdarzenia rdbWielokątForemny_CheckedChanged
            if (rdbWielokątForemny.Checked)
            {
                //odsloniecie kontrolek umozliwiajacych ustalenie liczby katow 
                lblLiczbaKątów.Visible = true;
                numUD_LiczbaKątów.Visible = true;
                //ustawienie domyslnej wartosci (minimalnej) w kontrolce numU...
                numUD_LiczbaKątów.Value = 3;
                //uaktywnienie kontrolki numUD..
                numUD_LiczbaKątów.Enabled = true;

            }
            else
            {
                //ukreycie kontrolek
                lblLiczbaKątów.Visible = false;
                numUD_LiczbaKątów.Visible = false;

            }
        }

        private void btnKolorWypełnienia_Click(object sender, EventArgs e)
        {
            ColorDialog PaletaKolorów = new ColorDialog();
            //ustawienie w Palecie Kolorów aktualnego koloru wypełnienia
            PaletaKolorów.Color = btnKolorWypełnienia.BackColor;
            //wizualizacja palety kolorow
            if (PaletaKolorów.ShowDialog() == DialogResult.OK)
                btnKolorWypełnienia.BackColor = PaletaKolorów.Color;
            //zwolnienie palety kolorow
            PaletaKolorów.Dispose();

        }

        private void rdbWielokątWypełniony_CheckedChanged(object sender, EventArgs e)
        {
            //rozpoznanie wejscia do metody obslugi zdarzenia rdbWielokątForemny_CheckedChanged
            if (rdbWielokątWypełniony.Checked)
            {
                //odsloniecie kontrolek umozliwiajacych ustalenie liczby katow 
                lblLiczbaKątów.Visible = true;
                numUD_LiczbaKątów.Visible = true;
                btnKolorWypełnienia.Visible = true;
                //ustawienie domyslnej wartosci (minimalnej) w kontrolce numU...
                numUD_LiczbaKątów.Value = 3;
                //uaktywnienie kontrolki numUD..
                numUD_LiczbaKątów.Enabled = true;

            }
            else
            {
                //ukreycie kontrolek
                lblLiczbaKątów.Visible = false;
                numUD_LiczbaKątów.Visible = false;
                btnKolorWypełnienia.Visible = false;
            }
        }

        private void rdbTrójkątSierpińskiego_CheckedChanged(object sender, EventArgs e)
        {
            //czy to jest ''zapalenie'' kontrolki
            if (rdbTrójkątSierpińskiego.Checked)
            {
                MessageBox.Show("Wykreślenie trojkąta sierpińskiego wymaga podania poziomu " +
                    "rekurencji oraz koloru wypelnienia \n UWAGA można przyjąć ustawienia domyślne " +
                    "odppowiedniach kontrolek", "Wykreślenie Trójkąta Sierpińskego", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                //odsloniecie kontrolek oomocniczysz
                lblPoziomRekurencji.Visible = true;
                numUDPoziomRekurencji.Visible = true;
                btnKolorWypełnienia.Visible = true;
                //przypisanie ustawien domyslnych
                numUDPoziomRekurencji.Value = 3;
                btnKolorWypełnienia.BackColor = Color.DarkRed;
                //ustawienie stanu aktywnosci kontrolek 
                numUDPoziomRekurencji.Enabled = true;
                btnKolorWypełnienia.Enabled = true;

            } 
            else
            {
                lblPoziomRekurencji.Visible = false;
                numUDPoziomRekurencji.Visible = false;
                btnKolorWypełnienia.Visible = false;
            }

        }
        //deklaracja

        void WykreślTrójkątSierpińskkiego(
            Graphics Rysownica, 
            int PoziomRekurencji, 
            Color KolorWypełnienia, 
            Point WierzchołekGórny, 
            Point WierzchołekLewyDolny, 
            Point WierzchołekPrawyDolny)
        {
            //sprawdzenie warunku brzegowego
            if (PoziomRekurencji == 0)
            {
                //deklaracja tablicy wspolrzednych wierzcholkow wielokata
                Point[] WierzchołkiTrójkąta = {WierzchołekGórny, WierzchołekLewyDolny, WierzchołekPrawyDolny};
                using (SolidBrush Pędzel = new SolidBrush(KolorWypełnienia))
                    Rysownica.FillPolygon(Pędzel, WierzchołkiTrójkąta);
                //tutaj nastapi automatyczne zwolnienie zasobu grafu=icznego pedzel
  
            }
            else
            {
                //w ramach podzialu trojkata opisanego wierzcholkami 
                //wyznaczamy punkty srodkowe krawedzi  trojkata
                Point PunktSrodkowyLewejKrawedzi = new Point(
                    (WierzchołekLewyDolny.X + WierzchołekGórny.X) / 2,
                    (WierzchołekLewyDolny.Y + WierzchołekGórny.Y) / 2 );
                Point PunktSrodkowyPrawejKrawedzi = new Point(
                    (WierzchołekGórny.X + WierzchołekPrawyDolny.X) / 2,
                     (WierzchołekGórny.Y + WierzchołekPrawyDolny.Y) / 2);
                Point PunktSrodkowyDolnejKrawedzi = new Point(
                    (WierzchołekLewyDolny.X + WierzchołekPrawyDolny.X)/2,
                    (WierzchołekLewyDolny.Y + WierzchołekPrawyDolny.Y) / 2);

                //wywolanie metody rekurencyjnej WykreślTrójkątSierpińskkiego dla trzech naroznych trojkatow ktorych wspolrzedne 

                WykreślTrójkątSierpińskkiego(Rysownica, PoziomRekurencji - 1, KolorWypełnienia, WierzchołekGórny, PunktSrodkowyLewejKrawedzi, PunktSrodkowyPrawejKrawedzi);
                WykreślTrójkątSierpińskkiego(Rysownica, PoziomRekurencji - 1, KolorWypełnienia, WierzchołekLewyDolny, PunktSrodkowyLewejKrawedzi, PunktSrodkowyDolnejKrawedzi);
                WykreślTrójkątSierpińskkiego(Rysownica, PoziomRekurencji - 1, KolorWypełnienia, PunktSrodkowyDolnejKrawedzi, PunktSrodkowyPrawejKrawedzi, WierzchołekPrawyDolny);

            }
        }


    }
}
