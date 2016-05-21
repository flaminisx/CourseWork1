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
        public Form1()
        {
            InitializeComponent();
            storage = new Storage();
            data = storage.getData();
            var known = chart.Series.Add("Points For Interpolation");
            known.ChartType = SeriesChartType.Point;
            foreach (PointF p in data)
            {
                DataPoint d = new DataPoint(p.X, p.Y);
                d.Label = "(" + p.X + ":" + p.Y + ")";
                known.Points.Add(d);
            }
            NewtonInterpolator newton = new NewtonInterpolator(data);
            newton.setPowerOfInterpolation(4);
            displayInterpolator(newton, "Newton", data[0].X, data[data.Count - 1].X);
            displayInterpolator(new SplineInterpolator(data), "Spline", data[0].X, data[data.Count - 1].X);
        }
        public void displayInterpolator(Interpolator interpolator, String name, double from, double to)
        {
            var series = chart.Series.Add(name);
            series.ChartType = SeriesChartType.Line;
            for (double i = from; i <= to; i+=0.01)
            {
                series.Points.AddXY(i, interpolator.getPoint(i));
            }
        }
        
    }
}
