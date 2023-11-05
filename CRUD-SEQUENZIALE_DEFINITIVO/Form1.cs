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

            dim = 0;

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

                if (nomeProdotto[0]!='@')
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

        // cancellazione logica

        public void CancellazioneLogica(int posizione)
        {
            FileStream file = new FileStream("./file_crud.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryWriter bw = new BinaryWriter(file);
            BinaryReader br = new BinaryReader(file);

            // copio la riga e aggiungo una § davanti alla riga così da renderlo eliminato (teoricamente)

            br.BaseStream.Seek((posizione) * size, 0);

            //nome prodotto
            byte[] bit = br.ReadBytes(32);
            string nomeProdotto = Encoding.ASCII.GetString(bit, 0, bit.Length).Trim();

            // prezzo prodotto
            bit = br.ReadBytes(32);
            string PrezzoProdotto = Encoding.ASCII.GetString(bit, 0, bit.Length).Trim();


            // riscrivo la riga
            string rigaeliminata =$"§{nomeProdotto.PadRight(31)}§{PrezzoProdotto.PadRight(31)}";
            byte[] strInByte = Encoding.Default.GetBytes(rigaeliminata);
            bw.BaseStream.Seek((posizione) * size, SeekOrigin.Begin);
            bw.Write(strInByte);
           

            file.Close();
            bw.Close();
            br.Close();

            // cancellazione nell'array

            nomiprodotti[posizione] = $"@{nomiprodotti[posizione]}";

        }

        // cancellazione fisica

        public void CancellazioneFisica(int posizione)
        {
            // cancellazione fisica nell'array

            for (int j = posizione, a = j + 1; j < dim; j++, a++)
            {
                nomiprodotti[j]= nomiprodotti[a];
                
            }
            
            // cancellazione fisica nel file

            FileStream file = new FileStream("./file_crud.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryWriter bw = new BinaryWriter(file);
            BinaryReader br = new BinaryReader(file);

            // nome prodotto

            string riga="";
           
            for (int j = posizione, a = j + 1; j < dim; j++, a++)
            {
                // posizionamento

                br.BaseStream.Seek((a) * size, 0);
                byte[] bit = br.ReadBytes(64);
                riga = Encoding.ASCII.GetString(bit, 0, bit.Length);

                // scambio righe

                bw.BaseStream.Seek((j) * size, SeekOrigin.Begin); // riga2 con riga 1
                byte[] strInByte = Encoding.Default.GetBytes(riga);
                bw.Write(strInByte);
                
            }
            dim--;

            file.Close();
            bw.Close();
            br.Close();
        }

        // funzione che trova l'indice di un prodotto nel file (in bit)

        public void IndiceProdotto(string prodotto)
        {
            int indice = 0;
            bool prodotto_trovato = false; // indica se i prodotto è stato trovato dall'utente

            for (int i = 0; i < dim; i++)
            {
                if (prodotto == nomiprodotti[i]) // se sono uguali
                {
                    indice = i * 64;
                    prodotto_trovato = true;
                    break;
                }
            }


            if (prodotto_trovato == false) // se è falso, l'input dell'utente è scorretto. Segnala errore
            {
                MessageBox.Show("Input errato. Il prodotto non esiste nella lista corrente", "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else // se è vero, indica l'indice
            {
                MessageBox.Show($"il {prodotto} si trova dal bit {indice} fino al bit {indice+63}");
            }
        }

        // array che conterrà i nomi e le posizioni

        public string[] nomiprodotti = new string[100];
        public int dim; // posizione 
       
        // variabili pubbliche

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

                    // aggiunta del prodotto su file

                    AggiungiProdotto((string)input_aggiungiprodotto, nome_temporaneo, dim);

                    dim++;
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
            trova_indice.Visible = false;

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
            trova_indice.Visible = true;

            // rendo invisibile le due scelte di cancellazione

            eliminazione_fisica.Visible = false;
            eliminazione_logica.Visible = false;
            annulla.Visible = false;
            titolo_elimina.Visible=false;
        }

        // CANCELLAZIONE LOGICA
        private void eliminazione_logica_CheckedChanged(object sender, EventArgs e)
        {
            // rendo visibili alcuni elementi

            aggiungi_prodotto.Visible = true;
            modifica_prodotto.Visible = true;
            elimina_prodotto.Visible = true;
            resetta_file.Visible = true;
            apri_file.Visible = true;
            trova_indice.Visible=true;

            // rendo invisibile le due scelte di cancellazione

            eliminazione_fisica.Visible = false;
            eliminazione_logica.Visible = false;
            annulla.Visible = false;
            titolo_elimina.Visible = false;

            // input prodotto da eliminare

            string titolo_input = "Eliminazione Prodotto - NOME", esempio = "nome prodotto", frase = "Inserisci il nome del prodotto che vuoi eliminare";
            object input_eliminaprodotto = Interaction.InputBox(frase, titolo_input, esempio);
            bool errore = true;

            if ((string)input_eliminaprodotto == "") // user esce o lascia il campo vuoto
            {
                MessageBox.Show("Errore nell'eliminazione del prodotto", "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else // se inserisce input "corretto"
            {
                for (int i = 0; i < dim; i++) // cerca il nome del prodotto nell'array
                {
                    if ((string)input_eliminaprodotto == nomiprodotti[i]) // prodotto trovato
                    {
                        CancellazioneLogica(i);
                        errore = false;
                        break;
                    }
                }

                // se non trova nessun nome (input errato) allora lo segnala all'utente

                if (errore == true)
                {
                    MessageBox.Show("Errore nell'eliminazione del prodotto. Nome prodotto non esistente", "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
        }

        // CANCELLAZIONE FISICA 
        private void eliminazione_fisica_CheckedChanged(object sender, EventArgs e)
        {
            // rendo visibili alcuni elementi

            aggiungi_prodotto.Visible = true;
            modifica_prodotto.Visible = true;
            elimina_prodotto.Visible = true;
            resetta_file.Visible = true;
            apri_file.Visible = true;
            trova_indice.Visible = true;

            // rendo invisibile le due scelte di cancellazione

            eliminazione_fisica.Visible = false;
            eliminazione_logica.Visible = false;
            annulla.Visible = false;
            titolo_elimina.Visible = false;

            // input prodotto da eliminare

            string titolo_input = "Eliminazione Prodotto - NOME", esempio = "nome prodotto", frase = "Inserisci il nome del prodotto che vuoi eliminare";
            object input_eliminaprodotto = Interaction.InputBox(frase, titolo_input, esempio);
            bool errore = true;

            if ((string)input_eliminaprodotto == "") // user esce o lascia il campo vuoto
            {
                MessageBox.Show("Errore nella modifica del prodotto", "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else // se inserisce input "corretto"
            {
                for (int i = 0; i < dim; i++) // cerca il nome del prodotto nell'array
                {
                    if ((string)input_eliminaprodotto == nomiprodotti[i]) // prodotto trovato
                    {
                        CancellazioneFisica(i);
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

        // riferisce all'utente l'indice di un prodotto scelto da lui
        private void trova_indice_Click(object sender, EventArgs e)
        {
            string titolo_input = "Ricerca indice prodotto - NOME", esempio = "nome prodotto", frase = "Inserisci il nome del prodotto di cui vuoi trovare l'indice";
            object input_ricercaprodotto = Interaction.InputBox(frase, titolo_input, esempio);

            if ((string)input_ricercaprodotto == "") // user esce o lascia il campo vuoto
            {
                MessageBox.Show("Errore nella ricerca dell'indice del prodotto", "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else // se inserisce input "corretto"
            {
                IndiceProdotto((string)input_ricercaprodotto);
            }
        }

    }
}
