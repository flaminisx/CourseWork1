using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;
using System.IO;
using System.Text;
using MathPart;

namespace GraphicPart
{
    public partial class Form1 : Form
    {
        Storage data;
        List<PointF> kdata;
        Color[] colors = { Color.DarkOrange, Color.ForestGreen };
        private int powerOfInterpolation = 4;
        private const int MAX_POWER = 1000000;
        int num = 0;
        private double min, max;
        public Form1()
        {
            InitializeComponent(); // ініціалізація інтерфейсу користувача
            data = new Storage(); // зчитування інтерполяційної сітки з файлу у змінну
            kdata = new List<PointF>();
            if (data.Count <= MAX_POWER)
                powerOfInterpolation = data.Count - 1; // встановлення степеня інтерполяції для методу Ньютона
            if (data.Count > 1)
            {
                min = data[0].X;
                max = data[data.Count - 1].X;
                displayKnown();
                displayInterpolators(min, max);
            }
            //chart.MouseWheel += new MouseEventHandler(chartWheelEvent); //розкоментувати для увімкнення збільшення графіку за допомогою прокрутки миші
            knownGridView.DataSource = data; //відображення інтерполяційної сітки
            methodPicker.SelectedIndex = 0;
            if (!File.Exists("rezults.txt")) File.Create("rezults.txt").Dispose(); // створити (якщо не існує) файл для збереження результатів
        }
        private void displayKnown() // відобразити точки інтерполяційної сітки
        {
            getKnown();
            if (kdata.Count < 0) return;
            var known = chart.Series.Add("known");
            known.LegendText = "Known points";
            known.ChartType = SeriesChartType.Point;
            foreach (PointF p in kdata)
            {
                DataPoint d = new DataPoint(p.X, p.Y);
                known.Points.Add(d);
            }
        }
        public void redisplayInterpolators(double from, double to) // перевідображення роботи обох методів на графіку у заданих межах
        {
            if (data.Count <= 1) return;
            if (data.Count <= MAX_POWER) powerOfInterpolation = data.Count - 1;
            try
            {
                foreach (var series in chart.Series)
                {
                    series.Points.Clear();
                }
            }
            catch (Exception e) { }
            finally
            {
                chart.Series.Clear();
            }
            displayKnown();
            displayInterpolators(from, to);
        }
        public void displayInterpolators(double from, double to) // відображення роботи обох методів на графіку у заданих межах
        {
            if (data.Count < 1) return;
            NewtonInterpolator newton = new NewtonInterpolator(data.ToList());
            newton.setPowerOfInterpolation(powerOfInterpolation);
            displayInterpolator(newton, "Newton", min, max);
            displayInterpolator(new SplineInterpolator(data.ToList()), "Spline", min, max);
            displayChartDomain();
        }
        public void displayInterpolator(Interpolator interpolator, string name, double from, double to) // відобразити роботу одного метода інтерполяції на графіку у заданих межах X
        { 
            var series = chart.Series.Add(name);
            series.ChartType = SeriesChartType.Line;
            series.Legend = name;
            series.LegendText = name + " interpolator";
            double step = (max - min)/ 100;
            for (double i = from; i <= to; i+=0.01)
            {
                series.Points.AddXY(i, interpolator.getPoint(i));
            }
            series.Color = colors[num++];
            if (num > 1) num = 0;
        }
        public void chartWheelEvent(object o, MouseEventArgs e) // обробник події прокрутки миші, збільшення/зменшення графіку
        {
            Console.WriteLine(e.Delta);
            Console.WriteLine(e.X);
            double x = (e.X / chart.Width) * (max - min);
            min += (x-min) * 10 / e.Delta;
            max -= (max - x) * 10 / e.Delta;
            redisplayInterpolators(min, max);
        }
        private void getKnown() // пошук точок, що будуть відображатись на графіку
        {
            kdata.Clear();
            foreach (PointF p in data)
            {
                if ((p.X >= min) && (p.X <= max))
                {
                    kdata.Add(p);
                }
            }
        }

        private void addInputBtn_Click(object sender, EventArgs e)  // обробник події натиснення кнопки "додати точку", додавання точки у інтерполяційну сітку 
        {
            data.Add(new PointF(Convert.ToSingle(inputXbox.Text), Convert.ToSingle(inputYbox.Text)));
            if (data.Count <= MAX_POWER)
                powerOfInterpolation = data.Count - 1;
            findMinMax();
            redisplayInterpolators(min, max);
            knownGridView.DataSource = null;
            knownGridView.DataSource = data;
        }

        private void sortData() //сортування точок у інтерполяційній сітці
        {
            data.Sort(new PointXComparer());
        }
        private void findMinMax() // Знаходження початкових найменшого і найбільшого значень X у інтерполяційній сітці
        {
            foreach (PointF p in data)
            {
                if (min > p.X) min = p.X;
                if (max < p.X) max = p.X;
            }
        }

        private void rebuildBtn_Click(object sender, EventArgs e) // обробник події натиснення кнопки "перебудувати", перебудова графіків
        {
            double mn = Convert.ToDouble(xMin.Text);
            double mx = Convert.ToDouble(xMax.Text);
            if (mn >= mx) return;
            min = mn;
            max = mx;
            redisplayInterpolators(min, max);
        }

        private void findYEvent(object sender, EventArgs e) //обробник події пошуку Y (подія зміни данних у findXbox або змыни вибору methodPicker)
        {
            double x = 0;
            timeBox.Text = "";
            iterationBox.Text = "";
            operationBox.Text = "";
            polyLabel.Text = "";
            try
            {
                string text = findXbox.Text.Replace(".", ",");
                x = Convert.ToDouble(text);
                switch (methodPicker.SelectedIndex)
                {
                    case 0:
                        var h = new NewtonInterpolator(data.ToList());
                        h.setPowerOfInterpolation(powerOfInterpolation);
                        findY(h, x);
                        break;
                    case 1:
                        var s = new SplineInterpolator(data.ToList());
                        findY(s, x);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                foundYbox.Text = "Error!";
            }
        }
        private void findY(Interpolator i, double x) //Знайти Y за заданим ынтерполятором та значенням X
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            double y = i.getPoint(x);
            foundYbox.Text = y.ToString();
            stopWatch.Stop();
            double ms = stopWatch.Elapsed.TotalMilliseconds;
            int iterations = i.getLastIterationCount();
            int operations = i.getLastOperationCount();
            string poly = i.getLastPolynomString(); 
            timeBox.Text = ms + "ms";
            iterationBox.Text = iterations.ToString();
            operationBox.Text = operations.ToString();
            polyLabel.Text = poly;
            writeRezultsToFile(x, y, i.getType(), poly, iterations, operations, ms);
        }
        private void writeRezultsToFile(double x, double y, string method, string poly, int iterations, int operations, double ms) // запис результатів у файл
        {
            using (Stream stream = File.Open("rezults.txt", FileMode.Append))
            using (TextWriter sr = new StreamWriter(stream, Encoding.UTF8))
            {
                sr.WriteLine(method);
                sr.WriteLine("x = {0}; y = {1}", x, y);
                sr.WriteLine("Polynom: " + poly);
                sr.WriteLine("Time: {0}ms, Operations: {1}", ms, operations);
            }
        }
        private void delBtn_Click(object sender, EventArgs e) // обробник події видалення точки з інтерполяційної сітки
        {
            foreach (DataGridViewRow r in knownGridView.SelectedRows)
            {
                data.RemoveAt(r.Index);
                Console.WriteLine(r.Index);
            }
            knownGridView.DataSource = null;
            knownGridView.DataSource = data;
            redisplayInterpolators(min, max);
        }
        private void displayChartDomain() // відобразити на екрані область зоображених на графіку даних
        {
            xMin.Text = min.ToString();
            xMax.Text = max.ToString();
        }
    }
}
