namespace UI_MainMenu
{
    partial class Form2
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.grafPret = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblGraficTip = new System.Windows.Forms.Label();
            this.txtGraphModel = new System.Windows.Forms.TextBox();
            this.lblGraphPerInc = new System.Windows.Forms.Label();
            this.lblGraphPerSfa = new System.Windows.Forms.Label();
            this.dataInceput = new System.Windows.Forms.DateTimePicker();
            this.dataSfarsit = new System.Windows.Forms.DateTimePicker();
            this.btnGrafic = new System.Windows.Forms.Button();
            this.btnInapoiGraph = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grafPret)).BeginInit();
            this.SuspendLayout();
            // 
            // grafPret
            // 
            chartArea3.Name = "ChartArea1";
            this.grafPret.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.grafPret.Legends.Add(legend3);
            this.grafPret.Location = new System.Drawing.Point(12, 12);
            this.grafPret.Name = "grafPret";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Preturi";
            this.grafPret.Series.Add(series3);
            this.grafPret.Size = new System.Drawing.Size(470, 300);
            this.grafPret.TabIndex = 0;
            this.grafPret.Text = "Grafic Pret";
            this.grafPret.Visible = false;
            // 
            // lblGraficTip
            // 
            this.lblGraficTip.AutoSize = true;
            this.lblGraficTip.Location = new System.Drawing.Point(506, 44);
            this.lblGraficTip.Name = "lblGraficTip";
            this.lblGraficTip.Size = new System.Drawing.Size(96, 13);
            this.lblGraficTip.TabIndex = 1;
            this.lblGraficTip.Text = "Introduceti modelul";
            // 
            // txtGraphModel
            // 
            this.txtGraphModel.Location = new System.Drawing.Point(609, 44);
            this.txtGraphModel.Name = "txtGraphModel";
            this.txtGraphModel.Size = new System.Drawing.Size(146, 20);
            this.txtGraphModel.TabIndex = 2;
            // 
            // lblGraphPerInc
            // 
            this.lblGraphPerInc.AutoSize = true;
            this.lblGraphPerInc.Location = new System.Drawing.Point(509, 95);
            this.lblGraphPerInc.Name = "lblGraphPerInc";
            this.lblGraphPerInc.Size = new System.Drawing.Size(87, 13);
            this.lblGraphPerInc.TabIndex = 3;
            this.lblGraphPerInc.Text = "Perioada inceput";
            // 
            // lblGraphPerSfa
            // 
            this.lblGraphPerSfa.AutoSize = true;
            this.lblGraphPerSfa.Location = new System.Drawing.Point(509, 145);
            this.lblGraphPerSfa.Name = "lblGraphPerSfa";
            this.lblGraphPerSfa.Size = new System.Drawing.Size(79, 13);
            this.lblGraphPerSfa.TabIndex = 4;
            this.lblGraphPerSfa.Text = "Perioada sfarsit";
            // 
            // dataInceput
            // 
            this.dataInceput.Location = new System.Drawing.Point(609, 95);
            this.dataInceput.Name = "dataInceput";
            this.dataInceput.Size = new System.Drawing.Size(200, 20);
            this.dataInceput.TabIndex = 5;
            // 
            // dataSfarsit
            // 
            this.dataSfarsit.Location = new System.Drawing.Point(609, 145);
            this.dataSfarsit.Name = "dataSfarsit";
            this.dataSfarsit.Size = new System.Drawing.Size(200, 20);
            this.dataSfarsit.TabIndex = 6;
            // 
            // btnGrafic
            // 
            this.btnGrafic.Location = new System.Drawing.Point(509, 202);
            this.btnGrafic.Name = "btnGrafic";
            this.btnGrafic.Size = new System.Drawing.Size(75, 23);
            this.btnGrafic.TabIndex = 7;
            this.btnGrafic.Text = "Afisare";
            this.btnGrafic.UseVisualStyleBackColor = true;
            this.btnGrafic.Click += new System.EventHandler(this.btnGrafic_Click);
            // 
            // btnInapoiGraph
            // 
            this.btnInapoiGraph.Location = new System.Drawing.Point(387, 276);
            this.btnInapoiGraph.Name = "btnInapoiGraph";
            this.btnInapoiGraph.Size = new System.Drawing.Size(75, 23);
            this.btnInapoiGraph.TabIndex = 8;
            this.btnInapoiGraph.Text = "Inapoi";
            this.btnInapoiGraph.UseVisualStyleBackColor = true;
            this.btnInapoiGraph.Visible = false;
            this.btnInapoiGraph.Click += new System.EventHandler(this.btnInapoiGraph_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 450);
            this.Controls.Add(this.btnInapoiGraph);
            this.Controls.Add(this.btnGrafic);
            this.Controls.Add(this.dataSfarsit);
            this.Controls.Add(this.dataInceput);
            this.Controls.Add(this.lblGraphPerSfa);
            this.Controls.Add(this.lblGraphPerInc);
            this.Controls.Add(this.txtGraphModel);
            this.Controls.Add(this.lblGraficTip);
            this.Controls.Add(this.grafPret);
            this.Name = "Form2";
            this.Text = "Statistica pret la un model de masina";
            ((System.ComponentModel.ISupportInitialize)(this.grafPret)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart grafPret;
        private System.Windows.Forms.Label lblGraficTip;
        private System.Windows.Forms.TextBox txtGraphModel;
        private System.Windows.Forms.Label lblGraphPerInc;
        private System.Windows.Forms.Label lblGraphPerSfa;
        private System.Windows.Forms.DateTimePicker dataInceput;
        private System.Windows.Forms.DateTimePicker dataSfarsit;
        private System.Windows.Forms.Button btnGrafic;
        private System.Windows.Forms.Button btnInapoiGraph;
    }
}