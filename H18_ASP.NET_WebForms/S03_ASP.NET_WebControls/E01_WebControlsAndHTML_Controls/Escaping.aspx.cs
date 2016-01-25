using System;

namespace E01_WebControlsAndHTML_Controls
{
    public partial class Escaping : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonJustShowText_Click(object sender, EventArgs e)
        {
            string enteredText = this.TextBoxSampleText.Text;
            LabelEnteredText.Text = enteredText;
            LiteralEnteredText.Text = enteredText;
        }

        protected void ButtonShowHtmlEncoded_Click(object sender, EventArgs e)
        {
            string enteredText = this.TextBoxSampleText.Text;
            LabelEnteredText.Text = Server.HtmlEncode(enteredText);
            LiteralEnteredText.Text = Server.HtmlEncode(enteredText);
        }
    }
}