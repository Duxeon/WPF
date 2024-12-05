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

namespace WPF_MathiasS_Act6._3
{    /// <summary>
     /// Interaction logic for MainWindow.xaml
     /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Brush couleur;
            Button[] boutons = new Button[100];
            InitializeComponent();
            for (int i = 0; i < 100; i++)
            {
                if (i % 2 == 0) couleur = Brushes.Black;
                else couleur = Brushes.White;
                BitmapImage bpng = new BitmapImage();
                Image png = new Image();
                boutons[i] = new Button
                {
                    Width = 65,
                    Height = 65,
                    Background = couleur,
                    Padding = new Thickness(0, 0, 0, 0)
                };
                if (i/10 == 1 || i / 10 == 8)
                {
                    bpng.BeginInit(); 
                    bpng.UriSource = new Uri("Image/p.png", UriKind.Relative);
                    bpng.EndInit();
                } 
                else if (i / 10 == 0 || i / 10 == 9) {
                    if (i == 0 || i == 7 || i == 70 || i == 77)
                    {
                        bpng.BeginInit();
                        bpng.UriSource = new Uri("Image/t.png", UriKind.Relative);
                        bpng.EndInit();
                    }
                    else if(i == 1 || i == 6 || i == 71 || i == 76)
                    {
                        bpng.BeginInit();
                        bpng.UriSource = new Uri("Image/kn.png", UriKind.Relative);
                        bpng.EndInit();
                    } else if (i == 2 || i == 5 || i == 72 || i == 75)
                    {
                        bpng.BeginInit();
                        bpng.UriSource = new Uri("Image/f.png", UriKind.Relative);
                        bpng.EndInit();
                    }
                    else if (i == 3 || i == 74)
                    {
                        bpng.BeginInit();
                        bpng.UriSource = new Uri("Image/k.png", UriKind.Relative);
                        bpng.EndInit();
                    }
                    else
                    {
                        bpng.BeginInit();
                        bpng.UriSource = new Uri("Image/q.png", UriKind.Relative);
                        bpng.EndInit();
                    }
                }
                else
                {
                    bpng = null;
                }
                png.Source = bpng;
                png.Stretch = Stretch.None;

                if (i < 78) 
                {
                    int k;
                    if (i.ToString().Length == 1) k = 0;
                    else k = 1;
                    if (i.ToString()[k] != '8' && i.ToString()[k] != '9') wrap.Children.Add(boutons[i]);
                }
            }
        }

    }
}