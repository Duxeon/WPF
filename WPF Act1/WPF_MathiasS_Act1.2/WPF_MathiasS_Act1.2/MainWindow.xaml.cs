using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_MathiasS_Act1._2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            {
                btn0.Click += new RoutedEventHandler(Zero);
                btn1.Click += new RoutedEventHandler(Un);
                btn2.Click += new RoutedEventHandler(Deux);
                btn3.Click += new RoutedEventHandler(Trois);
                btn4.Click += new RoutedEventHandler(Quatre);
                btn5.Click += new RoutedEventHandler(Cinq);
                btn6.Click += new RoutedEventHandler(Six);
                btn7.Click += new RoutedEventHandler(Sept);
                btn8.Click += new RoutedEventHandler(Huit);
                btn9.Click += new RoutedEventHandler(Neuf);
                btnC.Click += new RoutedEventHandler(Clear);
                btnP.Click += new RoutedEventHandler(Addition);
                btnM.Click += new RoutedEventHandler(Soustraction);
                btnF.Click += new RoutedEventHandler(Multiplication);
                btnD.Click += new RoutedEventHandler(Division);
                btnV.Click += new RoutedEventHandler(Virgule);
                btnE.Click += new RoutedEventHandler(Result);
            }
        }
        public void Addition(object sender, RoutedEventArgs e)
        {
            if (affichage.Text.Length != 0)
            {
                if (affichage.Text[^1] != ' ' && affichage.Text[^1] != '.')
                {
                    affichage.Text += " + ";
                }

            }
        }
        public void Soustraction(object sender, RoutedEventArgs e)
        {
            if (affichage.Text.Length != 0)
            {
                if (affichage.Text[^1] != ' ' && affichage.Text[^1] != '.')
                {
                    affichage.Text += " - ";
                }

            }
        }
        public void Multiplication(object sender, RoutedEventArgs e)
        {
            if (affichage.Text.Length != 0)
            {
                if (affichage.Text[^1] != ' ' && affichage.Text[^1] != '.')
                {
                    affichage.Text += " * ";
                }

            }
        }
        public void Division(object sender, RoutedEventArgs e)
        {
            if (affichage.Text.Length != 0)
            {
                if (affichage.Text[^1] != ' ' && affichage.Text[^1] != '.')
                {
                    affichage.Text += " / ";
                }

            }
        }
        public void Zero(object sender, RoutedEventArgs e) => affichage.Text += "0";
        public void Un(object sender, RoutedEventArgs e) => affichage.Text += "1";
        public void Deux(object sender, RoutedEventArgs e) => affichage.Text += "2";
        public void Trois(object sender, RoutedEventArgs e) => affichage.Text += "3";
        public void Quatre(object sender, RoutedEventArgs e) => affichage.Text += "4";
        public void Cinq(object sender, RoutedEventArgs e) => affichage.Text += "5";
        public void Six(object sender, RoutedEventArgs e) => affichage.Text += "6";
        public void Sept(object sender, RoutedEventArgs e) => affichage.Text += "7";
        public void Huit(object sender, RoutedEventArgs e) => affichage.Text += "8";
        public void Neuf(object sender, RoutedEventArgs e) => affichage.Text += "9";
        public void Clear(object sender, RoutedEventArgs e) => affichage.Text = "";
        public void Virgule(object sender, RoutedEventArgs e)
        {
            if (affichage.Text.Length != 0)
            {
                if (affichage.Text[^1] != ' ' && affichage.Text[^1] != ',')
                {
                    string[] numbers = affichage.Text.Split(' ');
                    string number = numbers[^1];
                    string[] decimalPart = number.Split(',');
                    if (decimalPart.Length == 1)
                    {
                        affichage.Text += ",";
                    }
                }
            }
        }

        public void Result(object sender, RoutedEventArgs e) 
        {
            if (affichage.Text.Length != 0)
            {
                if (affichage.Text[^1] != ' ' && affichage.Text[^1] != '.')
                {
                    string[] numbers = affichage.Text.Split(' ');
                    string number = numbers[0];
                    for (int i = 1; i < numbers.Length; i+=2)
                    {
                        switch (numbers[i])
                        {
                            case "+":
                                number = (double.Parse(number) + double.Parse(numbers[i + 1])).ToString();
                                break;
                            case "-":
                                number = (double.Parse(number) - double.Parse(numbers[i + 1])).ToString();
                                break;
                            case "*":
                                number = (double.Parse(number) * double.Parse(numbers[i + 1])).ToString();
                                break;
                            case "/":
                                number = ((Math.Round((double.Parse(number) / double.Parse(numbers[i + 1]))*10000))/10000).ToString();
                                break;
                            default:
                                break;
                        }
                    }
                    affichage.Text = number;
                }
            }
        }
    }
}
