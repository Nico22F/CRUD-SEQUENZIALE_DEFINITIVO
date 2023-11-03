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
            this.SuspendLayout();
            // 
            // aggiungi_prodotto
            // 
            this.aggiungi_prodotto.Location = new System.Drawing.Point(122, 77);
            this.aggiungi_prodotto.Name = "aggiungi_prodotto";
            this.aggiungi_prodotto.Size = new System.Drawing.Size(163, 76);
            this.aggiungi_prodotto.TabIndex = 0;
            this.aggiungi_prodotto.Text = "AGGIUNGI PRODOTTO";
            this.aggiungi_prodotto.UseVisualStyleBackColor = true;
            this.aggiungi_prodotto.Click += new System.EventHandler(this.aggiungi_prodotto_Click);
            // 
            // modifica_prodotto
            // 
            this.modifica_prodotto.Location = new System.Drawing.Point(122, 159);
            this.modifica_prodotto.Name = "modifica_prodotto";
            this.modifica_prodotto.Size = new System.Drawing.Size(163, 76);
            this.modifica_prodotto.TabIndex = 1;
            this.modifica_prodotto.Text = "MODIFICA PRODOTTO";
            this.modifica_prodotto.UseVisualStyleBackColor = true;
            this.modifica_prodotto.Click += new System.EventHandler(this.modifica_prodotto_Click);
            // 
            // elimina_prodotto
            // 
            this.elimina_prodotto.Location = new System.Drawing.Point(122, 241);
            this.elimina_prodotto.Name = "elimina_prodotto";
            this.elimina_prodotto.Size = new System.Drawing.Size(163, 76);
            this.elimina_prodotto.TabIndex = 2;
            this.elimina_prodotto.Text = "ELIMINA PRODOTTO";
            this.elimina_prodotto.UseVisualStyleBackColor = true;
            this.elimina_prodotto.Click += new System.EventHandler(this.elimina_prodotto_Click);
            // 
            // resetta_file
            // 
            this.resetta_file.Location = new System.Drawing.Point(122, 323);
            this.resetta_file.Name = "resetta_file";
            this.resetta_file.Size = new System.Drawing.Size(163, 76);
            this.resetta_file.TabIndex = 3;
            this.resetta_file.Text = "RESETTA FILE";
            this.resetta_file.UseVisualStyleBackColor = true;
            this.resetta_file.Click += new System.EventHandler(this.resetta_file_Click);
            // 
            // apri_file
            // 
            this.apri_file.Location = new System.Drawing.Point(12, 420);
            this.apri_file.Name = "apri_file";
            this.apri_file.Size = new System.Drawing.Size(358, 165);
            this.apri_file.TabIndex = 4;
            this.apri_file.Text = "VISUALIZZA FILE";
            this.apri_file.UseVisualStyleBackColor = true;
            this.apri_file.Click += new System.EventHandler(this.apri_file_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(365, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "CRUD CON ACCESSO SEQUENZIALE22F";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 597);
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
    }
}

