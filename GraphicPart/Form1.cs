using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MathPart;
using System.Windows.Forms.DataVisualization.Charting;

namespace GraphicPart
{
    public partial class Form1 : Form
    {
        Storage storage;
        List<PointF> data;
        List<PointF> kdata;
        Color[] colors = { Color.DarkOrange, Color.ForestGreen };
        private int num = 0;
        private double min, max;
        public Form1()
        {
            InitializeComponent();
            storage = new Storage();
            data = storage.getData();
            kdata = new List<PointF>();
            min = data[0].X;
            max = data[data.Count - 1].X;
            displayKnown();
            displayInterpolators(min, max);
            chart.MouseWheel += new MouseEventHandler(chartWheelEvent);
        }
        private void displayKnown()
        {
            getKnown();
            if (kdata.Count < 0) return;
            var known = chart.Series.Add("known");
            known.ChartType = SeriesChartType.Point;
            foreach (PointF p in kdata)
            {
                DataPoint d = new DataPoint(p.X, p.Y);
                //d.Label = "(" + p.X + ":" + p.Y + ")";
                known.Points.Add(d);
            }
        }
        public void redisplayInterpolators(double from, double to)
        {
            try
            {
                foreach (var series in chart.Series)
                {
                    //foreach (DataPoint p in series.Points) p.Label.Remove(0);
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
        public void displayInterpolators(double from, double to)
        {
            NewtonInterpolator newton = new NewtonInterpolator(data);
            newton.setPowerOfInterpolation(4);
            displayInterpolator(newton, "Newton", min, max);
            displayInterpolator(new SplineInterpolator(data), "Spline", min, max);
        }
        public void displayInterpolator(Interpolator interpolator, string name, double from, double to)
        { 
            var series = chart.Series.Add(name);
            series.ChartType = SeriesChartType.Line;
            double step = (max - min)/ 100;
            for (double i = from; i <= to; i+=0.01)
            {
                series.Points.AddXY(i, interpolator.getPoint(i));
            }
            series.Color = colors[num++];
            if (num > 1) num = 0;
        }
        public void chartWheelEvent(object o, MouseEventArgs e)
        {
            Console.WriteLine(e.Delta);
            Console.WriteLine(e.X);
            double x = (e.X/chart.Width)*(max-min);
            min += (x-min) * 10 / e.Delta;
            max -= (max - x) * 10 / e.Delta;
            redisplayInterpolators(min, max);
        }
        private void getKnown()
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
        private void sortData()
        {
            data.Sort(new PointXComparer());
        }

    }
}
