using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ahp_metoda_projekt
{
    public class Alternativa
    {
        public string imeAlternative;
        public double koristnost;
        public List<Parameter> parametri;
        public double rezultat;
        public Alternativa(string ime)
        {
            parametri = new List<Parameter>();
            imeAlternative = ime;
        }

    }
}
