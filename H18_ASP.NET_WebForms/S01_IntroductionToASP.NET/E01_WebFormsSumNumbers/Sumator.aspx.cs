using System;

namespace E01_WebFormsSumNumbers
{
    public partial class Sumator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonCalculateSum_Click(object sender, EventArgs e)
        {
            try
            {
                var firstNumber = Decimal.Parse(this.TextBoxFirstNumber.Text);
                var secondNumber = Decimal.Parse(this.TextBoxSecondNumber.Text);
                var sum = firstNumber + secondNumber;
                this.TextBoxResult.Text = sum.ToString();
            }
            catch (Exception)
            {
                this.TextBoxResult.Text = "Invalid input !";
            }
        }
    }
}