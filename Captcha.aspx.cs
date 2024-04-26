using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace A6
{
    public partial class Captcha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GenerateCaptcha();
        }

        private string GenerateRandomCode()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            char[] captchaChars = new char[6];
            for (int i = 0; i < 6; i++)
            {
                captchaChars[i] = chars[random.Next(chars.Length)];
            }
            return new string(captchaChars);
        }


        private void GenerateCaptcha()
        {
            string captchaCode = GenerateRandomCode();
            Session["CaptchaCode"] = captchaCode;

            using (Bitmap bitmap = new Bitmap(200, 60))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.Clear(Color.White);

                    // Draw random lines to make it harder for bots to parse
                    Random random = new Random();
                    for (int i = 0; i < 10; i++)
                    {
                        int x1 = random.Next(bitmap.Width);
                        int y1 = random.Next(bitmap.Height);
                        int x2 = random.Next(bitmap.Width);
                        int y2 = random.Next(bitmap.Height);
                        graphics.DrawLine(new Pen(Color.LightGray), x1, y1, x2, y2);
                    }

                    // Draw text on the image
                    Font font = new Font("Arial", 20, FontStyle.Bold);
                    graphics.DrawString(captchaCode, font, Brushes.Black, new PointF(10, 10));

                    // Output the image to the response stream
                    Response.ContentType = "image/jpeg";
                    bitmap.Save(Response.OutputStream, ImageFormat.Jpeg);
                }
            }
        }
    }
}