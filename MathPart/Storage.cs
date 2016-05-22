using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathPart
{
    public class Storage : ICollection<PointF>, IList<PointF>, IListSource
    {
        private String filename;
        List<PointF> data;
        public int Count
        {
            get
            {
                return data.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public bool ContainsListCollection
        {
            get
            {
                return true;
            }
        }

        public PointF this[int index]
        {
            get
            {
                return data[index];
            }

            set
            {
                data[index] = value;
            }
        }

        public Storage(String fileName="storage.txt")
        {
            filename = fileName;
            if (File.Exists(filename))
            {
                data = getData();
            }
            else
            {
                File.Create(filename).Dispose();
                data = new List<PointF>();
            }
            
        }
        private List<PointF> getData()
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
        private void writePoint(PointF p)
        {
            using (Stream stream = File.Open(filename, FileMode.Append))
            using (TextWriter sr = new StreamWriter(stream, Encoding.UTF8))
            {
                string line = p.X + " " + p.Y;
                sr.WriteLineAsync(line);
            }
        }
        private void writePoints(List<PointF> ps)
        {
            using (Stream stream = File.Open(filename, FileMode.Append))
            using (TextWriter sr = new StreamWriter(stream, Encoding.UTF8))
            {
                foreach (PointF p in ps)
                {
                    sr.WriteLine(p.X + " " + p.Y);
                }
            }
        }

        public void Add(PointF item)
        {
            writePoint(item);
            data.Add(item);
        }

        public void Clear()
        {
            data.Clear();
            File.WriteAllText(filename, string.Empty);
        }

        public bool Contains(PointF item)
        {
            return data.Contains(item);
        }

        public void CopyTo(PointF[] array, int arrayIndex)
        {
            data.CopyTo(array, arrayIndex);
        }

        public bool Remove(PointF item)
        {
            return data.Remove(item);
        }

        public IEnumerator<PointF> GetEnumerator()
        {
            return data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int IndexOf(PointF item)
        {
            return ((IList<PointF>)data).IndexOf(item);
        }

        public void Insert(int index, PointF item)
        {
            data.Insert(index, item);
            writePoint(item);
        }

        public void RemoveAt(int index)
        {
            data.RemoveAt(index);
            File.WriteAllText(filename, string.Empty);
            writePoints(data);
        }

        public void Sort(IComparer<PointF> comparer)
        {
            data.Sort(comparer);
        }

        public List<PointF> ToList()
        {
            return data;
        }

        public IList GetList()
        {
            return data;
        }
    }
}
