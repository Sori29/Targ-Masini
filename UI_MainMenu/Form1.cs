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

        private Label lblnNumeFirma;
        private Label lblnNumeModel;
        private Label lblnAn;
        private Label lblnCuloare;
        private Label lblnOptiuni;

        private TextBox txtNumeFirma;
        private TextBox txtNumeModel;
        private TextBox txtAn;
        private TextBox txtCuloare;
        private TextBox txtOptiuni;

        private Button btnAdauga;
        private Button btnRefresh;

        private Label lbleroare;

        private const int LATIME_CONTROL = 100;
        private const int DIMENSIUNE_PAS_Y = 30;
        private const int DIMENSIUNE_PAS_X = 100;
        private const int POZITIE_START_X = 50;
        public Form1()
        {
            InitializeComponent();
            Masina[] masini = adminMasini.GetMasini(out int nrMasini);

            //setare proprietati
            this.Size = new Size(1200, 135);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 100);
            this.Font = new Font("Arial", 9, FontStyle.Bold);
            this.ForeColor = Color.LimeGreen;
            this.Text = "Informatii masini";

            //adaugare control de tip Label pentru 'NumeFirma';
            lblNumeFirma = new Label();
            lblNumeFirma.Width = LATIME_CONTROL;
            lblNumeFirma.Text = "Nume firma";
            lblNumeFirma.Left = POZITIE_START_X;
            lblNumeFirma.Top= 4 * DIMENSIUNE_PAS_Y;
            lblNumeFirma.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblNumeFirma);

            //adaugare control de tip Label pentru 'NumeModel';
            lblNumeModel = new Label();
            lblNumeModel.Width = LATIME_CONTROL;
            lblNumeModel.Text = "Nume model";
            lblNumeModel.Left = 2 * DIMENSIUNE_PAS_X + POZITIE_START_X;
            lblNumeModel.Top = 4 * DIMENSIUNE_PAS_Y;
            lblNumeModel.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblNumeModel);

            //adaugare control de tip Label pentru 'An';
            lblAn = new Label();
            lblAn.Width = LATIME_CONTROL;
            lblAn.Text = "An fabricatie";
            lblAn.Left = 4 * DIMENSIUNE_PAS_X + 50;
            lblAn.Top = 4 * DIMENSIUNE_PAS_Y;
            lblAn.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblAn);

            //adaugare control de tip Label pentru 'Culoare';
            lblCuloare = new Label();
            lblCuloare.Width = LATIME_CONTROL;
            lblCuloare.Text = "Culoare";
            lblCuloare.Left = 6 * DIMENSIUNE_PAS_X + POZITIE_START_X;
            lblCuloare.Top = 4 * DIMENSIUNE_PAS_Y;
            lblCuloare.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblCuloare);

            //adaugare control de tip Label pentru 'Optiuni';
            lblOptiuni = new Label();
            lblOptiuni.Width = LATIME_CONTROL;
            lblOptiuni.Text = "Optiuni";
            lblOptiuni.Left = 8 * DIMENSIUNE_PAS_X + POZITIE_START_X;
            lblOptiuni.Top = 4 * DIMENSIUNE_PAS_Y;
            lblOptiuni.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblOptiuni);

            //adaugare contropl de tip button pentru 'Refresh';
            btnRefresh = new Button();
            btnRefresh.Width = LATIME_CONTROL;
            btnRefresh.Left = 10 * DIMENSIUNE_PAS_X + POZITIE_START_X;
            btnRefresh.Top = DIMENSIUNE_PAS_Y;
            btnRefresh.Text = "Refresh";
            btnRefresh.Click += OnButtonClicked;
            this.Controls.Add(btnRefresh);

            //adaugare control de tip button pentru 'Adaugare masina'
            btnAdauga = new Button();
            btnAdauga.Width = LATIME_CONTROL;
            btnAdauga.Location = new System.Drawing.Point(10 * DIMENSIUNE_PAS_X + POZITIE_START_X, 2 * DIMENSIUNE_PAS_Y);
            btnAdauga.Text = "Adauga";
            btnAdauga.Click += OnButton1Clicked;
            this.Controls.Add(btnAdauga);

            //adaugare control de tip Label pentru 'Introducere date noi';
            lblnNumeFirma = new Label();
            lblnNumeFirma.Width = 2 * LATIME_CONTROL;
            lblnNumeFirma.Text = "Introduceti firma";
            lblnNumeFirma.Left = POZITIE_START_X;
            lblnNumeFirma.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblnNumeFirma);

            lblnNumeModel = new Label();
            lblnNumeModel.Width = 2 * LATIME_CONTROL;
            lblnNumeModel.Text = "Introduceti model";
            lblnNumeModel.Left = 2 * DIMENSIUNE_PAS_X + POZITIE_START_X;
            lblnNumeModel.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblnNumeModel);

            lblnAn = new Label();
            lblnAn.Width = 2 * LATIME_CONTROL;
            lblnAn.Text = "Introduceti an fabricatie";
            lblnAn.Left = 4 * DIMENSIUNE_PAS_X + POZITIE_START_X;
            lblnAn.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblnAn);

            lblnCuloare = new Label();
            lblnCuloare.Width = 2 * LATIME_CONTROL;
            lblnCuloare.Text = "Introduceti culoare";
            lblnCuloare.Left = 6 * DIMENSIUNE_PAS_X + POZITIE_START_X;
            lblnCuloare.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblnCuloare);

            lblnOptiuni = new Label();
            lblnOptiuni.Width = 2 * LATIME_CONTROL;
            lblnOptiuni.Text = "Introduceti optiuni";
            lblnOptiuni.Left = 8 * DIMENSIUNE_PAS_X + POZITIE_START_X;
            lblnOptiuni.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblnOptiuni);

            //introducere control de tip textbox pentru 'Introducere date noi';
            txtNumeFirma = new TextBox();
            txtNumeFirma.Width = LATIME_CONTROL;
            txtNumeFirma.Location = new System.Drawing.Point(POZITIE_START_X, DIMENSIUNE_PAS_Y);
            this.Controls.Add(txtNumeFirma);

            txtNumeModel = new TextBox();
            txtNumeModel.Width = LATIME_CONTROL;
            txtNumeModel.Location = new System.Drawing.Point(POZITIE_START_X + 2 * DIMENSIUNE_PAS_X, DIMENSIUNE_PAS_Y);
            this.Controls.Add(txtNumeModel);

            txtAn = new TextBox();
            txtAn.Width = LATIME_CONTROL;
            txtAn.Location = new System.Drawing.Point(POZITIE_START_X + 4 * DIMENSIUNE_PAS_X, DIMENSIUNE_PAS_Y);
            this.Controls.Add(txtAn);

            txtCuloare = new TextBox();
            txtCuloare.Width = LATIME_CONTROL;
            txtCuloare.Location = new System.Drawing.Point(POZITIE_START_X + 6 * DIMENSIUNE_PAS_X, DIMENSIUNE_PAS_Y);
            this.Controls.Add(txtCuloare);

            txtOptiuni = new TextBox();
            txtOptiuni.Width = LATIME_CONTROL;
            txtOptiuni.Location = new System.Drawing.Point(POZITIE_START_X + 8 * DIMENSIUNE_PAS_X, DIMENSIUNE_PAS_Y);
            this.Controls.Add(txtOptiuni);

            lbleroare = new Label();
            lbleroare.Width = 4 * LATIME_CONTROL;
            lbleroare.Top = 2 * DIMENSIUNE_PAS_Y;
            lbleroare.Left = 50;
            lbleroare.ForeColor = Color.Red;


        }
        
        private void Form1_Load(object sender, EventArgs e)
        { 

        }

        private void OnButtonClicked(object sender, EventArgs e) // refresh
        {
            Masina[] masini = adminMasini.GetMasini(out int nrMasini);
            this.Size = new Size(1400, 65*nrMasini);
            AfiseazaMasini();
        }
        private void OnButton1Clicked(object sender, EventArgs e) //adaugare
        {
            Masina[] masini = adminMasini.GetMasini(out int nrMasini);
            if (txtNumeFirma.Text == String.Empty || txtNumeModel.Text == string.Empty || txtAn.Text == string.Empty || txtCuloare.Text == string.Empty || txtOptiuni.Text == string.Empty)
            {
                lbleroare.Text = "O casuta completata este goala, introduceti din nou";
                this.Controls.Add(lbleroare);
            }
            else if(txtAn.Text.Any(char.IsLetter))
            {
                lbleroare.Text = "Anul completat este invalid, introduceti din nou";
                this.Controls.Add(lbleroare);
            }
            else
            {
                lbleroare.Text = String.Empty;
                this.Controls.Add(lbleroare);
                string firma = txtNumeFirma.Text;
                string model = txtNumeModel.Text;
                int an = Int32.Parse(txtAn.Text);
                string culoare = txtCuloare.Text;
                string optiuni = txtOptiuni.Text;
                Masina masina = new Masina(nrMasini + 1, firma, model, an, culoare, optiuni);
                adminMasini.AddMasina(masina);
            }
        }
        private void AfiseazaMasini()
        {
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
                lblsNumeFirma[i].Left = 50;
                lblsNumeFirma[i].Top = (i + 5) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsNumeFirma[i]);

                //adaugare control de tip Label pentru numele modelelor;
                lblsNumeModel[i] = new Label();
                lblsNumeModel[i].Width = LATIME_CONTROL;
                lblsNumeModel[i].Text = masina.model;
                lblsNumeModel[i].Left = 2 * DIMENSIUNE_PAS_X + 50;
                lblsNumeModel[i].Top = (i + 5) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsNumeModel[i]);

                //adaugare control de tip Label pentru anul masinilor;
                lblsAn[i] = new Label();
                lblsAn[i].Width = LATIME_CONTROL;
                lblsAn[i].Text = masina.an.ToString();
                lblsAn[i].Left = 4 * DIMENSIUNE_PAS_X + 50;
                lblsAn[i].Top = (i + 5) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsAn[i]);

                //adaugare control de tip Label pentru Culoare masinilor;
                lblsCuloare[i] = new Label();
                lblsCuloare[i].Width = LATIME_CONTROL;
                lblsCuloare[i].Text = masina.culoare;
                lblsCuloare[i].Left = 6 * DIMENSIUNE_PAS_X + 50;
                lblsCuloare[i].Top = (i + 5) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsCuloare[i]);

                //adaugare control de tip Label pentru Optiunile masinilor;
                lblsOptiuni[i] = new Label();
                lblsOptiuni[i].Width = 5 * LATIME_CONTROL;
                lblsOptiuni[i].Text = masina.optiuni;
                lblsOptiuni[i].Left = 8 * DIMENSIUNE_PAS_X + 50;
                lblsOptiuni[i].Top = (i + 5) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsOptiuni[i]);
                i++;
            }
        }
    }
}
