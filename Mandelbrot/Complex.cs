using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandelbrot
{
    public class Complex
    {
        public double a;
        public double b;

        public Complex(double A, double B)
        {
            this.a = A;
            this.b = B;
        }

        public Complex Pow2()
        {
            return new Complex(a * a - b * b, 2 * a * b);
        }

        public double ModulusPow2()
        {
            return a * a + b * b;
        }
    }
}
