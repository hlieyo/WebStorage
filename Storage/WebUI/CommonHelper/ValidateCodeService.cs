using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace UI.CommonHelper
{
    public class ValidateCodeService
    {
        /// <summary>
        /// 生成验证图片
        /// </summary>
        ///<param name="checkCode">验证字符</param>
        public Byte[] CreateImages(string checkCode)
        {
            int iheight = 50;
            int iwidth = (int)(checkCode.Length * iheight / 1.85);
            Bitmap image = new Bitmap(iwidth, iheight);
            Graphics g = Graphics.FromImage(image);
            g.Clear(Color.White);
            //定义颜色
            Color[] c = { Color.Black, Color.Red, Color.DarkBlue, Color.Green, Color.Orange, Color.Brown, Color.DarkCyan, Color.Purple, Color.SkyBlue };
            //定义字体 
            string[] font = { "Verdana", "Microsoft Sans Serif", "Comic Sans MS", "Arial", "宋体", "Comic Sans MS" };
            Random rand = new Random();

            //输出不同字体和颜色的验证码字符
            for (int i = 0; i < checkCode.Length; i++)
            {
                int cindex = rand.Next(7);
                int findex = rand.Next(6);
                Font fs_font = new Font(font[findex], iheight / 2, FontStyle.Bold);
                Brush b = new SolidBrush(c[cindex]);
                int ii = 4;
                if ((i + 1) % 2 == 0)
                {
                    ii = 2;
                }
                g.DrawString(checkCode.Substring(i, 1), fs_font, b, 3 + (i * iheight / 2), ii);
            }

            //随机输出噪点
            for (int i = 0; i < image.Height; i = i + iheight / 5)
            {
                int cindex = rand.Next(7);

                //g.DrawLine(new Pen(c[cindex], iheight / 100), new Point(0, i), new Point(image.Width, i));                

                int jd = rand.Next(180);
                int jd1 = rand.Next(180);
                int w = rand.Next(image.Width / 2);
                int h = rand.Next(image.Height / 2);
                g.DrawPie(new Pen(c[cindex], iheight / 100 + iheight / 100), new Rectangle(w, h, image.Width, image.Height), jd, jd1);
            }

            //画一个边框
            //g.DrawRectangle(new Pen(Color.Red, 0), 100, 0, image.Width - 1, image.Height - 1);



            byte[] bt = null;
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                bt = new byte[ms.Length];
                ms.Seek(0, SeekOrigin.Begin);
                ms.Read(bt, 0, Convert.ToInt32(bt.Length));
            }

            //System.IO.MemoryStream ms = new System.IO.MemoryStream();
            //image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            //context.Response.ClearContent();//Response.ClearContent();
            //context.Response.ContentType = "image/Jpeg";
            //context.Response.BinaryWrite(ms.ToArray());
            g.Dispose();
            image.Dispose();
            return bt;
        }
    }
}