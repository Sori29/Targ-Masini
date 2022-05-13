﻿using System;
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

        public int IDMasina { get; set; }
        public string numeFirma { get; set; }
        public string model { get; set; }
        public int an { get; set; }
        public string culoare { get; set; }
        public string optiuni { get; set; }

        public Masina()
        {
            numeFirma = model = culoare = optiuni = string.Empty;
            an = 0;
        }

        public Masina(int IDMasina, string numeFirma, string model, int an, string culoare, string optiuni)
        {
            this.IDMasina = IDMasina;
            this.numeFirma = numeFirma;
            this.model = model;
            this.an = an;
            this.culoare = culoare;
            this.optiuni = optiuni;
        }

        public Masina(string linieFisier)
        {
            var dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);

            //ordinea de preluare a campurilor este data de ordinea in care au fost scrise in fisier prin apelul implicit al metodei ConversieLaSir_PentruFisier()
            IDMasina = Convert.ToInt32(dateFisier[IDMASINA]);
            numeFirma = dateFisier[NUMEFIRMA];
            model = dateFisier[MODEL];
            an = Convert.ToInt32(dateFisier[AN]);
            culoare = dateFisier[CULOARE];
            optiuni = dateFisier[OPTIUNI];

        }

        public string ConversieLaSir_PentruFisier()
        {
            string obiectMasinaPentruFisier = string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}",
                SEPARATOR_PRINCIPAL_FISIER,
                IDMasina.ToString(),
                (numeFirma ?? " NECUNOSCUT "),
                (model ?? " NECUNOSCUT "),
                an.ToString(),
                (culoare ?? "NECUNOSCUT"),
                (optiuni ?? "NECUNOSCUT"));

            return obiectMasinaPentruFisier;
        }

    }
}