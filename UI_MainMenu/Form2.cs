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
            if (dataInceput.Value > dataSfarsit.Value)
            {
                MessageBox.Show("Perioada inceputa nu poate sa fie mai mare decat perioada sfarsit","Introducere invalida",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            if(txtGraphModel.Text == String.Empty)
            {
                MessageBox.Show("Introducerea modelului este invalida, introduceti din nou", "Introducere invalida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if(txtGraphModel.Text!=String.Empty && dataInceput.Value<=dataSfarsit.Value)
            {
                int contor = 0;
                Masina[] masini = adminMasini.GetMasini(out int nrMasini);
                DateTime[] date = new DateTime[nrMasini];
                string[] modele=new string[nrMasini];
                uint[] pret = new uint[nrMasini];
                int i = 0;
                int j;
                foreach (Masina masina in masini)
                {
                    if (masina == null)
                    {
                        break;
                    }
                    else
                    {
                        date[contor] = masina.dataTranzactie.Value;
                        modele[contor]=masina.model;
                        pret[contor] = masina.pret;
                        contor++;
                    }
                }
                while(i<contor) //eliminare modele necorespunzatoare
                {
                    while(modele[i]!=txtGraphModel.Text)
                    {
                        for(j=i;j<contor-1; j++)
                        {
                            date[j] = date[j + 1];
                            modele[j] = modele[j + 1];
                            pret[j] = pret[j + 1];
                        }
                        if (contor <= i)
                            break;
                        contor--;

                    }
                    i++;
                }
                i = 0;
                while(i<contor)//verificare date in intervalul definit
                {
                    while(date[i].CompareTo(dataInceput.Value)<0 || date[i].CompareTo(dataSfarsit.Value)>0)
                    {
                        for (j = i; j < contor-1; j++)
                        {
                            date[j] = date[j + 1];
                            modele[j] = modele[j + 1];
                            pret[j] = pret[j + 1];
                        }
                        contor--;
                        if (contor <= i)
                            break;
                    }
                    i++;
                }
                if (contor == 0)
                {
                    MessageBox.Show("Cautarea selectata nu a returnat o valoare","Eroare cautare",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                else
                {
                    for (i = 0; i < contor; i++)
                        grafPret.Series["Preturi"].Points.AddXY(date[i].ToShortDateString(),pret[i].ToString()); //adaugare puncte
                    grafPret.Visible = true;
                    btnInapoiGraph.Visible = true;
                }
                            
            }
            
        }

        private void btnInapoiGraph_Click(object sender, EventArgs e)
        {
            grafPret.Visible = false;
            grafPret.Series.Clear();
            grafPret.Series.Add("Preturi");
            btnInapoiGraph.Visible = false;
        }
    }
}
