using System;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace WPF_MathiasSchmit_ACT3bis
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CalendarDateRange blackoutDays = new CalendarDateRange(new DateTime(0001, 01, 01), DateTime.Now.AddDays(-1));
            startDate.BlackoutDates.Add(blackoutDays); endDate.BlackoutDates.Add(blackoutDays);
            startDate.CalendarClosed += new RoutedEventHandler(SelectDateChangeEvent);
            btnTime.Click += new RoutedEventHandler(BtnTimeClick);
            btnPrix.Click += new RoutedEventHandler(CalcPrix);
        }

        public double NbrJour()
        {
            if (startDate.Text.Length >= 6 && endDate.Text.Length >= 6)
            {
                int yearS = 2000 + int.Parse(startDate.Text[6].ToString() + startDate.Text[7].ToString());
                int yearE = 2000 + int.Parse(endDate.Text[6].ToString() + endDate.Text[7].ToString());
                DateTime start = new DateTime(yearS, int.Parse(startDate.Text[3].ToString() + startDate.Text[4].ToString()), int.Parse(startDate.Text[0].ToString() + startDate.Text[1].ToString()));
                DateTime end = new DateTime(yearS, int.Parse(endDate.Text[3].ToString() + endDate.Text[4].ToString()), int.Parse(endDate.Text[0].ToString() + endDate.Text[1].ToString()));
                string template = (endDate.SelectedDate.Value.Date - startDate.SelectedDate.Value.Date).ToString();
                char chars = 'a';
                string text = "";
                int i = 0;
                while (chars != '.')
                {
                    chars = template[i];
                    i++;
                    if (chars != '.')
                    {
                        text += chars;
                    }
                }
                return (double.Parse(text));
            }
            return 1000000;
        }

        public void BtnTimeClick(object sender, RoutedEventArgs e)
        {
            string text = Math.Round(NbrJour() / 7).ToString();
            textTime.Text = text + " semaine(s)";
        }

        public void SelectDateChangeEvent(object sender, RoutedEventArgs e)
        {
            if (startDate.SelectedDate != null)
            {
                if (startDate.SelectedDate != null)
                    endDate.SelectedDate = null;
                CalendarDateRange blackoutDays = new CalendarDateRange(new DateTime(0001, 01, 01), startDate.SelectedDate.Value.Date);
                endDate.BlackoutDates.Clear();
                endDate.BlackoutDates.Add(blackoutDays);
                CalendarDateRange blackoutDays2;
                DateTime test = startDate.SelectedDate.Value.Date;
                if (startDate.SelectedDate.Value.Date.Month >= 07 && startDate.SelectedDate.Value.Date.Month <= 10)
                {
                    test = new DateTime(startDate.SelectedDate.Value.Date.Year, 10, 31);
                    blackoutDays2 = new CalendarDateRange(test, new DateTime(9999, 12, 31));
                }
                else
                {
                    if (startDate.SelectedDate.Value.Date.Month > 10)
                    {
                        test = new DateTime(startDate.SelectedDate.Value.Date.Year + 1, 06, 31);
                    }
                    else
                    {
                        test = new DateTime(startDate.SelectedDate.Value.Date.Year, 06, 31);
                    }
                    blackoutDays2 = new CalendarDateRange(test, new DateTime(9999, 12, 31));
                }
            }
            

        }

        public void CalcPrix(object sender, RoutedEventArgs e)
        {
            double prix;
            if (startDate.SelectedDate != null && endDate.SelectedDate != null && Tente.IsChecked != null && Chalet.IsChecked != null && Reserved.IsChecked != null)
            {
                bool tente = bool.Parse(Tente.IsChecked.ToString());
                bool chalet = bool.Parse(Chalet.IsChecked.ToString());
                int prs;
                if (int.TryParse(nbrPersonnes.Text, out prs))
                {
                    if (startDate.SelectedDate.Value.Date.Month >= 07 && startDate.SelectedDate.Value.Date.Month <= 10)
                    {
                        if (chalet)
                        {
                            if (prs <= 4)
                            {
                                prix = 547;
                            }
                            else if (prs == 5)
                            {
                                prix = 580;
                            }
                            else if (prs == 6)
                            {
                                prix = 597;
                            }
                            else
                            {
                                prix = 1000000 * prs;
                            }
                        }
                        else if (tente)
                        {
                            if (prs <= 4)
                            {
                                prix = 347;
                            }
                            else if (prs == 5)
                            {
                                prix = 370;
                            }
                            else if (prs == 6)
                            {
                                prix = 400;
                            }
                            else
                            {
                                prix = 1000000 * prs;
                            }
                        }
                        else
                        {
                            prix = 0;
                        }

                    }
                    else
                    {
                        if (chalet)
                        {
                            if (prs <= 4)
                            {
                                prix = 297;
                            }
                            else if (prs == 5)
                            {
                                prix = 330;
                            }
                            else if (prs == 6)
                            {
                                prix = 347;
                            }
                            else
                            {
                                prix = 1000000*prs;
                            }
                        }
                        else if (tente)
                        {
                            if (prs <= 4)
                            {
                                prix = 198;
                            }
                            else if (prs == 5)
                            {
                                prix = 220;
                            }
                            else if (prs == 6)
                            {
                                prix = 250;
                            }
                            else
                            {
                                prix = 1000000*prs;
                            }
                        }
                        else
                        {
                            prix = 0;
                        }
                    }

                    if (NbrJour() >= 5 * 7)
                    {
                        prix = prix * 0.9;
                    }
                    else if (NbrJour() >= 3 * 7)
                    {
                        prix = prix * 0.95;
                    }

                    prix += prs * 0.3;
                    if (bool.Parse(Reserved.IsChecked.ToString()))
                    {
                        prix += 12;
                    }
                }
                else
                {
                    prix = 1000000;
                }
                PrixAff.Text = prix.ToString();
                SemmAff.Text = Math.Round(NbrJour() / 7).ToString();
            }
            else
            {
                prix = 2000000;
            }
            PrixAff.Text = prix.ToString();
            SemmAff.Text = Math.Round(NbrJour() / 7).ToString();
        }
    }
}