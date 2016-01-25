using System;

namespace E01_WebControlsAndHTML_Controls
{
    public partial class WebServerControls : System.Web.UI.Page
    {
        Random randomGenerator = new Random();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int minValue = int.Parse(this.TextBoxInputFirst.Text);
                int maxValue = int.Parse(this.TextBoxInputSecond.Text);
                int randomNumber = randomGenerator.Next(minValue, maxValue + 1);

                this.LabelResult.Text = "<div>" + "result: " + randomNumber + "</div>";
                this.LabelResult.Visible = true;
            }
        }
    }
}