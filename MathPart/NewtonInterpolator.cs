using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;

namespace MathPart
{
    public class NewtonInterpolator : Interpolator
    {
        List<PointF> data;
        private string poly;
        private int operations;
        private int iterations;
        int power;
        public void setPowerOfInterpolation(int p)      // Встановлення степеня інтерполяції
        {
            power = p;
        }
        public NewtonInterpolator() { }
        public NewtonInterpolator(List<PointF> points)
        {
            this.data = points;
        }
        private double finiteDifference(int k, int n)   // рекурсивна функція для підрахунку кінцевої різниці
        {
            operations += 1;
            return (n == 1) ? data[k + 1].Y - data[k].Y : finiteDifference(k + 1, n - 1) - finiteDifference(k, n - 1);
        }
        public double getPoint(double t)    // Пошук Y по заданому X
        {
            operations = iterations = 0;
            double q = (t - data[0].X) / (data[1].X - data[0].X);
            double f = data[0].Y;
            poly = String.Format("{0:#.##}", f);
            operations += 3;
            int factorial = 1;
            double productQ = 1;
            for (int i = 1; i < power; i++)
            {
                factorial *= i;
                productQ *= (q - i + 1);
                double fd = finiteDifference(0, i);
                f += productQ * fd / factorial;
                operations += 6;
                iterations++;
                poly += String.Format(" + ({0:#.##} * {1})/{2}!", productQ, (fd != 0) ? fd.ToString("F") : "0", i);
            }
            return f;
        }
        public string getType() // Повернення типу інтерполяціЇ
        {
            return "Newton Interpolator";
        }

        public string getLastPolynomString() // Отримання поліному у вигляді рядка
        {
            return poly;
        }

        public int getLastOperationCount()  // Отримання кільноксті виконаних операцій за останній виклик getPoint()
        {
            return operations;
        }

        public int getLastIterationCount()  // Отримання кільноксті виконаних ітерацій за останній виклик getPoint()
        {
            return iterations;
        }

        public void init(List<PointF> data) // ініціалізація
        {
            this.data = data;
        }
    }
}
