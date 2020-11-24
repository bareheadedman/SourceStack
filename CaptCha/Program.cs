using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaptCha
{
    class Program
    {
        static void Main(string[] args)
        {
            string box = "0123456789abcdefghijklmnobqrstuvwxyzABCDEFGHIJKLMNOBQRSTUVWXYZ";
            Random random = new Random();
            int width = 200;
            int height = 80;

            Bitmap image = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(image);
            g.Clear(Color.White);



            for (int i = 0; i < 60; i++)
            {
                g.DrawLine(new Pen(Color.FromArgb(random.Next(255), random.Next(255), random.Next(255), random.Next(255))),
                           new Point(random.Next(60), random.Next(70)),
                           new Point(random.Next(60) * 3, random.Next(70))
                          );

            }

            int a = 0;
            for (int i = 0; i < 4; i++)
            {

                string temp = box[random.Next(box.Length - 1)].ToString();
                g.DrawString(temp,
                    new Font("宋体", 50),
                    new SolidBrush(Color.FromArgb(220, random.Next(255), random.Next(255), random.Next(255))),
                    new Point(random.Next(25) + a, random.Next(25))
                    );
                a += 40;
            }

            for (int i = 0; i < 80; i++)
            {
                image.SetPixel(random.Next(200), random.Next(80), Color.FromArgb(random.Next(255), random.Next(255), random.Next(255), random.Next(255)));
            }
            image.Save(@"D:\lw\CaptCha.JPG", ImageFormat.Jpeg);

        }

        public void Line(Graphics graphics, int count,Bitmap bitmap)
        {
            if (graphics == null)
            {
                throw new NullReferenceException($"{DateTime.Now}试图调用CaptCha类的Line方法,Graphics为{graphics}");
            }
            if (count <= 0 || bitmap.Width <= 0 || bitmap.Height <= 0)
            {
                throw new ArgumentOutOfRangeException($"{DateTime.Now}试图调用CaptCha类的Line方法传入的参数小于或等于0,count{count},x{bitmap.Width},y{bitmap.Height}");
            }
            Random random = new Random();
            for (int i = 0; i < count; i++)
            {
                graphics.DrawLine(new Pen(Color.FromArgb(random.Next(255), random.Next(255), random.Next(255), random.Next(255))),
                           new Point(random.Next((bitmap.Width / 3)), random.Next(bitmap.Height)),
                           new Point(random.Next(bitmap.Width), random.Next(bitmap.Height))
                          );

            }

        }
        public void Draw(Graphics graphics,string box,int count,int distance ,int xize)
        {
            Random random = new Random();
            int a = 0;
            for (int i = 0; i < count; i++)
            {

                string temp = box[random.Next(box.Length - 1)].ToString();
                graphics.DrawString(temp,
                    new Font("宋体", xize),
                    new SolidBrush(Color.FromArgb(220, random.Next(255), random.Next(255), random.Next(255))),
                    new Point(random.Next(25) + a, random.Next(25))
                    );
                a += distance;
            }

        }

    }
}
