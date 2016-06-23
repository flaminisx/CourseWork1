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
    public class Storage : ICollection<PointF>, IList<PointF>, IListSource //класс для збереження інтерполяційної сітки
    {
        public class HasSuchPointException : Exception
        { }
        private String filename; // назва файлу для збереження данних
        private List<PointF> data; // список вузлів інтерполяції
        public int Count //кількість вузлів інтерполяції
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

        public PointF this[int index] // доступ до вузлів інтерполіції
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
        private List<PointF> getData() //зчитування сітки інтерполяції з файлу
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
        private void writePoint(PointF p) //запис однієї точки у файл
        {
            using (Stream stream = File.Open(filename, FileMode.Append))
            using (TextWriter sr = new StreamWriter(stream, Encoding.UTF8))
            {
                string line = p.X + " " + p.Y;
                sr.WriteLineAsync(line);
            }
        }
        private void writePoints(List<PointF> ps) // запис кількох точок у файл
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
        public bool HasX(PointF point) // Перевірка на наявність точки з такою координатою Х
        {
            bool r = false;
            foreach (PointF p in data)
            {
                if (p.X == point.X) r = true;
            }
            return r;
        }
        public void Add(PointF item) // додавання точки у файл і список
        {
            if (HasX(item)) throw new HasSuchPointException();
            writePoint(item);
            data.Add(item);
        }

        public void Clear() // очищення файлу і списку
        {
            data.Clear();
            File.WriteAllText(filename, string.Empty);
        }

        public bool Contains(PointF item) // перевірка чи є точка у сітці
        {
            return data.Contains(item);
        }

        public void CopyTo(PointF[] array, int arrayIndex) 
        {
            data.CopyTo(array, arrayIndex);
        }

        public bool Remove(PointF item) //видалення вузлу інтерполяції
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

        public int IndexOf(PointF item) // пошук у сітці інтерполяції
        {
            return ((IList<PointF>)data).IndexOf(item);
        }

        public void Insert(int index, PointF item) // вставка у сітку
        {
            data.Insert(index, item);
            writePoint(item);
        }

        public void RemoveAt(int index) //видалення вузлу інтерполяції за індексом
        {
            data.RemoveAt(index);
            File.WriteAllText(filename, string.Empty);
            writePoints(data);
        }

        public void Sort(IComparer<PointF> comparer) //сортування за заданим порівнювачем
        {
            data.Sort(comparer);
        }

        public List<PointF> ToList() // приведення типу до списку
        {
            return data;
        }

        public IList GetList()
        {
            return data;
        }
    }
}
