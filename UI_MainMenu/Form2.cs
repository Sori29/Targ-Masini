using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using Librarie;
using NivelStocareDate;
using static Librarie.Enumerari;

namespace UI_MainMenu
{
    public partial class Form2 : Form
    {
        static string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
        static string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        static string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;
        AdministareMasini_FisierTxt adminMasini = new AdministareMasini_FisierTxt(caleCompletaFisier);
        DataTable dateTabel;
        public Form2()
        {
            InitializeComponent();

        }

        public Form2(DataTable Tabelprimit)
        {
            InitializeComponent();
            dateTabel = Tabelprimit;
        }
        private void btnGrafic_Click(object sender, EventArgs e)
        {
            int contor = 0;
            Masina[] masini = adminMasini.GetMasini(out int nrMasini);
            DateTime[] date = new DateTime[nrMasini];
            string[] modele=new string[nrMasini];
            uint[] pret = new uint[nrMasini];
            foreach (Masina masina in masini)
            {
                if (masina == null)
                {
                    break;
                }
                else
                {
                    date[contor] = masina.dataTranzactie.Value;
                    modele[contor]=masina.model.ToString();
                    pret[contor] = masina.pret;
                    contor++;
                }
            }
            for(int i = 0; i <= contor; i++) //eliminare modele necorespunzatoare
            {
                if(modele[i]!=txtGraphModel.Text)
                {
                    if(i==contor)
                    {
                        contor--;
                    }
                    else
                    {
                        for(int poz = i; poz < contor-1; poz++)
                        {
                            modele[poz] = modele[poz + 1];
                            date[poz] = date[poz + 1];
                            pret[poz] = pret[poz + 1];
                        }
                        contor--;
                    }
                }
            }
            for (int i=0; i<=contor; i++)//verificare date in intervalul definit
            {
                if(date[i]<dataInceput.Value || date[i] > dataSfarsit.Value)
                {
                    if (i != contor)
                    {
                            for (int poz = i; poz <= contor; poz++)
                            {
                                modele[i] = modele[i + 1];
                                date[i] = date[i + 1];
                                pret[i] = pret[i + 1];
                            }
                    }
                    contor--;
                }
            }
            for (int i = 0; i < contor; i++)
                grafPret.Series["Preturi"].Points.AddXY(date[i].ToShortDateString(),pret[i].ToString()); //adaugare puncte
            grafPret.Visible = true;
        }
        
    }
}
