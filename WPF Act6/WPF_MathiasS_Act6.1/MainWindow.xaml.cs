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

namespace WPF_MathiasS_Act6._1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Brush couleur;
            InitializeComponent();
            for (int i = 0; i < 100; i++)
            {
                if (i % 2 == 0) couleur = Brushes.Black;
                else couleur = Brushes.White;
                wrap.Children.Add(new Button
                {
                    Width = 65,
                    Height = 65,
                    Content = (i + 1).ToString(),
                    Background = couleur,
                    Foreground = Brushes.Red,
                    Padding = new Thickness(0,0,0,0)
                });

                foreach (Button item in wrap.Children)
                {
                    item.Click += new RoutedEventHandler(delNmb);
                }
            }
        }

        public void delNmb(object senders, RoutedEventArgs e) { 
            ((Button)senders).Content = null;
        }
    }
}