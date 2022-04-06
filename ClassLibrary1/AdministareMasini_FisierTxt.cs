using Librarie;
using System.IO;

namespace NivelStocareDate
{
    public class AdministareMasini_FisierTxt
    {
        private const int NR_MAX_MASINI = 50;
        private string numeFisier;

        public AdministareMasini_FisierTxt(string numeFisier)
        {
            this.numeFisier = numeFisier;
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }
        public void AddMasina(Masina masina)
        {
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true))
            {
                streamWriterFisierText.WriteLine(masina.ConversieLaSir_PentruFisier());
            }
        }
        public Masina[] GetMasini(out int nrMasini)
        {
            Masina[] masini = new Masina[NR_MAX_MASINI];

            // instructiunea 'using' va apela streamReader.Close()
            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                nrMasini = 0;
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    masini[nrMasini++] = new Masina(linieFisier);
                }
            }

            return masini;
        }
    }
}