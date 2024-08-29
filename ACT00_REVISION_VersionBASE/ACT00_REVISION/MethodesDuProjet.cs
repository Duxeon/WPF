using System;
using System.Collections.Generic;
using System.Text;

namespace ACT00_REVISION
{ // écrire les signatures des procédures et fonctions...
    class MethodesDuProjet
    {
        public void Affiche(string methode, bool ok, out string infos)
        {
            string verbe;
            infos = "";
            // mémorisation du verbe 'est' ou 'n'est pas' pour former la bonne phrase en fonction d'un booléen passé en paramètre
            if (ok)
            {
                verbe = " est ";
            }
            else
            {
                verbe = " n'est pas ";
            }
            // selon la méthode, on prépare la bonne phrase.
            switch (methode)
            {
                case "triangle":
                    infos = "le polygone" + verbe + "un triangle.";
                    break;
                case "equilateral":
                    infos = "le polygone" + verbe + "un triangle equilateral.";
                    break;
                case "isocele":
                    infos = "le polygone" + verbe + "un triangle isocele.";
                    break;
                case "rectangle":
                    infos = "le polygone" + verbe + "un triangle rectangle.";
                    break;
                default:
                    break;
            }
        }

        public double Hypo(double x, double y)
        {
            double z = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
            return z;
        }

        public bool TriangleRectangle(double a, double b, double c)
        {
            bool ok = false;
            double hypothenuse = Hypo(b, c);
            if (a == hypothenuse)
            {
                ok = true;
            }
            return ok;
        }

        public void OrdonneCotes(ref double a, ref double b, ref double c)
        {
            double temp;

            if ((b >= a) && (b >= c))
            {
                temp = a;
                a = b;
                b = temp;
            }
            else if ((c >= a) && (c >= b))
            {
                temp = a;
                a = c;
                c = temp;
            }
        }

        public bool Triangle(double a, double b, double c)
        {
            bool ok = false;

            OrdonneCotes(ref a, ref b, ref c);

            if (a <= (b + c))
            {
                ok = true;
            }
            return ok;
        }
        // procédure qui détermine si un triangle est isocèle ou non sur base des longueurs de côtés
        public void Isocele(double a, double b, double c, out bool ok)
        {
            ok = false;
            if ((a == b) ^ (a == c) ^ (b == c))   // '^' est le 'ou' exclusif (xor)
            {
                ok = true;
            }
        }
        // fonction booléenne qui détermine si un triangle est équilatéral sur base de ses côtés
        public bool Equi(double a, double b, double c) // nommée Equi
        {
            bool ok = false;
            if ((a == b) && (a == c))
            {
                ok = true;
            }
            return ok;
        }
    }
}
