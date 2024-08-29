using System;

namespace ACT00_REVISION
{
    class Program
    {
        static void Main(string[] args)
        {
            // déclaration des variables.... COMPLETER AVEC CE QUI MANQUE

            string rep;
            
            double c1 = 0;
            double c2 = 0;
            double c3 = 0;
            bool ok = false;
            string infos;
            MethodesDuProjet mdp = new MethodesDuProjet();

            Console.WriteLine("Testez les polygones !");
            //On recommence tant que désiré
            do
            {
                c1 = lireDouble(1);
                c2 = lireDouble(2);
                c3 = lireDouble(3);

                mdp.OrdonneCotes(ref c1, ref c2, ref c3);
                // série de test
                if (mdp.Triangle(c1,c2,c3))
                {
                    mdp.Affiche("triangle", true, out infos);
                    Console.WriteLine(infos);

                    // vérification équilatéral
                    if (mdp.Equi(c1, c2, c3))
                    {
                        mdp.Affiche("equilateral", true, out infos);
                        Console.WriteLine(infos);
                    }
                    else
                    {
                        // vérification triangle rectangle
                        if (mdp.TriangleRectangle(c1, c2, c3))
                        {
                            mdp.Affiche("rectangle", true, out infos);
                            Console.WriteLine(infos);
                        }
                        else
                        {
                            mdp.Affiche("rectangle", false, out infos);
                            Console.WriteLine(infos);
                        }
                        // vérification du cas isocèle et affichage dans le cas positif
                        mdp.Isocele(c1, c2, c3, out ok);
                        if (ok)
                        {
                            mdp.Affiche("isocele", true, out infos);
                            Console.WriteLine(infos);
                        }

                    }
                }
                else // si ce n'est pas un triangle
                {
                    mdp.Affiche("triangle", false, out infos);
                    Console.WriteLine(infos);
                }
                // reprise ?
                Console.WriteLine("Voulez-vous tester un autre polygône ? (Tapez entrer)");
                rep = Console.ReadLine();
            } while (rep == "");
        }
        //Récupération d'une donnée fournie par l'utilisateur en 'double' : on suppose qu'il ne se trompe pas !
        static double lireDouble(int numeroCote)
        {
            double cote;
            Console.Write("Tapez la valeur du côté " + numeroCote + " : ");
            cote = double.Parse(Console.ReadLine());
            return cote;
        }
    }
}
