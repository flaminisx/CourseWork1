﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathPart
{
    interface Interpolator
    {
        void init(List<KeyValuePair<double,double>> data);
        double getPoint(double x);
    }
}