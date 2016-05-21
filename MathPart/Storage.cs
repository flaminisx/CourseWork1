using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathPart
{
    public class Storage
    {
        private String filename;
        public Storage(String fileName="storage.txt")
        {
            filename = fileName;
        }
        public List<PointF> getData()
        {
            List<PointF> values = new List<PointF>();
            using (Stream stream = File.Open(filename, FileMode.Open))
            using (TextReader sr = new StreamReader(stream, Encoding.UTF8))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] arr = line.Split(' ');
                    values.Add(new PointF((float)Double.Parse(arr[0]), (float)Double.Parse(arr[1])));

                }
            }
            return values;
        }
        public void addPoint(PointF p)
        {
            using (Stream stream = File.Open(filename, FileMode.Append))
            using (TextWriter sr = new StreamWriter(stream, Encoding.UTF8))
            {
                string line = p.X + " " + p.Y;
                sr.WriteLineAsync(line);
            }
        }
        public void addPoints(List<PointF> ps)
        {
            using (Stream stream = File.Open(filename, FileMode.Append))
            using (TextWriter sr = new StreamWriter(stream, Encoding.UTF8))
            {
                string text = "";
                foreach(PointF p in ps)
                {
                    text += p.X + " " + p.Y + "\n";
                }
                sr.WriteAsync(text);
            }
        }

    }
}
