using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RandomSierpinskiTriangle
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        Bitmap bitmap;
        Graphics GFX;
        float h, a, b, y, x, r;
        PointF A, B, C;
        PointF[] points = new PointF[3];
        Random random;

        private void MainForm_Load(object sender, EventArgs e)
        {
            random = new Random();

            this.TopMost = true;
            this.Bounds = Screen.PrimaryScreen.Bounds;
            this.WindowState = FormWindowState.Maximized;

            pbCanvas.Size = this.Size;
            bitmap = new Bitmap(this.Width, this.Height);
            GFX = Graphics.FromImage(bitmap);

            GFX.TranslateTransform(this.Width / 2, this.Height / 2);// + h / 2);
            bool flipped = true;
            r = 500;
            r *= flipped ? -1 : 1;
            float thetaA = (float)Math.PI / 2;
            float thetaB = 210 * (float)Math.PI / 180;
            float thetaC = 11 * (float)Math.PI / 6;

            A = new PointF(r * (float)Math.Cos(thetaA), r * (float)Math.Sin(thetaA));
            B = new PointF(r * (float)Math.Cos(thetaB), r * (float)Math.Sin(thetaB));
            C = new PointF(r * (float)Math.Cos(thetaC), r * (float)Math.Sin(thetaC));

            h = Math.Abs(B.Y);
            a = (float)Math.Tan(2 * Math.PI / 3);
            b = A.Y;

            //y = random.Next(0, (int)Math.Floor(h)) - b;
            //x = random.Next(0, (int)Math.Floor(2 * (y + b) / a)) - (y + b) / a;
            //y *= -1;


            GFX.Clear(Color.White);

            //GFX.FillEllipse(Brushes.Aqua, x, y, 5, 5);

            ////GFX.DrawLine(Pens.Black, A, B);
            ////GFX.DrawLine(Pens.Black, A, C);
            ////GFX.DrawLine(Pens.Black, C, B);

            //GFX.FillEllipse(Brushes.Red, A.X, A.Y, 10, 10);
            //GFX.FillEllipse(Brushes.Red, B.X, B.Y, 10, 10);
            //GFX.FillEllipse(Brushes.Red, C.X, C.Y, 10, 10);

            //bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
            points[0] = A;
            points[1] = B;
            points[2] = C;

            //for (int i = 0; i < 70; i++)
            //{
            var rpoint = RandomPoint();
            GFX.FillEllipse(Brushes.Black, rpoint.X, rpoint.Y, 1, 1);// 10, 10);
            pbCanvas.Image = bitmap;
            //}

            //Update();

            timer.Interval = 1;
            timer.Start();
        }

        private void Fractal(int pt, int n)
        {
            int rc = 0;

            for (int j = 0; j < n; j++)
            {
                int i = random.Next(3);
                x += (points[i].X - x) / 2;
                y += (points[i].Y - y) / 2;
                GFX.FillEllipse(Brushes.Black, x, y, pt, pt);
                //bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
                //rc++;
                //y *= -1;
            }
            //bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
            //rc++;
            //y *= -1;

            if (rc % 2 == 1)
                bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);

        }

        private void Update(object sender, EventArgs e)
        {

            Fractal(1, 100);
            //GFX.FillEllipse(new SolidBrush(Color.FromArgb(random.Next(255),random.Next(255),random.Next(255))), x, y, 1, 1);


            //GFX.FillEllipse(Brushes.Red, A.X, A.Y, 10, 10);
            //GFX.FillEllipse(Brushes.Red, B.X, B.Y, 10, 10);
            //GFX.FillEllipse(Brushes.Red, C.X, C.Y, 10, 10);

            //GFX.Clear(Color.White);
            //GFX.DrawLine(Pens.Black, A, B);
            //GFX.DrawLine(Pens.Black, A, C);
            //GFX.DrawLine(Pens.Black, C, B);


            //bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
            //GFX.DrawString($"{x}, {y}", new Font("Calibri",16), Brushes.Black, 0, 0);
            pbCanvas.Image = bitmap;
        }

        private PointF RandomPoint()
        {
            y = random.Next(0, (int)Math.Abs(A.Y) + (int)h) - h - h;
            x = random.Next(0, (int)Math.Abs(2 * (y - b) / a)) + (y - b) / a;
            //y *= -1;

            return new PointF(x, y);
        }
    }
}
