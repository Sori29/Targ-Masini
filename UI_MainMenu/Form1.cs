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
    public partial class Form1 : Form
    {
        static string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
        static string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        static string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;
        AdministareMasini_FisierTxt adminMasini = new AdministareMasini_FisierTxt(caleCompletaFisier);


        private Label lbleroare;

        private const int LATIME_CONTROL = 100;
        private const int OFFSET = 500;
        private const int DIMENSIUNE_PAS_Y = 30;
        private const int DIMENSIUNE_PAS_X = 150;
        public Form1()
        {
            InitializeComponent();
            Masina[] masini = adminMasini.GetMasini(out int nrMasini);

            //setare proprietati
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 100);
            this.Font = new Font("Arial", 9, FontStyle.Bold);
            this.ForeColor = Color.LimeGreen;
            this.Text = "Targ masini";

            lbleroare = new Label();
            lbleroare.Width = 4 * LATIME_CONTROL;
            lbleroare.Top = 11 * DIMENSIUNE_PAS_Y;
            lbleroare.Left = 70;
            lbleroare.ForeColor = Color.Red;

        }
        private void AfiseazaMasini()
        {
            Masina[] masini = adminMasini.GetMasini(out int nrMasini);
            int i = 0;
            foreach (Masina masina in masini)
            {
                if (masina == null)
                    break;
                else
                {
                        string[] rand = { masina.IDMasina.ToString(), masina.numeFirma , masina.model, masina.an.ToString(),
                                          masina.culoare, masina.numeVanzator, masina.numeCumparator, masina.dataTranzactie.Value.ToShortTimeString(),
                                          masina.pret.ToString(), masina.optiuni 
                                        };
                    dateMasini.Rows.Add(rand);
                }
            }
        }
        private void Golire_casutetxt()
        {
            txtNumeFirma.Text = String.Empty;
            txtNumeModel.Text = String.Empty;
            txtAn.Text = String.Empty;
            txtVanzator.Text=String.Empty;
            txtCumparator.Text=String.Empty;
            txtPret.Text=String.Empty;
        }
        private void btnAdauga_Click(object sender, EventArgs e)
        {
            Masina[] masini = adminMasini.GetMasini(out int nrMasini);
            if (txtNumeFirma.Text == String.Empty || txtNumeModel.Text == string.Empty || txtAn.Text == string.Empty || cmbCuloare.SelectedValue.ToString() == string.Empty || lstOptiuni.SelectedValue.ToString() == string.Empty || txtVanzator.Text == string.Empty || txtCumparator.Text==string.Empty || txtPret.Text==string.Empty)
            {
                lbleroare.Text = "O casuta completata sau selectata este goala, introduceti din nou";
                this.Controls.Add(lbleroare);
            }
            else if (txtAn.Text.Any(char.IsLetter))
            {
                lbleroare.Text = "Anul completat este invalid, introduceti din nou";
                lblnAn.ForeColor = Color.Red;
                this.Controls.Add(lbleroare);
            }
            else
            {
                lblnAn.ForeColor = Color.LimeGreen;
                lbleroare.Text = String.Empty;
                this.Controls.Add(lbleroare);
                string firma = txtNumeFirma.Text;
                string model = txtNumeModel.Text;
                uint an = UInt32.Parse(txtAn.Text);
                string culoare = cmbCuloare.SelectedText;
                string optiuni = lstOptiuni.SelectedValue.ToString();
                string nume_vanzator = txtVanzator.Text;
                string nume_cumparator = txtCumparator.Text;
                DateTime data = dataTranzactie.Value;
                uint pret=UInt32.Parse(txtPret.Text);
                Masina masina = new Masina(nrMasini + 1, firma, model, an, culoare, optiuni,nume_vanzator,nume_cumparator,data,pret);
                Golire_casutetxt();
                adminMasini.AddMasina(masina);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            AfiseazaMasini();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            AfiseazaMasini();
        }

        private void dateMasini_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
