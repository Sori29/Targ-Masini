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

namespace UI_MainMenu
{
    public partial class Form1 : Form
    {
        AdministareMasini_FisierTxt adminMasini;

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

        private Label lblnNumeFirma;
        private Label lblnNumeModel;
        private Label lblnAn;
        private Label lblnCuloare;
        private Label lblnOptiuni;

        private TextBox txtNume;
        private TextBox txtPrenume;
        private TextBox txtNote;

        private Button btnAdauga;
        private Button btnRefresh;

        private Label lbleroare;

        private const int LATIME_CONTROL = 100;
        private const int DIMENSIUNE_PAS_Y = 30;
        private const int DIMENSIUNE_PAS_X = 100;
        public Form1()
        {
            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;
            AdministareMasini_FisierTxt adminMasini = new AdministareMasini_FisierTxt(caleCompletaFisier);
            InitializeComponent();
            Masina[] masini = adminMasini.GetMasini(out int nrMasini);

            //setare proprietati
            this.Size = new Size(1000, 300);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(100, 100);
            this.Font = new Font("Arial", 9, FontStyle.Bold);
            this.ForeColor = Color.LimeGreen;
            this.Text = "Informatii masini";

            //adaugare control de tip Label pentru 'NumeFirma';
            lblNumeFirma = new Label();
            lblNumeFirma.Width = LATIME_CONTROL;
            lblNumeFirma.Text = "Nume firma";
            lblNumeFirma.Left = DIMENSIUNE_PAS_X;
            lblNumeFirma.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblNumeFirma);

            //adaugare control de tip Label pentru 'NumeModel';
            lblNumeModel = new Label();
            lblNumeModel.Width = LATIME_CONTROL;
            lblNumeModel.Text = "Nume model";
            lblNumeModel.Left = 2 * DIMENSIUNE_PAS_X;
            lblNumeModel.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblNumeModel);

            //adaugare control de tip Label pentru 'An';
            lblAn = new Label();
            lblAn.Width = LATIME_CONTROL;
            lblAn.Text = "An fabricatie";
            lblAn.Left = 3 * DIMENSIUNE_PAS_X;
            lblAn.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblAn);

            //adaugare control de tip Label pentru 'Culoare';
            lblCuloare = new Label();
            lblCuloare.Width = LATIME_CONTROL;
            lblCuloare.Text = "Culoare";
            lblCuloare.Left = 4 * DIMENSIUNE_PAS_X;
            lblCuloare.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblCuloare);

            //adaugare control de tip Label pentru 'Optiuni';
            lblOptiuni = new Label();
            lblOptiuni.Width = LATIME_CONTROL;
            lblOptiuni.Text = "Optiuni";
            lblOptiuni.Left = 5 * DIMENSIUNE_PAS_X;
            lblOptiuni.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblOptiuni);

            btnRefresh = new Button();
            btnRefresh.Width = LATIME_CONTROL;
            btnRefresh.Left = 7 * DIMENSIUNE_PAS_X;
            btnRefresh.Text = "Refresh";
            btnRefresh.Click += OnButtonClicked;
            this.Controls.Add(btnRefresh);
            //adaugare control de tip Label pentru 'Introducere date noi';

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            AfiseazaMasini();
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            AfiseazaMasini();
        }
        private void AfiseazaMasini()
        {
            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;
            AdministareMasini_FisierTxt adminMasini = new AdministareMasini_FisierTxt(caleCompletaFisier);
            Masina[] masini = adminMasini.GetMasini(out int nrMasini);

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
                lblsNumeFirma[i].Left = DIMENSIUNE_PAS_X;
                lblsNumeFirma[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsNumeFirma[i]);

                //adaugare control de tip Label pentru numele modelelor;
                lblsNumeModel[i] = new Label();
                lblsNumeModel[i].Width = LATIME_CONTROL;
                lblsNumeModel[i].Text = masina.model;
                lblsNumeModel[i].Left = 2 * DIMENSIUNE_PAS_X;
                lblsNumeModel[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsNumeModel[i]);

                //adaugare control de tip Label pentru anul masinilor;
                lblsAn[i] = new Label();
                lblsAn[i].Width = LATIME_CONTROL;
                lblsAn[i].Text = masina.an.ToString();
                lblsAn[i].Left = 3 * DIMENSIUNE_PAS_X;
                lblsAn[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsAn[i]);

                //adaugare control de tip Label pentru Culoare masinilor;
                lblsCuloare[i] = new Label();
                lblsCuloare[i].Width = LATIME_CONTROL;
                lblsCuloare[i].Text = masina.culoare;
                lblsCuloare[i].Left = 4 * DIMENSIUNE_PAS_X;
                lblsCuloare[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsCuloare[i]);

                //adaugare control de tip Label pentru Optiunile masinilor;
                lblsOptiuni[i] = new Label();
                lblsOptiuni[i].Width = 5 * LATIME_CONTROL;
                lblsOptiuni[i].Text = masina.optiuni;
                lblsOptiuni[i].Left = 5 * DIMENSIUNE_PAS_X;
                lblsOptiuni[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsOptiuni[i]);
                i++;
            }
        }
    }
}
