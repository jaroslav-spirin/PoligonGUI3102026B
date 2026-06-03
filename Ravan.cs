using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoligonGUI3102026B
{
    internal class Ravan
    {
        public static int SIS(Vektor a, Tacka B, Tacka C)
        {
            Vektor AB = new Vektor(a.pocetak, B);
            Vektor AC = new Vektor(a.pocetak, C);
            double aAB = Vektor.VP(a, AB);
            double aAC = Vektor.VP(a, AC);
            if (aAC * aAB > 0) return 0; // sa iste
            if (aAC * aAB < 0) return -1; // razne strane
            return 1; // bar jedna tacka lezi na Vektoru
        }
    }
}
