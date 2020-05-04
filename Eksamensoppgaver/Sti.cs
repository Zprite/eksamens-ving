using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksamensoppgaver
{
    class Sti
    {
        public int Lengde { get; set; }
        public string HytteTil { get; set; }
        public Sti (string h, int l)
        {
            this.Lengde = l;
            this.HytteTil = h;
        }
    }
}
