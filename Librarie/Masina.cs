using System;
using System.Linq;
using static Librarie.Enumerari;
namespace Librarie
{
    public class Masina
    {
        
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';

        private const int IDMASINA = 0;
        private const int NUMEFIRMA = 1;
        private const int MODEL = 2;
        private const int AN = 3;
        private const int CULOARE = 4;
        private const int OPTIUNI = 5;
        private const int NUMEVANZATOR = 6;
        private const int NUMECUMPARATOR = 7;
        private const int DATATRANZACTIE = 8;
        private const int PRET = 9;

        public int IDMasina { get; set; }
        public string numeFirma { get; set; }
        public string model { get; set; }
        public uint an { get; set; }
        public string culoare { get; set; }
        public string optiuni { get; set; }

        public string numeVanzator { get; set; }
        public string numeCumparator { get;set; }
        public DateTime? dataTranzactie { get; set; }
        public uint pret { get; set; }
        public Masina()
        {
            numeFirma = model = culoare = optiuni = numeCumparator = numeVanzator = string.Empty;
            an = pret = 0;
            dataTranzactie = null;

        }

        public Masina(int IDMasina, string numeFirma, string model, uint an, string culoare, string optiuni,string numeVanzator, string NumeCumparator,DateTime dataTranzactie,uint pret)
        {
            this.IDMasina = IDMasina;
            this.numeFirma = numeFirma;
            this.model = model;
            this.an = an;
            this.culoare = culoare;
            this.optiuni = optiuni;
            this.numeVanzator=numeVanzator;
            this.numeCumparator = NumeCumparator;
            this.dataTranzactie = dataTranzactie;
            this.pret= pret;
        }

        public Masina(string linieFisier)
        {
            var dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);

            //ordinea de preluare a campurilor este data de ordinea in care au fost scrise in fisier prin apelul implicit al metodei ConversieLaSir_PentruFisier()
            IDMasina = Convert.ToInt32(dateFisier[IDMASINA]);
            numeFirma = dateFisier[NUMEFIRMA];
            model = dateFisier[MODEL];
            an = Convert.ToUInt32(dateFisier[AN]);
            culoare = dateFisier[CULOARE];
            optiuni = dateFisier[OPTIUNI];
            numeVanzator = dateFisier[NUMEVANZATOR];
            numeCumparator = dateFisier[NUMECUMPARATOR];
            dataTranzactie = Convert.ToDateTime(dateFisier[DATATRANZACTIE]);
            pret = Convert.ToUInt32(dateFisier[PRET]);

        }

        public string ConversieLaSir_PentruFisier()
        {
            string obiectMasinaPentruFisier = string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}{0}{8}{0}{9}{0}{10}{0}",
                SEPARATOR_PRINCIPAL_FISIER,
                IDMasina.ToString(),
                (numeFirma ?? " NECUNOSCUT "),
                (model ?? " NECUNOSCUT "),
                an.ToString(),
                (culoare ?? "NECUNOSCUT"),
                (optiuni ?? "NECUNOSCUT"),
                (numeVanzator ?? "NECUNOSCUT"),
                (numeCumparator ?? "NECUNOSCUT"),
                (dataTranzactie.ToString()),
                pret.ToString());

            return obiectMasinaPentruFisier;
        }

    }
}