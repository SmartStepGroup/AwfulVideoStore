#region Usings

using System;
using System.Web.UI;

#endregion

namespace AwfulVideoStore {
    public partial class Login : Page {
        protected void Page_Load(object sender, EventArgs e) {}

        protected void lgnButtnClck(object sender, EventArgs e) {
            if (unTB.Text == "admin" && passTB.Text == "admin") {
                Session["LoggedUser"] = "admin";
            }
            if (unTB.Text == "user" && passTB.Text == "user")
            {
                Session["LoggedUser"] = "user";
            }

            Response.Redirect("Default.aspx");
        }
    }
}