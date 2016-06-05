using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathPart;
using System.Globalization;
using System.Drawing;

namespace ConsoleApplication
{
    class Program
    {
        List<PointF> values;
        private void initializeData(String fileName)
        {
            values = new List<PointF>();
            try
            {
                using (Stream stream = File.Open("input.txt", FileMode.Open))
                using (TextReader sr = new StreamReader(stream, Encoding.UTF8))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] arr = line.Split(' ');
                        values.Add(new PointF(Convert.ToSingle(arr[0]), Convert.ToSingle(arr[1])));

                    }
                }
            }
            catch (FileNotFoundException e)
            {
                Console.Write("File #{0} was not found!", e.FileName);
            }
            catch (Exception e)
            {
                Console.Write("File has invalid format!");
            }
        }
        private void showInput()
        {
            Console.WriteLine("You entered {0} values:", values.Count);
            foreach (PointF value in values)
            {
                Console.WriteLine("({0} : {1})", value.X, value.Y);
            }
        }
        public Program()
        {
            initializeData("input");
            
            Interpolator i = selectMethod();
            while (i == null)
            {
                i = selectMethod();
            }
            double x = getX();
            Console.WriteLine("({0} : {1})", x, i.getPoint(x));
            Console.ReadKey();
        }
        private double getX()
        {
            Console.WriteLine("Enter x: ");
            try
            {
                return Double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            }
            catch (Exception)
            {
                Console.WriteLine("Try again..");
                return getX();
            }
        }
        private Interpolator selectMethod()
        {
            Console.WriteLine("Press\t1 to select Cubic Spline Interpolator");
            Console.WriteLine("\t2 for Newton Interpolator");
            var k = Console.ReadKey(true);
            Interpolator i;
            switch (k.KeyChar)
            {
                case '1':
                    i = new SplineInterpolator();
                    break;
                case '2':
                    i = new NewtonInterpolator();
                    break;
                default:
                    i = null;
                    break;
            }
            try
            {
                i.init(values);
            }
            catch (NotImplementedException e)
            {
                Console.WriteLine("Not implemented yet");
                return null;
            }
            catch(NullReferenceException e)
            {
                Console.WriteLine("Please, select from list.");
            }
            return i;
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
        static void Main(string[] args)
        {
            new Program();
        }
    }
}
