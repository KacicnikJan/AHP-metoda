namespace ahp_metoda_projekt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnFinalResult = new System.Windows.Forms.Button();
            this.btnAddAlternative = new System.Windows.Forms.Button();
            this.textBoxAddAlternative = new System.Windows.Forms.TextBox();
            this.btnSaveParameter = new System.Windows.Forms.Button();
            this.btnRemoveNode = new System.Windows.Forms.Button();
            this.btnAddNode = new System.Windows.Forms.Button();
            this.textBoxAddNode = new System.Windows.Forms.TextBox();
            this.btnSaveAlternative = new System.Windows.Forms.Button();
            this.tabAlternative = new System.Windows.Forms.TabControl();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.treeView = new System.Windows.Forms.TreeView();
            this.pomočToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.datotekaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.labelParameter = new System.Windows.Forms.Label();
            this.alternative_lb = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.graf_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFinalResult
            // 
            this.btnFinalResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnFinalResult.Location = new System.Drawing.Point(649, 674);
            this.btnFinalResult.Margin = new System.Windows.Forms.Padding(2);
            this.btnFinalResult.Name = "btnFinalResult";
            this.btnFinalResult.Size = new System.Drawing.Size(138, 40);
            this.btnFinalResult.TabIndex = 0;
            this.btnFinalResult.Text = "Izračunaj!";
            this.btnFinalResult.UseVisualStyleBackColor = true;
            this.btnFinalResult.Click += new System.EventHandler(this.KoncniRezultat_bt);
            // 
            // btnAddAlternative
            // 
            this.btnAddAlternative.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddAlternative.BackgroundImage")));
            this.btnAddAlternative.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddAlternative.Location = new System.Drawing.Point(119, 636);
            this.btnAddAlternative.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddAlternative.Name = "btnAddAlternative";
            this.btnAddAlternative.Size = new System.Drawing.Size(26, 23);
            this.btnAddAlternative.TabIndex = 4;
            this.btnAddAlternative.UseVisualStyleBackColor = true;
            this.btnAddAlternative.Click += new System.EventHandler(this.DodajAlternativo);
            // 
            // textBoxAddAlternative
            // 
            this.textBoxAddAlternative.Location = new System.Drawing.Point(20, 636);
            this.textBoxAddAlternative.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxAddAlternative.Name = "textBoxAddAlternative";
            this.textBoxAddAlternative.Size = new System.Drawing.Size(92, 20);
            this.textBoxAddAlternative.TabIndex = 2;
            // 
            // btnSaveParameter
            // 
            this.btnSaveParameter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSaveParameter.Location = new System.Drawing.Point(155, 323);
            this.btnSaveParameter.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveParameter.Name = "btnSaveParameter";
            this.btnSaveParameter.Size = new System.Drawing.Size(114, 26);
            this.btnSaveParameter.TabIndex = 6;
            this.btnSaveParameter.Text = "Izračunaj in shrani";
            this.btnSaveParameter.UseVisualStyleBackColor = true;
            this.btnSaveParameter.Click += new System.EventHandler(this.shraniPodatkeOParametru);
            // 
            // btnRemoveNode
            // 
            this.btnRemoveNode.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveNode.BackgroundImage")));
            this.btnRemoveNode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRemoveNode.Location = new System.Drawing.Point(116, 287);
            this.btnRemoveNode.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemoveNode.Name = "btnRemoveNode";
            this.btnRemoveNode.Size = new System.Drawing.Size(26, 23);
            this.btnRemoveNode.TabIndex = 4;
            this.btnRemoveNode.UseVisualStyleBackColor = true;
            this.btnRemoveNode.Click += new System.EventHandler(this.izbrisiVozlisce_btn);
            // 
            // btnAddNode
            // 
            this.btnAddNode.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddNode.BackgroundImage")));
            this.btnAddNode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddNode.Location = new System.Drawing.Point(86, 287);
            this.btnAddNode.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddNode.Name = "btnAddNode";
            this.btnAddNode.Size = new System.Drawing.Size(26, 23);
            this.btnAddNode.TabIndex = 3;
            this.btnAddNode.UseVisualStyleBackColor = true;
            this.btnAddNode.Click += new System.EventHandler(this.DodajVozlisce_btn);
            // 
            // textBoxAddNode
            // 
            this.textBoxAddNode.Location = new System.Drawing.Point(16, 290);
            this.textBoxAddNode.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxAddNode.Name = "textBoxAddNode";
            this.textBoxAddNode.Size = new System.Drawing.Size(66, 20);
            this.textBoxAddNode.TabIndex = 2;
            // 
            // btnSaveAlternative
            // 
            this.btnSaveAlternative.Location = new System.Drawing.Point(158, 674);
            this.btnSaveAlternative.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveAlternative.Name = "btnSaveAlternative";
            this.btnSaveAlternative.Size = new System.Drawing.Size(79, 22);
            this.btnSaveAlternative.TabIndex = 6;
            this.btnSaveAlternative.Text = "Shrani";
            this.btnSaveAlternative.UseVisualStyleBackColor = true;
            this.btnSaveAlternative.UseWaitCursor = true;
            this.btnSaveAlternative.Click += new System.EventHandler(this.ShraniPodatkeOAlternativi_bt);
            // 
            // tabAlternative
            // 
            this.tabAlternative.Location = new System.Drawing.Point(158, 407);
            this.tabAlternative.Margin = new System.Windows.Forms.Padding(2);
            this.tabAlternative.Name = "tabAlternative";
            this.tabAlternative.SelectedIndex = 0;
            this.tabAlternative.Size = new System.Drawing.Size(632, 252);
            this.tabAlternative.TabIndex = 5;
            this.tabAlternative.SelectedIndexChanged += new System.EventHandler(this.tabAlternative_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(155, 53);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(632, 257);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            // 
            // treeView
            // 
            this.treeView.Location = new System.Drawing.Point(17, 53);
            this.treeView.Margin = new System.Windows.Forms.Padding(2);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(125, 221);
            this.treeView.TabIndex = 0;
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            // 
            // pomočToolStripMenuItem
            // 
            this.pomočToolStripMenuItem.Name = "pomočToolStripMenuItem";
            this.pomočToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.pomočToolStripMenuItem.Text = "Pomoč";
            // 
            // datotekaToolStripMenuItem
            // 
            this.datotekaToolStripMenuItem.Name = "datotekaToolStripMenuItem";
            this.datotekaToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.datotekaToolStripMenuItem.Text = "Datoteka";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.datotekaToolStripMenuItem,
            this.pomočToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(819, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // labelParameter
            // 
            this.labelParameter.AutoSize = true;
            this.labelParameter.Location = new System.Drawing.Point(155, 35);
            this.labelParameter.Name = "labelParameter";
            this.labelParameter.Size = new System.Drawing.Size(0, 13);
            this.labelParameter.TabIndex = 8;
            // 
            // alternative_lb
            // 
            this.alternative_lb.FormattingEnabled = true;
            this.alternative_lb.Location = new System.Drawing.Point(20, 407);
            this.alternative_lb.Name = "alternative_lb";
            this.alternative_lb.Size = new System.Drawing.Size(125, 212);
            this.alternative_lb.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(155, 359);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 43);
            this.button1.TabIndex = 10;
            this.button1.Text = "Oceni alternative";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.DodajTabeZaAlternative);
            // 
            // graf_btn
            // 
            this.graf_btn.Location = new System.Drawing.Point(483, 674);
            this.graf_btn.Name = "graf_btn";
            this.graf_btn.Size = new System.Drawing.Size(124, 40);
            this.graf_btn.TabIndex = 11;
            this.graf_btn.Text = "Graf";
            this.graf_btn.UseVisualStyleBackColor = true;
            this.graf_btn.Click += new System.EventHandler(this.graf_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 726);
            this.Controls.Add(this.graf_btn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.alternative_lb);
            this.Controls.Add(this.labelParameter);
            this.Controls.Add(this.btnSaveAlternative);
            this.Controls.Add(this.btnSaveParameter);
            this.Controls.Add(this.btnFinalResult);
            this.Controls.Add(this.tabAlternative);
            this.Controls.Add(this.btnAddAlternative);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.textBoxAddAlternative);
            this.Controls.Add(this.btnRemoveNode);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.btnAddNode);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBoxAddNode);
            this.Name = "Form1";
            this.Text = "AHP metoda";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFinalResult;
        private System.Windows.Forms.Button btnAddAlternative;
        private System.Windows.Forms.TextBox textBoxAddAlternative;
        private System.Windows.Forms.Button btnSaveParameter;
        private System.Windows.Forms.Button btnRemoveNode;
        private System.Windows.Forms.Button btnAddNode;
        private System.Windows.Forms.TextBox textBoxAddNode;
        private System.Windows.Forms.Button btnSaveAlternative;
        private System.Windows.Forms.TabControl tabAlternative;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.ToolStripMenuItem pomočToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem datotekaToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label labelParameter;
        private System.Windows.Forms.ListBox alternative_lb;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button graf_btn;
    }
}

