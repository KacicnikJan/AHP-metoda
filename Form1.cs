using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ahp_metoda_projekt;
using System.IO;

namespace ahp_metoda_projekt
{
    public partial class Form1 : Form
    {
        public List<Parameter> parametri;
        public TreeNode trenutnoVozlisce;
        public DataGridView alternativeGridView;
        public List<Alternativa> alternative;

        public Form1()
        {
            parametri = new List<Parameter>();
            trenutnoVozlisce = new TreeNode();
            alternative = new List<Alternativa>();
            alternativeGridView = new DataGridView();
            // Tukaj doodamo "event handler" za dinamicno ustvarjen datagridview
            alternativeGridView.CellEndEdit += new DataGridViewCellEventHandler(NasprotnaVrednost);
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            Zacetek zacetek = new Zacetek();
            var result = zacetek.ShowDialog();

            if ((result == DialogResult.OK) && (zacetek.textBoxProblemName.Text != ""))
            {
                zacetek.Close();
                string problemName = zacetek.textBoxProblemName.Text;

                TreeNode rootNode = new TreeNode(problemName);
                treeView.Nodes.Add(rootNode);
            }
            graf_btn.Enabled = false;
        }
        
        private void DodajVozlisce_btn(object sender, EventArgs e)
        {
            try
            {
                TreeNode izbranoVozlisce;
                // Če ima drevo kakšno vozlišče ter izbrano vozlišče
                if ((treeView.Nodes.Count != 0) && (treeView.SelectedNode != null))
                {
                    // Izberemo vozlišče, ter dodamo novo
                    izbranoVozlisce = treeView.SelectedNode;
                    izbranoVozlisce.Nodes.Add(new TreeNode(textBoxAddNode.Text));
                }
                // Če ni vozlišča, dodamo "Root node"
                else
                {
                    treeView.Nodes.Add(new TreeNode(textBoxAddNode.Text));
                }

                OsveziDataGridOče();
            }
            catch { }
        }
        
        private void izbrisiVozlisce_btn(object sender, EventArgs e)
        {
            try
            {
                TreeNode izbranoVozlisce = treeView.SelectedNode;
                izbranoVozlisce.Remove();
            }
            catch { }
        }
        
        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            OsveziDataGridOče();
        }
                
        private void shraniPodatkeOParametru(object sender, EventArgs e)
        {
            try
            {
                int steviloStolpcev = dataGridView1.Columns.Count;
                int steviloVrstic = dataGridView1.Rows.Count;
                
                for (int i = 0; i < steviloStolpcev; i++)
                {
                    double vsota = 0;
                    // Izračun celotnega seštevka vrstice
                    for (int j = 0; j < steviloVrstic - 1; j++)
                    {
                        vsota += Convert.ToDouble(dataGridView1[i, j].Value);
                    }

                    //Vsako vrstico delimo s seštevkom (vsota) in vpišemo število v "datagrid"
                    for (int j = 0; j < steviloVrstic - 1; j++)
                    {
                        dataGridView1[i, j].Value = Convert.ToDouble(dataGridView1[i, j].Value) / vsota;
                    }
                }

                TreeNode izbranoVozlisce = treeView.SelectedNode;
                if (izbranoVozlisce.Parent == null)
                {
                    var parameter = new Parameter(izbranoVozlisce.Text, 1)
                    {
                        jeKoren = true,
                        vozlisce = izbranoVozlisce
                    };
                    parametri.Add(parameter);
                }

                // Na koncu vsake vrstice zapisemo utež parametra v zadnji stolpec
                for (int i = 0; i < steviloVrstic - 1; i++)
                {
                    double vsota = 0;
                    // Računanje stolpcev, vendar zadnjega ne upoštevamo (utež)
                    for (int j = 0; j < steviloStolpcev - 1; j++)
                    {
                        vsota += Convert.ToDouble(dataGridView1[j, i].Value);
                    }

                    // Računanje uteži
                    double utez = vsota / (dataGridView1.Rows.Count - 1);
                    dataGridView1[steviloStolpcev - 1, i].Value = utez;

                    string imeParametra = dataGridView1.Rows[i].HeaderCell.Value.ToString();
                    // Ustvari nov parameter z imenom trenutne vrstice in z izracunano utezjo
                    Parameter parameter = new Parameter(imeParametra, utez);
                    trenutnoVozlisce = new TreeNode();
                    // Najdi vozlišče trenutnega parametra v seznamu vseh vozlišč
                    PoisciVozlisceZImenom(treeView.Nodes[0], imeParametra);
                    parameter.vozlisce = trenutnoVozlisce;

                    if (izbranoVozlisce.Parent == null)
                    {
                        parametri.First(p => p.jeKoren).otroci.Add(trenutnoVozlisce);
                    }

                    // Shrani vse otroke od trenutnega parametra (če jih ima) za kasnejšo preverjanje, če ima kakšne otroke in katere
                    foreach (TreeNode node in trenutnoVozlisce.Nodes)
                    {
                        parameter.otroci.Add(node);
                    }

                    if (izbranoVozlisce.Parent == null)
                    {
                        parameter.staršJeKoren = true;
                    }

                    // Dodamo parameter v list parametrov
                    parametri.Add(parameter);
                }
            }
            catch { }
        }
        
        public void PoisciVozlisceZImenom(TreeNode node, string name)
        {
            foreach (TreeNode actualNode in node.Nodes)
            {
                if (actualNode.Text == name)
                {
                    trenutnoVozlisce = actualNode;
                }

                PoisciVozlisceZImenom(actualNode, name);
            }
        }

        // Ko spremenimo število se v "kontra" stoplcu spremeni število (1/št.)
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int indexStolpca = dataGridView1.CurrentCell.ColumnIndex;
            int indexVrstice = dataGridView1.CurrentCell.RowIndex;
            dataGridView1[indexVrstice, indexStolpca].Value = 1 / (Convert.ToDouble(dataGridView1[indexStolpca, indexVrstice].Value));
        }

        public void NasprotnaVrednost(object sender, EventArgs e)
        {
            int indexStolpca = alternativeGridView.CurrentCell.ColumnIndex;
            int indexVrstice = alternativeGridView.CurrentCell.RowIndex;
            alternativeGridView[indexVrstice, indexStolpca].Value = 1 / (Convert.ToDouble(alternativeGridView[indexStolpca, indexVrstice].Value));

        }


        // RAČUNANJE IN USTAVRJANJE ALTERNATIV =========================================================================
        private void DodajTabeZaAlternative(object sender, EventArgs e)
        {
            foreach (Parameter parameter in parametri)
            {
                // Parameter brez otrok
                if (parameter.otroci.Count == 0)
                {
                    tabAlternative.TabPages.Add(parameter.imeParametra);
                }
            }
            OsveziAlternative();
        }

        private void DodajAlternativo(object sender, EventArgs e)
        {
            alternative.Add(new Alternativa(textBoxAddAlternative.Text));

            OsveziDataGridList();
            OsveziAlternative();
        }
        
        private void tabAlternative_SelectedIndexChanged(object sender, EventArgs e)
        {
            OsveziDataGridList();
        }
        
        private void ShraniPodatkeOAlternativi_bt(object sender, EventArgs e)
        {
            int steviloStolpcev = alternativeGridView.Columns.Count;
            int steviloVrstic = alternativeGridView.Rows.Count;

            // Za vsak stolpec posebej
            for (int i = 0; i < steviloStolpcev - 1; i++)
            {
                double vsota = 0;
                // Izračun celotnega seštevka vrstice
                for (int j = 0; j < steviloVrstic - 1; j++)
                {
                    vsota += Convert.ToDouble(alternativeGridView[i, j].Value);
                }

                // Nato vsako vrstico delimo z seštevkom (vsota) in vpišemo število v "datagrid"
                for (int j = 0; j < steviloVrstic - 1; j++)
                {
                    alternativeGridView[i, j].Value = Convert.ToDouble(alternativeGridView[i, j].Value) / vsota;
                }
            }

            // Na koncu vsake vrstice zapišemo utež parametra v zadnji stolpec
            for (int i = 0; i < steviloVrstic - 1; i++)
            {
                double vsota = 0;
                // Računanje stolpcev, vendar zadnjega ne upoštevamo (utež)
                for (int j = 0; j < steviloStolpcev - 1; j++)
                {
                    vsota += Convert.ToDouble(alternativeGridView[j, i].Value);
                }

                // Računanje koristnosti
                double koristnost = vsota / (alternativeGridView.Rows.Count - 1);
                alternativeGridView[steviloStolpcev - 1, i].Value = koristnost;

                string imeAlternative = alternativeGridView.Rows[i].HeaderCell.Value.ToString();
                // Tukaj shranimo koristnost alternative pri dolocenem parametru
                Parameter parameter = new Parameter(tabAlternative.SelectedTab.Text, koristnost);

                // iskanje alternative in shranjevanje parametrov
                int index = 0;
                int stevec = 0;
                foreach (Alternativa alternativa in alternative)
                {
                    if (alternativa.imeAlternative == imeAlternative)
                    {
                        index = stevec;
                        break;
                    }
                    stevec++;
                }

                alternative[index].koristnost = koristnost;
                alternative[index].parametri.Add(parameter);
            }
        }


        // IZRIS IN KONČNI IZRAČUNI ====================================================================================
        private void KoncniRezultat_bt(object sender, EventArgs e)
        {
            try
            {
                List<Parameter> korenskiOtroci = new List<Parameter>();
                var poNivoju = parametri.OrderByDescending(p => p.vozlisce.Level);

                // Za vsako alternativo računamo koristnost
                foreach (Alternativa alternativa in alternative)
                {
                    for (int i = 0; i < poNivoju.Count(); i++)
                    {
                        Parameter parameter = parametri.Single(p => p.imeParametra == poNivoju.ElementAt(i).vozlisce.Text);
                        if (parameter.otroci.Count == 0)
                        {
                            int index = 0;
                            // V alternativi išči koristnost za ta parameter
                            for (int j = 0; j < alternativa.parametri.Count; j++)
                            {
                                if (alternativa.parametri[j].imeParametra == parameter.imeParametra)
                                {
                                    index = j;
                                }
                            }
                            parameter.koristnost = alternativa.parametri[index].utez;
                        }
                        else
                        {
                            double koristnost = 0;
                            foreach (TreeNode node in parameter.otroci)
                            {
                                Parameter otrok = parametri.Single(x => x.imeParametra == node.Text);
                                koristnost += otrok.utez * otrok.koristnost;
                            }
                            parameter.koristnost = koristnost;
                        }
                    }

                    Parameter koren = parametri.Single(p => p.jeKoren);
                    double resultAlternativa = 0;
                    foreach (TreeNode childNode in koren.otroci)
                    {
                        Parameter otrok = parametri.Single(p => p.imeParametra == childNode.Text);
                        resultAlternativa += otrok.utez * otrok.koristnost;
                    }
                    alternativa.rezultat = resultAlternativa;
                }
                KoncneOcene();
            }
            catch { }
        }

        private void graf_btn_Click(object sender, EventArgs e)
        {
            NarisiGraf();
        }

        private void OsveziDataGridOče()
        {
            // Po vsakem dodajanju vozlisca osvežimo "datagridview" tabelo
            TreeNode selectedNode = treeView.SelectedNode;
            labelParameter.Text = selectedNode.Text;
            dataGridView1.ColumnCount = selectedNode.Nodes.Count + 1;

            // Dodajanje imena stolpcev
            for (int i = 0; i < selectedNode.Nodes.Count; i++)
            {
                dataGridView1.Columns[i].Name = selectedNode.Nodes[i].Text;
            }

            // Dodamo ime "zadnjemu" stolpcu
            dataGridView1.Columns[selectedNode.Nodes.Count].Name = "Utež";
            dataGridView1.Rows.Clear();

            // Izgradnja "matrice"
            for (int i = 0; i < selectedNode.Nodes.Count; i++)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[i].Clone();

                for (int j = 0; j < selectedNode.Nodes.Count; j++)
                {
                    // Nastavimo 1 po diagonali
                    if (i == j)
                    {
                        row.Cells[j].Value = "1";
                    }
                    else
                    {
                        row.Cells[j].Value = "";
                    }
                }
                // Nastavimo imena vrstic
                row.HeaderCell.Value = selectedNode.Nodes[i].Text;

                // Dodamo vrstice v datagrid
                dataGridView1.Rows.Add(row);
            }
        }

        private void OsveziDataGridList()
        {
            foreach (TabPage tab in tabAlternative.TabPages)
            {
                if (tabAlternative.SelectedTab.Text == tab.Text)
                {

                    tab.Controls.Clear();
                    tab.Controls.Add(alternativeGridView);
                    alternativeGridView.Height = 252;
                    alternativeGridView.Width = 632;
                    alternativeGridView.Name = "alternativeGridView";

                    alternativeGridView.ColumnCount = alternative.Count + 1;


                    // Dodajanje imena stolpcev
                    for (int i = 0; i < alternative.Count; i++)
                    {
                        alternativeGridView.Columns[i].Name = alternative[i].imeAlternative;
                    }

                    // Dodamo ime "zadnjemu" stolpcu
                    alternativeGridView.Columns[alternative.Count].Name = "Koristnost";
                    alternativeGridView.Rows.Clear();

                    // Izgradnja "matrice"
                    for (int i = 0; i < alternative.Count; i++)
                    {
                        DataGridViewRow row = (DataGridViewRow)alternativeGridView.Rows[i].Clone();

                        for (int j = 0; j < alternative.Count; j++)
                        {
                            // Nastavimo 1 po diagonali
                            if (i == j)
                            {
                                row.Cells[j].Value = "1";
                            }
                            else
                            {
                                row.Cells[j].Value = "";
                            }
                        }
                        // Nastavimo imena vrstic
                        row.HeaderCell.Value = alternative[i].imeAlternative;

                        // Dodamo vrstice v datagrid
                        alternativeGridView.Rows.Add(row);
                    }
                }
            }
        }

        private void OsveziAlternative()
        {
            List<string> alt = new List<string>();
            foreach (var alternativa in alternative)
            {
                alt.Add(alternativa.imeAlternative);
            }
            alternative_lb.DataSource = alt;
            
        }

        private void KoncneOcene()
        {
            string koncniRezultati="";
            foreach(var item in alternative)
            {
                koncniRezultati += item.imeAlternative + "  " + item.rezultat.ToString()+"\n";
            }
            MessageBox.Show(koncniRezultati);
            
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "text | .txt";
            save.Title = "Shrani rezultate";
            save.ShowDialog();
            if (save.FileName != "")
            {
                File.WriteAllText(save.FileName,koncniRezultati);
            }
            graf_btn.Enabled = true;
        }

        private void NarisiGraf()
        {
            Chart graf = new Chart() { Dock = DockStyle.Fill }; ;

            var grafForm = new Form
            {
                Visible = false,
                TopMost = true,
                Width = 1000,
                Height = 800                
            };


            var chartArea = new ChartArea("graf");
            chartArea.AxisY.Title = "Vrednost";
            chartArea.AxisX.Title = "Alternativa";
            graf.ChartAreas.Add(chartArea);
            graf.Legends.Add("legend1");

            graf.Titles.Add("Primerjava alternativ");

            for (int i = 0; i < alternative.Count; i++)
            {
                graf.Series.Add(alternative[i].imeAlternative);
                graf.Series[alternative[i].imeAlternative].LegendText = alternative[i].imeAlternative;
                graf.Series[alternative[i].imeAlternative].ChartType = SeriesChartType.Bar;
                graf.Series[alternative[i].imeAlternative].IsValueShownAsLabel = true;
                graf.Series[alternative[i].imeAlternative].Points.AddXY(alternative[i].imeAlternative, alternative[i].rezultat);
            }
            grafForm.Controls.Add(graf);
            grafForm.ShowDialog();

            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Slika | .png";
            save.ShowDialog();

            if (save.FileName != "")
            {
                graf.SaveImage(save.FileName, System.Drawing.Imaging.ImageFormat.Png);
            }
        }
    }
}