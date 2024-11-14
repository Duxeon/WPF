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
using Methode;
namespace UAA14_I4_MathiasS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            btnCalculer.Click += new RoutedEventHandler(Calc);
            btnReset.Click += new RoutedEventHandler(Reset);
            txtNombre1.KeyDown += new KeyEventHandler(detect);
            txtNombre1.KeyUp += new KeyEventHandler(detect);
        }
        public void detect(object sender, KeyEventArgs e)
        {
            antiError(txtNombre1);
            antiError(txtNombre2);
        }
        public void antiError(TextBox sender)
        {
            bool ok = true;
            for (int i = 0; i < sender.Text.Length; i++)
            {
                if (sender.Text[i] != '0' && sender.Text[i] != '1')
                {
                    sender.Text = sender.Text.Remove(i);
                }
            }
        }
        public void Calc(object sender, RoutedEventArgs e)
        {
            ushort[] tRes = new ushort[7];
            txtResultat.Text = "Error";
            if (!(txtNombre1.Text == "" || txtNombre2.Text == "" || txtNombre1.Text.Length > 7 || txtNombre2.Text.Length > 7))
            {
                ushort[] t1 = RemplirTableau(txtNombre1.Text);
                ushort[] t2 = RemplirTableau(txtNombre2.Text);
                if (optAddition.IsEnabled)
                {
                    Additionne(t1, t2, out tRes, out bool ok);
                    if (ok)
                    {
                        txtResultat.Text = Concatene(tRes);
                    } 
                }
                else if (optSoustraction.IsEnabled)
                {
                    if (Soustrait(t1 ,t2 , out tRes))
                    {
                        txtResultat.Text = Concatene(tRes);
                    }
                }
            }
        }
        public void Reset(object sender, RoutedEventArgs e)
        {
            txtResultat.Text = "";
            txtNombre1.Text = "";
            txtNombre2.Text = "";
            optAddition.IsEnabled = true;
            optSoustraction.IsEnabled = false;
        }
        public ushort[] RemplirTableau(string nombreBinaire)
        {
            ushort[] TabBin = new ushort[8];
            for (int i = 0; i < TabBin.Length; i++)
            {
                TabBin[i] = 0;
            }
            for (int i = 0; i < nombreBinaire.Length; i++)
            {
                TabBin[7 - i] = ushort.Parse(nombreBinaire[nombreBinaire.Length - 1 - i].ToString());
            }
            return TabBin;
        }
        public void Additionne(ushort[] t1, ushort[] t2, out ushort[] tRes, out bool ok)
        {
            ok = true;
            ushort report = 0;
            ushort res;
            tRes = new ushort[8];
            for (int i = 7; i >= 0; i--)
            {
                res = (ushort)(t1[i] + t2[i] + report);
                if ((int)(res / 2) == 0)
                {
                    report = 0;
                }
                else
                {
                    report = 1;
                }
                if (res == 1)
                {
                    tRes[i] = 1;
                }
                else
                {
                    if (res % 2 == 1)
                    {
                        tRes[i] = 1;
                    }
                    else
                    {
                        tRes[i] = 0;
                    }
                }

            }
            if (report == 1)
            {
                ok = false;
            }
        }
        public bool Soustrait(ushort[] t1, ushort[] t2, out ushort[] tRes)
        {
            int[] tTemp = new int[8];
            tRes = new ushort[8];
            bool ok = true;

            for (int i = 0; i <= 7; i++)
            {
                tTemp[i] = t1[i] - t2[i];
            }
            for (int i = 7; i >= 1; i--)
            {
                if (tTemp[i] == -1)
                {
                    t2[i - 1] = (ushort)(t2[i - 1] + 1);
                    t1[i] = (ushort)(t1[i] + 2);
                }
                if (t1[i] < t2[i])
                {
                    t2[i - 1] = (ushort)(t2[i - 1] + 1);
                    t1[i] = (ushort)(t1[i] + 2);
                }
                tRes[i] = (ushort)(t1[i] - t2[i]);
            }
            if (t1[0] >= t2[0])
            {
                tRes[0] = (ushort)(t1[0] - t2[0]);
            }
            else
            {
                ok = false;
            }
            return ok;
        }
        public string Concatene(ushort[] t)
        {
            string chaine = "";
            for (int i = 0; i < t.Length; i++)
            {
                chaine += t[i];
            }
            return chaine;
        }
    }
}