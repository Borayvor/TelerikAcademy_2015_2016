using System;

namespace E01_WebControlsAndHTML_Controls
{
    public partial class HtmlServerControls : System.Web.UI.Page
    {
        Random randomGenerator = new Random();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSubmit_ServerClick(object sender, EventArgs e)
        {
            int minValue = int.Parse(this.TextFieldFirst.Value);
            int maxValue = int.Parse(this.TextFieldSecond.Value);
            int randomNumber = randomGenerator.Next(minValue, maxValue + 1);

            Response.Write("<div>" + "result: " + randomNumber + "</div>");
        }
    }
}