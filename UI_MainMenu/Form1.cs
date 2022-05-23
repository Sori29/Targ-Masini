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

        private Label lblNumeFirma;
        private Label lblNumeModel;
        private Label lblAn;
        private Label lblCuloare;
        private Label lblOptiuni;

        private Label[] lblsNumeFirma;
        private Label[] lblsNumeModel;
        private Label[] lblsAn;
        private Label[] lblsCuloare;
        private Label[] lblsOptiuni;

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
            this.Text = "Informatii masini";

            lbleroare = new Label();
            lbleroare.Width = 4 * LATIME_CONTROL;
            lbleroare.Top = 11 * DIMENSIUNE_PAS_Y;
            lbleroare.Left = 70;
            lbleroare.ForeColor = Color.Red;


        }
        private void AfiseazaMasini()
        {
            Masina[] masini = adminMasini.GetMasini(out int nrMasini);
            //adaugare control de tip Label pentru 'NumeFirma';
            lblNumeFirma = new Label();
            lblNumeFirma.Width = LATIME_CONTROL;
            lblNumeFirma.Text = "Nume firma";
            lblNumeFirma.Left = OFFSET;
            lblNumeFirma.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblNumeFirma);

            //adaugare control de tip Label pentru 'NumeModel';
            lblNumeModel = new Label();
            lblNumeModel.Width = LATIME_CONTROL;
            lblNumeModel.Text = "Nume model";
            lblNumeModel.Left = DIMENSIUNE_PAS_X + OFFSET;
            lblNumeModel.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblNumeModel);

            //adaugare control de tip Label pentru 'An';
            lblAn = new Label();
            lblAn.Width = LATIME_CONTROL;
            lblAn.Text = "An fabricatie";
            lblAn.Left = 2 * DIMENSIUNE_PAS_X + OFFSET;
            lblAn.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblAn);

            //adaugare control de tip Label pentru 'Culoare';
            lblCuloare = new Label();
            lblCuloare.Width = LATIME_CONTROL;
            lblCuloare.Text = "Culoare";
            lblCuloare.Left = 3 * DIMENSIUNE_PAS_X + OFFSET;
            lblCuloare.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblCuloare);

            //adaugare control de tip Label pentru 'Optiuni';
            lblOptiuni = new Label();
            lblOptiuni.Width = LATIME_CONTROL;
            lblOptiuni.Text = "Optiuni";
            lblOptiuni.Left = 4 * DIMENSIUNE_PAS_X + OFFSET;
            lblOptiuni.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblOptiuni);
            lblsNumeFirma = new Label[nrMasini];
            lblsNumeModel = new Label[nrMasini];
            lblsAn = new Label[nrMasini];
            lblsCuloare = new Label[nrMasini];
            lblsOptiuni=new Label[nrMasini];

            int i = 0;
            foreach (Masina masina in masini)
            {
                if (masina == null)
                    break;
                //adaugare control de tip Label pentru numele firmelor;
                lblsNumeFirma[i] = new Label();
                lblsNumeFirma[i].Width = LATIME_CONTROL;
                lblsNumeFirma[i].Text = masina.numeFirma;
                lblsNumeFirma[i].Left = OFFSET;
                lblsNumeFirma[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsNumeFirma[i]);

                //adaugare control de tip Label pentru numele modelelor;
                lblsNumeModel[i] = new Label();
                lblsNumeModel[i].Width = LATIME_CONTROL;
                lblsNumeModel[i].Text = masina.model;
                lblsNumeModel[i].Left = DIMENSIUNE_PAS_X + OFFSET;
                lblsNumeModel[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsNumeModel[i]);

                //adaugare control de tip Label pentru anul masinilor;
                lblsAn[i] = new Label();
                lblsAn[i].Width = LATIME_CONTROL;
                lblsAn[i].Text = masina.an.ToString();
                lblsAn[i].Left = 2 * DIMENSIUNE_PAS_X + OFFSET;
                lblsAn[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsAn[i]);

                //adaugare control de tip Label pentru Culoare masinilor;
                lblsCuloare[i] = new Label();
                lblsCuloare[i].Width = LATIME_CONTROL;
                lblsCuloare[i].Text = masina.culoare;
                lblsCuloare[i].Left = 3 * DIMENSIUNE_PAS_X + OFFSET;
                lblsCuloare[i].Top = (i+1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsCuloare[i]);

                //adaugare control de tip Label pentru Optiunile masinilor;
                lblsOptiuni[i] = new Label();
                lblsOptiuni[i].Width = 5 * LATIME_CONTROL;
                lblsOptiuni[i].Text = masina.optiuni;
                lblsOptiuni[i].Left = 4 * DIMENSIUNE_PAS_X + OFFSET;
                lblsOptiuni[i].Top = (i+1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsOptiuni[i]);
                i++;
            }
        }
        private void Golire_casutetxt()
        {
            txtNumeFirma.Text = String.Empty;
            txtNumeModel.Text = String.Empty;
            txtAn.Text = String.Empty;
            txtCuloare.Text = String.Empty;
            txtOptiuni.Text = String.Empty;
        }
        private void btnAdauga_Click(object sender, EventArgs e)
        {
            Masina[] masini = adminMasini.GetMasini(out int nrMasini);
            if (txtNumeFirma.Text == String.Empty || txtNumeModel.Text == string.Empty || txtAn.Text == string.Empty || txtCuloare.Text == string.Empty || txtOptiuni.Text == string.Empty)
            {
                lbleroare.Text = "O casuta completata este goala, introduceti din nou";
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
                int an = Int32.Parse(txtAn.Text);
                string culoare = txtCuloare.Text;
                string optiuni = txtOptiuni.Text;
                Masina masina = new Masina(nrMasini + 1, firma, model, an, culoare, optiuni);
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
    }
}
