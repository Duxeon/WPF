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

namespace CE_UAA14WPF_Dec24_SchmitMathias
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            nbrL.KeyUp += new KeyEventHandler(VerifNumber);
            nbrC.KeyUp += new KeyEventHandler(VerifNumber);
            bala.Click += new RoutedEventHandler(ModifListeAPuce);
            solo.Click += new RoutedEventHandler(ModifListeAPuce);
            mare.Click += new RoutedEventHandler(ModifListeAPuce);
            valider.Click += new RoutedEventHandler(ButtonValidate);
        }

        public void VerifNumber(object senders, KeyEventArgs e)
        {
            TextBox textBox = (TextBox)senders;
            int j;
            if (!int.TryParse(textBox.Text, out j))
            {
                TextBox tb2 = new TextBox();
                tb2.Text = "";
                string k;
                for (int i = 0; i < textBox.Text.Length; i++)
                {
                    k = textBox.Text[i].ToString();
                    if (int.TryParse(k, out j))
                    {
                        tb2.Text += "" + j;
                    }
                }
                textBox.Text = tb2.Text;
            }

        }
        public void ModifListeAPuce(object senders, RoutedEventArgs e)
        {
            if (senders == bala)
            {
                if (bala.IsChecked == true)
                {
                    mare.IsChecked = false;
                    solo.IsChecked = false;
                }
            }
            else if(senders == mare)
            {
                if (mare.IsChecked == true)
                {
                    bala.IsChecked = false;
                    solo.IsChecked = false;
                }
            }
            else if (senders == solo)
            {
                if (solo.IsChecked == true)
                {
                    mare.IsChecked = false;
                    bala.IsChecked = false;
                }
            }
            if (bala.IsChecked == true) gb2.Visibility = Visibility.Visible;
            else gb2.Visibility = Visibility.Hidden;
        }
        public void ButtonValidate(object sender, RoutedEventArgs e)
        {
            code.Text = "Test WPF 6T 2024";
            if (bala.IsChecked == true)
            {
                if (nbrL.Text != "" && nbrC.Text != "")
                {
                    if (int.Parse(nbrL.Text) <= 12 && int.Parse(nbrC.Text) <= 12 && int.Parse(nbrL.Text) >= 2 && int.Parse(nbrC.Text) >= 2)
                    {
                        Bala(int.Parse(nbrL.Text), int.Parse(nbrC.Text));
                    }
                    else
                    {
                        code.Text = "Veuillez indiquer un nombre de Ligne et un nombre de Colonne entre 2 et 12";
                    }
                }
                else
                {
                    code.Text = "Veuillez indiquer un nombre de Ligne ET un nombre de Colonne";
                }
            }
            else
            {
                SoloAndMare(solo.IsChecked == true);
            }
        }
        public void Bala(int nbrL, int nbrC)
        {
            grod.Width = (Width*2)/3;
            grod.Height = (Height*8)/10;
            Button[,] boutons = new Button[nbrC, nbrL];
            grod.Children.Clear();
            for (int i = 0; i < nbrC; i++)
            {
                for (int j = 0; j < nbrL; j++)
                {
                    boutons[i, j] = new Button()
                    {
                        Background = Brushes.Khaki,
                        Foreground = Brushes.Red,
                        Content = "X",
                        FontSize = 22,
                        Width = (grod.Width/nbrL),
                        Height = (grod.Height/nbrC),
                    };
                    if (i == 0 || i == nbrC - 1 || j == 0 || j == nbrL - 1) boutons[i, j].Click += new RoutedEventHandler(BalaClick);
                    else boutons[i,j].Visibility = Visibility.Hidden;
                    grod.Children.Add(boutons[i, j]);
                }
            }
        }
        public void BalaClick(object sender, EventArgs e)
        {
            Brush temp = ((Button)sender).Background;
            ((Button)sender).Background = ((Button)sender).Foreground;
            ((Button)sender).Foreground = temp;
        }
        public void SoloAndMare(bool isSolo)
        {
            grod.Width = (Width * 2) / 3;
            grod.Height = (Height * 8) / 10;
            int nbr;
            if (isSolo) nbr = 9;
            else nbr = 7;
            Button[,] boutons = new Button[nbr, nbr];
            grod.Children.Clear(); 
            for (int i = 0; i < nbr; i++)
            {
                for (int j = 0; j < nbr; j++)
                {
                    boutons[i, j] = new Button()
                    {
                        Background = Brushes.Khaki,
                        Foreground = Brushes.Red,
                        Content = setImage("image/petitCercleRouge.png"),
                        FontSize = 22,
                        Width = (grod.Width / nbr),
                        Height = (grod.Height / nbr),
                    };
                    switch (isSolo)
                    {
                        case true:
                            if ((i>=3&&i<=5)||(j >= 3 && j <= 5)) boutons[i, j].Click += new RoutedEventHandler(SoloAndMareClick);
                            else boutons[i, j].Visibility = Visibility.Hidden;
                            break;
                        case false:
                            if (((i == 3)^(j == 3))||(i+j == 6)^(i == j)) boutons[i, j].Click += new RoutedEventHandler(SoloAndMareClick);
                            else boutons[i, j].Visibility = Visibility.Hidden;
                            break;
                    }
                    grod.Children.Add(boutons[i, j]);
                }
            }
        }
        public void SoloAndMareClick(object sender, EventArgs e)
        {
            ((Button)sender).Content = setImage("image/golfBall60.png");
        }

        public Image setImage(string uri)
        {
            BitmapImage imageBouton = new BitmapImage();
            imageBouton.BeginInit();
            imageBouton.UriSource = new Uri(uri, UriKind.Relative);
            imageBouton.EndInit();
            Image imBouton = new Image();
            imBouton.Source = imageBouton;
            imBouton.Stretch = Stretch.None;
            return imBouton;
        }
    }
}