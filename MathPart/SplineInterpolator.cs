using System;
using System.Collections.Generic;
using System.Drawing;

namespace MathPart
{
    public class SplineInterpolator : Interpolator
    {
        private struct SplineTuple  // структура, що зберігає коєфіцієнти кожного сплайну
        {
            public double a, b, c, d, x;
        }
        SplineTuple[] splines;      // сплайни
        private string poly;    
        private int operations;
        private int iterations;
        private int initOperations;
        private int initIterations;
        public SplineInterpolator() { }
        public SplineInterpolator(List<PointF> points)      
        {
            this.init(points);
        }
        public void init(List<PointF> data) // ініціалізація, побудова сплайнів 
        {
            initOperations = initIterations = 0;
            var n = data.Count;
            splines = new SplineTuple[n];
            for (int i = 0; i < n; ++i)
            {
                splines[i].x = data[i].X;
                splines[i].a = data[i].Y;   
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
                initOperations += 16;
                initIterations++;
            }

            for (int i = n - 2; i > 0; --i)
            {
                splines[i].c = alpha[i] * splines[i + 1].c + beta[i];
                initOperations += 2;
                initIterations++;
            }

            for (int i = n - 1; i > 0; --i)
            {
                double hi = splines[i].x - splines[i - 1].x;
                splines[i].d = (splines[i].c - splines[i - 1].c) / hi;
                splines[i].b = hi * (2.0 * splines[i].c + splines[i - 1].c) / 6.0 + (splines[i].a - splines[i - 1].a) / hi;
                initOperations += 0;
                initIterations++;
            }
        }

        public double getPoint(double x) //Пошук Y за допомогою побудованих сплайнів та параметра X
        {
            operations = initOperations;
            iterations = initIterations;
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
            operations += 9;
            poly = String.Format("{1} + {2} * {0} + ({3}/2) * {0}^2 + ({4}/6)*{0}^3",
                                "(" + x + " - " + s.x + ")", 
                                (s.a != 0) ? s.a.ToString("F") : "0",
                                (s.b != 0) ? s.b.ToString("F") : "0", 
                                (s.c != 0) ? s.c.ToString("F") : "0",
                                (s.d != 0) ? s.d.ToString("F") : "0");
            return s.a + (s.b + (s.c / 2.0 + s.d * dx / 6.0) * dx) * dx;
        }
        SplineTuple binarySearch(double x) // бінарний пошук потрібного сплайну
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

        public string getType() // Повернення типу інтерполяціЇ
        {
            return "Cubic Spline Interpolator";
        }

        public string getLastPolynomString() // Отримання поліному у вигляді рядка
        {
            return poly;
        }

        public int getLastOperationCount() // Отримання кількості виконаних операцій за побудову сплайнів та пошук точки
        {
            return operations;
        }

        public int getLastIterationCount() // Отримання кількості виконаних ітерацій за побудову сплайнів та пошук точки
        {
            return iterations;
        }
    }
}
