using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoligonGUI3102026B
{
    internal class Vektor
    {
        public Tacka pocetak;
        public Tacka kraj;
        public Tacka centriraj()
        {
            double x = kraj.x - pocetak.x;
            double y = kraj.y - pocetak.y;
            return new Tacka(x, y);
        }
        public void stampaj()
        {
            Console.WriteLine("Od x1={0}, y1={1} Do x2={2}, y2={3}", pocetak.x, pocetak.y, kraj.x, kraj.y);
        }
        public Vektor(Tacka a, Tacka b)
        {
            pocetak = a;
            kraj = b;
        }
        public static double SP(Vektor a, Vektor b)
        {
            Tacka aC = a.centriraj();
            Tacka bC = b.centriraj();
            return aC.x * bC.x + aC.y * bC.y;
        }
        public static double VP(Vektor a, Vektor b)
        {
            Tacka aC = a.centriraj();
            Tacka bC = b.centriraj();
            return aC.x * bC.y - bC.x * aC.y;
        }
        public double duzina()
        {
            Tacka A = this.centriraj();
            double duzina = A.d();
            return duzina;
        }
        public bool sece(Vektor b)
        {
            int x = Ravan.SIS(this, b.pocetak, b.kraj);
            int y = Ravan.SIS(b, this.pocetak, this.kraj);
            if (x * y != 0) return true;
            else return false;
        }
    }
}
