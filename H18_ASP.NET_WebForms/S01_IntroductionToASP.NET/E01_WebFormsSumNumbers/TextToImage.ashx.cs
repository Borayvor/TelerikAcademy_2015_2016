namespace E01_WebFormsSumNumbers
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Web;

    /// <summary>
    /// Summary description for TextToImage
    /// </summary>
    public class TextToImage : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "image/png";
            var text = context.Request.Params["text"] ?? context.Request.Path.Substring(1, (context.Request.Path.Length - 5));
            var image = this.CreateBitmapImage(text);

            image.Save(context.Response.OutputStream, ImageFormat.Png);
        }

        private object CreateBitmapImage(object text)
        {
            throw new NotImplementedException();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        private Bitmap CreateBitmapImage(string txt, string fontname = "Algerian", int fontsize = 26)
        {
            //creating bitmap image
            Bitmap bmp = new Bitmap(1, 1);

            //FromImage method creates a new Graphics from the specified Image.
            Graphics graphics = Graphics.FromImage(bmp);

            // Create the Font object for the image text drawing.
            Font font = new Font(fontname, fontsize);

            // Instantiating object of Bitmap image again with the correct size for the text and font.
            SizeF stringSize = graphics.MeasureString(txt, font);
            bmp = new Bitmap(bmp, (int)stringSize.Width, (int)stringSize.Height);
            graphics = Graphics.FromImage(bmp);

            /* It can also be a way
           bmp = new Bitmap(bmp, new Size((int)graphics.MeasureString(txt, font).Width, (int)graphics.MeasureString(txt, font).Height));*/

            //Draw Specified text with specified format 
            graphics.DrawString(txt, font, Brushes.Purple, 0, 0);
            font.Dispose();
            graphics.Flush();
            graphics.Dispose();
            return bmp;     //return Bitmap Image 
        }
    }
}