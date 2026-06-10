using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoligonGUI3102026B
{
    public class Tacka
    {
        public double x;
        public double y;
        public double d()
        {
            return Math.Sqrt(x * x + y * y);
        }
        public Tacka(double a, double b)
        {
            x = a;
            y = b;
        }
        public static bool iste(Tacka A, Tacka B)
        {
            if ((A.x == B.x) && (A.y == B.y)) return true;
            else return false;
        }
        public string toString()
        {
            return "("+x+", "+y+")";
        }
    }
}
