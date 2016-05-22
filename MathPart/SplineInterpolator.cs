using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathPart
{
    public class SplineInterpolator : Interpolator
    {
        SplineTuple[] splines; 
        private struct SplineTuple
        {
            public double a, b, c, d, x;
        }
        public SplineInterpolator() { }
        public SplineInterpolator(List<PointF> points)
        {
            KeyValuePair<double, double>[] data = new KeyValuePair<double, double>[points.Count];
            for (int i = 0; i < points.Count; i++)
            {
                data[i] = new KeyValuePair<double, double>(points[i].X, points[i].Y);
            }
            this.init(data);
        }
        public SplineInterpolator(KeyValuePair<double, double>[] data)
        {
            this.init(data);
        }
        public void init(KeyValuePair<double, double>[] data)
        {
            var n = data.Length;
            splines = new SplineTuple[n];
            for (int i = 0; i < n; ++i)
            {
                splines[i].x = data[i].Key;
                splines[i].a = data[i].Value;
            }
            splines[0].c = splines[n - 1].c = 0.0;

            double[] alpha = new double[n - 1];
            double[] beta = new double[n - 1];
            alpha[0] = beta[0] = 0.0;
            for (int i = 1; i < n - 1; ++i)
            {
                double hi = splines[i].x - splines[i - 1].x;
                double hi1 = splines[i + 1].x - splines[i].x;
                double A = hi;
                double C = 2.0 * (hi + hi1);
                double B = hi1;
                double F = 6.0 * ((splines[i + 1].a - splines[i].a) / hi1 - (splines[i].a - splines[i - 1].a) / hi);
                double z = (A * alpha[i - 1] + C);
                alpha[i] = -B / z;
                beta[i] = (F - A * beta[i - 1]) / z;
            }

            for (int i = n - 2; i > 0; --i)
            {
                splines[i].c = alpha[i] * splines[i + 1].c + beta[i];
            }

            for (int i = n - 1; i > 0; --i)
            {
                double hi = splines[i].x - splines[i - 1].x;
                splines[i].d = (splines[i].c - splines[i - 1].c) / hi;
                splines[i].b = hi * (2.0 * splines[i].c + splines[i - 1].c) / 6.0 + (splines[i].a - splines[i - 1].a) / hi;
            }
        }

        public double getPoint(double x)
        {
            if (splines == null)
            {
                throw new IndexOutOfRangeException();
            }
            int n = splines.Length;
            SplineTuple s;
            if (x <= splines[0].x)
            {
                s = splines[0];
            }
            else if (x >= splines[n - 1].x)
            {
                s = splines[n - 1];
            }
            else
            {
                s = binarySearch(x);
            }
            double dx = x - s.x;
            return s.a + (s.b + (s.c / 2.0 + s.d * dx / 6.0) * dx) * dx;
        }
        SplineTuple binarySearch(double x)
        {
            int i = 0;
            int j = splines.Length - 1;
            while (i + 1 < j)
            {
                int k = i + (j - i) / 2;
                if (x <= splines[k].x)
                {
                    j = k;
                }
                else
                {
                    i = k;
                }
            }
            return splines[j];
        }
    }
}
