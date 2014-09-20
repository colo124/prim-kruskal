using ARM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prims_kruskal
{
    public partial class Principal : Form
    {
        public static Form K;
        private NodoVisual seleccionado;
        private List<Nodo> nodos;
        private List<Enlace> enlaces;
        private Grafo g = new Grafo();

        SolidBrush brush = new SolidBrush(Color.Black);
        Font font = new Font("Arial", 9);
        Pen pen = new Pen(Color.Black, 3);

        public Principal() // constructor
        {
            InitializeComponent();
            this.nodos = new List<Nodo>(); // lista de nodos
            this.enlaces = new List<Enlace>();

            K = this;
            this.seleccionado = null; //inicializa seleccionado en null 
        }
        private void button1_Click(object sender, EventArgs e) // Funcion: recibe los valores para dibijar el nodo, crea un nuevo punto y un nuevo nodo y llama a la funcion para dibujar
        {
            NodoVisual n = new NodoVisual();
            int x,y = 0;
            x = int.Parse(this.textBox3.Text);
            y = int.Parse(this.textBox4.Text);
            Point p = new Point(x,y);
            n.Center = p;
            n.nombre = this.textBox1.Text;
            bool bandera = true;
            if (this.nodos.Count > 0) {  
                foreach (var Nodo in nodos)
                {
                    if (n.nombre == Nodo.nombre)
                    {
                        MessageBox.Show("No se puede repitir el nombre de un Nodo", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bandera = false;
                    }
                }
            }
            if (bandera) { 
                this.nodos.Add(n);
                this.g.AgregarNodo((Nodo)n);
                Dibujar();
            }
        }
        private void button1_Click_1(object sender, EventArgs e) //Evento: Dibujo; Captura los elementos seleccionados en el dropdown y luego los busca por el nombre en la lista de nodos, luego se los manda a la funcion de dibujar la linea
        {
            var desde = this.Desde.Items[this.Desde.SelectedIndex]; //elem seleccionado desde
            var hasta = this.Hasta.Items[this.Hasta.SelectedIndex]; //elem seleccionado hasta
            var nodo_desde= this.nodos.FirstOrDefault(d => d.nombre == desde); //busca en la lista de nodos donde el nombre sea el mismo
            var nodo_hasta = this.nodos.FirstOrDefault(h => h.nombre == hasta); //busca en la lista de nodos donde el nombre sea el mismo
            var peso = int.Parse(this.textBox6.Text);
            this.DibujarEnlace(peso, (NodoVisual)nodo_desde, (NodoVisual)nodo_hasta);
            
        }
        private void Dibujar() // Funcion: Dibujo; Dibuja los nodos con sus respectivos nombres, a su ves carga los nombres los dropdowns.
        {
            Desde.Items.Clear();
            Hasta.Items.Clear();
            Graphics s = prims_kruskal.Principal.K.CreateGraphics();
            foreach (NodoVisual nodo in this.nodos)
            {
                Desde.Items.Add(nodo.nombre);
                Hasta.Items.Add(nodo.nombre);
                s.FillEllipse(brush, nodo.Center.X, nodo.Center.Y, 30, 30);
                s.DrawString(nodo.nombre, font, brush, nodo.Center.X + 7, nodo.Center.Y + 30);
            }

            foreach (var enlace in this.enlaces)
            {
                Point nodoA = new Point(((NodoVisual)enlace.NodoA).Center.X + 15, ((NodoVisual)enlace.NodoA).Center.Y + 15);
                Point nodoB = new Point(((NodoVisual)enlace.NodoB).Center.X + 15, ((NodoVisual)enlace.NodoB).Center.Y + 15);
                s.DrawLine(pen, nodoA, nodoB);
            }
            
        }
        private void DibujarEnlace(int peso, NodoVisual desde, NodoVisual hasta) // Funcion : Dibujo; Se encarga de trazar una linea entre dos nodos
        {
            Graphics g = prims_kruskal.Principal.K.CreateGraphics();
            Point d = new Point(desde.Center.X + 15, desde.Center.Y + 15);
            Point h = new Point(hasta.Center.X + 15, hasta.Center.Y + 15);
            EnlaceVisual e = new EnlaceVisual(peso, desde, hasta);
            bool bandera = true;
            if (this.enlaces.Count > 0)
            {
                foreach (var Enlace in enlaces)
                {
                    if (e.NodoA == Enlace.NodoA && e.NodoB == Enlace.NodoB || e.NodoB == Enlace.NodoA && e.NodoA == Enlace.NodoB)
                    {
                        MessageBox.Show("No se puede repetir un enlace ya creado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bandera = false;
                    }
                }
            }
            if (e.NodoA == e.NodoB)
            {
                MessageBox.Show("No se puede crear un enlace a si mismo", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bandera = false;
            }
            if (bandera)
            {
                enlaces.Add(e);
                g.DrawLine(pen, d, h);
                //PointF p = new PointF(d.X-h.X,d.Y-h.Y);
                //g.DrawString(peso.ToString(), font, brush, p);
                this.g.AgregarEnlace(e);
            }


        }
      
        private void Form1_MouseDown(object sender, MouseEventArgs e) //evento: movimiento; genera un cuadrado alrededor del circulo que al tocarlo simula la seleccion del nodo
        {
            foreach (NodoVisual n in this.nodos)
            {
                if ((n.Center.X <= e.X) && (n.Center.X + 30 >= e.X) && (n.Center.Y <= e.Y) && (n.Center.Y + 30 >= e.Y))
                {
                    this.seleccionado = n;
                }
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e) //evento: movimiento; controla el movimiento del nodo, va actualizando el x e y del nodo y redibujandolo a medida que se mueve
        {

            if (this.seleccionado != null) 
            {
                this.seleccionado.Center.X = e.X;
                this.seleccionado.Center.Y = e.Y;
                Graphics s = prims_kruskal.Principal.K.CreateGraphics();
                s.Clear(this.BackColor);
                this.Dibujar();
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)// evento: movimiento; suelta el nodo cuando soltas el click del mouse
        {
            this.seleccionado = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.enlaces = Prim.Ejecutar(g);
            Graphics s = prims_kruskal.Principal.K.CreateGraphics();
            s.Clear(this.BackColor);
            this.Dibujar();
        }
    }
}
