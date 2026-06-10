using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoligonGUI3102026B
{
    public partial class Form1 : Form
    {
        private readonly List<Tacka> _points = new List<Tacka>();
        poligon radni = new poligon(0);
        public Form1()
        {
            InitializeComponent();
            this.Width = 800;
            this.Height = 500;
            panel1.Paint += Panel1_Paint;

            this.Resize += Form1_Resize;
            // initial layout
            LayoutPanel();
        }
        private void LayoutPanel()
        {
            int left = this.Width/2;
            int top = 30;
            int right = 10;
            int bottom = 10;

            panel1.Location = new Point(left, top);
            panel1.Size = new Size(
            this.ClientSize.Width - left - right,
            this.ClientSize.Height - top - bottom);
        }
        public void button1_Click(object sender, EventArgs e)
        {
            radni = poligon.ucitaj();
            foreach(Tacka t in radni.teme)
            {
                AddPoint(t);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void AddPoint(Tacka t)
        {
            _points.Add(t);
            listBox1.Items.Add(t.toString());
            panel1.Invalidate();
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            if (radni != null)
            {
                Pen linija = new Pen(Color.Black, 2);
                int panelHeight = panel1.ClientSize.Height;
                int panelWidth = panel1.ClientSize.Width;
                int pocetak = panelWidth / 10;
                int kraj = panelWidth - pocetak;
                int visina = panelHeight * 9 / 10;
                e.Graphics.DrawLine(linija, pocetak, visina, kraj, visina);
                kraj = panelHeight / 10;
                e.Graphics.DrawLine(linija, pocetak, visina, pocetak, kraj);
                foreach (Vektor v in radni.stranice())
                {
                    CrtajLiniju(e.Graphics, v);
                }
                foreach (var t in _points)
                {
                    CrtajTacku(e.Graphics, t);
                }
            }
        }

        public void CrtajTacku(Graphics dr, Tacka t)
        {
            int panelHeight = panel1.ClientSize.Height;
            int panelWidth = panel1.ClientSize.Width;
            int x = panelWidth / 10 + (int)t.x*20;
            int y = panelHeight * 9 / 10 - (int)t.y*30;
            using (var cetka = new SolidBrush(Color.Red))
            {
                dr.FillEllipse(cetka, x - 4, y - 4, 8, 8);
            }
        }

        void CrtajLiniju(Graphics dr, Vektor v)
        {
            int panelHeight = panel1.ClientSize.Height;
            int panelWidth = panel1.ClientSize.Width;
            int x = panelWidth / 10;
            int y = panelHeight * 9 / 10;
            Pen linija = new Pen(Color.Black, 2);
            dr.DrawLine(linija, x + (float)v.pocetak.x * 20, y - (float)v.pocetak.y * 30, x + (float)v.kraj.x * 20, y - (float)v.kraj.y * 30);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (_points.Count!=0) radni.snimi();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AddPoint(new Tacka(double.Parse(textBox1.Text), double.Parse(textBox2.Text)));
        }

        private void button7_Click(object sender, EventArgs e)
        {
            radni = new poligon(_points.Count, _points.ToArray());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radni.prost()) MessageBox.Show("Prost");
            else MessageBox.Show("Nije prost");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (radni.konveksan()) MessageBox.Show("Konveksan");
            else MessageBox.Show("Konkavan");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show(radni.povrsina().ToString());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            _points.Clear();
            listBox1.Items.Clear();
            radni = new poligon(0);
            panel1.Invalidate();
        }
    }
}
