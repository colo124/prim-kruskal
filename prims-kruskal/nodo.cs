using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace prims_kruskal
{
    public class nodo
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Principal());
        }

        public string name;
		SolidBrush brush = new SolidBrush(Color.Black);
		public nodo()
		{			
		}
		public Point Center;
		Font font=new Font("Arial",9);
		public ArrayList ar=new ArrayList();
		public void setcenter(Point p)
		{
			Center = p;
		}
		public void drawc()
		{
            Graphics s = prims_kruskal.Principal.K.CreateGraphics();
			
			s.FillEllipse(brush,Center.X,Center.Y,30,30);
			s.DrawString(name,font,brush,Center.X,Center.Y+30);
		} 

    }
}
