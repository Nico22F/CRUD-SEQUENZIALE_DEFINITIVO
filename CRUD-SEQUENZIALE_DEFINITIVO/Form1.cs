using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Reflection;

namespace CRUD_SEQUENZIALE_DEFINITIVO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // controllo che il file sia presente. In caso contrario, lo creo

            if (File.Exists("./file_crud.dat") == false)
            {
                ResetFile();
            }
        }

        // FUNZIONI UTILIZZATE

        public void ResetFile()
        {
            FileStream file = new FileStream("./file_crud.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryWriter bw = new BinaryWriter(file);
            string prodotto = "@", prezzo = "@";
            byte[] strInByte;

            string riga = prodotto.PadRight(32) + prezzo.PadRight(32);
            strInByte = Encoding.Default.GetBytes(riga);

            for (int i = 1; i <= 100; i++)
            {
                bw.Write(strInByte);
            }

            file.Close();
            bw.Close();
        }

        public void AggiungiProdotto(string prezzo, string nome)
        {
            FileStream file = new FileStream("./file_crud.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryWriter bw = new BinaryWriter(file);

            // nome prodotto

            string riga = nome.PadRight(32) + prezzo.PadRight(32);
            byte[] strInByte = Encoding.Default.GetBytes(riga);
            bw.BaseStream.Seek((counter_riga - 1) * size, SeekOrigin.Begin);
            bw.Write(strInByte);

            counter_riga++;

            file.Close();
            bw.Close();
        }

        // array che conterrà i nomi e le posizioni

        public string[] nomiprodotti = new string[100];
        public int dim; // posizione 
       
        // variabili pubbliche

        public int counter_riga = 1;
        const int size = 64;


        // aggiunge un prodotto alla lista
        private void aggiungi_prodotto_Click(object sender, EventArgs e)
        {
            // input box nome e do while per input corretto
            // nel caso l'utente esca quando inserisce il nome oppure lascia il campo vuoto, non verrà chiesto il prezzo


            string titolo_input = "Aggiungi Prodotto - NOME", esempio = "nome prodotto", frase = "Inserisci il nome del prodotto che vuoi aggiungere";
            object input_aggiungiprodotto = Interaction.InputBox(frase, titolo_input, esempio);

            if ((string)input_aggiungiprodotto == "") // user esce o lascia il campo vuoto
            {
                MessageBox.Show("Errore nell'aggiunta del prodotto", "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                nomiprodotti[dim] = (string)input_aggiungiprodotto;
                string nome_temporaneo = (string)input_aggiungiprodotto; // salvo il nome in una variabile temporanea, verrà scritto nel file solo se il prezzo verrà scritto nel modo corretto

                // input prezzo

                titolo_input = "Aggiungi Prodotto - Prezzo"; esempio = "prezzo prodotto"; frase = "Inserisci il prezzo del prodotto che vuoi aggiungere";
                input_aggiungiprodotto = Interaction.InputBox(frase, titolo_input, esempio);
                int prova_numero = 0; // se la conversione risultasse corretta (questa sotto) la stringa convertita in float finirebbe qua

                // tryparse serve per vedere se la conversione funziona
                if (!int.TryParse((string)input_aggiungiprodotto, out prova_numero))
                {
                    MessageBox.Show("Errore nell'aggiunta del prodotto", "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    nomiprodotti[dim] = null;
                }
                else
                {
                    // se non da nessun errore, dim (posizione) aumenta e viene aggiunto il prodotto al file

                    dim++;

                    // aggiunta del prodotto su file

                    AggiungiProdotto((string)input_aggiungiprodotto, nome_temporaneo);
                }
            }
        }

        private void modifica_prodotto_Click(object sender, EventArgs e)
        {

        }

        private void elimina_prodotto_Click(object sender, EventArgs e)
        {

        }

        // resetta il file e riempie tutto con @
        private void resetta_file_Click(object sender, EventArgs e)
        {
            // prima di resettare chiede una conferma dall'utente

            DialogResult ConfermaReset = MessageBox.Show("Vuoi resettare l'intero file?", "RESET FILE", MessageBoxButtons.YesNo);

            if (ConfermaReset == DialogResult.Yes) // se l'utente clicca si
            {
                ResetFile();
            }
        }

        // quando cliccato, apre il file dove sono visualizzati tutti i prodotti
        private void apri_file_Click(object sender, EventArgs e)
        {
            // trova il percorso del file

            string percorsoFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "file_crud.dat");

            // apre il file

            Process.Start(percorsoFile);
        }

    }
}
