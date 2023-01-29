using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows;
using System.Diagnostics;
using System.Reflection;

namespace Projekt3_Plutka62026
{
    public partial class ProjektIndywidualny3 : Form
    {
        struct OpisKrzywejBeziera
        {

            public Point kpPunktP0;
            public Point kpPunktP1;
            public Point kpPunktP2;
            public Point kpPunktP3;

            public ushort kpNumerPunktuKontrolnego;
            public float kpPromieńPunktuKontrolnego;
        }
        
        OpisKrzywejBeziera kpKrzywaBeziera;
        Font FontOpisuPunktów = new Font("Arial", 10, FontStyle.Italic);

        struct OpisSklejanejKrzywejBeziera
        {

            public Point kpPunktP0;
            public Point kpPunktP1;
            public Point kpPunktP2;
            public Point kpPunktP3;
            public Point kpPunktP4;
            public Point kpPunktP5;
            public Point kpPunktP6;

            public ushort kpNumerPunktuKontrolnego;
            public float kpPromieńPunktuKontrolnego;
        }
        OpisSklejanejKrzywejBeziera kpSklejanaKrzywaBeziera;


        struct OpisKrzywejKardynalnej
        {
            
            public PointF kpPunkt01;
            public PointF kpPunkt02;
            public PointF kpPunkt03;
            public PointF kpPunkt04;
            public PointF kpPunkt05;

            public ushort kpNumerPunktuKontrolnego;
            public float kpPromieńPunktuKontrolnego;
        }
        OpisKrzywejKardynalnej kpKrzywaKardynalna;


        const ushort kpPromienPunktu = 2;
        Graphics kpRysownica;
        Pen kpPióro;
        SolidBrush kpPędzel;
        Point kpPunkt = Point.Empty;

        
        public ProjektIndywidualny3()
        {
            InitializeComponent();
           
            kppbRysownica.Image = new Bitmap(kppbRysownica.Width, kppbRysownica.Height);
            kpRysownica = Graphics.FromImage(kppbRysownica.Image);
            kpPióro = new Pen(Color.Red, 1.7F);
            kpPióro.DashStyle = DashStyle.Dash;
            kpPióro.StartCap = LineCap.Round;
            kpPióro.EndCap = LineCap.Round;
            kpPędzel = new SolidBrush(DefaultBackColor);
        }

        private void kppbRysownica_MouseDown(object sender, MouseEventArgs e)
        {
            kplblX.Text = e.Location.X.ToString();
            kplblY.Text = e.Location.Y.ToString();
            if (e.Button == MouseButtons.Left)
                kpPunkt = e.Location;

        }

        private void kppbRysownica_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void kppbRysownica_MouseUp(object sender, MouseEventArgs e)
        {
            kplblX.Text = e.Location.X.ToString();
            kplblY.Text = e.Location.Y.ToString();
            int kpLewyGórnyNarożnikX = (kpPunkt.X > e.Location.X) ? e.Location.X : kpPunkt.X;
            int kpLewyGórnyNarożnikY = (kpPunkt.Y > e.Location.Y) ? e.Location.Y : kpPunkt.Y;
            int kpSzerokość = Math.Abs(kpPunkt.X - e.Location.X);
            int kpWysokość = Math.Abs(kpPunkt.Y - e.Location.Y);
             


            if (e.Button == MouseButtons.Left)
            {


                if (kprdbProstokąt.Checked)
                {
                    ushort kpStopieńWielokąta = 4;
                    for (int i = 0; i < kpStopieńWielokąta; i++)
                        kpRysownica.DrawRectangle(kpPióro, kpLewyGórnyNarożnikX, kpLewyGórnyNarożnikY,
                            kpSzerokość, kpWysokość);
                }
                if (kprdbProstokątWypełniony.Checked)
                {
                    ushort kpStopieńWielokąta = 4;
                    for (int i = 0; i < kpStopieńWielokąta; i++)
                        kpPędzel.Color = kpbtnKolorWypełnienia.BackColor;
                    kpRysownica.FillRectangle(kpPędzel, kpLewyGórnyNarożnikX, kpLewyGórnyNarożnikY,
                            kpSzerokość, kpWysokość);
                }
                if (kprdbKwadrat.Checked)
                {
                    ushort kpStopieńWielokąta = (ushort)kpnumUDLiczbaKątów.Value;
                    int R = kpSzerokość;
                    double kpKątPołożeniaPierwszegoWierzchołka = 0.0;
                    double kpKątMiędzyWierzchołkamiWielokąta = 360.0 / kpStopieńWielokąta;
                    Point[] kpWierzchołkiWielokąta = new Point[kpStopieńWielokąta];
                    for (int i = 0; i < kpStopieńWielokąta; i++)
                    {
                        kpWierzchołkiWielokąta[i].X = kpLewyGórnyNarożnikX +
                          (int)(R * Math.Cos(Math.PI * (kpKątPołożeniaPierwszegoWierzchołka +
                            i * kpKątMiędzyWierzchołkamiWielokąta) / 180));

                        kpWierzchołkiWielokąta[i].Y = kpLewyGórnyNarożnikY +
                          (int)(R * Math.Sin(Math.PI * (kpKątPołożeniaPierwszegoWierzchołka +
                            i * kpKątMiędzyWierzchołkamiWielokąta) / 180));

                    }
                    kpRysownica.DrawPolygon(kpPióro, kpWierzchołkiWielokąta);
                }
                if (kprdbKwadratWypełniony.Checked)
                {
                    ushort kpStopieńWielokąta = (ushort)kpnumUDLiczbaKątów.Value;
                    int R = kpSzerokość;
                    double kpKątPołożeniaPierwszegoWierzchołka = 0.0;
                    double kpKątMiędzyWierzchołkamiWielokąta = 360.0 / kpStopieńWielokąta;
                    Point[] kpWierzchołkiWielokąta = new Point[kpStopieńWielokąta];
                    for (int i = 0; i < kpStopieńWielokąta; i++)
                    {
                        kpWierzchołkiWielokąta[i].X = kpLewyGórnyNarożnikX +
                          (int)(R * Math.Cos(Math.PI * (kpKątPołożeniaPierwszegoWierzchołka +
                            i * kpKątMiędzyWierzchołkamiWielokąta) / 180));

                        kpWierzchołkiWielokąta[i].Y = kpLewyGórnyNarożnikY +
                          (int)(R * Math.Sin(Math.PI * (kpKątPołożeniaPierwszegoWierzchołka +
                            i * kpKątMiędzyWierzchołkamiWielokąta) / 180));

                    }
                    kpPędzel.Color = kpbtnKolorWypełnienia.BackColor;
                    kpRysownica.FillPolygon(kpPędzel, kpWierzchołkiWielokąta);
                }

                if (kprdbOkrąg.Checked)
                {
                    ushort kpStopieńWielokąta = 360;
                    int R = kpSzerokość;
                    double kpKątPołożeniaPierwszegoWierzchołka = 0.0;
                    double kpKątMiędzyWierzchołkamiWielokąta = 360.0 / kpStopieńWielokąta;
                    Point[] kpWierzchołkiWielokąta = new Point[kpStopieńWielokąta];
                    for (int i = 0; i < kpStopieńWielokąta; i++)
                    {
                        kpWierzchołkiWielokąta[i].X = kpLewyGórnyNarożnikX +
                          (int)(R * Math.Cos(Math.PI * (kpKątPołożeniaPierwszegoWierzchołka +
                            i * kpKątMiędzyWierzchołkamiWielokąta) / 180));

                        kpWierzchołkiWielokąta[i].Y = kpLewyGórnyNarożnikY +
                          (int)(R * Math.Sin(Math.PI * (kpKątPołożeniaPierwszegoWierzchołka +
                            i * kpKątMiędzyWierzchołkamiWielokąta) / 180));

                    }
                    kpRysownica.DrawPolygon(kpPióro, kpWierzchołkiWielokąta);
                }
                if (kprdbOkrągWypełniony.Checked)
                {
                    ushort kpStopieńWielokąta = 360;
                    int R = kpSzerokość;
                    double kpKątPołożeniaPierwszegoWierzchołka = 0.0;
                    double kpKątMiędzyWierzchołkamiWielokąta = 360.0 / kpStopieńWielokąta;
                    Point[] kpWierzchołkiWielokąta = new Point[kpStopieńWielokąta];
                    for (int i = 0; i < kpStopieńWielokąta; i++)
                    {
                        kpWierzchołkiWielokąta[i].X = kpLewyGórnyNarożnikX +
                          (int)(R * Math.Cos(Math.PI * (kpKątPołożeniaPierwszegoWierzchołka +
                            i * kpKątMiędzyWierzchołkamiWielokąta) / 180));

                        kpWierzchołkiWielokąta[i].Y = kpLewyGórnyNarożnikY +
                          (int)(R * Math.Sin(Math.PI * (kpKątPołożeniaPierwszegoWierzchołka +
                            i * kpKątMiędzyWierzchołkamiWielokąta) / 180));

                    }
                    kpPędzel.Color = kpbtnKolorWypełnienia.BackColor;
                    kpRysownica.FillPolygon(kpPędzel, kpWierzchołkiWielokąta);
                }
                if (kprdbElipsa.Checked)
                {
                    ushort kpStopieńWielokąta = 360;
                    for (int i = 0; i < kpStopieńWielokąta; i++)
                        kpRysownica.DrawEllipse(kpPióro, kpLewyGórnyNarożnikX, kpLewyGórnyNarożnikY,
                           kpSzerokość, kpWysokość);
                }
                if (kprdbElipsaWypełniona.Checked)
                {
                    ushort kpStopieńWielokąta = 360;
                    for (int i = 0; i < kpStopieńWielokąta; i++)
                        kpPędzel.Color = kpbtnKolorWypełnienia.BackColor;
                    kpRysownica.FillEllipse(kpPędzel, kpLewyGórnyNarożnikX, kpLewyGórnyNarożnikY,
                           kpSzerokość, kpWysokość);
                }
                if (kprdbWycinekElipsy.Checked)
                {
                    
                }


                if (kprdbKrzywaBeziera.Checked)
                {
                    if (kpgrbWybieranieKrzywych.Enabled)
                    {
                        kpgrbWybieranieKrzywych.Enabled = false;
                        kpKrzywaBeziera.kpNumerPunktuKontrolnego = 0;
                        kpKrzywaBeziera.kpPromieńPunktuKontrolnego = 5;
                        kpKrzywaBeziera.kpPunktP0 = e.Location;

                        using (SolidBrush kpPędzel = new SolidBrush(Color.Black))
                        {
                            kpRysownica.FillEllipse(kpPędzel,
                                e.Location.X - kpKrzywaBeziera.kpPromieńPunktuKontrolnego,
                                e.Location.Y - kpKrzywaBeziera.kpPromieńPunktuKontrolnego,
                                2 * kpKrzywaBeziera.kpPromieńPunktuKontrolnego,
                                2 * kpKrzywaBeziera.kpPromieńPunktuKontrolnego);
                            kpRysownica.DrawString("p" + kpKrzywaBeziera.kpNumerPunktuKontrolnego.ToString(),
                                FontOpisuPunktów, kpPędzel, e.Location);
                        }
                    }
                    else
                    {
                        kpKrzywaBeziera.kpNumerPunktuKontrolnego++;
                        switch (kpKrzywaBeziera.kpNumerPunktuKontrolnego)
                        {
                            case 1: kpKrzywaBeziera.kpPunktP1 = e.Location; break;
                            case 2: kpKrzywaBeziera.kpPunktP2 = e.Location; break;
                            case 3: kpKrzywaBeziera.kpPunktP3 = e.Location; break;
                        }
                        if (kpKrzywaBeziera.kpNumerPunktuKontrolnego < 3)
                        {
                            using (SolidBrush kpPędzel = new SolidBrush(Color.Red))
                            {
                                kpRysownica.FillEllipse(kpPędzel,
                                 e.Location.X - kpKrzywaBeziera.kpPromieńPunktuKontrolnego,
                                e.Location.Y - kpKrzywaBeziera.kpPromieńPunktuKontrolnego,
                                2 * kpKrzywaBeziera.kpPromieńPunktuKontrolnego,
                                2 * kpKrzywaBeziera.kpPromieńPunktuKontrolnego);
                                kpRysownica.DrawString("p" + kpKrzywaBeziera.kpNumerPunktuKontrolnego.ToString(),
                                    FontOpisuPunktów, kpPędzel, e.Location);
                            }
                        }
                        else
                        {
                            using (SolidBrush kpPędzel = new SolidBrush(Color.Black))
                            {
                                kpRysownica.FillEllipse(kpPędzel,
                                 e.Location.X - kpKrzywaBeziera.kpPromieńPunktuKontrolnego,
                                e.Location.Y - kpKrzywaBeziera.kpPromieńPunktuKontrolnego,
                                2 * kpKrzywaBeziera.kpPromieńPunktuKontrolnego,
                                2 * kpKrzywaBeziera.kpPromieńPunktuKontrolnego);
                                kpRysownica.DrawString("p" + kpKrzywaBeziera.kpNumerPunktuKontrolnego.ToString(),
                                    FontOpisuPunktów, kpPędzel, e.Location);
                            }
                            kpRysownica.DrawBezier(kpPióro,
                                kpKrzywaBeziera.kpPunktP0,
                                kpKrzywaBeziera.kpPunktP1,
                                kpKrzywaBeziera.kpPunktP2,
                                kpKrzywaBeziera.kpPunktP3);
                            kpgrbWybieranieKrzywych.Enabled = true;
                        }
                    }


                }
                if (kprdbSklejanaKrzywaBeziera.Checked)

                {

                    if (kpgrbWybieranieKrzywych.Enabled)

                    {

                        kpgrbWybieranieKrzywych.Enabled = false;

                        kpSklejanaKrzywaBeziera.kpNumerPunktuKontrolnego = 0;

                        kpSklejanaKrzywaBeziera.kpPromieńPunktuKontrolnego = 4;

                        kpSklejanaKrzywaBeziera.kpPunktP0 = e.Location;



                        using (SolidBrush kpPędzel = new SolidBrush(Color.Black))

                        {

                            kpRysownica.FillEllipse(kpPędzel,

                                e.Location.X - kpSklejanaKrzywaBeziera.kpPromieńPunktuKontrolnego,

                                e.Location.Y - kpSklejanaKrzywaBeziera.kpPromieńPunktuKontrolnego,

                                2 * kpSklejanaKrzywaBeziera.kpPromieńPunktuKontrolnego,

                                2 * kpSklejanaKrzywaBeziera.kpPromieńPunktuKontrolnego);

                            kpRysownica.DrawString("p" + kpSklejanaKrzywaBeziera.kpNumerPunktuKontrolnego.ToString(),

                                FontOpisuPunktów, kpPędzel, e.Location);

                        }

                    }

                    else

                    {

                        kpSklejanaKrzywaBeziera.kpNumerPunktuKontrolnego++;

                        switch (kpSklejanaKrzywaBeziera.kpNumerPunktuKontrolnego)

                        {

                            case 1: kpSklejanaKrzywaBeziera.kpPunktP1 = e.Location; break;

                            case 2: kpSklejanaKrzywaBeziera.kpPunktP2 = e.Location; break;

                            case 3: kpSklejanaKrzywaBeziera.kpPunktP3 = e.Location; break;

                        }

                        if (kpSklejanaKrzywaBeziera.kpNumerPunktuKontrolnego < 3)

                        {

                            using (SolidBrush kpPędzel = new SolidBrush(Color.Red))

                            {

                                kpRysownica.FillEllipse(kpPędzel,

                                 e.Location.X - kpSklejanaKrzywaBeziera.kpPromieńPunktuKontrolnego,

                                e.Location.Y - kpSklejanaKrzywaBeziera.kpPromieńPunktuKontrolnego,

                                2 * kpSklejanaKrzywaBeziera.kpPromieńPunktuKontrolnego,

                                2 * kpSklejanaKrzywaBeziera.kpPromieńPunktuKontrolnego);

                                kpRysownica.DrawString("p" + kpSklejanaKrzywaBeziera.kpNumerPunktuKontrolnego.ToString(),

                                    FontOpisuPunktów, kpPędzel, e.Location);

                            }

                        }

                        else

                        {

                            using (SolidBrush kpPędzel = new SolidBrush(Color.Black))

                            {

                                kpRysownica.FillEllipse(kpPędzel,

                                 e.Location.X - kpSklejanaKrzywaBeziera.kpPromieńPunktuKontrolnego,

                                e.Location.Y - kpSklejanaKrzywaBeziera.kpPromieńPunktuKontrolnego,

                                2 * kpSklejanaKrzywaBeziera.kpPromieńPunktuKontrolnego,

                                2 * kpSklejanaKrzywaBeziera.kpPromieńPunktuKontrolnego);

                                kpRysownica.DrawString("p" + kpSklejanaKrzywaBeziera.kpNumerPunktuKontrolnego.ToString(),

                                    FontOpisuPunktów, kpPędzel, e.Location);

                            }

                            kpRysownica.DrawBezier(kpPióro,

                                kpSklejanaKrzywaBeziera.kpPunktP0,

                                kpSklejanaKrzywaBeziera.kpPunktP1,

                                kpSklejanaKrzywaBeziera.kpPunktP2,

                                kpSklejanaKrzywaBeziera.kpPunktP3);

                            if (kpgrbWybieranieKrzywych.Enabled)

                            {



                                kpSklejanaKrzywaBeziera.kpNumerPunktuKontrolnego = 3;

                                kpSklejanaKrzywaBeziera.kpPromieńPunktuKontrolnego = 4;

                                kpSklejanaKrzywaBeziera.kpPunktP3 = e.Location;



                                using (SolidBrush kpPędzel = new SolidBrush(Color.Black))

                                {

                                    kpRysownica.FillEllipse(kpPędzel,

                                        e.Location.X - kpSklejanaKrzywaBeziera.kpPromieńPunktuKontrolnego,

                                        e.Location.Y - kpSklejanaKrzywaBeziera.kpPromieńPunktuKontrolnego,

                                        2 * kpSklejanaKrzywaBeziera.kpPromieńPunktuKontrolnego,

                                        2 * kpSklejanaKrzywaBeziera.kpPromieńPunktuKontrolnego);

                                    kpRysownica.DrawString("p" + kpSklejanaKrzywaBeziera.kpNumerPunktuKontrolnego.ToString(),

                                        FontOpisuPunktów, kpPędzel, e.Location);

                                }

                            }

                            else

                            {

                                kpSklejanaKrzywaBeziera.kpNumerPunktuKontrolnego++;

                                switch (kpSklejanaKrzywaBeziera.kpNumerPunktuKontrolnego)

                                {

                                    case 1: kpSklejanaKrzywaBeziera.kpPunktP4 = e.Location; break;

                                    case 2: kpSklejanaKrzywaBeziera.kpPunktP5 = e.Location; break;

                                    case 3: kpSklejanaKrzywaBeziera.kpPunktP6 = e.Location; break;

                                }

                                if (kpSklejanaKrzywaBeziera.kpNumerPunktuKontrolnego < 3)

                                {

                                    using (SolidBrush kpPędzel = new SolidBrush(Color.Red))

                                    {

                                        kpRysownica.FillEllipse(kpPędzel,

                                         e.Location.X - kpSklejanaKrzywaBeziera.kpPromieńPunktuKontrolnego,

                                        e.Location.Y - kpSklejanaKrzywaBeziera.kpPromieńPunktuKontrolnego,

                                        2 * kpSklejanaKrzywaBeziera.kpPromieńPunktuKontrolnego,

                                        2 * kpSklejanaKrzywaBeziera.kpPromieńPunktuKontrolnego);

                                        kpRysownica.DrawString("p" + kpSklejanaKrzywaBeziera.kpNumerPunktuKontrolnego.ToString(),

                                            FontOpisuPunktów, kpPędzel, e.Location);

                                    }

                                }

                                else

                                {

                                    using (SolidBrush kpPędzel = new SolidBrush(Color.Black))

                                    {

                                        kpRysownica.FillEllipse(kpPędzel,

                                         e.Location.X - kpSklejanaKrzywaBeziera.kpPromieńPunktuKontrolnego,

                                        e.Location.Y - kpSklejanaKrzywaBeziera.kpPromieńPunktuKontrolnego,

                                        2 * kpSklejanaKrzywaBeziera.kpPromieńPunktuKontrolnego,

                                        2 * kpSklejanaKrzywaBeziera.kpPromieńPunktuKontrolnego);

                                        kpRysownica.DrawString("p" + kpSklejanaKrzywaBeziera.kpNumerPunktuKontrolnego.ToString(),

                                            FontOpisuPunktów, kpPędzel, e.Location);

                                    }

                                    kpRysownica.DrawBezier(kpPióro,

                                        kpSklejanaKrzywaBeziera.kpPunktP3,

                                        kpSklejanaKrzywaBeziera.kpPunktP4,

                                        kpSklejanaKrzywaBeziera.kpPunktP5,

                                        kpSklejanaKrzywaBeziera.kpPunktP6);

                                    kpgrbWybieranieKrzywych.Enabled = true;

                                }

                            }

                        }

                    }


                }
                if (kprdbKrzyweLejkowatej.Checked)
                {

                    if (kpgrbWybieranieKrzywych.Enabled)
                    {
                        kpgrbWybieranieKrzywych.Enabled = false;
                        kpSklejanaKrzywaBeziera.kpNumerPunktuKontrolnego = 0;
                        kpSklejanaKrzywaBeziera.kpPromieńPunktuKontrolnego = 4;
                        kpSklejanaKrzywaBeziera.kpPunktP0 = e.Location;

                        using (SolidBrush kpPędzel = new SolidBrush(Color.Black))
                        {
                            kpRysownica.FillEllipse(kpPędzel,
                                e.Location.X - kpSklejanaKrzywaBeziera.kpPromieńPunktuKontrolnego,
                                e.Location.Y - kpSklejanaKrzywaBeziera.kpPromieńPunktuKontrolnego,
                                2 * kpSklejanaKrzywaBeziera.kpPromieńPunktuKontrolnego,
                                2 * kpSklejanaKrzywaBeziera.kpPromieńPunktuKontrolnego);
                            kpRysownica.DrawString("p" + kpSklejanaKrzywaBeziera.kpNumerPunktuKontrolnego.ToString(),
                                FontOpisuPunktów, kpPędzel, e.Location);
                        }
                    }
                    else
                    {
                        kpSklejanaKrzywaBeziera.kpNumerPunktuKontrolnego++;
                        switch (kpSklejanaKrzywaBeziera.kpNumerPunktuKontrolnego)
                        {
                            case 1: kpSklejanaKrzywaBeziera.kpPunktP1 = e.Location; break;
                            case 2: kpSklejanaKrzywaBeziera.kpPunktP2 = e.Location; break;
                            case 3: kpSklejanaKrzywaBeziera.kpPunktP3 = e.Location; break;
                        }
                        if (kpSklejanaKrzywaBeziera.kpNumerPunktuKontrolnego < 3)
                        {
                            using (SolidBrush kpPędzel = new SolidBrush(Color.Red))
                            {
                                kpRysownica.FillEllipse(kpPędzel,
                                 e.Location.X - kpSklejanaKrzywaBeziera.kpPromieńPunktuKontrolnego,
                                e.Location.Y - kpSklejanaKrzywaBeziera.kpPromieńPunktuKontrolnego,
                                2 * kpSklejanaKrzywaBeziera.kpPromieńPunktuKontrolnego,
                                2 * kpSklejanaKrzywaBeziera.kpPromieńPunktuKontrolnego);
                                kpRysownica.DrawString("p" + kpSklejanaKrzywaBeziera.kpNumerPunktuKontrolnego.ToString(),
                                    FontOpisuPunktów, kpPędzel, e.Location);
                            }
                        }
                        else
                        {
                            using (SolidBrush kpPędzel = new SolidBrush(Color.Black))
                            {
                                kpRysownica.FillEllipse(kpPędzel,
                                 e.Location.X - kpSklejanaKrzywaBeziera.kpPromieńPunktuKontrolnego,
                                e.Location.Y - kpSklejanaKrzywaBeziera.kpPromieńPunktuKontrolnego,
                                2 * kpSklejanaKrzywaBeziera.kpPromieńPunktuKontrolnego,
                                2 * kpSklejanaKrzywaBeziera.kpPromieńPunktuKontrolnego);
                                kpRysownica.DrawString("p" + kpSklejanaKrzywaBeziera.kpNumerPunktuKontrolnego.ToString(),
                                    FontOpisuPunktów, kpPędzel, e.Location);
                            }
                            kpRysownica.DrawBezier(kpPióro,
                                kpSklejanaKrzywaBeziera.kpPunktP0,
                                kpSklejanaKrzywaBeziera.kpPunktP1,
                                kpSklejanaKrzywaBeziera.kpPunktP2,
                                kpSklejanaKrzywaBeziera.kpPunktP3);
                            if (kpgrbWybieranieKrzywych.Enabled == false)
                            {

                                kpSklejanaKrzywaBeziera.kpNumerPunktuKontrolnego = 3;
                                kpSklejanaKrzywaBeziera.kpPromieńPunktuKontrolnego = 4;
                                kpSklejanaKrzywaBeziera.kpPunktP3 = e.Location;

                                using (SolidBrush kpPędzel = new SolidBrush(Color.Black))
                                {
                                    kpRysownica.FillEllipse(kpPędzel,
                                        e.Location.X - kpSklejanaKrzywaBeziera.kpPromieńPunktuKontrolnego,
                                        e.Location.Y - kpSklejanaKrzywaBeziera.kpPromieńPunktuKontrolnego,
                                        2 * kpSklejanaKrzywaBeziera.kpPromieńPunktuKontrolnego,
                                        2 * kpSklejanaKrzywaBeziera.kpPromieńPunktuKontrolnego);
                                    kpRysownica.DrawString("p" + kpSklejanaKrzywaBeziera.kpNumerPunktuKontrolnego.ToString(),
                                        FontOpisuPunktów, kpPędzel, e.Location);
                                }
                            }
                            else
                            {
                                kpSklejanaKrzywaBeziera.kpNumerPunktuKontrolnego++;
                                switch (kpSklejanaKrzywaBeziera.kpNumerPunktuKontrolnego)
                                {
                                    case 1: kpSklejanaKrzywaBeziera.kpPunktP4 = e.Location; break;
                                    case 2: kpSklejanaKrzywaBeziera.kpPunktP5 = e.Location; break;
                                    case 3: kpSklejanaKrzywaBeziera.kpPunktP6 = e.Location; break;
                                }
                                if (kpSklejanaKrzywaBeziera.kpNumerPunktuKontrolnego < 3)
                                {
                                    using (SolidBrush kpPędzel = new SolidBrush(Color.Red))
                                    {
                                        kpRysownica.FillEllipse(kpPędzel,
                                         e.Location.X - kpSklejanaKrzywaBeziera.kpPromieńPunktuKontrolnego,
                                        e.Location.Y - kpSklejanaKrzywaBeziera.kpPromieńPunktuKontrolnego,
                                        2 * kpSklejanaKrzywaBeziera.kpPromieńPunktuKontrolnego,
                                        2 * kpSklejanaKrzywaBeziera.kpPromieńPunktuKontrolnego);
                                        kpRysownica.DrawString("p" + kpSklejanaKrzywaBeziera.kpNumerPunktuKontrolnego.ToString(),
                                            FontOpisuPunktów, kpPędzel, e.Location);
                                    }
                                }
                                else
                                {
                                    using (SolidBrush kpPędzel = new SolidBrush(Color.Black))
                                    {
                                        kpRysownica.FillEllipse(kpPędzel,
                                         e.Location.X - kpSklejanaKrzywaBeziera.kpPromieńPunktuKontrolnego,
                                        e.Location.Y - kpSklejanaKrzywaBeziera.kpPromieńPunktuKontrolnego,
                                        2 * kpSklejanaKrzywaBeziera.kpPromieńPunktuKontrolnego,
                                        2 * kpSklejanaKrzywaBeziera.kpPromieńPunktuKontrolnego);
                                        kpRysownica.DrawString("p" + kpSklejanaKrzywaBeziera.kpNumerPunktuKontrolnego.ToString(),
                                            FontOpisuPunktów, kpPędzel, e.Location);
                                    }
                                    kpRysownica.DrawBezier(kpPióro,
                                        kpSklejanaKrzywaBeziera.kpPunktP3,
                                        kpSklejanaKrzywaBeziera.kpPunktP4,
                                        kpSklejanaKrzywaBeziera.kpPunktP5,
                                        kpSklejanaKrzywaBeziera.kpPunktP6);
                                    
                                }
                                kpgrbWybieranieKrzywych.Enabled = true;
                            }
                            
                        }

                       
                    }
                   

                }
                if (kprdbKrzywaKardynalna.Checked)
                {
                    
                    if (kpgrbWybieranieKrzywych.Enabled)
                    {
                        kpgrbWybieranieKrzywych.Enabled = false;
                        kpKrzywaKardynalna.kpNumerPunktuKontrolnego = 0;
                        kpKrzywaKardynalna.kpPromieńPunktuKontrolnego = 4;
                        kpKrzywaKardynalna.kpPunkt01 = e.Location;

                        using (SolidBrush kpPędzel = new SolidBrush(Color.Black))
                        {
                            kpRysownica.FillEllipse(kpPędzel,
                                e.Location.X - kpKrzywaKardynalna.kpPromieńPunktuKontrolnego,
                                e.Location.Y - kpKrzywaKardynalna.kpPromieńPunktuKontrolnego,
                                2 * kpKrzywaKardynalna.kpPromieńPunktuKontrolnego,
                                2 * kpKrzywaKardynalna.kpPromieńPunktuKontrolnego);
                            kpRysownica.DrawString("p" + kpKrzywaKardynalna.kpNumerPunktuKontrolnego.ToString(),
                                FontOpisuPunktów, kpPędzel, e.Location);
                        }
                    }
                    else
                    {
                        kpKrzywaKardynalna.kpNumerPunktuKontrolnego++;
                        switch (kpKrzywaKardynalna.kpNumerPunktuKontrolnego)
                        {
                            case 1: kpKrzywaKardynalna.kpPunkt02 = e.Location; break;
                            case 2: kpKrzywaKardynalna.kpPunkt03 = e.Location; break;
                            case 3: kpKrzywaKardynalna.kpPunkt04 = e.Location; break;
                            case 4: kpKrzywaKardynalna.kpPunkt05 = e.Location; break;
                        }
                        if (kpKrzywaKardynalna.kpNumerPunktuKontrolnego < 4)
                        {
                            using (SolidBrush kpPędzel = new SolidBrush(Color.Red))
                            {
                                kpRysownica.FillEllipse(kpPędzel,
                                 e.Location.X - kpKrzywaKardynalna.kpPromieńPunktuKontrolnego,
                                e.Location.Y - kpKrzywaKardynalna.kpPromieńPunktuKontrolnego,
                                2 * kpKrzywaKardynalna.kpPromieńPunktuKontrolnego,
                                2 * kpKrzywaKardynalna.kpPromieńPunktuKontrolnego);
                                kpRysownica.DrawString("p" + kpKrzywaKardynalna.kpNumerPunktuKontrolnego.ToString(),
                                    FontOpisuPunktów, kpPędzel, e.Location);
                            }
                        }
                        else
                        {
                            using (SolidBrush kpPędzel = new SolidBrush(Color.Black))
                            {
                                kpRysownica.FillEllipse(kpPędzel,
                                 e.Location.X - kpKrzywaKardynalna.kpPromieńPunktuKontrolnego,
                                e.Location.Y - kpKrzywaKardynalna.kpPromieńPunktuKontrolnego,
                                2 * kpKrzywaKardynalna.kpPromieńPunktuKontrolnego,
                                2 * kpKrzywaKardynalna.kpPromieńPunktuKontrolnego);
                                kpRysownica.DrawString("p" + kpKrzywaKardynalna.kpNumerPunktuKontrolnego.ToString(),
                                    FontOpisuPunktów, kpPędzel, e.Location);
                            }
                            PointF[] points = {
                                kpKrzywaKardynalna.kpPunkt01,
                                kpKrzywaKardynalna.kpPunkt02,
                                kpKrzywaKardynalna.kpPunkt03,
                                kpKrzywaKardynalna.kpPunkt04,
                                kpKrzywaKardynalna.kpPunkt05};
                            kpRysownica.DrawCurve(kpPióro, points, 1.0f);
                            kpgrbWybieranieKrzywych.Enabled = true;
                        }
                        
                    }
                    

                }
                if (kprdbZamkniętaKrzywaKardynalna.Checked)
                {

                    if (kpgrbWybieranieKrzywych.Enabled)
                    {
                        kpgrbWybieranieKrzywych.Enabled = false;
                        kpKrzywaKardynalna.kpNumerPunktuKontrolnego = 0;
                        kpKrzywaKardynalna.kpPromieńPunktuKontrolnego = 4;
                        kpKrzywaKardynalna.kpPunkt01 = e.Location;

                        using (SolidBrush kpPędzel = new SolidBrush(Color.Black))
                        {
                            kpRysownica.FillEllipse(kpPędzel,
                                e.Location.X - kpKrzywaKardynalna.kpPromieńPunktuKontrolnego,
                                e.Location.Y - kpKrzywaKardynalna.kpPromieńPunktuKontrolnego,
                                2 * kpKrzywaKardynalna.kpPromieńPunktuKontrolnego,
                                2 * kpKrzywaKardynalna.kpPromieńPunktuKontrolnego);
                            kpRysownica.DrawString("p" + kpKrzywaKardynalna.kpNumerPunktuKontrolnego.ToString(),
                                FontOpisuPunktów, kpPędzel, e.Location);
                        }
                    }
                    else
                    {
                        kpKrzywaKardynalna.kpNumerPunktuKontrolnego++;
                        switch (kpKrzywaKardynalna.kpNumerPunktuKontrolnego)
                        {
                            case 1: kpKrzywaKardynalna.kpPunkt02 = e.Location; break;
                            case 2: kpKrzywaKardynalna.kpPunkt03 = e.Location; break;
                            case 3: kpKrzywaKardynalna.kpPunkt04 = e.Location; break;
                            case 4: kpKrzywaKardynalna.kpPunkt05 = e.Location; break;
                        }
                        if (kpKrzywaKardynalna.kpNumerPunktuKontrolnego < 4)
                        {
                            using (SolidBrush kpPędzel = new SolidBrush(Color.Red))
                            {
                                kpRysownica.FillEllipse(kpPędzel,
                                 e.Location.X - kpKrzywaKardynalna.kpPromieńPunktuKontrolnego,
                                e.Location.Y - kpKrzywaKardynalna.kpPromieńPunktuKontrolnego,
                                2 * kpKrzywaKardynalna.kpPromieńPunktuKontrolnego,
                                2 * kpKrzywaKardynalna.kpPromieńPunktuKontrolnego);
                                kpRysownica.DrawString("p" + kpKrzywaKardynalna.kpNumerPunktuKontrolnego.ToString(),
                                    FontOpisuPunktów, kpPędzel, e.Location);
                            }
                        }
                        else
                        {
                            using (SolidBrush kpPędzel = new SolidBrush(Color.Black))
                            {
                                kpRysownica.FillEllipse(kpPędzel,
                                 e.Location.X - kpKrzywaKardynalna.kpPromieńPunktuKontrolnego,
                                e.Location.Y - kpKrzywaKardynalna.kpPromieńPunktuKontrolnego,
                                2 * kpKrzywaKardynalna.kpPromieńPunktuKontrolnego,
                                2 * kpKrzywaKardynalna.kpPromieńPunktuKontrolnego);
                                kpRysownica.DrawString("p" + kpKrzywaKardynalna.kpNumerPunktuKontrolnego.ToString(),
                                    FontOpisuPunktów, kpPędzel, e.Location);
                            }
                            PointF[] points = {
                                kpKrzywaKardynalna.kpPunkt01,
                                kpKrzywaKardynalna.kpPunkt02,
                                kpKrzywaKardynalna.kpPunkt03,
                                kpKrzywaKardynalna.kpPunkt04,
                                kpKrzywaKardynalna.kpPunkt05};
                            kpRysownica.DrawClosedCurve(kpPióro, points);
                            kpgrbWybieranieKrzywych.Enabled = true;
                        }

                    }


                }
                if (kprdbWypełnionaZamkniętaKrzywaKardynalna.Checked)
                {

                    if (kpgrbWybieranieKrzywych.Enabled)
                    {
                        kpgrbWybieranieKrzywych.Enabled = false;
                        kpKrzywaKardynalna.kpNumerPunktuKontrolnego = 0;
                        kpKrzywaKardynalna.kpPromieńPunktuKontrolnego = 4;
                        kpKrzywaKardynalna.kpPunkt01 = e.Location;

                        using (SolidBrush kpPędzel = new SolidBrush(Color.Black))
                        {
                            kpRysownica.FillEllipse(kpPędzel,
                                e.Location.X - kpKrzywaKardynalna.kpPromieńPunktuKontrolnego,
                                e.Location.Y - kpKrzywaKardynalna.kpPromieńPunktuKontrolnego,
                                2 * kpKrzywaKardynalna.kpPromieńPunktuKontrolnego,
                                2 * kpKrzywaKardynalna.kpPromieńPunktuKontrolnego);
                            kpRysownica.DrawString("p" + kpKrzywaKardynalna.kpNumerPunktuKontrolnego.ToString(),
                                FontOpisuPunktów, kpPędzel, e.Location);
                        }
                    }
                    else
                    {
                        kpKrzywaKardynalna.kpNumerPunktuKontrolnego++;
                        switch (kpKrzywaKardynalna.kpNumerPunktuKontrolnego)
                        {
                            case 1: kpKrzywaKardynalna.kpPunkt02 = e.Location; break;
                            case 2: kpKrzywaKardynalna.kpPunkt03 = e.Location; break;
                            case 3: kpKrzywaKardynalna.kpPunkt04 = e.Location; break;
                            case 4: kpKrzywaKardynalna.kpPunkt05 = e.Location; break;
                        }
                        if (kpKrzywaKardynalna.kpNumerPunktuKontrolnego < 4)
                        {
                            using (SolidBrush kpPędzel = new SolidBrush(Color.Red))
                            {
                                kpRysownica.FillEllipse(kpPędzel,
                                 e.Location.X - kpKrzywaKardynalna.kpPromieńPunktuKontrolnego,
                                e.Location.Y - kpKrzywaKardynalna.kpPromieńPunktuKontrolnego,
                                2 * kpKrzywaKardynalna.kpPromieńPunktuKontrolnego,
                                2 * kpKrzywaKardynalna.kpPromieńPunktuKontrolnego);
                                kpRysownica.DrawString("p" + kpKrzywaKardynalna.kpNumerPunktuKontrolnego.ToString(),
                                    FontOpisuPunktów, kpPędzel, e.Location);
                            }
                        }
                        else
                        {
                            using (SolidBrush kpPędzel = new SolidBrush(Color.Black))
                            {
                                kpRysownica.FillEllipse(kpPędzel,
                                 e.Location.X - kpKrzywaKardynalna.kpPromieńPunktuKontrolnego,
                                e.Location.Y - kpKrzywaKardynalna.kpPromieńPunktuKontrolnego,
                                2 * kpKrzywaKardynalna.kpPromieńPunktuKontrolnego,
                                2 * kpKrzywaKardynalna.kpPromieńPunktuKontrolnego);
                                kpRysownica.DrawString("p" + kpKrzywaKardynalna.kpNumerPunktuKontrolnego.ToString(),
                                    FontOpisuPunktów, kpPędzel, e.Location);
                            }
                            PointF[] points = {
                                kpKrzywaKardynalna.kpPunkt01,
                                kpKrzywaKardynalna.kpPunkt02,
                                kpKrzywaKardynalna.kpPunkt03,
                                kpKrzywaKardynalna.kpPunkt04,
                                kpKrzywaKardynalna.kpPunkt05};
                            kpPędzel.Color = kpbtnKolorWypełnienia.BackColor;
                            kpRysownica.FillClosedCurve(kpPędzel, points);
                            kpgrbWybieranieKrzywych.Enabled = true;
                        }

                    }


                }

                if (kprdbWypełnionaObramowanaZamknietaKrzywaKardynalna.Checked)
                {

                    if (kpgrbWybieranieKrzywych.Enabled)
                    {
                        kpgrbWybieranieKrzywych.Enabled = false;
                        kpKrzywaKardynalna.kpNumerPunktuKontrolnego = 0;
                        kpKrzywaKardynalna.kpPromieńPunktuKontrolnego = 4;
                        kpKrzywaKardynalna.kpPunkt01 = e.Location;

                        using (SolidBrush kpPędzel = new SolidBrush(Color.Black))
                        {
                            kpRysownica.FillEllipse(kpPędzel,
                                e.Location.X - kpKrzywaKardynalna.kpPromieńPunktuKontrolnego,
                                e.Location.Y - kpKrzywaKardynalna.kpPromieńPunktuKontrolnego,
                                2 * kpKrzywaKardynalna.kpPromieńPunktuKontrolnego,
                                2 * kpKrzywaKardynalna.kpPromieńPunktuKontrolnego);
                            kpRysownica.DrawString("p" + kpKrzywaKardynalna.kpNumerPunktuKontrolnego.ToString(),
                                FontOpisuPunktów, kpPędzel, e.Location);
                        }
                    }
                    else
                    {
                        kpKrzywaKardynalna.kpNumerPunktuKontrolnego++;
                        switch (kpKrzywaKardynalna.kpNumerPunktuKontrolnego)
                        {
                            case 1: kpKrzywaKardynalna.kpPunkt02 = e.Location; break;
                            case 2: kpKrzywaKardynalna.kpPunkt03 = e.Location; break;
                            case 3: kpKrzywaKardynalna.kpPunkt04 = e.Location; break;
                            case 4: kpKrzywaKardynalna.kpPunkt05 = e.Location; break;
                        }
                        if (kpKrzywaKardynalna.kpNumerPunktuKontrolnego < 4)
                        {
                            using (SolidBrush kpPędzel = new SolidBrush(Color.Red))
                            {
                                kpRysownica.FillEllipse(kpPędzel,
                                 e.Location.X - kpKrzywaKardynalna.kpPromieńPunktuKontrolnego,
                                e.Location.Y - kpKrzywaKardynalna.kpPromieńPunktuKontrolnego,
                                2 * kpKrzywaKardynalna.kpPromieńPunktuKontrolnego,
                                2 * kpKrzywaKardynalna.kpPromieńPunktuKontrolnego);
                                kpRysownica.DrawString("p" + kpKrzywaKardynalna.kpNumerPunktuKontrolnego.ToString(),
                                    FontOpisuPunktów, kpPędzel, e.Location);
                            }
                        }
                        else
                        {
                            using (SolidBrush kpPędzel = new SolidBrush(Color.Black))
                            {
                                kpRysownica.FillEllipse(kpPędzel,
                                 e.Location.X - kpKrzywaKardynalna.kpPromieńPunktuKontrolnego,
                                e.Location.Y - kpKrzywaKardynalna.kpPromieńPunktuKontrolnego,
                                2 * kpKrzywaKardynalna.kpPromieńPunktuKontrolnego,
                                2 * kpKrzywaKardynalna.kpPromieńPunktuKontrolnego);
                                kpRysownica.DrawString("p" + kpKrzywaKardynalna.kpNumerPunktuKontrolnego.ToString(),
                                    FontOpisuPunktów, kpPędzel, e.Location);
                            }
                            PointF[] points = {
                                kpKrzywaKardynalna.kpPunkt01,
                                kpKrzywaKardynalna.kpPunkt02,
                                kpKrzywaKardynalna.kpPunkt03,
                                kpKrzywaKardynalna.kpPunkt04,
                                kpKrzywaKardynalna.kpPunkt05};
                            kpPędzel.Color = kpbtnKolorWypełnienia.BackColor;
                            kpRysownica.FillClosedCurve(kpPędzel, points);
                            kpRysownica.DrawClosedCurve(kpPióro, points);
                            kpgrbWybieranieKrzywych.Enabled = true;
                        }

                    }


                }

                if (kprdbŁukElipsy.Checked)
                {
                    //deklaracje uzupełniające
                    ushort kpStopieńWielokąta = 1000;
                    int R = kpSzerokość;
                    double kpKątPołożeniaPierwszegoWierzchołka = 90.0;
                    double kpKątMiędzyWierzchołkamiWielokąta = 90.0 / kpStopieńWielokąta;
                    //deklaracja tablicy dla przechowania współrzednych wierzchołków wielokąta
                    Point[] kpWierzchołkiWielokąta = new Point[kpStopieńWielokąta];
                    //wyznaczenie współrzędncyh wierzhołków wielokąta i wpisanie ich do tablicy wierzchołkiwielokąta
                    for (int i = 0; i < kpStopieńWielokąta; i++)
                    {//stosujemy wzór na równanie parametryczne okręgu
                        kpWierzchołkiWielokąta[i].X = kpLewyGórnyNarożnikX + (int)(R * Math.Cos(Math.PI
                            * (kpKątPołożeniaPierwszegoWierzchołka + i * kpKątMiędzyWierzchołkamiWielokąta) / 180.0));

                        kpWierzchołkiWielokąta[i].Y = kpLewyGórnyNarożnikY + (int)(R * Math.Sin(Math.PI
                            * (kpKątPołożeniaPierwszegoWierzchołka + i * kpKątMiędzyWierzchołkamiWielokąta) / 180.0));

                    }
                    //wykreslenie prostokąta
                    kpRysownica.DrawPolygon(kpPióro, kpWierzchołkiWielokąta);
                }

                if(kprdbWycinekElipsy.Checked)
                {

                    Rectangle rect = new Rectangle(
       kpLewyGórnyNarożnikY, kpLewyGórnyNarożnikX, kpWysokość, kpSzerokość);
                    kpRysownica.DrawPie(kpPióro, rect, 0.0f, 90.0f);

                }

                if (kprdbWypełnionyWycinekElipsy.Checked)
                {

                    Rectangle rect = new Rectangle(
       kpLewyGórnyNarożnikY, kpLewyGórnyNarożnikX, kpWysokość, kpSzerokość);
                    kpPędzel.Color = kpbtnKolorWypełnienia.BackColor;
                    kpRysownica.FillPie(kpPędzel, rect, 0.0f, 90.0f);

                }

                if (kprdbWypełnionyObramowanyWycinekElipsy.Checked)
                {

                    Rectangle rect = new Rectangle(
       kpLewyGórnyNarożnikY, kpLewyGórnyNarożnikX, kpWysokość, kpSzerokość);
                    kpPędzel.Color = kpbtnKolorWypełnienia.BackColor;
                    kpRysownica.FillPie(kpPędzel, rect, 0.0f, 90.0f);
                    kpRysownica.DrawPie(kpPióro, rect, 0.0f, 90.0f);

                }

                if (kprdbTrapez.Checked)
                {

                    //deklaracje uzupełniające
                    ushort kpStopieńWielokąta = 4;
                    int R = kpSzerokość;
                    double kpKątPołożeniaPierwszegoWierzchołka = 00.0;
                    double kpKątMiędzyWierzchołkamiWielokąta = 90.0 / kpStopieńWielokąta;
                    //deklaracja tablicy dla przechowania współrzednych wierzchołków wielokąta
                    Point[] kpWierzchołkiWielokąta = new Point[kpStopieńWielokąta];
                    //wyznaczenie współrzędncyh wierzhołków wielokąta i wpisanie ich do tablicy wierzchołkiwielokąta
                    for (int i = 0; i < kpStopieńWielokąta; i++)
                    {//stosujemy wzór na równanie parametryczne okręgu
                        kpWierzchołkiWielokąta[i].X = kpLewyGórnyNarożnikX + (int)(R * Math.Cos(Math.PI
                            * (kpKątPołożeniaPierwszegoWierzchołka + i * kpKątMiędzyWierzchołkamiWielokąta) / 90.0));

                        kpWierzchołkiWielokąta[i].Y = kpLewyGórnyNarożnikY + (int)(R * Math.Sin(Math.PI
                            * (kpKątPołożeniaPierwszegoWierzchołka + i * kpKątMiędzyWierzchołkamiWielokąta) / 90.0));

                    }
                    kpRysownica.DrawPolygon(kpPióro, kpWierzchołkiWielokąta);
                }

                if (kprdbRomb.Checked)
                {
                    ushort kpStopieńWielokąta = (ushort)kpnumUDLiczbaKątów.Value;
                    int R = kpSzerokość;
                    double kpKątPołożeniaPierwszegoWierzchołka = 0.0;
                    double kpKątMiędzyWierzchołkamiWielokąta = 360.0 / kpStopieńWielokąta;
                    Point[] kpWierzchołkiWielokąta = new Point[kpStopieńWielokąta];
                    for (int i = 0; i < kpStopieńWielokąta; i++)
                    {
                        kpWierzchołkiWielokąta[i].X = kpLewyGórnyNarożnikX +
                          (int)(2*R * Math.Cos(Math.PI * (kpKątPołożeniaPierwszegoWierzchołka +
                            i * kpKątMiędzyWierzchołkamiWielokąta) / 180));

                        kpWierzchołkiWielokąta[i].Y = kpLewyGórnyNarożnikY +
                          (int)(R * Math.Sin(Math.PI * (kpKątPołożeniaPierwszegoWierzchołka +
                            i * kpKątMiędzyWierzchołkamiWielokąta) / 180));

                    }
                    kpRysownica.DrawPolygon(kpPióro, kpWierzchołkiWielokąta);
                }
                if (kprdbPółkole.Checked)
                {
                    //deklaracje uzupełniające
                    ushort kpStopieńWielokąta = 100;
                    int R = kpSzerokość;
                    double kpKątPołożeniaPierwszegoWierzchołka = 00.0;
                    double kpKątMiędzyWierzchołkamiWielokąta = 180.0 / kpStopieńWielokąta;
                    //deklaracja tablicy dla przechowania współrzednych wierzchołków wielokąta
                    Point[] kpWierzchołkiWielokąta = new Point[kpStopieńWielokąta];
                    //wyznaczenie współrzędncyh wierzhołków wielokąta i wpisanie ich do tablicy wierzchołkiwielokąta
                    for (int i = 0; i < kpStopieńWielokąta; i++)
                    {//stosujemy wzór na równanie parametryczne okręgu
                        kpWierzchołkiWielokąta[i].X = kpLewyGórnyNarożnikX + (int)(R * Math.Cos(Math.PI
                            * (kpKątPołożeniaPierwszegoWierzchołka + i * kpKątMiędzyWierzchołkamiWielokąta) / 180.0));

                        kpWierzchołkiWielokąta[i].Y = kpLewyGórnyNarożnikY + (int)(R * Math.Sin(Math.PI
                            * (kpKątPołożeniaPierwszegoWierzchołka + i * kpKątMiędzyWierzchołkamiWielokąta) / 180.0));

                    }
                    //wykreslenie prostokąta
                    kpRysownica.DrawPolygon(kpPióro, kpWierzchołkiWielokąta);
                }
                

            }               
            kppbRysownica.Refresh();
        }

        private void KrzywaKardynalna(object sender, EventArgs e)
        {
            
        }




        private void kprdbZamkniętaKrzywaKardynalna_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void kprdbProstokąt_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void kprdbOkrąg_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void kprdbRomb_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void kprdbKrzywaBeziera_CheckedChanged(object sender, EventArgs e)
        {
            if (kprdbKrzywaBeziera.Checked)
               
            MessageBox.Show("Wykreślenie krzywej beziera wymaga zaznaczenia" +
                "4 punktów na Rysownicy",
                "Kreślenie krzywej Beziera",
                 MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
        }

        private void kpbtnKolorWypełnienia_Click(object sender, EventArgs e)
        {
            ColorDialog kpPaletaKolorów = new ColorDialog();
            //ustawienie w Palecie Kolorów aktualnego koloru wypełnienia
            kpPaletaKolorów.Color = kpbtnKolorWypełnienia.BackColor;
            //wizualizacja palety kolorow
            if (kpPaletaKolorów.ShowDialog() == DialogResult.OK)
                kpbtnKolorWypełnienia.BackColor = kpPaletaKolorów.Color;
            //zwolnienie palety kolorow
            kpPaletaKolorów.Dispose();

        }


        private void kprdbProstokątWypełniony_CheckedChanged(object sender, EventArgs e)
        {
            if (kprdbProstokątWypełniony.Checked)
            {
                kpbtnKolorWypełnienia.Visible = true;
                
            }
            else
            {
                kpbtnKolorWypełnienia.Visible = false;
            }
        }

        private void kprdbKwadratWypełniony_CheckedChanged(object sender, EventArgs e)
        {
            if (kprdbKwadratWypełniony.Checked)
            {
                kpbtnKolorWypełnienia.Visible = true;

            }
            else
            {
                kpbtnKolorWypełnienia.Visible = false;
            }
        }

        private void kprdbElipsaWypełniona_CheckedChanged(object sender, EventArgs e)
        {
            if (kprdbElipsaWypełniona.Checked)
            {
                kpbtnKolorWypełnienia.Visible = true;

            }
            else
            {
                kpbtnKolorWypełnienia.Visible = false;
            }
        }

        private void kprdbOkrągWypełniony_CheckedChanged(object sender, EventArgs e)
        {
            if (kprdbOkrągWypełniony.Checked)
            {
                kpbtnKolorWypełnienia.Visible = true;

            }
            else
            {
                kpbtnKolorWypełnienia.Visible = false;
            }
        }

        private void ProjektIndywidualny3_Load(object sender, EventArgs e)
        {

        }

        private void kprdbSklejanaKrzywaBeziera_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void kprdbWypełnionaZamkniętaKrzywaKardynalna_CheckedChanged(object sender, EventArgs e)
        {
            if (kprdbWypełnionaZamkniętaKrzywaKardynalna.Checked)
            {
                kpbtnKolorWypełnienia.Visible = true;

            }
            else
            {
                kpbtnKolorWypełnienia.Visible = false;
            }
        }

        private void kprdbWypełnionaObramowanaZamknietaKrzywaKardynalna_CheckedChanged(object sender, EventArgs e)
        {

            if (kprdbWypełnionaObramowanaZamknietaKrzywaKardynalna.Checked)
            {
                kpbtnKolorWypełnienia.Visible = true;

            }
            else
            {
                kpbtnKolorWypełnienia.Visible = false;
            }
        }

        private void kprdbWypełnionyWycinekElipsy_CheckedChanged(object sender, EventArgs e)
        {
            if (kprdbWypełnionyWycinekElipsy.Checked)
            {
                kpbtnKolorWypełnienia.Visible = true;

            }
            else
            {
                kpbtnKolorWypełnienia.Visible = false;
            }
        }

        private void kprdbWypełnionyObramowanyWycinekElipsy_CheckedChanged(object sender, EventArgs e)
        {
            if (kprdbWypełnionyObramowanyWycinekElipsy.Checked)
            {
                kpbtnKolorWypełnienia.Visible = true;

            }
            else
            {
                kpbtnKolorWypełnienia.Visible = false;
            }
        }

        private void zapiszBitMapęWPlikuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog OknoWyboruPlikuDoZapisu = new SaveFileDialog();
            OknoWyboruPlikuDoZapisu.Filter = "Pdf files (*.pdf)|*.pdf|All files (*.*)|*.*";
            OknoWyboruPlikuDoZapisu.FilterIndex = 1; 
            OknoWyboruPlikuDoZapisu.RestoreDirectory = true;
            OknoWyboruPlikuDoZapisu.InitialDirectory = "E:\\"; 
            OknoWyboruPlikuDoZapisu.Title = "Wybór pliku do zapisu BitMapy";
            if (OknoWyboruPlikuDoZapisu.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamWriter PlikZnakowy = new System.IO.StreamWriter(OknoWyboruPlikuDoZapisu.FileName);
                try
                {
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR: podczas zapisywania Bitmapy w pliku wystąpił błąd: " + ex.Message);
                }
                finally
                { 
                    PlikZnakowy.Close();
                }
            }
            else
                MessageBox.Show("UWAGA: nie dokonano wyboru pliku i polecenia zapisu nie zostało zrealizowane");
        }

        private void odczytajBitMapęZPlikuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OknoWyboruPlikuDoOdczytu = new OpenFileDialog();
            OknoWyboruPlikuDoOdczytu.Filter = "pdffiles (*.pdf)|*.pdf|All files(*.*)|*.*";
            OknoWyboruPlikuDoOdczytu.FilterIndex = 1; 
            OknoWyboruPlikuDoOdczytu.RestoreDirectory = true;
            OknoWyboruPlikuDoOdczytu.InitialDirectory = "H:\\";
            OknoWyboruPlikuDoOdczytu.Title = "Wybór pliku do odczytuBitMapy";
            
            if (OknoWyboruPlikuDoOdczytu.ShowDialog() == DialogResult.OK)
            {
                string WierszDanych; 
                string[] DaneWiersza; 
                ushort LicznikWierszy; 
                System.IO.StreamReader PlikZnakowy = new System.IO.StreamReader(OknoWyboruPlikuDoOdczytu.FileName);
               
                LicznikWierszy = 0;
                while (!((WierszDanych = PlikZnakowy.ReadLine()) is null))
                    LicznikWierszy++;

               
                PlikZnakowy.Close();

                
                PlikZnakowy = new System.IO.StreamReader(OknoWyboruPlikuDoOdczytu.FileName);

                try

                {
                    int NrWiersza = 0;

                    while (!((WierszDanych = PlikZnakowy.ReadLine()) is null))
                    {
                        DaneWiersza = WierszDanych.Split(';');

                        DaneWiersza[0].Trim(); DaneWiersza[1].Trim(); DaneWiersza[2].Trim();


                    }


                    kppbRysownica.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR: błąd operacji (działania) na pliku (wyświetlony komunikat): ---> " + ex.Message);
                }
                finally
                {
                    PlikZnakowy.Close();
                    PlikZnakowy.Dispose();
                }
            }
            else
                MessageBox.Show("Plik do odczytu tablicy TWS nie został wybrany i obsługa polecenia: 'Odczytanie stablicowanego szeregu z pliku' (z menu poziomu Plik) nie może być zrealizowana");

        }

        private void exitZFormularzaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult PytanieDoUżytkownika = MessageBox.Show("Czy napewno chcesz zamknąć formularz (co może skutkować utratą danych zapisanych na formularzu?)",
                this.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
           
            if (PytanieDoUżytkownika == DialogResult.Yes)
                Close();
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void kolorTłaRysownicyToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            ColorDialog PaletaKolorów = new ColorDialog();
            PaletaKolorów.Color = kppbRysownica.BackColor;
           
            if (PaletaKolorów.ShowDialog() == DialogResult.OK) 
                kppbRysownica.BackColor = PaletaKolorów.Color;
            PaletaKolorów.Dispose();
        }

        private void koloryLiniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog kpPaletaKolorów = new ColorDialog();
            kpPaletaKolorów.Color = kpbtnKolorWypełnienia.BackColor;
            
            if (kpPaletaKolorów.ShowDialog() == DialogResult.OK)

                kpPaletaKolorów.Dispose();
            kpPióro.Color = kpPaletaKolorów.Color;
        }

        private void kolorWypełnieniaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ColorDialog kpPaletaKolorów = new ColorDialog();
            kpPaletaKolorów.Color = kpbtnKolorWypełnienia.BackColor;
            if (kpPaletaKolorów.ShowDialog() == DialogResult.OK)
                kpbtnKolorWypełnienia.BackColor = kpPaletaKolorów.Color;
            kpPaletaKolorów.Dispose();

        }


        private void kolorCzcionkiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog OknoCzcionki = new FontDialog();
            OknoCzcionki.Font = this.Font;
            if (OknoCzcionki.ShowDialog() == DialogResult.OK)
                this.Font = OknoCzcionki.Font;
            OknoCzcionki.Dispose();
        }

        private void solidToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            kpPióro.DashStyle = DashStyle.Solid;
        }

        private void dashToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            kpPióro.DashStyle = DashStyle.Dash;
        }

        private void dashDotToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            kpPióro.DashStyle = DashStyle.DashDot;
        }

        private void dashDotDotToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            kpPióro.DashStyle = DashStyle.DashDotDot;
        }

        private void dotToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            kpPióro.DashStyle = DashStyle.Dot;
        }

        private void toolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            kpPióro.Width = 1;
        }

        private void toolStripMenuItem3_Click_1(object sender, EventArgs e)
        {
            kpPióro.Width = 2;
        }

        private void toolStripMenuItem4_Click_1(object sender, EventArgs e)
        {
            kpPióro.Width = 3;
        }

        private void toolStripMenuItem5_Click_1(object sender, EventArgs e)
        {
            kpPióro.Width = 4;
        }

        private void toolStripMenuItem6_Click_1(object sender, EventArgs e)
        {
            kpPióro.Width = 5;
        }

       

        private void grotyRozpoczęciaLiniToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void flatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kpPióro.StartCap = LineCap.Flat;
        }

        private void squareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kpPióro.StartCap = LineCap.Square;
        }

        private void triangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kpPióro.StartCap = LineCap.Triangle;
        }

        private void roundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kpPióro.StartCap = LineCap.Round;
        }

        private void flatToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            kpPióro.EndCap = LineCap.Flat;
        }

        private void squareToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            kpPióro.EndCap = LineCap.Square;
        }

        private void triangleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            kpPióro.EndCap = LineCap.Triangle;
        }

        private void roundToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            kpPióro.EndCap = LineCap.Round;
        }
    }
    }
    
