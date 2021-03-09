using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Security.Cryptography;

namespace GLB.Global
{
    /// <summary>
    /// 全局所使用的所有工具类
    /// </summary>
    public static class Tool
    {



        /// <summary>
        /// 生成一个jpg图像并保存
        /// </summary>
        /// <param name="imageCode">所需要画在图片上的字符串</param>
        public static byte[] CreateImageCode(string imageCode)
        {

            Random random = new Random();
            Bitmap image = new Bitmap(50, 20);  //生成一个像素图“画板”
            Graphics g = Graphics.FromImage(image);    //在画板的基础上生成一个绘图对象
            g.Clear(Color.White);           //添加底色
            for (int i = 0; i < 30; i++)
            {
                //画直线
                g.DrawLine(new Pen(Color.Silver),
                    new Point(random.Next(0, 10), random.Next(3, 17)),
                    new Point(random.Next(40, 50), random.Next(3, 17)));

            }
            g.DrawString(imageCode,       //绘制字符串
                new Font("宋体", 13),                //指定字体
                 new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.DarkRed, 1.2f, true),    //绘制时使用的刷子
                new PointF(5, 1)                    //左上角定位
            );
            for (int i = 0; i < 50; i++)
            {
                //绘制一个像素的点
                image.SetPixel(random.Next(0, 50),
                    random.Next(0, 20),
                    Color.FromArgb(random.Next()));
            }

            image.Save(@"D:\VisualStudio\SourceStack\_17BangMVC\Bang\Images\InputCode.jpeg", ImageFormat.Jpeg);//保存到文件
            MemoryStream ms = new MemoryStream();
            image.Save(ms, ImageFormat.Jpeg);
            return ms.ToArray();//将流内容写入byte数组返回
        }

        /// <summary>
        /// 随机生成一个大写的字母
        /// </summary>
        /// <returns>返回一个生成的随机大写字母</returns>
        public static string Letter(Random random)
        {
            char[] table = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            int nub = DiceRandom(0, 26, random);
            return table[nub].ToString();
        }

        /// <summary>
        /// 生成一个随机数
        /// </summary>
        /// <param name="min">包含当前数字的最小值</param>
        /// <param name="max">包含当前数字的最大值</param>
        /// <returns>返回一个随机数</returns>
        public static int DiceRandom(int min, int max, Random random)
        {
            return random.Next(min, max + 1);
        }

        /// <summary>
        /// 随机生成的带数字和大写字母的字符串
        /// </summary>
        /// <param name="length">字符串的长度</param>
        /// <returns>返回一个随机生成的带数字和大写字母的字符串</returns>
        public static string ImageCode(int length)
        {
            Random random = new Random();
            string imageCode = null;
            ///生成一个字母和数字随机的字符串
            for (int i = 0; i < length; i++)
            {
                if (DiceRandom(0, 1, random) == 1)
                {
                    imageCode += Letter(random);
                }
                else
                {
                    imageCode += DiceRandom(0, 9, random);
                }
            }
            return imageCode;
        }

        /// <summary>
        /// 使用MD5进行加密
        /// </summary>
        /// <param name="source">要加密的字符串</param>
        /// <returns> 返回加密过后的字符串</returns>
        public static string MD5Crytp(string source)
        {
            byte[] bytes = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(source));

            StringBuilder SB = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                SB.Append(bytes[i].ToString("x2"));
            }

            return SB.ToString();
        }


    }
}
