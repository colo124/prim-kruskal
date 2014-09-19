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
        private nodo seleccionado;
        private List<nodo> nodos;
       // enlace = new ArrayList();

        SolidBrush brush = new SolidBrush(Color.Black);
        Font font = new Font("Arial", 9);
        Pen pen = new Pen(Color.Black, 3);

        public Principal() // constructor
        {
            InitializeComponent();
            this.nodos = new List<nodo>(); // lista de nodos
            K = this;
            this.seleccionado = null; //inicializa seleccionado en null 
            select_algorithm();
        }
        private void button1_Click(object sender, EventArgs e) // Funcion: recibe los valores para dibijar el nodo, crea un nuevo punto y un nuevo nodo y llama a la funcion para dibujar
        {
            nodo n = new nodo();
            int x,y = 0;
            x = int.Parse(this.textBox3.Text);
            y = int.Parse(this.textBox4.Text);
            Point p = new Point(x,y);
            n.Center = p;
            n.name = this.textBox1.Text;
            this.nodos.Add(n);
            draw();
        }
        private void button1_Click_1(object sender, EventArgs e) //Evento: Dibujo; Captura los elementos seleccionados en el dropdown y luego los busca por el nombre en la lista de nodos, luego se los manda a la funcion de dibujar la linea
        {
            var desde = this.Desde.Items[this.Desde.SelectedIndex]; //elem seleccionado desde
            var hasta = this.Hasta.Items[this.Hasta.SelectedIndex]; //elem seleccionado hasta
            var nodo_desde= this.nodos.FirstOrDefault(d => d.name == desde); //busca en la lista de nodos donde el nombre sea el mismo
            var nodo_hasta = this.nodos.FirstOrDefault(h => h.name == hasta); //busca en la lista de nodos donde el nombre sea el mismo
            this.draw_line(nodo_desde, nodo_hasta);
        }
        private void draw() // Funcion: Dibujo; Dibuja los nodos con sus respectivos nombres, a su ves carga los nombres los dropdowns.
        {
            Desde.Items.Clear();
            Hasta.Items.Clear();
            Graphics s = prims_kruskal.Principal.K.CreateGraphics();
            foreach (nodo nodo in this.nodos)
            {
                Desde.Items.Add(nodo.name);
                Hasta.Items.Add(nodo.name);
                s.FillEllipse(brush, nodo.Center.X, nodo.Center.Y, 30, 30);
                s.DrawString(nodo.name, font, brush, nodo.Center.X+7, nodo.Center.Y + 30);
                
            }
            
        }
        private void draw_line(nodo desde, nodo hasta) // Funcion : Dibujo; Se encarga de trazar una linea entre dos nodos
        {
            
           
            Graphics g = prims_kruskal.Principal.K.CreateGraphics();
            Point d = new Point(desde.Center.X + 15, desde.Center.Y + 15);
            Point h = new Point(hasta.Center.X + 15, hasta.Center.Y + 15);
            enlace aux = new enlace(12, desde.name, hasta.name);
            g.DrawLine(pen, d, h);

        }
        public void select_algorithm()
        {
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (Prims.Checked)
            {
                Kruscal.Checked = false;
            }
        }
        private void Kruscal_CheckedChanged(object sender, EventArgs e)
        {
            if (Kruscal.Checked)
            {
                Prims.Checked = false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e) //evento: movimiento; genera un cuadrado alrededor del circulo que al tocarlo simula la seleccion del nodo
        {
            foreach (nodo n in this.nodos)
            {
                if ((n.Center.X <= e.X) && (n.Center.X + 30 >= e.X) && (n.Center.Y <= e.Y) && (n.Center.Y + 30 >= e.Y))
                {
                    //MessageBox.Show("el nodo es" + n.name);
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
                this.draw();
                //this.draw_line();
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)// evento: movimiento; suelta el nodo cuando soltas el click del mouse
        {
            this.seleccionado = null;
        }




    }
}
