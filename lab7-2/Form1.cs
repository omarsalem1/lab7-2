using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab7_2
{ 
    
    public partial class Form1 : Form
    {
        public delegate void MyDelegate();
        MyDelegate m_delegate;

        // line variables
        Pen line_pen;
        Point line_startpt;
        Point line_endpt;
        // rectangle variables
        Pen rect_pen;
        Point rect_startpt;
        int rect_width;
        int rect_length;
        //circle variables
        Pen cir_pen;
        Point cir_startpt;
        int cir_width;
        int cir_length;


        protected override void OnPaint(PaintEventArgs e)
        {
            if (m_delegate!=null)
            {
                m_delegate();
            }

        }

        public Form1()
        {
            InitializeComponent();
            line_pen = new Pen(Color.Black, 2.5f);
            line_startpt = new Point();
            line_endpt = new Point();
            //
            rect_pen = new Pen(Color.Black, 2.5f);
            rect_startpt = new Point();
            //
            cir_pen= new Pen(Color.Black, 2.5f);
            cir_startpt = new Point();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
           // line_startpt = new Point(e.X, e.Y);
            line_startpt.X = e.X;
            line_startpt.Y = e.Y;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            line_endpt.X = e.X;
            line_endpt.Y = e.Y;
            
           // draw_line();
            this.Invalidate();

        }
        public void draw_line()
        {
            Graphics g = this.CreateGraphics();

            g.DrawLine(line_pen, line_startpt, line_endpt);

        }
        public void draw_rectangle()
        {
            Graphics g = this.CreateGraphics();
            rect_startpt = line_startpt;
            rect_width = Math.Abs(line_startpt.X - line_endpt.X);
            rect_length =Math.Abs( line_startpt.Y - line_endpt.Y);
            
            
            g.DrawRectangle(rect_pen,rect_startpt.X,rect_startpt.Y,rect_width,rect_length);
            
        }
        public void draw_circle()
        {
            Graphics g = this.CreateGraphics();
            double cir_raduis;
            cir_startpt = line_startpt;
            cir_width = (line_startpt.X - line_endpt.X)* (line_startpt.X - line_endpt.X);
            cir_length = (line_startpt.Y - line_endpt.Y)* (line_startpt.Y - line_endpt.Y);
            cir_raduis = Math.Sqrt((double)cir_width + (double)cir_length);
            g.DrawEllipse(cir_pen,cir_startpt.X,cir_startpt.Y,(float)cir_raduis,(float)cir_raduis);

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            switch ((int)e.KeyChar) {
                case 3:
                    m_delegate = new MyDelegate(draw_circle);
                    break;
                case 12:
                    m_delegate = new MyDelegate(draw_line);
                    break;
                        
                case 18:
                    m_delegate = new MyDelegate(draw_rectangle);
                    break;
            }
        }

        //private void Form1_Paint(object sender, PaintEventArgs e)
        //{

        //}
    }
    
}
