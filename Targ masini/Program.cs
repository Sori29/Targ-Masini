using System;
using System.Configuration;
using System.IO;
using Librarie;
using NivelStocareDate;
using static Librarie.Enumerari;
using System.Globalization;
using System.Threading;

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
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;
            AdministareMasini_FisierTxt adminMasini = new AdministareMasini_FisierTxt(caleCompletaFisier);
            Masina masinaNoua = new Masina();
            int nrMasini = 0;
            adminMasini.GetMasini(out nrMasini);
            CultureInfo originalCulture = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("ro-RO");
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
            
            string infoStudent = string.Format("<-------------Masina cu id-ul #{0}------------->\nFirma: {1}\tModel: {2}\tAn fabricatie: {3}\tCuloare: {4}\tOptiuni: {5}\nNume vanzator: {6}\tNume cumparator: {7}\tData tranzactie: {8}\tPret: {9}",
                   masina.IDMasina,
                   masina.numeFirma ?? " NECUNOSCUT ",
                   masina.model ?? " NECUNOSCUT ",
                   masina.an,
                   masina.culoare ?? " NECUNOSCUT ",
                   masina.optiuni ?? " NECUNOSCUT ",
                   masina.numeVanzator ?? "NECUNOSCUT",
                   masina.numeCumparator ?? "NECUNOSCUT",
                   masina.dataTranzactie.Value.ToShortDateString(),
                   masina.pret + " RON");

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
            uint an = UInt32.Parse(Console.ReadLine());

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
                culoare = culoare + (Enumerari.Culoare)nr;
            else
            {
                while (nr < 0 || nr > 8)
                {
                    Console.WriteLine("Optiune inexistenta, introduceti alta valoare (1-8):");
                    nr = Int32.Parse(Console.ReadLine());
                }
                culoare = culoare + (Enumerari.Culoare)nr;
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
                    optiuni = optiuni + (Enumerari.Optiuni)optiune+", ";
            }
            Console.WriteLine("Introduceti nume vanzator:"); string numeVanzator = Console.ReadLine();
            Console.WriteLine("\nIntroduceti nume cumparator:"); string numeCumparator = Console.ReadLine();
            int[] data_tranzactie=new int[2];
            int OK = 1;
            Console.WriteLine("Introduceti data tranzactie in formatul (zz/mm/yyyy):");
            string data_citita = Console.ReadLine();
            DateTime datatranzactie;
            string pattern = "dd-MM-yyyy";
            while(true)
            {
                if (DateTime.TryParseExact(data_citita,pattern,null,DateTimeStyles.None,out datatranzactie))
                {
                    Console.WriteLine("Data citita este invalida, introduceti din nou");
                    data_citita = Console.ReadLine();
                }
                else
                {
                    datatranzactie = Convert.ToDateTime(data_citita);
                    break;
                }
            }
            Console.WriteLine("Introduceti pret (RON):"); uint pret=Convert.ToUInt32(Console.ReadLine());

            Masina masina = new Masina(0, nume, model, an, culoare, optiuni,numeVanzator,numeCumparator,datatranzactie,pret);
            return masina;
        }
    }
}

