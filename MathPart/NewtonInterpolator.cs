using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathPart
{
    public class NewtonInterpolator : Interpolator
    {
        public NewtonInterpolator() { }
        public NewtonInterpolator(KeyValuePair<double, double>[] data)
        {
            this.init(data);
        }
        public double getPoint(double x)
        {
            throw new NotImplementedException();
        }

        public void init(KeyValuePair<double, double>[] data)
        {
            throw new NotImplementedException();
        }
    }
}
