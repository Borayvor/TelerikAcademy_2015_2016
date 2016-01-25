using System;

namespace E01_WebControlsAndHTML_Controls
{
    public partial class StudentsAndCourses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            this.LiteralResult.Text =
                "First name: " + this.TextBoxFirstName.Text + "<br />" +
                "Last name: " + this.TextBoxLastName.Text + "<br />" +
                "Faculty number: " + this.TextBoxFacultyNumber.Text + "<br />" +
                "University: " + this.DropDownListUniversity.SelectedValue + "<br />" +
                "Specialty: " + this.DropDownListSpecialty.SelectedValue + "<br />" +
                "Courses: " + this.ListBoxListOfCourses.SelectedValue;
        }
    }
}