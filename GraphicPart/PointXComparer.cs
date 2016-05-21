using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicPart
{
    class PointXComparer : IComparer<PointF>
    {
        public int Compare(PointF x, PointF y)
        {
            if (x.X - y.X < 0) return -1;
            if (x.X - y.X > 0) return 1;
            else return 0;
        }
    }
}
