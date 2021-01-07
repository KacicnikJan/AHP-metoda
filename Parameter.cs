using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ahp_metoda_projekt
{
    public class Parameter
    {
        public string imeParametra;
        public double utez;
        public double koristnost;
        public List<TreeNode> otroci;
        public bool jeKoren = false;
        public bool staršJeKoren = false;
        public TreeNode vozlisce;

        public Parameter(string ime, double _utez)
        {
            otroci = new List<TreeNode>();
            utez = _utez;
            imeParametra = ime;
        }
    }
}
