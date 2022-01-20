using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Sekretariat
{
    public partial class Sekretariat : Form
    {
        public Sekretariat()
        {
            InitializeComponent();
        }

          

        private void zakończToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonDodaj_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textImieUczen.Text) || String.IsNullOrEmpty(textNazwiskoUczen.Text) || String.IsNullOrEmpty(textNazwiskoPUczen.Text) || String.IsNullOrEmpty(textImiematkiUczen.Text) || String.IsNullOrEmpty(textImieojcaUczen.Text) || dataUrodzeniaUczen == null || String.IsNullOrEmpty(textPeselUczen.Text) || String.IsNullOrEmpty(textPlecUczen.Text) || String.IsNullOrEmpty(textKlasaUczen.Text) || String.IsNullOrEmpty(textGrupaUczen.Text))
            {
                MessageBox.Show("Nie dodano wymaganych wartości!", "Błąd",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                dataGridViewUczen.Rows.Add(textImieUczen.Text, text2ImieUczen.Text, textNazwiskoUczen.Text, textNazwiskoPUczen.Text, textImiematkiUczen.Text, textImieojcaUczen.Text, dataUrodzeniaUczen.Text, textPeselUczen.Text, textPlecUczen.Text, textKlasaUczen.Text, textGrupaUczen.Text);
            }
        }

        private void buttonDodajNauczyciel_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textImieNauczyciel.Text) || String.IsNullOrEmpty(textNazwiskoNauczyciel.Text) || String.IsNullOrEmpty(textNazwiskoPNauczyciel.Text) || String.IsNullOrEmpty(textImiematkiNauczyciel.Text) || String.IsNullOrEmpty(textImieojcaNauczyciel.Text) || dataUrodzeniaNauczyciel == null || String.IsNullOrEmpty(textPeselNauczyciel.Text) || String.IsNullOrEmpty(textPlecNauczyciel.Text) || String.IsNullOrEmpty(textKlasyNauczyciel.Text) || String.IsNullOrEmpty(textPrzedmiotyNauczyciel.Text) || dataZatrudnieniaNauczyciel == null)
            {
                MessageBox.Show("Nie dodano wymaganych wartości!", "Błąd",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                dataGridViewNauczyciel.Rows.Add(textImieNauczyciel.Text, text2ImieNauczyciel.Text, textNazwiskoNauczyciel.Text, textNazwiskoPNauczyciel.Text, textImiematkiNauczyciel.Text, textImieojcaNauczyciel.Text, dataUrodzeniaNauczyciel.Text, textPeselNauczyciel.Text, textPlecNauczyciel.Text, textWychowawstwoNauczyciel.Text,textPrzedmiotyNauczyciel.Text, textKlasyNauczyciel.Text, dataZatrudnieniaNauczyciel.Text);
            }
        }

        private void buttonDodajPracownik_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textImiePracownik.Text) || String.IsNullOrEmpty(textNazwiskoPracownik.Text) || String.IsNullOrEmpty(textNazwiskoPPracownik.Text) || String.IsNullOrEmpty(textImiematkiPracownik.Text) || String.IsNullOrEmpty(textImieojcaPracownik.Text) || dataUrodzeniaPracownik == null || String.IsNullOrEmpty(textPeselPracownik.Text) || String.IsNullOrEmpty(textPlecPracownik.Text) || String.IsNullOrEmpty(textEtatPracownik.Text) || String.IsNullOrEmpty(textStanowiskoPracownik.Text) || dataZatrudnieniaPracownik == null)
            {
                MessageBox.Show("Nie dodano wymaganych wartości!", "Błąd",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                dataGridViewPracownik.Rows.Add(textImiePracownik.Text, text2ImiePracownik.Text, textNazwiskoPracownik.Text, textNazwiskoPPracownik.Text, textImiematkiPracownik.Text, textImieojcaPracownik.Text, dataUrodzeniaPracownik.Text, textPeselPracownik.Text, textPlecPracownik.Text, textEtatPracownik.Text, textStanowiskoPracownik.Text, dataZatrudnieniaPracownik.Text);
            }
        }

        private void buttonZapiszUczen_Click(object sender, EventArgs e)
        {

            TextWriter writer = new StreamWriter(@"C:\Users\pryce\source\repos\Sekretariat\Sekretariat\Uczniowie.txt");
            for (int i = 0; i < dataGridViewUczen.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridViewUczen.Columns.Count; j++)
                {
                    writer.Write("\t" + dataGridViewUczen.Rows[i].Cells[j].Value.ToString() + "\t" + "/");
                }
                writer.WriteLine("");
            }
            writer.Close();
            MessageBox.Show("Zapisano");
        }
    

        private void buttonWczytajUczen_Click(object sender, EventArgs e)
        {
            dataGridViewUczen.Rows.Clear();
            dataGridViewUczen.Refresh();
                string[] lines = File.ReadAllLines(@"C:\Users\pryce\source\repos\Sekretariat\Sekretariat\Uczniowie.txt");
                string[] values;

                for (int i = 0; i < lines.Length; i++)
                {
                    values = lines[i].ToString().Split('/');
                    string[] row = new string[values.Length];

                    for (int j = 0; j < values.Length; j++ ){
                    row[j] = values[j].Trim();
                }
                    dataGridViewUczen.Rows.Add(row);
                }
        }

        private void buttonEdytujUczen_Click(object sender, EventArgs e)
        {
            DataGridViewRow newDataRow = dataGridViewUczen.Rows[indexRow];
            newDataRow.Cells[0].Value = textImieUczen.Text;
            newDataRow.Cells[1].Value = text2ImieUczen.Text;
            newDataRow.Cells[2].Value = textNazwiskoUczen.Text;
            newDataRow.Cells[3].Value = textNazwiskoPUczen.Text;
            newDataRow.Cells[4].Value = textImiematkiUczen.Text;
            newDataRow.Cells[5].Value = textImieojcaUczen.Text;
            newDataRow.Cells[6].Value = dataUrodzeniaUczen.Text;
            newDataRow.Cells[7].Value = textPeselUczen.Text;
            newDataRow.Cells[8].Value = textPlecUczen.Text;
            newDataRow.Cells[9].Value = textKlasaUczen.Text;
            newDataRow.Cells[10].Value = textGrupaUczen.Text;
        }

        int indexRow;
        private void dataGridViewUczen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = e.RowIndex;
            DataGridViewRow row = dataGridViewUczen.Rows[indexRow];

            textImieUczen.Text = row.Cells[0].Value.ToString();
            text2ImieUczen.Text = row.Cells[1].Value.ToString();
            textNazwiskoUczen.Text = row.Cells[2].Value.ToString();
            textNazwiskoPUczen.Text = row.Cells[3].Value.ToString();
            textImiematkiUczen.Text = row.Cells[4].Value.ToString();
            textImieojcaUczen.Text = row.Cells[5].Value.ToString();
            textPeselUczen.Text = row.Cells[7].Value.ToString();
            textPlecUczen.Text = row.Cells[8].Value.ToString();
            textKlasaUczen.Text = row.Cells[9].Value.ToString();
            textGrupaUczen.Text = row.Cells[10].Value.ToString();
                       
        }

        private void buttonZapiszNauczyciel_Click(object sender, EventArgs e)
        {
            TextWriter writer = new StreamWriter(@"C:\Users\pryce\source\repos\Sekretariat\Sekretariat\Nauczyciele.txt");
            for (int i = 0; i < dataGridViewNauczyciel.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridViewNauczyciel.Columns.Count; j++)
                {
                    writer.Write("\t" + dataGridViewNauczyciel.Rows[i].Cells[j].Value.ToString() + "\t" + "/");
                }
                writer.WriteLine("");
            }
            writer.Close();
            MessageBox.Show("Zapisano");
        }

        private void buttonWczytajNauczyciel_Click(object sender, EventArgs e)
        {
            dataGridViewNauczyciel.Rows.Clear();
            dataGridViewNauczyciel.Refresh();
            string[] lines = File.ReadAllLines(@"C:\Users\pryce\source\repos\Sekretariat\Sekretariat\Nauczyciele.txt");
            string[] values;

            for (int i = 0; i < lines.Length; i++)
            {
                values = lines[i].ToString().Split('/');
                string[] row = new string[values.Length];

                for (int j = 0; j < values.Length; j++)
                {
                    row[j] = values[j].Trim();
                }
                dataGridViewNauczyciel.Rows.Add(row);
            }
        }

        private void dataGridViewNauczyciel_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = e.RowIndex;
            DataGridViewRow row = dataGridViewNauczyciel.Rows[indexRow];

            textImieNauczyciel.Text = row.Cells[0].Value.ToString();
            text2ImieNauczyciel.Text = row.Cells[1].Value.ToString();
            textNazwiskoNauczyciel.Text = row.Cells[2].Value.ToString();
            textNazwiskoPNauczyciel.Text = row.Cells[3].Value.ToString();
            textImiematkiNauczyciel.Text = row.Cells[4].Value.ToString();
            textImieojcaNauczyciel.Text = row.Cells[5].Value.ToString();
            textPeselNauczyciel.Text = row.Cells[7].Value.ToString();
            textPlecNauczyciel.Text = row.Cells[8].Value.ToString();
            textWychowawstwoNauczyciel.Text = row.Cells[9].Value.ToString();
            textPrzedmiotyNauczyciel.Text = row.Cells[10].Value.ToString();
            textKlasyNauczyciel.Text = row.Cells[11].Value.ToString();
        }

        private void buttonEdytujNauczyciel_Click(object sender, EventArgs e)
        {
            DataGridViewRow newDataRow = dataGridViewNauczyciel.Rows[indexRow];
            newDataRow.Cells[0].Value = textImieNauczyciel.Text;
            newDataRow.Cells[1].Value = text2ImieNauczyciel.Text;
            newDataRow.Cells[2].Value = textNazwiskoNauczyciel.Text;
            newDataRow.Cells[3].Value = textNazwiskoPNauczyciel.Text;
            newDataRow.Cells[4].Value = textImiematkiNauczyciel.Text;
            newDataRow.Cells[5].Value = textImieojcaNauczyciel.Text;
            newDataRow.Cells[6].Value = dataUrodzeniaNauczyciel.Text;
            newDataRow.Cells[7].Value = textPeselNauczyciel.Text;
            newDataRow.Cells[8].Value = textPlecNauczyciel.Text;
            newDataRow.Cells[9].Value = textWychowawstwoNauczyciel.Text;
            newDataRow.Cells[10].Value = textPrzedmiotyNauczyciel.Text;
            newDataRow.Cells[11].Value = textKlasyNauczyciel.Text;
            newDataRow.Cells[12].Value = dataZatrudnieniaNauczyciel.Text;
        }

        private void buttonZapiszPracownik_Click(object sender, EventArgs e)
        {
            TextWriter writer = new StreamWriter(@"C:\Users\pryce\source\repos\Sekretariat\Sekretariat\Pracownicy.txt");
            for (int i = 0; i < dataGridViewPracownik.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridViewPracownik.Columns.Count; j++)
                {
                    writer.Write("\t" + dataGridViewPracownik.Rows[i].Cells[j].Value.ToString() + "\t" + "/");
                }
                writer.WriteLine("");
            }
            writer.Close();
            MessageBox.Show("Zapisano");
        }

        private void buttonWczytajPracownik_Click(object sender, EventArgs e)
        {
            dataGridViewPracownik.Rows.Clear();
            dataGridViewPracownik.Refresh();
            string[] lines = File.ReadAllLines(@"C:\Users\pryce\source\repos\Sekretariat\Sekretariat\Pracownicy.txt");
            string[] values;

            for (int i = 0; i < lines.Length; i++)
            {
                values = lines[i].ToString().Split('/');
                string[] row = new string[values.Length];

                for (int j = 0; j < values.Length; j++)
                {
                    row[j] = values[j].Trim();
                }
                dataGridViewPracownik.Rows.Add(row);
            }
        }

        private void dataGridViewPracownik_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = e.RowIndex;
            DataGridViewRow row = dataGridViewPracownik.Rows[indexRow];

            textImiePracownik.Text = row.Cells[0].Value.ToString();
            text2ImiePracownik.Text = row.Cells[1].Value.ToString();
            textNazwiskoPracownik.Text = row.Cells[2].Value.ToString();
            textNazwiskoPPracownik.Text = row.Cells[3].Value.ToString();
            textImiematkiPracownik.Text = row.Cells[4].Value.ToString();
            textImieojcaPracownik.Text = row.Cells[5].Value.ToString();
            textPeselPracownik.Text = row.Cells[7].Value.ToString();
            textPlecPracownik.Text = row.Cells[8].Value.ToString();
            textEtatPracownik.Text = row.Cells[9].Value.ToString();
            textStanowiskoPracownik.Text = row.Cells[10].Value.ToString();
        }

        private void buttonEdytujPracownik_Click(object sender, EventArgs e)
        {
            DataGridViewRow newDataRow = dataGridViewPracownik.Rows[indexRow];
            newDataRow.Cells[0].Value = textImiePracownik.Text;
            newDataRow.Cells[1].Value = text2ImiePracownik.Text;
            newDataRow.Cells[2].Value = textNazwiskoPracownik.Text;
            newDataRow.Cells[3].Value = textNazwiskoPPracownik.Text;
            newDataRow.Cells[4].Value = textImiematkiPracownik.Text;
            newDataRow.Cells[5].Value = textImieojcaPracownik.Text;
            newDataRow.Cells[6].Value = dataUrodzeniaPracownik.Text;
            newDataRow.Cells[7].Value = textPeselPracownik.Text;
            newDataRow.Cells[8].Value = textPlecPracownik.Text;
            newDataRow.Cells[9].Value = textEtatPracownik.Text;
            newDataRow.Cells[10].Value = textStanowiskoPracownik.Text;
            newDataRow.Cells[11].Value = dataZatrudnieniaPracownik.Text;
        }
    }
}
