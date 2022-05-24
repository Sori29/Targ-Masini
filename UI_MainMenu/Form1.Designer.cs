namespace UI_MainMenu
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblnNumeFirma = new System.Windows.Forms.Label();
            this.lblnNumeModel = new System.Windows.Forms.Label();
            this.lblnAn = new System.Windows.Forms.Label();
            this.lblnCuloare = new System.Windows.Forms.Label();
            this.lblnOptiuni = new System.Windows.Forms.Label();
            this.txtNumeFirma = new System.Windows.Forms.TextBox();
            this.txtNumeModel = new System.Windows.Forms.TextBox();
            this.txtAn = new System.Windows.Forms.TextBox();
            this.btnAdauga = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblnNumeVanzator = new System.Windows.Forms.Label();
            this.lblnNumeCumparator = new System.Windows.Forms.Label();
            this.lblnDataTranzactie = new System.Windows.Forms.Label();
            this.lblnPret = new System.Windows.Forms.Label();
            this.txtVanzator = new System.Windows.Forms.TextBox();
            this.txtCumparator = new System.Windows.Forms.TextBox();
            this.dataTranzactie = new System.Windows.Forms.DateTimePicker();
            this.cmbCuloare = new System.Windows.Forms.ComboBox();
            this.lstOptiuni = new System.Windows.Forms.ListBox();
            this.txtPret = new System.Windows.Forms.TextBox();
            this.dateMasini = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Firma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.An = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Culoare = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vanzator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cumparator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data_tranzactie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pret = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Optiuni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dateMasini)).BeginInit();
            this.SuspendLayout();
            // 
            // lblnNumeFirma
            // 
            this.lblnNumeFirma.AutoSize = true;
            this.lblnNumeFirma.Location = new System.Drawing.Point(62, 13);
            this.lblnNumeFirma.Name = "lblnNumeFirma";
            this.lblnNumeFirma.Size = new System.Drawing.Size(32, 13);
            this.lblnNumeFirma.TabIndex = 0;
            this.lblnNumeFirma.Text = "Firma";
            // 
            // lblnNumeModel
            // 
            this.lblnNumeModel.AutoSize = true;
            this.lblnNumeModel.Location = new System.Drawing.Point(62, 58);
            this.lblnNumeModel.Name = "lblnNumeModel";
            this.lblnNumeModel.Size = new System.Drawing.Size(36, 13);
            this.lblnNumeModel.TabIndex = 1;
            this.lblnNumeModel.Text = "Model";
            // 
            // lblnAn
            // 
            this.lblnAn.AutoSize = true;
            this.lblnAn.Location = new System.Drawing.Point(62, 99);
            this.lblnAn.Name = "lblnAn";
            this.lblnAn.Size = new System.Drawing.Size(66, 13);
            this.lblnAn.TabIndex = 2;
            this.lblnAn.Text = "An fabricatie";
            // 
            // lblnCuloare
            // 
            this.lblnCuloare.AutoSize = true;
            this.lblnCuloare.Location = new System.Drawing.Point(62, 146);
            this.lblnCuloare.Name = "lblnCuloare";
            this.lblnCuloare.Size = new System.Drawing.Size(43, 13);
            this.lblnCuloare.TabIndex = 3;
            this.lblnCuloare.Text = "Culoare";
            // 
            // lblnOptiuni
            // 
            this.lblnOptiuni.AutoSize = true;
            this.lblnOptiuni.Location = new System.Drawing.Point(62, 191);
            this.lblnOptiuni.Name = "lblnOptiuni";
            this.lblnOptiuni.Size = new System.Drawing.Size(40, 13);
            this.lblnOptiuni.TabIndex = 4;
            this.lblnOptiuni.Text = "Optiuni";
            // 
            // txtNumeFirma
            // 
            this.txtNumeFirma.Location = new System.Drawing.Point(159, 10);
            this.txtNumeFirma.Name = "txtNumeFirma";
            this.txtNumeFirma.Size = new System.Drawing.Size(86, 20);
            this.txtNumeFirma.TabIndex = 5;
            // 
            // txtNumeModel
            // 
            this.txtNumeModel.Location = new System.Drawing.Point(159, 58);
            this.txtNumeModel.Name = "txtNumeModel";
            this.txtNumeModel.Size = new System.Drawing.Size(86, 20);
            this.txtNumeModel.TabIndex = 6;
            // 
            // txtAn
            // 
            this.txtAn.Location = new System.Drawing.Point(159, 99);
            this.txtAn.Name = "txtAn";
            this.txtAn.Size = new System.Drawing.Size(86, 20);
            this.txtAn.TabIndex = 7;
            // 
            // btnAdauga
            // 
            this.btnAdauga.Location = new System.Drawing.Point(65, 415);
            this.btnAdauga.Name = "btnAdauga";
            this.btnAdauga.Size = new System.Drawing.Size(75, 23);
            this.btnAdauga.TabIndex = 10;
            this.btnAdauga.Text = "Adauga";
            this.btnAdauga.UseVisualStyleBackColor = true;
            this.btnAdauga.Click += new System.EventHandler(this.btnAdauga_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(170, 415);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 11;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblnNumeVanzator
            // 
            this.lblnNumeVanzator.AutoSize = true;
            this.lblnNumeVanzator.Location = new System.Drawing.Point(62, 229);
            this.lblnNumeVanzator.Name = "lblnNumeVanzator";
            this.lblnNumeVanzator.Size = new System.Drawing.Size(49, 13);
            this.lblnNumeVanzator.TabIndex = 12;
            this.lblnNumeVanzator.Text = "Vanzator";
            // 
            // lblnNumeCumparator
            // 
            this.lblnNumeCumparator.AutoSize = true;
            this.lblnNumeCumparator.Location = new System.Drawing.Point(63, 270);
            this.lblnNumeCumparator.Name = "lblnNumeCumparator";
            this.lblnNumeCumparator.Size = new System.Drawing.Size(61, 13);
            this.lblnNumeCumparator.TabIndex = 13;
            this.lblnNumeCumparator.Text = "Cumparator";
            // 
            // lblnDataTranzactie
            // 
            this.lblnDataTranzactie.AutoSize = true;
            this.lblnDataTranzactie.Location = new System.Drawing.Point(63, 319);
            this.lblnDataTranzactie.Name = "lblnDataTranzactie";
            this.lblnDataTranzactie.Size = new System.Drawing.Size(79, 13);
            this.lblnDataTranzactie.TabIndex = 14;
            this.lblnDataTranzactie.Text = "Data tranzactie";
            // 
            // lblnPret
            // 
            this.lblnPret.AutoSize = true;
            this.lblnPret.Location = new System.Drawing.Point(65, 359);
            this.lblnPret.Name = "lblnPret";
            this.lblnPret.Size = new System.Drawing.Size(26, 13);
            this.lblnPret.TabIndex = 15;
            this.lblnPret.Text = "Pret";
            // 
            // txtVanzator
            // 
            this.txtVanzator.Location = new System.Drawing.Point(159, 229);
            this.txtVanzator.Name = "txtVanzator";
            this.txtVanzator.Size = new System.Drawing.Size(114, 20);
            this.txtVanzator.TabIndex = 16;
            // 
            // txtCumparator
            // 
            this.txtCumparator.Location = new System.Drawing.Point(159, 270);
            this.txtCumparator.Name = "txtCumparator";
            this.txtCumparator.Size = new System.Drawing.Size(114, 20);
            this.txtCumparator.TabIndex = 17;
            // 
            // dataTranzactie
            // 
            this.dataTranzactie.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dataTranzactie.Location = new System.Drawing.Point(159, 319);
            this.dataTranzactie.Name = "dataTranzactie";
            this.dataTranzactie.Size = new System.Drawing.Size(121, 20);
            this.dataTranzactie.TabIndex = 18;
            // 
            // cmbCuloare
            // 
            this.cmbCuloare.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCuloare.FormattingEnabled = true;
            this.cmbCuloare.Items.AddRange(new object[] {
            "Alb",
            "Negru",
            "Galben",
            "Portocaliu",
            "Gri",
            "Rosu",
            "Verde",
            "Albastru"});
            this.cmbCuloare.Location = new System.Drawing.Point(159, 143);
            this.cmbCuloare.Name = "cmbCuloare";
            this.cmbCuloare.Size = new System.Drawing.Size(121, 21);
            this.cmbCuloare.TabIndex = 19;
            // 
            // lstOptiuni
            // 
            this.lstOptiuni.FormattingEnabled = true;
            this.lstOptiuni.Items.AddRange(new object[] {
            "Aer conditionat",
            "Navigatie",
            "Cutie automata",
            "Cutie manuala",
            "ABS",
            "ESP",
            "Airbaguri",
            "Camera de bord",
            "Avertizor centura",
            "Sistem audio",
            "Mufa auxiliara",
            "Tapiterie piele",
            "Tapiterie textila",
            "Volan incalzit",
            "Geamuri electrice",
            "Trapa electrica"});
            this.lstOptiuni.Location = new System.Drawing.Point(160, 191);
            this.lstOptiuni.Name = "lstOptiuni";
            this.lstOptiuni.ScrollAlwaysVisible = true;
            this.lstOptiuni.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstOptiuni.Size = new System.Drawing.Size(120, 17);
            this.lstOptiuni.TabIndex = 20;
            // 
            // txtPret
            // 
            this.txtPret.Location = new System.Drawing.Point(159, 359);
            this.txtPret.Name = "txtPret";
            this.txtPret.Size = new System.Drawing.Size(100, 20);
            this.txtPret.TabIndex = 21;
            // 
            // dateMasini
            // 
            this.dateMasini.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dateMasini.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Firma,
            this.Model,
            this.An,
            this.Culoare,
            this.Vanzator,
            this.Cumparator,
            this.Data_tranzactie,
            this.Pret,
            this.Optiuni});
            this.dateMasini.Location = new System.Drawing.Point(311, 10);
            this.dateMasini.Name = "dateMasini";
            this.dateMasini.Size = new System.Drawing.Size(714, 335);
            this.dateMasini.TabIndex = 33;
            this.dateMasini.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dateMasini_CellContentClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // Firma
            // 
            this.Firma.HeaderText = "Firma";
            this.Firma.Name = "Firma";
            // 
            // Model
            // 
            this.Model.HeaderText = "Model";
            this.Model.Name = "Model";
            // 
            // An
            // 
            this.An.HeaderText = "An";
            this.An.Name = "An";
            // 
            // Culoare
            // 
            this.Culoare.HeaderText = "Culoare";
            this.Culoare.Name = "Culoare";
            // 
            // Vanzator
            // 
            this.Vanzator.HeaderText = "Vanzator";
            this.Vanzator.Name = "Vanzator";
            // 
            // Cumparator
            // 
            this.Cumparator.HeaderText = "Cumparator";
            this.Cumparator.Name = "Cumparator";
            // 
            // Data_tranzactie
            // 
            this.Data_tranzactie.HeaderText = "Data tranzactie";
            this.Data_tranzactie.Name = "Data_tranzactie";
            // 
            // Pret
            // 
            this.Pret.HeaderText = "Pret [RON]";
            this.Pret.Name = "Pret";
            // 
            // Optiuni
            // 
            this.Optiuni.HeaderText = "Optiuni";
            this.Optiuni.Name = "Optiuni";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1050, 482);
            this.Controls.Add(this.dateMasini);
            this.Controls.Add(this.txtPret);
            this.Controls.Add(this.lstOptiuni);
            this.Controls.Add(this.cmbCuloare);
            this.Controls.Add(this.dataTranzactie);
            this.Controls.Add(this.txtCumparator);
            this.Controls.Add(this.txtVanzator);
            this.Controls.Add(this.lblnPret);
            this.Controls.Add(this.lblnDataTranzactie);
            this.Controls.Add(this.lblnNumeCumparator);
            this.Controls.Add(this.lblnNumeVanzator);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnAdauga);
            this.Controls.Add(this.txtAn);
            this.Controls.Add(this.txtNumeModel);
            this.Controls.Add(this.txtNumeFirma);
            this.Controls.Add(this.lblnOptiuni);
            this.Controls.Add(this.lblnCuloare);
            this.Controls.Add(this.lblnAn);
            this.Controls.Add(this.lblnNumeModel);
            this.Controls.Add(this.lblnNumeFirma);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dateMasini)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblnNumeFirma;
        private System.Windows.Forms.Label lblnNumeModel;
        private System.Windows.Forms.Label lblnAn;
        private System.Windows.Forms.Label lblnCuloare;
        private System.Windows.Forms.Label lblnOptiuni;
        private System.Windows.Forms.TextBox txtNumeFirma;
        private System.Windows.Forms.TextBox txtNumeModel;
        private System.Windows.Forms.TextBox txtAn;
        private System.Windows.Forms.Button btnAdauga;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblnNumeVanzator;
        private System.Windows.Forms.Label lblnNumeCumparator;
        private System.Windows.Forms.Label lblnDataTranzactie;
        private System.Windows.Forms.Label lblnPret;
        private System.Windows.Forms.TextBox txtVanzator;
        private System.Windows.Forms.TextBox txtCumparator;
        private System.Windows.Forms.DateTimePicker dataTranzactie;
        private System.Windows.Forms.ComboBox cmbCuloare;
        private System.Windows.Forms.ListBox lstOptiuni;
        private System.Windows.Forms.TextBox txtPret;
        private System.Windows.Forms.DataGridView dateMasini;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Firma;
        private System.Windows.Forms.DataGridViewTextBoxColumn Model;
        private System.Windows.Forms.DataGridViewTextBoxColumn An;
        private System.Windows.Forms.DataGridViewTextBoxColumn Culoare;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vanzator;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cumparator;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data_tranzactie;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pret;
        private System.Windows.Forms.DataGridViewTextBoxColumn Optiuni;
    }
}

