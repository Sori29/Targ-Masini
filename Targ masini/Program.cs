using System;
using System.Configuration;
using Librarie;
using NivelStocareDate;

namespace EvidentaStudenti
{
    class Program
    {
        static void Main(string[] args)
        {
            string numeFisier;
            if (args.Length == 0)
            {
                Console.Write("Linia de comanda nu contine argumente\n");
                numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            }
            else
            {
                numeFisier = args[0];
            }
            AdministareMasini_FisierTxt adminMasini = new AdministareMasini_FisierTxt(numeFisier);
            Masina masinaNoua = new Masina();
            int nrMasini = 0;
            adminMasini.GetMasini(out nrMasini);

            string optiune;
            do
            {
                Console.WriteLine("C. Citire informatii masina de la tastatura");
                Console.WriteLine("A. Afisarea ultimei masini introduse");
                Console.WriteLine("F. Afisare masini din fisier");
                Console.WriteLine("S. Salvare masina in fisier");
                Console.WriteLine("X. Inchidere program");
                Console.WriteLine("Alegeti o optiune");
                optiune = Console.ReadLine();
                switch (optiune.ToUpper())
                {
                    case "C":
                        masinaNoua = CitireMasinaTastatura();

                        break;
                    case "A":
                        AfisareMasina(masinaNoua);

                        break;
                    case "F":
                        Masina[] masini = adminMasini.GetMasini(out nrMasini);
                        AfisareMasini(masini, nrMasini);

                        break;
                    case "S":
                        int idMasina = nrMasini + 1;
                        masinaNoua.IDMasina=idMasina;
                        //adaugare masina in fisier
                        adminMasini.AddMasina(masinaNoua);
                        nrMasini = nrMasini + 1;

                        break;
                    case "X":
                        return;
                    default:
                        Console.WriteLine("Optiune inexistenta");
                        break;
                }
            } while (optiune.ToUpper() != "X");

            Console.ReadKey();
        }

        public static void AfisareMasina(Masina masina)
        {

            string infoStudent = string.Format("<-------------Masina cu id-ul #{0}------------->\nFirma: {1}\tModel: {2}\tAn fabricatie: {3}\tCuloare: {4}\tOptiuni: {5}",
                   masina.IDMasina,
                   masina.numeFirma ?? " NECUNOSCUT ",
                   masina.model ?? " NECUNOSCUT ",
                   masina.an,
                   masina.culoare ?? " NECUNOSCUT ",
                   masina.optiuni ?? " NECUNOSCUT ");

            Console.WriteLine(infoStudent);
        }

        public static void AfisareMasini(Masina[] masini, int nrMasini)
        {
            Console.WriteLine("Masinile sunt:");
            for (int contor = 0; contor < nrMasini; contor++)
            {
                AfisareMasina(masini[contor]);
            }
        }

        public static Masina CitireMasinaTastatura()
        {
            Console.WriteLine("Introduceti nume firma:");
            string nume = Console.ReadLine();

            Console.WriteLine("Introduceti numele modelului:");
            string model = Console.ReadLine();

            Console.WriteLine("Introduceti an fabricatie:");
            int an = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Introduceti culoare:" +
                "\n1. Alb" +
                "\n2. Negru" +
                "\n3. Galben" +
                "\n4. Portocaliu" +
                "\n5. Gri" +
                "\n6. Rosu" +
                "\n7. Verde" +
                "\n8. Albastru");
            int nr = Int32.Parse(Console.ReadLine());
            string culoare = string.Empty;
            if (nr >= 1 && nr < 9)
                culoare = culoare + (Masina.Culoare)nr;
            else
            {
                while (nr < 0 || nr > 8)
                {
                    Console.WriteLine("Optiune inexistenta, introduceti alta valoare (1-8):");
                    nr = Int32.Parse(Console.ReadLine());
                }
                culoare = culoare + (Masina.Culoare)nr;
            }
            Console.WriteLine("Introduceti dotari:" +
                "\n1. Aer Conditionat" +
                "\n2. Navigatie" +
                "\n3. Cutie automata" +
                "\n4. Cutie manuala" +
                "\n5. ABS" +
                "\n6. ESP" +
                "\n7. Airbaguri" +
                "\n8. Camera bord" +
                "\n9. Avertizor centura de siguranta" +
                "\n10. Sistem audio radio" +
                "\n11. Mufa auxiliara" +
                "\n12. Tapiterie piele" +
                "\n13. Tapiterie textila" +
                "\n14. Volan incalzit" +
                "\n15. Geamuri electrice" +
                "\n16.Trapa electrica");
            string sir=Console.ReadLine();
            string[] sir_optiuni = sir.Split(' ');
            string optiuni=String.Empty;
            for (int contor = 0; contor < sir_optiuni.Length; contor++)
            {
                int optiune=Int32.Parse(sir_optiuni[contor]);
                if(optiune >= 17 || optiune <1)
                    contor++;
                else 
                    optiuni = optiuni + (Masina.Optiuni)optiune+", ";
            }
            Masina masina = new Masina(0, nume, model, an, culoare, optiuni);
            return masina;
        }
    }
}

