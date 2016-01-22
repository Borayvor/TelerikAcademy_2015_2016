namespace E01_Hello
{
    using System;
    using System.Reflection;

    public partial class Hello : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LabelLocation.Text = Assembly.GetExecutingAssembly().Location;
        }

        protected void ButtonHelloName_Click(object sender, EventArgs e)
        {
            string result = "Hello";

            if (!string.IsNullOrWhiteSpace(this.TextBoxName.Text))
            {
                result += string.Format(" {0}", this.TextBoxName.Text);
            }

            this.LabelResult.Text = result + " !";
        }
    }
}