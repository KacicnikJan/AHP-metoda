namespace ahp_metoda_projekt
{
    partial class Zacetek
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
            this.textBoxProblemName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnCancelAdd = new System.Windows.Forms.Button();
            this.btnConfirmAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxProblemName
            // 
            this.textBoxProblemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxProblemName.Location = new System.Drawing.Point(81, 91);
            this.textBoxProblemName.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxProblemName.Name = "textBoxProblemName";
            this.textBoxProblemName.Size = new System.Drawing.Size(188, 26);
            this.textBoxProblemName.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(81, 61);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Podajte ime problema:";
            // 
            // btnCancelAdd
            // 
            this.btnCancelAdd.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.btnCancelAdd.Location = new System.Drawing.Point(81, 131);
            this.btnCancelAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelAdd.Name = "btnCancelAdd";
            this.btnCancelAdd.Size = new System.Drawing.Size(69, 28);
            this.btnCancelAdd.TabIndex = 7;
            this.btnCancelAdd.Text = "Prekliči";
            this.btnCancelAdd.UseVisualStyleBackColor = true;
            this.btnCancelAdd.Click += new System.EventHandler(this.btnCancelAdd_Click);
            // 
            // btnConfirmAdd
            // 
            this.btnConfirmAdd.Location = new System.Drawing.Point(199, 131);
            this.btnConfirmAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmAdd.Name = "btnConfirmAdd";
            this.btnConfirmAdd.Size = new System.Drawing.Size(70, 28);
            this.btnConfirmAdd.TabIndex = 6;
            this.btnConfirmAdd.Text = "Dodaj";
            this.btnConfirmAdd.UseVisualStyleBackColor = true;
            this.btnConfirmAdd.Click += new System.EventHandler(this.btnConfirmAdd_Click);
            // 
            // Zacetek
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 213);
            this.Controls.Add(this.textBoxProblemName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelAdd);
            this.Controls.Add(this.btnConfirmAdd);
            this.Name = "Zacetek";
            this.Text = "Zacetek";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox textBoxProblemName;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnCancelAdd;
        public System.Windows.Forms.Button btnConfirmAdd;
    }
}