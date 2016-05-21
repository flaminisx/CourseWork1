using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;

namespace MathPart
{
    public class NewtonInterpolator : Interpolator
    {
        KeyValuePair<double, double>[] data;
        int n;
        public void setPowerOfInterpolation(int p)
        {
            n = p;
        }
        public NewtonInterpolator() { }
        public NewtonInterpolator(List<PointF> points)
        {
            data = new KeyValuePair<double, double>[points.Count];
            for (int i = 0; i < points.Count; i++)
            {
                data[i] = new KeyValuePair<double, double>(points[i].X, points[i].Y);
            }
        }
        public NewtonInterpolator(KeyValuePair<double, double>[] data)
        {
            this.init(data);
        }
        public double getPoint(double x)
        {
            double res = data[0].Value, F, d;
            int i, j, k;
            for (i = 1; i <= n; i++)
            {
                F = 0;
                for (j = 0; j <= i; j++)
                {
                    d = 1;
                    for (k = 0; k <= i; k++)
                    {
                        if (k != j) d *= (data[j].Key - data[k].Key);
                    }
                    F += data[j].Value / d;
                }
                for (k = 0; k < i; k++) F *= (x - data[k].Key);
                res += F;
            }
            return res;
        }

        public void init(KeyValuePair<double, double>[] _data)
        {
            data = _data;
            n = getN();
        }
        public int getN()
        {
            Console.WriteLine("Enter the power of interpolation: ");
            try
            {
                return int.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                Console.WriteLine("Try again..");
                return getN();
            }
        }
    }
}
