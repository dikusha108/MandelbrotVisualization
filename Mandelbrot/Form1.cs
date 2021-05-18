using System;
using System.Drawing;
using System.Windows.Forms;

namespace Mandelbrot
{
    public partial class Form1 : Form
    {
        double hx = 0, hy = 0, x_, y_, n = 0;
        Size size;
        double sizeArea, scaleArea;
        public Form1()
        {
            InitializeComponent();
            size = pictureBox1.Size;
            sizeArea = 2;
            scaleArea = 2;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Draw();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        public void Draw()
        {
            Bitmap btm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            int iterations = 100;
            size = pictureBox1.Size;

            for (int x=0; x<pictureBox1.Width; x++)
            {
                x_ = (hx - sizeArea / 2) + x * (sizeArea / size.Width);
                for (int y = 0; y < pictureBox1.Height; y++)
                {
                    y_ = (hy - sizeArea / 2) + y * (sizeArea / size.Height);

                    Complex Z = new Complex(0, 0);

                    int count = 0;

                    do
                    {
                        count++;
                        Z = Z.Pow2();
                        Z = Sum(Z, new Complex(x_, y_));
                        if (Z.ModulusPow2() > 4) break;

                    } while (count < iterations);
                    
                    btm.SetPixel(x, y, count < 100 ? Color.FromArgb(200 - count % 50 * 4, 220 - count % 45 * 4, 220 - count % 30 * 6) : Color.FromArgb(250, 250, 250));
                }
            }

            pictureBox1.Image = btm;
        }

        //private void btnUvel_Click (object sender, EventArgs e)
        //{
        //    try
        //    {
        //        n = Math.Abs(Double.Parse(text.Text));
        //        sizeArea /= n;
        //        Draw();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int X = e.X, Y = e.Y;
            switch (e.Button)
            {
                case MouseButtons.Left:
                    hx = (hx - sizeArea / 2) + X * (sizeArea / size.Width);
                    hy = (hy - sizeArea / 2) + Y * (sizeArea / size.Height);
                    sizeArea /= scaleArea;
                    Draw();
                    break;
                case MouseButtons.Middle:
                    sizeArea = 2;
                    scaleArea = 2;
                    Draw();
                    break;
                case MouseButtons.Right:
                    x_ = (hx - sizeArea / 2) + X * (sizeArea / size.Width);
                    y_ = (hy - sizeArea / 2) + Y * (sizeArea / size.Height);
                    sizeArea *= scaleArea;
                    Draw();
                    break;
                default:
                    break;
            }
        }

        public Complex Sum(Complex X, Complex Y)
        {
            return new Complex(X.a + Y.a, X.b + Y.b);
        }

    }
}
