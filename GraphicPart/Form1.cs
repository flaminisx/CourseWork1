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
        Storage data;
        List<PointF> kdata;
        Color[] colors = { Color.DarkOrange, Color.ForestGreen };
        private int powerOfInterpolation = 4;
        private const int MAX_POWER = 4;
        int num = 0;
        private double min, max;
        public Form1()
        {
            InitializeComponent();
            data = new Storage();
            kdata = new List<PointF>();
            if (data.Count <= MAX_POWER)
                powerOfInterpolation = data.Count - 1;
            if (data.Count > 1)
            {
                min = data[0].X;
                max = data[data.Count - 1].X;
                displayKnown();
                displayInterpolators(min, max);
            }
            //chart.MouseWheel += new MouseEventHandler(chartWheelEvent); //uncomment to wheel
            knownGridView.DataSource = data;
            methodPicker.SelectedIndex = 0;
        }
        private void displayKnown()
        {
            getKnown();
            if (kdata.Count < 0) return;
            var known = chart.Series.Add("known");
            known.LegendText = "Known points";
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
        public void displayInterpolators(double from, double to)
        {
            if (data.Count < 1) return;
            NewtonInterpolator newton = new NewtonInterpolator(data.ToList());
            newton.setPowerOfInterpolation(powerOfInterpolation);
            displayInterpolator(newton, "Newton", min, max);
            displayInterpolator(new SplineInterpolator(data.ToList()), "Spline", min, max);
            displayChartDomain();
        }
        public void displayInterpolator(Interpolator interpolator, string name, double from, double to)
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

        private void addInputBtn_Click(object sender, EventArgs e)
        {
            data.Add(new PointF(Convert.ToSingle(inputXbox.Text), Convert.ToSingle(inputYbox.Text)));
            if (data.Count <= MAX_POWER)
                powerOfInterpolation = data.Count - 1;
            findMinMax();
            redisplayInterpolators(min, max);
            knownGridView.Update();
            knownGridView.Refresh();
        }

        private void sortData()
        {
            data.Sort(new PointXComparer());
        }
        private void findMinMax()
        {
            foreach (PointF p in data)
            {
                if (min > p.X) min = p.X;
                if (max < p.X) max = p.X;
            }
        }

        private void rebuildBtn_Click(object sender, EventArgs e)
        {
            double mn = Convert.ToDouble(xMin.Text);
            double mx = Convert.ToDouble(xMax.Text);
            if (mn >= mx) return;
            min = mn;
            max = mx;
            redisplayInterpolators(min, max);
        }

        private void findXbox_TextChanged(object sender, EventArgs e)
        {
            double x = 0;
            try
            {
                x = Convert.ToDouble(findXbox.Text);
                switch (methodPicker.SelectedIndex)
                {
                    case 0:
                        var h = new NewtonInterpolator(data.ToList());
                        h.setPowerOfInterpolation(powerOfInterpolation);
                        foundYbox.Text = h.getPoint(x).ToString();
                        break;
                    case 1:
                        var s = new SplineInterpolator(data.ToList());
                        foundYbox.Text = s.getPoint(x).ToString();
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

        private void delBtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in knownGridView.SelectedRows)
            {
                data.RemoveAt(r.Index);
                Console.WriteLine(r.Index);
            }
            knownGridView.Update();
            knownGridView.Refresh();
            redisplayInterpolators(min, max);
        }

        private void knownGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine(e.RowIndex);
        }

        private void displayChartDomain()
        {
            xMin.Text = min.ToString();
            xMax.Text = max.ToString();
        }
    }
}
