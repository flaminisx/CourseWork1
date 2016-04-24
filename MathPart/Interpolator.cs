using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathPart
{
    public interface Interpolator
    {
        void init(KeyValuePair<double,double>[] data);
        double getPoint(double x);
    }
}
