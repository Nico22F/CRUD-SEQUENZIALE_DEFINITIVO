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
            else // riaggiorno l'array con i nomi e le posizioni dei prodotti
            {
                AggiornoArray();
            }

            // rendo invisibili alcuni elementi

            eliminazione_fisica.Visible = false;
            eliminazione_logica.Visible = false;
            annulla.Visible = false;
            titolo_elimina.Visible = false;
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

        public void AggiungiProdotto(string prezzo, string nome, int posizione)
        {
            FileStream file = new FileStream("./file_crud.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryWriter bw = new BinaryWriter(file);

            // nome prodotto

            string riga = nome.PadRight(32) + prezzo.PadRight(32);
            byte[] strInByte = Encoding.Default.GetBytes(riga);
            bw.BaseStream.Seek((posizione) * size, SeekOrigin.Begin);
            bw.Write(strInByte);

            counter_riga++;

            file.Close();
            bw.Close();
        }

        // modifica un prodotto della lista
        public void ModificaProdotto(int posizione)
        {
            FileStream file = new FileStream("./file_crud.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryReader br = new BinaryReader(file);

            string nomeProdotto, PrezzoProdotto;

            br.BaseStream.Seek((posizione) * size, 0);
            //nome prodotto
            byte[] bit = br.ReadBytes(32);
            nomeProdotto = Encoding.ASCII.GetString(bit, 0, bit.Length).Trim();

            // prezzo prodotto
            bit = br.ReadBytes(32);
            PrezzoProdotto = Encoding.ASCII.GetString(bit, 0, bit.Length).Trim();

            // input modfica prodotto nome

            string titolo_input = "Modifica Prodotto - NOME", frase = "Inserisci il nome del prodotto che vuoi modifcare";
            object input_aggiungiprodotto = Interaction.InputBox(frase, titolo_input, nomeProdotto);

            if ((string)input_aggiungiprodotto == "") // user esce o lascia il campo vuoto
            {
                MessageBox.Show("Errore nella modifica del prodotto", "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                string nome_temporaneo = (string)input_aggiungiprodotto; // salvo il nome in una variabile temporanea, verrà scritto nel file solo se il prezzo verrà scritto nel modo corretto

                // input prezzo

                titolo_input = "Modifica Prodotto - Prezzo"; frase = "Inserisci il prezzo del prodotto che vuoi modificare";
                input_aggiungiprodotto = Interaction.InputBox(frase, titolo_input, PrezzoProdotto);
                int prova_numero = 0; // se la conversione risultasse corretta (questa sotto) la stringa convertita in float finirebbe qua

                // tryparse serve per vedere se la conversione funziona
                if (!int.TryParse((string)input_aggiungiprodotto, out prova_numero))
                {
                    MessageBox.Show("Errore nell'aggiunta del prodotto", "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                }
                else
                {
                    // se non da nessun errore, dim (posizione) aumenta e viene aggiunto il prodotto al file

                    nomiprodotti[posizione] = nome_temporaneo;

                    // modifica del prodotto su file
                    file.Close();
                    br.Close();
                    AggiungiProdotto((string)input_aggiungiprodotto, nome_temporaneo,posizione);
                }
            }
            file.Close();
            br.Close();
        }

        // quando apro il programma, se è presente un file (precedentemente creato), riaggiorno l'array

        public void AggiornoArray()
        {
            FileStream file = new FileStream("./file_crud.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryReader br = new BinaryReader(file);

            string nomeProdotto;
            bool uscita = false;
            
            while(uscita == false) 
            {
                br.BaseStream.Seek((dim) * size, 0);
                //nome prodotto
                byte[] bit = br.ReadBytes(32);
                nomeProdotto = Encoding.ASCII.GetString(bit, 0, bit.Length).Trim();

                // aggiungo all'array il nome del prodotto se non è nullo (@)

                if (nomeProdotto!="@")
                {
                    nomiprodotti[dim] = nomeProdotto;
                    dim++;
                }
                else
                {
                    uscita = true;
                }

            }

            file.Close();
            br.Close();
        }

        // funzione che resetta gli elementi dell'array

        public void ResetArray()
        {
            for (int i = 0;i < dim;i++) 
            {
                nomiprodotti[i] = null;
            }
            dim = 0;
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

                    AggiungiProdotto((string)input_aggiungiprodotto, nome_temporaneo, counter_riga-1);
                }
            }
        }

        // modifica un elemnto nel file
        private void modifica_prodotto_Click(object sender, EventArgs e)
        {
            string titolo_input = "MODIFICA Prodotto - NOME", esempio = "nome prodotto", frase = "Inserisci il nome del prodotto che vuoi modificare";
            object input_modificaprodotto = Interaction.InputBox(frase, titolo_input, esempio);
            bool errore = true;

            if ((string)input_modificaprodotto == "") // user esce o lascia il campo vuoto
            {
                MessageBox.Show("Errore nella modifica del prodotto", "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else // se inserisce input "corretto"
            {
                for (int i = 0; i < dim; i++) // cerca il nome del prodotto nell'array
                {
                    if((string)input_modificaprodotto == nomiprodotti[i]) // prodotto trovato
                    {
                        ModificaProdotto(i);
                        errore = false;
                        break;
                    }
                }

                // se non trova nessun nome (input errato) allora lo segnala all'utente

                if (errore == true)
                {
                    MessageBox.Show("Errore nella modifica del prodotto. Nome prodotto non esistente", "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }

            }
       }

        // elimina il prodotto con la cancellazione logica o fisica (scelta dall'utente9
        private void elimina_prodotto_Click(object sender, EventArgs e)
        {
           // rendo invisibili alcuni elementi

            aggiungi_prodotto.Visible = false;
            modifica_prodotto.Visible=false;
            elimina_prodotto.Visible = false;
            resetta_file.Visible = false;
            apri_file.Visible = false;

            // rendo visibile le due scelte di cancellazione

            eliminazione_fisica.Visible = true;
            eliminazione_logica.Visible = true;
            annulla.Visible = true;
            titolo_elimina.Visible = true;
        }

        // resetta il file e riempie tutto con @
        private void resetta_file_Click(object sender, EventArgs e)
        {
            // prima di resettare chiede una conferma dall'utente

            DialogResult ConfermaReset = MessageBox.Show("Vuoi resettare l'intero file?", "RESET FILE", MessageBoxButtons.YesNo);

            if (ConfermaReset == DialogResult.Yes) // se l'utente clicca si
            {
                ResetFile(); // resetta file

                ResetArray(); //resetta array
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

        // annulla l'eliminazione di un prodotto
        private void annulla_Click(object sender, EventArgs e)
        {
            // rendo visibili alcuni elementi

            aggiungi_prodotto.Visible = true;
            modifica_prodotto.Visible = true;
            elimina_prodotto.Visible = true;
            resetta_file.Visible = true;
            apri_file.Visible = true;

            // rendo invisibile le due scelte di cancellazione

            eliminazione_fisica.Visible = false;
            eliminazione_logica.Visible = false;
            annulla.Visible = false;
            titolo_elimina.Visible=false;
        }

        // CANCELLAZIONE LOGICA
        private void eliminazione_logica_CheckedChanged(object sender, EventArgs e)
        {

        }

        // CANCELLAZIONE FISICA 
        private void eliminazione_fisica_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
