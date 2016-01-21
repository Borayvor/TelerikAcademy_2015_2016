namespace E01_WebFormsSumNumbers
{
    using System;
    using System.Web;
    using System.Web.UI;

    public partial class Converter : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var text = this.Request.Params["text"] ?? "Default";
            this.ImageOutput.ImageUrl = "TextToImage.ashx?text=" + text;
        }

        protected void ButtonRenderImage_Click(object sender, EventArgs e)
        {
            string text = string.IsNullOrEmpty(this.TextBoxInput.Text) ? "Empty" : this.TextBoxInput.Text;
            this.ImageOutput.ImageUrl = "TextToImage.ashx?text=" + HttpContext.Current.Server.UrlEncode(text);
        }
    }
}