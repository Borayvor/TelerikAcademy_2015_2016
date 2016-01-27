namespace E01_Cars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.UI.WebControls;

    public partial class Searching : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            ViewState["producers"] = GetProducers().ToArray();
            ViewState["extras"] = GetExtras().ToArray();

            if (!IsPostBack)
            {
                var currentProducers = ((string[])ViewState["producers"]).Select(x => new ListItem(x)).ToArray();
                this.DropDownListProducer.Items.AddRange(currentProducers);
                this.DropDownListProducer.DataBind();

                var currentExtras = ((string[])ViewState["extras"]).Select(x => new ListItem(x)).ToArray();
                this.CheckBoxListExtra.Items.AddRange(currentExtras);
            }

            var models = ViewState["models"];
            if (models != null && this.DropDownListModel.SelectedIndex == 0)
            {
                this.DropDownListModel.DataSource = ((string[])models).Select(x => new ListItem(x)).ToArray();
                this.DropDownListModel.DataBind();
            }
        }



        protected void DropDownListProducer_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList listView = sender as DropDownList;

            if (listView == null)
            {
                return;
            }

            ViewState["models"] = GetModelsByProducer(listView.SelectedValue).ToArray();
        }



        protected void DropDownListModel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void SearchButton_Command(object sender, CommandEventArgs e)
        {
            string name = this.DropDownListProducer.SelectedValue;
            string model = this.DropDownListModel.SelectedValue;

            string extras = string.Empty;
            foreach (ListItem extra in this.CheckBoxListExtra.Items)
            {
                if (extra.Selected)
                {
                    if (extras == string.Empty)
                    {
                        extras = extra.Value;
                    }
                    else
                    {
                        extras += " " + extra.Value;
                    }
                }
            }

            string engine = this.RadioButtonListEngines.SelectedValue;

            this.LiteralResult.Text = "<br />" +
                "Producer: " + name + "<br />" +
                "Model: " + model + "<br />" +
                "Extras: " + extras + "<br />" +
                "Engine: " + engine + "<br />";
            this.LiteralResult.DataBind();
        }

        private List<Producer> producers = new List<Producer>
        {
            new Producer() {
                Name = "BMV", Models = new List<string>() { "320", "520", "x5", "x6" }
            },
            new Producer() {
                Name = "Audi", Models = new List<string>() { "A4", "A5", "320", "520" }
            },
        };

        private List<Extra> extras = new List<Extra>
        {
            new Extra() { Name = "audio" },
            new Extra() { Name = "video" }
        };


        private IEnumerable<string> GetModelsByProducer(string selectedProducer)
        {
            return this.producers
               .Where(x => x.Name == selectedProducer)
               .SelectMany(x => x.Models)
               .Distinct();
        }

        private IEnumerable<string> GetProducers()
        {
            return this.producers.Select(x => x.Name).Distinct();
        }

        private IEnumerable<string> GetExtras()
        {
            return this.extras.Select(x => x.Name).Distinct();
        }

        protected void CheckBoxListExtra_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void RadioButtonListEngines_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}