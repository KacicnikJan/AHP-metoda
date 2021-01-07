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
            alternativeGridView.CellEndEdit += new DataGridViewCellEventHandler(oppositeValue);
            InitializeComponent();
        }

        // Aplikacija začne delovati ko uporabnik vpiše problem
        private void Form1_Load(object sender, EventArgs e)
        {
            Zacetek zacetek = new Zacetek();
            var result = zacetek.ShowDialog();
            // Če je uporabnik kliknil "Dodaj" in če je vnesel ime problema se ustvari koren
            if ((result == DialogResult.OK) && (zacetek.textBoxProblemName.Text != ""))
            {
                zacetek.Close();
                string problemName = zacetek.textBoxProblemName.Text;

                TreeNode rootNode = new TreeNode(problemName);
                treeView.Nodes.Add(rootNode);
            }

        }

        // Dodajanje vozlišč
        private void DodajVozlisce_btn(object sender, EventArgs e)
        {
            TreeNode izbranoVozlisce;
            // Če ima drevo kakšno vozlišče ter izbrano vozlišče
            if ((treeView.Nodes.Count != 0) && (treeView.SelectedNode != null))
            {
                // Izberemo vozlišče, ter dodamo novo
                izbranoVozlisce = treeView.SelectedNode;
                izbranoVozlisce.Nodes.Add(new TreeNode(textBoxAddNode.Text));
            }
            // Če ni vozlišla, dodamo "Root node"
            else
            {
                treeView.Nodes.Add(new TreeNode(textBoxAddNode.Text));
            }

            OsveziDataGridOče();
        }

        // Gumb za brisanje vozlišč
        private void btnRemoveNode_Click(object sender, EventArgs e)
        {
            TreeNode izbranoVozlisce = treeView.SelectedNode;
            izbranoVozlisce.Remove();
        }

        // Kadar uporabnik izbere vozlišče
        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            OsveziDataGridOče();
        }

        // Shranjevanje in izračun parametrov
        private void btnSaveParameter_Click(object sender, EventArgs e)
        {
            int steviloStolpcev = dataGridView1.Columns.Count;
            int steviloVrstic = dataGridView1.Rows.Count;

            // Za vsak stolpec posebaj
            for (int i = 0; i < steviloStolpcev; i++)
            {

                double vsota = 0;
                // Izračun celotnega seštevka vrstice
                for (int j = 0; j < steviloVrstic - 1; j++)
                {
                    vsota += Convert.ToDouble(dataGridView1[i, j].Value);
                }

                // Nato vsako vrstico delimo z seštevkom (vsota) in vpišemo število v "datagrid"
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
                    isRoot = true,
                    node = izbranoVozlisce
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
                double weight = vsota / (dataGridView1.Rows.Count - 1);
                dataGridView1[steviloStolpcev - 1, i].Value = weight;

                string parameterName = dataGridView1.Rows[i].HeaderCell.Value.ToString();
                // Ustvari nov parameter z imenom trenutne vrstice in z izracunano utezjo
                Parameter parameter = new Parameter(parameterName, weight);
                trenutnoVozlisce = new TreeNode();
                // Najdi vozlišče trenutnega parametra v seznamu vseh vozlišč
                findNodeWithName(treeView.Nodes[0], parameterName);
                parameter.node = trenutnoVozlisce;
                parameter.stars = parametri.Single(p => p.name == izbranoVozlisce.Text);

                if (izbranoVozlisce.Parent == null)
                {
                    parametri.First(p => p.isRoot).childNodes.Add(trenutnoVozlisce);
                }

                // Shrani vse otroke od trenutnega parametra (če jih ima) za kasnejšo preverjanje, če ima kakšne otroke in katere
                foreach (TreeNode node in trenutnoVozlisce.Nodes)
                {
                    parameter.childNodes.Add(node);
                }

                if (izbranoVozlisce.Parent == null)
                {
                    parameter.parentIsRoot = true;
                }

                // Dodamo parameter v list parametrov
                parametri.Add(parameter);
            }
        }

        // Iskanje imena vozlišča
        public void findNodeWithName(TreeNode node, string name)
        {
            foreach (TreeNode actualNode in node.Nodes)
            {
                if (actualNode.Text == name)
                {
                    trenutnoVozlisce = actualNode;
                }

                findNodeWithName(actualNode, name);
            }
        }

        // Ko spremenimo število se v "kontra" stoplcu spremeni število (1/št.)
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int indexStolpca = dataGridView1.CurrentCell.ColumnIndex;
            int indexVrstice = dataGridView1.CurrentCell.RowIndex;
            dataGridView1[indexVrstice, indexStolpca].Value = 1 / (Convert.ToDouble(dataGridView1[indexStolpca, indexVrstice].Value));
        }

        public void oppositeValue(object sender, EventArgs e)
        {
            int indexStolpca = alternativeGridView.CurrentCell.ColumnIndex;
            int indexVrstice = alternativeGridView.CurrentCell.RowIndex;
            alternativeGridView[indexVrstice, indexStolpca].Value = 1 / (Convert.ToDouble(alternativeGridView[indexStolpca, indexVrstice].Value));

        }


        // RAČUNANJE IN USTAVRJANJE ALTERNATIV =============================================================================
        private void DodajTabeZaAlternative(object sender, EventArgs e)
        {
            foreach (Parameter parameter in parametri)
            {
                // Parameter brez otrok
                if (parameter.childNodes.Count == 0)
                {
                    tabAlternative.TabPages.Add(parameter.name);
                }
            }
            OsveziAlternative();
        }

        // Dodajanje novih alternativ
        private void btnAddAlternative_Click(object sender, EventArgs e)
        {
            alternative.Add(new Alternativa(textBoxAddAlternative.Text));

            OsveziDataGridList();
            OsveziAlternative();
        }

        // Spreminjanje "datagridviewih" alternativ
        private void tabControlAlternative_SelectedIndexChanged(object sender, EventArgs e)
        {
            OsveziDataGridList();
        }

        // Shranjevanje in izračun alternativ
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
                    if (alternativa.name == imeAlternative)
                    {
                        index = stevec;
                        break;
                    }
                    stevec++;
                }

                alternative[index].koristnost = koristnost;
                alternative[index].parameters.Add(parameter);

            }
        }


        // ZADNJI DEL, IZRIS IN KONČNI IZRAČUNI ====================================================================================
        // Računanje rezultata in izris rezultata

        private void OceniParametre(Parameter korenski, Alternativa a, List<Parameter> korenskiOtroci)
        {
            if (korenski.parentIsRoot == true)
            {
                korenskiOtroci.Add(korenski);
            }
            if (korenski.childNodes.Count == 0)
            {
                int index = 0;
                // V alternativi išči koristnost za ta parameter
                for (int j = 0; j < a.parameters.Count; j++)
                {
                    if (a.parameters[j].name == korenski.name)
                    {
                        index = j;
                    }
                }
                korenski.koristnost = korenski.weight * a.parameters[index].weight;
                return;
            }
            // Če parameter ima otroke
            else
            {
                double koristnost = 0;
                // Gremo skozi vse otroke
                foreach (TreeNode node in korenski.childNodes)
                {
                    Parameter p = parametri.Single(par => par.name == node.Text);
                    if (node.Nodes.Count == 0)
                    {
                        for (int j = 0; j < parametri.Count; j++)
                        {
                            if (parametri[j].name == node.Text)
                            {
                                koristnost += parametri[j].koristnost;
                            }
                        }
                    }
                    else
                    {
                        OceniParametre(p, a, korenskiOtroci);
                        koristnost += p.koristnost * p.weight;
                    }
                }
                korenski.koristnost = koristnost;
            }
        }
        private void KoncniRezultat_bt(object sender, EventArgs e)
        {
            List<Parameter> korenskiOtroci = new List<Parameter>();
            var poNivoju = parametri.OrderByDescending(p => p.node.Level);

            // Za vsako alternativo računamo koristnost
            foreach (Alternativa alternativa in alternative)
            {
                for (int i = 0; i < poNivoju.Count(); i++)
                {
                    Parameter parameter = parametri.Single(p => p.name == poNivoju.ElementAt(i).node.Text);
                    if (parameter.childNodes.Count == 0)
                    {
                        int index = 0;
                        // V alternativi išči koristnost za ta parameter
                        for (int j = 0; j < alternativa.parameters.Count; j++)
                        {
                            if (alternativa.parameters[j].name == parameter.name)
                            {
                                index = j;
                            }
                        }
                        parameter.koristnost = alternativa.parameters[index].weight;
                    }
                    else
                    {
                        double koristnost = 0;
                        foreach (TreeNode node in parameter.childNodes)
                        {
                            Parameter otrok = parametri.Single(x => x.name == node.Text);
                            koristnost += otrok.weight * otrok.koristnost;
                        }
                        parameter.koristnost = koristnost;
                    }
                }

                Parameter koren = parametri.Single(p => p.isRoot);
                double resultAlternativa = 0;
                foreach (TreeNode childNode in koren.childNodes)
                {
                    Parameter otrok = parametri.Single(p => p.name == childNode.Text);
                    resultAlternativa += otrok.weight * otrok.koristnost;
                }
                alternativa.result = resultAlternativa;
            }

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
                        alternativeGridView.Columns[i].Name = alternative[i].name;
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
                        row.HeaderCell.Value = alternative[i].name;

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
                alt.Add(alternativa.name);
            }
            alternative_lb.DataSource = alt;
            alternative_lb.Enabled = false;
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
                graf.Series.Add(alternative[i].name);
                graf.Series[alternative[i].name].LegendText = alternative[i].name;
                graf.Series[alternative[i].name].ChartType = SeriesChartType.Bar;
                graf.Series[alternative[i].name].IsValueShownAsLabel = true;
                graf.Series[alternative[i].name].Points.AddXY(alternative[i].name, alternative[i].result);
            }
            grafForm.Controls.Add(graf);
            grafForm.ShowDialog();
            graf.SaveImage("graf_alternativ.png", System.Drawing.Imaging.ImageFormat.Png);
        }
    }
}