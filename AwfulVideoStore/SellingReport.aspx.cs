#region Usings

using System;
using System.Web.UI;
using System.Linq;

#endregion

namespace AwfulVideoStore {
    public partial class SellingReport : Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (Session["LoggedUser"] == "admin") {
                var movies = new SellingReportServce().Load();
                var regular = movies.Where(_ => _.MovieCodeName == "Regular").Count();
                var newReleases = movies.Where(_ => _.MovieCodeName == "New Release").Count();
                var children = movies.Where(_ => _.MovieCodeName == "Children").Count();

                if (regular >= newReleases && regular >= children)
                    bestSellLbl.Text = "Regular";
            
                if (children >= newReleases && children >= regular)
                    bestSellLbl.Text = "Children";
                
                if (newReleases >= children && newReleases >= regular)
                    bestSellLbl.Text = "New Releases";

                list.DataSource = movies;
                list.DataBind();
            }
        }
    }
}