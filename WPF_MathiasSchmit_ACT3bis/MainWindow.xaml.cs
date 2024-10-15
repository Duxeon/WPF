using System;
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
            startDate.BlackoutDates.Add(blackoutDays);
            btnTime.Click += new RoutedEventHandler(BtnTimeClick);
        }

        public void BtnTimeClick(object sender, RoutedEventArgs e)
        {
            int yearS = 2000 + int.Parse(startDate.Text[6].ToString() + startDate.Text[7].ToString());
            int yearE = 2000 + int.Parse(endDate.Text[6].ToString() + endDate.Text[7].ToString());
            DateTime start = new DateTime(yearS, int.Parse(startDate.Text[3].ToString() + startDate.Text[4].ToString()), int.Parse(startDate.Text[0].ToString() + startDate.Text[1].ToString()));
            DateTime end = new DateTime(yearS, int.Parse(endDate.Text[3].ToString() + endDate.Text[4].ToString()), int.Parse(endDate.Text[0].ToString() + endDate.Text[1].ToString()));
            string template = (end - start).ToString();
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
            text = (Math.Round(double.Parse(text)/7)).ToString();
            textTime.Text = text + " semaine(s)";
        }

        public void SelectDateChangeEvent(object sender, RoutedEventArgs e)
        {
            CalendarDateRange blackoutDays = new CalendarDateRange(new DateTime(0001, 01, 01), endDate.SelectedDate.Value.Date);
            endDate.BlackoutDates.Clear();
            endDate.BlackoutDates.Add(blackoutDays);
        }
    }
}