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
        public DataTable TabelDate;
        private int rowIndex = 0;
        private string culoare_selectata;
        private string cautare_selectata;
        private const int LATIME_CONTROL = 100;
        private const int OFFSET = 500;
        private const int DIMENSIUNE_PAS_Y = 30;
        private const int DIMENSIUNE_PAS_X = 150;
        public Form1()
        {
            InitializeComponent();
            TipAdauga.SetToolTip(btnAdauga, "Buton pentru adaugare in fisierul txt si tabelul afisat");
            TipRefresh.SetToolTip(btnRefresh, "Buton pentru refresh al tabelului afisat in caz de desincronizare");
            TipCautare.SetToolTip(btnCautare, "Buton pentru initializare proces de cautare in tabelul afisat");
            TipGrafic.SetToolTip(btnGrafic, "Buton pentru afisarea unei noi ferestre pentru afisare grafic pe o perioada de tip a pretului unei masini");
            Masina[] masini = adminMasini.GetMasini(out int nrMasini);

            //setare proprietati
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);
            this.Font = new Font("Arial", 9, FontStyle.Bold);
            this.ForeColor = Color.DarkSlateGray;
            this.Text = "Targ masini";
            initializare_coloane();


        }
        private void initializare_coloane() //initializare coloane tabel de date
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
        private void verificare_duplicare_vanzator_cumparator(DataGridView dateMasini) //functie de verificare si afisare mesaj de tip box in cazul in care exista un vanzator sau un cumparator dublicat
        {
            dateMasini.Sort(dateMasini.Columns[7], ListSortDirection.Descending);
            for(int row=0;row<dateMasini.Rows.Count-1;row++)
            {
                if (!dateMasini.Rows[row].Cells[7].Value.Equals(dateMasini.Rows[row + 1].Cells[7].Value))
                    continue;
                else
                {
                    string cumparator = dateMasini.Rows[row].Cells[6].Value.ToString();
                    string vanzator = dateMasini.Rows[row].Cells[5].Value.ToString();
                        for(int row2 = row+1; row2 < dateMasini.Rows.Count-1; row2++)
                        {
                            string cumparator_comparare=dateMasini.Rows[row2].Cells[6].Value.ToString();
                            string vanzator_comparare = dateMasini.Rows[row2].Cells[5].Value.ToString();
                                if (vanzator == vanzator_comparare)
                                {
                                    dateMasini.Rows[row].DefaultCellStyle.BackColor = Color.Red;
                                    dateMasini.Rows[row2].DefaultCellStyle.BackColor = Color.Red;
                                    MessageBox.Show("Exista o persoana care vinde mai multe masini in aceeasi zi","Nume identice",MessageBoxButtons.OK,MessageBoxIcon.Information);
                                    row = dateMasini.Rows.Count - 1;
                                    break;
                                }
                                if (cumparator == cumparator_comparare)
                                {
                                    dateMasini.Rows[row].DefaultCellStyle.BackColor = Color.Red;
                                    dateMasini.Rows[row2].DefaultCellStyle.BackColor = Color.Red;
                                    MessageBox.Show("Exista o persoana care cumparara mai multe masini in aceeasi zi", "Nume identice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    row = dateMasini.Rows.Count - 1;
                                    break;  
                                }
                        }
                }
                dateMasini.Columns[0].SortMode=DataGridViewColumnSortMode.NotSortable;
                dateMasini.Sort(dateMasini.Columns[0], ListSortDirection.Ascending);
            }
        }
        private void ClearCheckedBoxes() // functie de debifare casute selectate pentru sectiunea Optiuni
        {
            foreach(int i in lstOptiuni.CheckedIndices)
            {
                lstOptiuni.SetItemCheckState(i, CheckState.Unchecked);
            }
        }
        private void AdaugareRand(Masina masina) // functie de adaugare rand in Tabelul de date
        {
            TabelDate.Rows.Add(masina.IDMasina, masina.numeFirma, masina.model, masina.an, masina.culoare, masina.numeVanzator,
                               masina.numeCumparator, masina.dataTranzactie.Value.ToShortDateString(), masina.pret, masina.optiuni);
        }
        private void AfiseazaMasini() //afisarea masinilor
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
        private void Golire_casutetxt() // functie de golire casute la introducerea unei masini
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
        private void btnAdauga_Click(object sender, EventArgs e) // functie de agaugare in fisier si dataTable
        {
            Masina[] masini = adminMasini.GetMasini(out int nrMasini);
            if (txtNumeFirma.Text == String.Empty || txtNumeModel.Text == string.Empty || txtAn.Text == string.Empty || cmbCuloare.SelectedIndex==-1 || lstOptiuni.CheckedItems == null || txtVanzator.Text == string.Empty || txtCumparator.Text==string.Empty || txtPret.Text==string.Empty)
            {
                MessageBox.Show("O casuta obligatorie nu a fost completa", "Adaugare invalida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtAn.Text.Any(char.IsLetter))
            {
                MessageBox.Show("Anul completat este invalid", "Adaugare invalida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblnAn.ForeColor = Color.Red;
                
            }
            else if(Int32.Parse(txtAn.Text) > dataTranzactie.Value.Year)
            {
                MessageBox.Show("Anul fabricatiei nu poate sa fie mai mare decat an tranzactie", "Adaugare invalida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblnAn.ForeColor=Color.Red;
                lblnDataTranzactie.ForeColor = Color.Red;
            }
            else
            {
                lblnAn.ForeColor = Color.LimeGreen;
                lblnDataTranzactie.ForeColor= Color.LimeGreen;
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

        private void cmbCuloare_SelectionChangeCommitted(object sender, EventArgs e) //functie de preluare culoare din combobox
        {
            ComboBox c = (ComboBox)sender;
            culoare_selectata = c.GetItemText(c.SelectedItem);
        }

        private void dateMasini_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e) // functie de afisare apelare "stergere" prin click dreapta pe randul din tabela
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
        private void contextMenuStrip1_Click(object sender, EventArgs e) // functie de stergere a liniei selectate cu sincronizare in fisier
        {
            MessageBox.Show("Sunteti sigur ca doriti sa stergeti randul selectat?", "Confirmare stergere", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.No)
            {
                return;
            }
            else if (DialogResult == DialogResult.Yes)
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
                        for(int contor = rowIndex; contor < nrMasini-1; contor++) //resincronziare ID
                        {
                            string[] linie = file[contor].Split(';');
                            int IDcurent=Int32.Parse(linie[0]);
                            IDcurent = IDcurent - 1;
                            linie[0] = IDcurent.ToString();
                            file[contor] = String.Join(";", linie);
                        }
                        File.WriteAllLines(caleCompletaFisier, file.ToArray()); //scriere in fisier
                    }
                    initializare_coloane();
                    AfiseazaMasini();
                }
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

        private void cmbCautare_SelectionChangesCommitted(object sender, EventArgs e) //selectare optiune selectata in dropdown-ul pentru cautare
        {
            ComboBox c = (ComboBox)sender;
            cautare_selectata = c.GetItemText(c.SelectedItem);
            txtCautare.Visible = true;
            btnInapoi.Visible = true;
        }

        private void txtCautare_TextChanged(object sender, EventArgs e) //Functie de cautare automata, returneaza eroare in caz ca nu gaseste
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
                    MessageBox.Show("Cautarea nu a returnat rezultate","Cautare esuata",MessageBoxButtons.OK,MessageBoxIcon.Error);
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


        private void Form1_Shown(object sender, EventArgs e)
        {
            verificare_duplicare_vanzator_cumparator(dateMasini);
        }

        private void btnGrafic_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2(TabelDate);
            frm2.ShowDialog();
        }
    }
}
