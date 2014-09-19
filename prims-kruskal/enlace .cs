using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace prims_kruskal
{

    public class enlace
    {
        public enlace(long p,string f,string t)
		{
			peso=p;
			from=f;
			to=t;
		}
        public Point Center1, Center2;
        public long peso;
        public string from;
        public string to;
        public void setcenter(Point p)
        {
            Point s = new Point();
            s.X = p.X + 10;
            s.Y = p.Y + 10;
            Center1 = s;
        }
        public void setcenter1(Point p)
        {
            Point s = new Point();
            s.X = p.X + 10;
            s.Y = p.Y + 10;
            Center2 = s;
        }
    }
}
