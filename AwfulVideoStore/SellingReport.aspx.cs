#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

#endregion

namespace AwfulVideoStore {
    public partial class SellingReport : Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (Session["LoggedUser"] == "admin") {
                var movies = (List<Movie>)Session["Films"];
                var regular = movies.Count(_ => _.MovieCodeName == "Regular");
                var newReleases = movies.Count(_ => _.MovieCodeName == "New Release");
                var children = movies.Count(_ => _.MovieCodeName == "Children");

                if (regular >= newReleases && regular >= children)
                    bestSellLbl.Text = "Best selling is: Regular";
            
                if (children >= newReleases && children >= regular)
                    bestSellLbl.Text = "Best selling is: Children";
                
                if (newReleases >= children && newReleases >= regular)
                    bestSellLbl.Text = "Best selling is: New Releases";

                list.DataSource = movies;
                list.DataBind();
            }
        }
    }
}