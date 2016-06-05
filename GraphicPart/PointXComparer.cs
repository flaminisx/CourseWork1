using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicPart
{
    class PointXComparer : IComparer<PointF> //класс, що порівнює 2 точки за данними X
    {
        public int Compare(PointF x, PointF y)
        {
            if (x.X - y.X < 0) return -1;
            if (x.X - y.X > 0) return 1;
            else return 0;
        }
    }
}
