#region Usings

using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI;
using System.Xml;

#endregion

namespace AwfulVideoStore {
    public partial class Default : Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (Session["LoggedUser"] != null) {
                lgnLink.Visible = false;
                msg.InnerText = "Hello, " + Session["LoggedUser"];
                msg.Visible = true;
                list.Visible = true;

                var fileName = string.Format(@"{0}\{1}", Path.GetFullPath(Server.MapPath("~/App_Data")), "Database.xml");

                var doc = new XmlDocument();
                doc.Load(fileName);
                var films = new List<Film>();
                foreach (XmlNode node in doc.DocumentElement.ChildNodes) {
                    films.Add(new Film {
                        Name = node.ChildNodes[0].InnerText,
                        Price = node.ChildNodes[1].InnerText,
                        Rating = int.Parse(node.ChildNodes[2].InnerText)
                    });
                }
                list.DataSource = films;
                list.DataBind();
            }
            else {
                lgnLink.Visible = true;
                msg.Visible = false;
                list.Visible = false;
            }
        }
    }

    public class Film {
        public string Name { get; set; }
        public string Price { get; set; }
        public int Rating { get; set; }

        public override string ToString() {
            return Name + " for " + Price;
        }
    }
}