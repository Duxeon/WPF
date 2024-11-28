using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_mathiasS_Act4.Views;

namespace WPF_mathiasS_Act4
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            bp1.Click += new RoutedEventHandler(Page1);
            bp2.Click += new RoutedEventHandler(Page2);
            main.Content = new Page0();
        }

        public void Page1(object sender, EventArgs e)
        {
            main.Content = new Page1();
        }
        public void Page2(object sender, EventArgs e)
        {
            main.Content = new Page2();
        }
    }
}