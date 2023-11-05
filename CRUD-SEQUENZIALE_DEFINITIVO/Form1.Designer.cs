namespace CRUD_SEQUENZIALE_DEFINITIVO
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.aggiungi_prodotto = new System.Windows.Forms.Button();
            this.modifica_prodotto = new System.Windows.Forms.Button();
            this.elimina_prodotto = new System.Windows.Forms.Button();
            this.resetta_file = new System.Windows.Forms.Button();
            this.apri_file = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.eliminazione_logica = new System.Windows.Forms.CheckBox();
            this.eliminazione_fisica = new System.Windows.Forms.CheckBox();
            this.annulla = new System.Windows.Forms.Button();
            this.titolo_elimina = new System.Windows.Forms.Label();
            this.trova_indice = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // aggiungi_prodotto
            // 
            this.aggiungi_prodotto.Font = new System.Drawing.Font("Perpetua Titling MT", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aggiungi_prodotto.ForeColor = System.Drawing.Color.DodgerBlue;
            this.aggiungi_prodotto.Location = new System.Drawing.Point(12, 103);
            this.aggiungi_prodotto.Name = "aggiungi_prodotto";
            this.aggiungi_prodotto.Size = new System.Drawing.Size(358, 76);
            this.aggiungi_prodotto.TabIndex = 0;
            this.aggiungi_prodotto.Text = "AGGIUNGI PRODOTTO";
            this.aggiungi_prodotto.UseVisualStyleBackColor = true;
            this.aggiungi_prodotto.Click += new System.EventHandler(this.aggiungi_prodotto_Click);
            // 
            // modifica_prodotto
            // 
            this.modifica_prodotto.Font = new System.Drawing.Font("Perpetua Titling MT", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modifica_prodotto.ForeColor = System.Drawing.Color.DodgerBlue;
            this.modifica_prodotto.Location = new System.Drawing.Point(196, 241);
            this.modifica_prodotto.Name = "modifica_prodotto";
            this.modifica_prodotto.Size = new System.Drawing.Size(181, 76);
            this.modifica_prodotto.TabIndex = 1;
            this.modifica_prodotto.Text = "MODIFICA PRODOTTO";
            this.modifica_prodotto.UseVisualStyleBackColor = true;
            this.modifica_prodotto.Click += new System.EventHandler(this.modifica_prodotto_Click);
            // 
            // elimina_prodotto
            // 
            this.elimina_prodotto.Font = new System.Drawing.Font("Perpetua Titling MT", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.elimina_prodotto.ForeColor = System.Drawing.Color.DodgerBlue;
            this.elimina_prodotto.Location = new System.Drawing.Point(189, 367);
            this.elimina_prodotto.Name = "elimina_prodotto";
            this.elimina_prodotto.Size = new System.Drawing.Size(181, 76);
            this.elimina_prodotto.TabIndex = 2;
            this.elimina_prodotto.Text = "ELIMINA PRODOTTO";
            this.elimina_prodotto.UseVisualStyleBackColor = true;
            this.elimina_prodotto.Click += new System.EventHandler(this.elimina_prodotto_Click);
            // 
            // resetta_file
            // 
            this.resetta_file.Font = new System.Drawing.Font("Perpetua Titling MT", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetta_file.ForeColor = System.Drawing.Color.DodgerBlue;
            this.resetta_file.Location = new System.Drawing.Point(20, 241);
            this.resetta_file.Name = "resetta_file";
            this.resetta_file.Size = new System.Drawing.Size(163, 76);
            this.resetta_file.TabIndex = 3;
            this.resetta_file.Text = "RESETTA FILE";
            this.resetta_file.UseVisualStyleBackColor = true;
            this.resetta_file.Click += new System.EventHandler(this.resetta_file_Click);
            // 
            // apri_file
            // 
            this.apri_file.Font = new System.Drawing.Font("Perpetua Titling MT", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apri_file.ForeColor = System.Drawing.Color.DodgerBlue;
            this.apri_file.Location = new System.Drawing.Point(12, 493);
            this.apri_file.Name = "apri_file";
            this.apri_file.Size = new System.Drawing.Size(358, 92);
            this.apri_file.TabIndex = 4;
            this.apri_file.Text = "VISUALIZZA FILE";
            this.apri_file.UseVisualStyleBackColor = true;
            this.apri_file.Click += new System.EventHandler(this.apri_file_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Ivory;
            this.label1.Location = new System.Drawing.Point(5, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(341, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "CRUD CON ACCESSO SEQUENZIALE22F";
            // 
            // eliminazione_logica
            // 
            this.eliminazione_logica.AutoSize = true;
            this.eliminazione_logica.Font = new System.Drawing.Font("Perpetua Titling MT", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eliminazione_logica.ForeColor = System.Drawing.Color.Azure;
            this.eliminazione_logica.Location = new System.Drawing.Point(82, 168);
            this.eliminazione_logica.Name = "eliminazione_logica";
            this.eliminazione_logica.Size = new System.Drawing.Size(259, 25);
            this.eliminazione_logica.TabIndex = 6;
            this.eliminazione_logica.Text = "Cancellazione logica";
            this.eliminazione_logica.UseVisualStyleBackColor = true;
            this.eliminazione_logica.CheckedChanged += new System.EventHandler(this.eliminazione_logica_CheckedChanged);
            // 
            // eliminazione_fisica
            // 
            this.eliminazione_fisica.AutoSize = true;
            this.eliminazione_fisica.Font = new System.Drawing.Font("Perpetua Titling MT", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eliminazione_fisica.ForeColor = System.Drawing.Color.Azure;
            this.eliminazione_fisica.Location = new System.Drawing.Point(82, 241);
            this.eliminazione_fisica.Name = "eliminazione_fisica";
            this.eliminazione_fisica.Size = new System.Drawing.Size(247, 25);
            this.eliminazione_fisica.TabIndex = 7;
            this.eliminazione_fisica.Text = "Cancellazione fisica";
            this.eliminazione_fisica.UseVisualStyleBackColor = true;
            this.eliminazione_fisica.CheckedChanged += new System.EventHandler(this.eliminazione_fisica_CheckedChanged);
            // 
            // annulla
            // 
            this.annulla.Font = new System.Drawing.Font("Perpetua Titling MT", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.annulla.ForeColor = System.Drawing.Color.DodgerBlue;
            this.annulla.Location = new System.Drawing.Point(120, 323);
            this.annulla.Name = "annulla";
            this.annulla.Size = new System.Drawing.Size(140, 78);
            this.annulla.TabIndex = 8;
            this.annulla.Text = "ANNULLA CANCELLAZIONE";
            this.annulla.UseVisualStyleBackColor = true;
            this.annulla.Click += new System.EventHandler(this.annulla_Click);
            // 
            // titolo_elimina
            // 
            this.titolo_elimina.AutoSize = true;
            this.titolo_elimina.Font = new System.Drawing.Font("Palatino Linotype", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titolo_elimina.ForeColor = System.Drawing.Color.Ivory;
            this.titolo_elimina.Location = new System.Drawing.Point(11, 14);
            this.titolo_elimina.Name = "titolo_elimina";
            this.titolo_elimina.Size = new System.Drawing.Size(320, 31);
            this.titolo_elimina.TabIndex = 9;
            this.titolo_elimina.Text = "Scegli il tipo di cancellazione";
            // 
            // trova_indice
            // 
            this.trova_indice.Font = new System.Drawing.Font("Perpetua Titling MT", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trova_indice.ForeColor = System.Drawing.Color.DodgerBlue;
            this.trova_indice.Location = new System.Drawing.Point(20, 364);
            this.trova_indice.Name = "trova_indice";
            this.trova_indice.Size = new System.Drawing.Size(163, 82);
            this.trova_indice.TabIndex = 10;
            this.trova_indice.Text = "TROVA INDICE PRODOTTO";
            this.trova_indice.UseVisualStyleBackColor = true;
            this.trova_indice.Click += new System.EventHandler(this.trova_indice_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.ClientSize = new System.Drawing.Size(382, 597);
            this.Controls.Add(this.trova_indice);
            this.Controls.Add(this.titolo_elimina);
            this.Controls.Add(this.annulla);
            this.Controls.Add(this.eliminazione_fisica);
            this.Controls.Add(this.eliminazione_logica);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.apri_file);
            this.Controls.Add(this.resetta_file);
            this.Controls.Add(this.elimina_prodotto);
            this.Controls.Add(this.modifica_prodotto);
            this.Controls.Add(this.aggiungi_prodotto);
            this.Name = "Form1";
            this.Text = "FINESTRA22F";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button aggiungi_prodotto;
        private System.Windows.Forms.Button modifica_prodotto;
        private System.Windows.Forms.Button elimina_prodotto;
        private System.Windows.Forms.Button resetta_file;
        private System.Windows.Forms.Button apri_file;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox eliminazione_logica;
        private System.Windows.Forms.CheckBox eliminazione_fisica;
        private System.Windows.Forms.Button annulla;
        private System.Windows.Forms.Label titolo_elimina;
        private System.Windows.Forms.Button trova_indice;
    }
}

