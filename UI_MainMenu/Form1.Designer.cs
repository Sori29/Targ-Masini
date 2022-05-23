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
            this.txtCuloare = new System.Windows.Forms.TextBox();
            this.txtOptiuni = new System.Windows.Forms.TextBox();
            this.btnAdauga = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblnNumeFirma
            // 
            this.lblnNumeFirma.AutoSize = true;
            this.lblnNumeFirma.Location = new System.Drawing.Point(59, 13);
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
            // txtCuloare
            // 
            this.txtCuloare.Location = new System.Drawing.Point(159, 143);
            this.txtCuloare.Name = "txtCuloare";
            this.txtCuloare.Size = new System.Drawing.Size(86, 20);
            this.txtCuloare.TabIndex = 8;
            // 
            // txtOptiuni
            // 
            this.txtOptiuni.Location = new System.Drawing.Point(159, 188);
            this.txtOptiuni.Name = "txtOptiuni";
            this.txtOptiuni.Size = new System.Drawing.Size(214, 20);
            this.txtOptiuni.TabIndex = 9;
            // 
            // btnAdauga
            // 
            this.btnAdauga.Location = new System.Drawing.Point(65, 252);
            this.btnAdauga.Name = "btnAdauga";
            this.btnAdauga.Size = new System.Drawing.Size(75, 23);
            this.btnAdauga.TabIndex = 10;
            this.btnAdauga.Text = "Adauga";
            this.btnAdauga.UseVisualStyleBackColor = true;
            this.btnAdauga.Click += new System.EventHandler(this.btnAdauga_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(170, 252);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 11;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(800, 375);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnAdauga);
            this.Controls.Add(this.txtOptiuni);
            this.Controls.Add(this.txtCuloare);
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
        private System.Windows.Forms.TextBox txtCuloare;
        private System.Windows.Forms.TextBox txtOptiuni;
        private System.Windows.Forms.Button btnAdauga;
        private System.Windows.Forms.Button btnRefresh;
    }
}

