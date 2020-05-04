using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksamensoppgaver
{
    class Hytte
    {
        public Sti[] TilgjengeligeStier { get; set; }
        public string Navn { get; set;}
        public Hytte(string navn, Sti [] stier)
        {
            this.TilgjengeligeStier = stier;
            this.Navn = navn;
        }
    }
}
