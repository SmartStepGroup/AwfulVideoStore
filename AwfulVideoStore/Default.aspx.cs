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
            var fileName = string.Format(@"{0}\{1}", Path.GetFullPath(Server.MapPath("~/App_Data")), "Database.xml");
            var films = new List<Film>();

            if (Session["LoggedUser"] != null) {
                lgnLnk.Visible = false;
                msg.InnerText = "Hello, " + Session["LoggedUser"];
                msg.Visible = true;
                list.Visible = true;
                excelBtn.Visible = true;
            }

            if (Session["LoggedUser"] == "admin") {
                var doc = LoadXml(fileName);
                foreach (XmlNode node in doc.DocumentElement.ChildNodes) {
                    films.Add(new Film {
                        Name = node.ChildNodes[0].InnerText,
                        Price = node.ChildNodes[1].InnerText,
                        Rating = int.Parse(node.ChildNodes[2].InnerText)
                    });
                }
            }
            else if (Session["LoggedUser"] == "user") {
                var doc = LoadXml(fileName);
                foreach (XmlNode node in doc.DocumentElement.ChildNodes) {
                    if (int.Parse(node.ChildNodes[2].InnerText) > 14) continue;

                    films.Add(new Film {
                        Name = node.ChildNodes[0].InnerText,
                        Price = node.ChildNodes[1].InnerText,
                        Rating = int.Parse(node.ChildNodes[2].InnerText)
                    });
                }
            }
            else {
                lgnLnk.Visible = true;
                msg.Visible = false;
                list.Visible = false;
                excelBtn.Visible = false;
            }

            list.DataSource = films;
            list.DataBind();
            Session["Films"] = films;
        }

        private static XmlDocument LoadXml(string fileName) {
            var doc = new XmlDocument();
            doc.Load(fileName);
            return doc;
        }

        protected void excelBtnClck(object sender, EventArgs e) {
            var films = (List<Film>) Session["Films"];
            var pck = ExcelExporter.Export(films);

            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;  filename=Films.xlsx");
            Response.BinaryWrite(pck.GetAsByteArray());
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