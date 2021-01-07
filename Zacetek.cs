using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ahp_metoda_projekt
{
    public partial class Zacetek : Form
    {
        public Zacetek()
        {
            InitializeComponent();
        }
               
        private void btnConfirmAdd_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelAdd_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
