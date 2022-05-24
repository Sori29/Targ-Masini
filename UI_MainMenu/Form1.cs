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
        DataTable TabelDate;
        private int rowIndex = 0;
        private string culoare_selectata;
        private string cautare_selectata;
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
            //initializare coloane tabel de date
            initializare_coloane();

            lbleroare = new Label();
            lbleroare.Width = 4 * LATIME_CONTROL;
            lbleroare.Top = 16 * DIMENSIUNE_PAS_Y;
            lbleroare.Left = 70;
            lbleroare.ForeColor = Color.Red;

        }

        private void initializare_coloane()
        {
            TabelDate = new DataTable();
            TabelDate.Columns.Add("ID", typeof(int));
            TabelDate.Columns.Add("Firma", typeof(string));
            TabelDate.Columns.Add("Model", typeof(string));
            TabelDate.Columns.Add("An", typeof(uint));
            TabelDate.Columns.Add("Culoare", typeof(string));
            TabelDate.Columns.Add("Vanzator", typeof(string));
            TabelDate.Columns.Add("Cumparator", typeof(string));
            TabelDate.Columns.Add("Data tranzactie", typeof(string));
            TabelDate.Columns.Add("Pret", typeof(uint));
            TabelDate.Columns.Add("Optiuni", typeof(string));
        }
        private void ClearCheckedBoxes()
        {
            foreach(int i in lstOptiuni.CheckedIndices)
            {
                lstOptiuni.SetItemCheckState(i, CheckState.Unchecked);
            }
        }
        private void AdaugareRand(Masina masina)
        {
            TabelDate.Rows.Add(masina.IDMasina, masina.numeFirma, masina.model, masina.an, masina.culoare, masina.numeVanzator,
                               masina.numeCumparator, masina.dataTranzactie.Value.ToShortDateString(), masina.pret, masina.optiuni);
        }
        private void AfiseazaMasini()
        {
            Masina[] masini = adminMasini.GetMasini(out int nrMasini);
            foreach (Masina masina in masini)
            {
                if (masina == null)
                    break;
                else
                {
                    AdaugareRand(masina);   
                }
            }
            dateMasini.DataSource = TabelDate;
        }
        private void Golire_casutetxt()
        {
            txtNumeFirma.Text = String.Empty;
            txtNumeModel.Text = String.Empty;
            txtAn.Text = String.Empty;
            txtVanzator.Text=String.Empty;
            txtCumparator.Text=String.Empty;
            txtPret.Text=String.Empty;
            ClearCheckedBoxes();
            cmbCuloare.SelectedItem = null;
        }
        private void btnAdauga_Click(object sender, EventArgs e)
        {
            Masina[] masini = adminMasini.GetMasini(out int nrMasini);
            if (txtNumeFirma.Text == String.Empty || txtNumeModel.Text == string.Empty || txtAn.Text == string.Empty || cmbCuloare.SelectedIndex==-1 || lstOptiuni.CheckedItems == null || txtVanzator.Text == string.Empty || txtCumparator.Text==string.Empty || txtPret.Text==string.Empty)
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
                string optiuni = string.Empty;
                foreach(object itemChecked in lstOptiuni.CheckedItems)
                {
                    optiuni = optiuni + itemChecked.ToString() + ",";
                }
                string nume_vanzator = txtVanzator.Text;
                string nume_cumparator = txtCumparator.Text;
                DateTime data = dataTranzactie.Value;
                uint pret=UInt32.Parse(txtPret.Text);
                Masina masina = new Masina(nrMasini + 1, firma, model, an, culoare_selectata, optiuni,nume_vanzator,nume_cumparator,data,pret);
                Golire_casutetxt();
                AdaugareRand(masina);
                dateMasini.DataSource = TabelDate;
                adminMasini.AddMasina(masina);
            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            AfiseazaMasini();
        }

        private void dateMasini_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lstOptiuni_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cmbCuloare_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox c = (ComboBox)sender;
            culoare_selectata = c.GetItemText(c.SelectedItem);
        }

        private void dateMasini_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.Button==MouseButtons.Right)
            {
                this.dateMasini.Rows[e.RowIndex].Selected = true;
                this.rowIndex = e.RowIndex;
                this.dateMasini.CurrentCell = this.dateMasini.Rows[e.RowIndex].Cells[1];
                this.contextMenuStrip1.Show(this.dateMasini, e.Location);
                contextMenuStrip1.Show(Cursor.Position);
            }
        }
        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {
            Masina[] masini = adminMasini.GetMasini(out int nrMasini);
            if (!this.dateMasini.Rows[this.rowIndex].IsNewRow)
            {
                TabelDate.Rows.RemoveAt(this.rowIndex);
                TabelDate.Reset();
                var file = new List<string>(System.IO.File.ReadAllLines(caleCompletaFisier));
                file.RemoveAt(rowIndex);
                if (rowIndex == nrMasini - 1)
                {
                    File.WriteAllLines(caleCompletaFisier, file.ToArray());
                }
                else
                {
                    for(int contor = rowIndex; contor < nrMasini-1; contor++)
                                    {
                                        string[] linie = file[contor].Split(';');
                                        int IDcurent=Int32.Parse(linie[0]);
                                        IDcurent = IDcurent - 1;
                                        linie[0] = IDcurent.ToString();
                                        file[contor] = String.Join(";", linie);
                                    }
                                    File.WriteAllLines(caleCompletaFisier, file.ToArray());
                }
                initializare_coloane();
                AfiseazaMasini();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            initializare_coloane();
            AfiseazaMasini();
            dateMasini.Update();
            dateMasini.Refresh();
            //dateMasini.DataSource = TabelDate;
        }

        private void btnCautare_Click(object sender, EventArgs e)
        {
            lblCautare.Visible = true;
            cmbCautare.Visible = true;
        }

        private void cmbCautare_SelectionChangesCommitted(object sender, EventArgs e)
        {
            ComboBox c = (ComboBox)sender;
            cautare_selectata = c.GetItemText(c.SelectedItem);
            txtCautare.Visible = true;
            btnInapoi.Visible = true;
        }

        private void txtCautare_TextChanged(object sender, EventArgs e)
        {
            string valuare_cautata=txtCautare.Text;
            int poz = TabelDate.Columns.IndexOf(cautare_selectata);
            try
            {
                var re = from row in TabelDate.AsEnumerable()
                         where row[poz].ToString().Contains(valuare_cautata)
                         select row;
                if(re.Count() == 0)
                {
                    MessageBox.Show("Fara rezultate");
                }
                else
                {
                    dateMasini.DataSource=re.CopyToDataTable();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnInapoi_Click(object sender, EventArgs e)
        {
            lblCautare.Visible = false;
            cmbCautare.Visible = false;
            txtCautare.Visible = false;
            btnInapoi.Visible = false;
        }
    }
}
