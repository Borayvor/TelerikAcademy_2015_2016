namespace E01_Hello
{
    using System;

    public partial class PageLifecycle : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            Response.Write("<div>" + "Page_PreInit invoked" + "</div><br/>");
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            Response.Write("<div>" + "Page_Init invoked" + "</div><br/>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("<div>" + "Page_Load invoked" + "</div><br/>");
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            Response.Write("<div>" + "Page_PreRender invoked" + "</div><br/>");
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            // Response is unavailable at page unload
            // Response.Write("Page_Unload invoked" + "<br/>");
        }

        protected void ButtonOK_Init(object sender, EventArgs e)
        {
            Response.Write("<div>" + "ButtonOK_Init invoked" + "</div><br/>");
        }

        protected void ButtonOK_Load(object sender, EventArgs e)
        {
            Response.Write("<div>" + "ButtonOK_Load invoked" + "</div><br/>");
        }

        protected void ButtonOK_Click(object sender, EventArgs e)
        {
            Response.Write("<div>" + "ButtonOK_Click invoked" + "</div><br/>");
        }

        protected void ButtonOK_PreRender(object sender, EventArgs e)
        {
            Response.Write("<div>" + "ButtonOK_PreRender invoked" + "</div><br/>");
        }

        protected void ButtonOK_Unload(object sender, EventArgs e)
        {
            // Response is unavailable at control unload
            // Response.Write("ButtonOK_Unload invoked" + "<br/>");
        }
    }
}