#region Usings

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Xml;

#endregion

namespace AwfulVideoStore {
    public partial class Default : Page {
        protected void Page_Load(object sender, EventArgs e) {
            var fileName = string.Format(@"{0}\{1}", Path.GetFullPath(Server.MapPath("~/App_Data")), "Database.xml");
            var movies = new List<Movie>();

            if (Session["LoggedUser"] != null) {
                lgnLnk.Visible = false;
                msg.InnerText = "Hello, " + Session["LoggedUser"];
                msg.Visible = true;
                list.Visible = true;
                excelBtn.Visible = true;
                excelExpPopular.Visible = true;
                sellLnk.Visible = true;
            }

            if (Session["LoggedUser"] == "admin") {
                var doc = LoadXml(fileName);
                foreach (XmlNode node in doc.DocumentElement.ChildNodes) {
                    movies.Add(new Movie(int.Parse(node.ChildNodes[3].InnerText)) {
                        Title = node.ChildNodes[0].InnerText,
                        Price = node.ChildNodes[1].InnerText,
                        Rating = int.Parse(node.ChildNodes[2].InnerText)
                    });
                }
            }
            else if (Session["LoggedUser"] == "user") {
                excelBtn.Visible = false;
                excelExpPopular.Visible = false;
                sellLnk.Visible = false;
                var doc = LoadXml(fileName);
                foreach (XmlNode node in doc.DocumentElement.ChildNodes) {
                    if (int.Parse(node.ChildNodes[2].InnerText) > 14) continue;

                    movies.Add(new Movie(int.Parse(node.ChildNodes[3].InnerText)) {
                        Title = node.ChildNodes[0].InnerText,
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
                excelExpPopular.Visible = false;
                sellLnk.Visible = false;
            }

            list.DataSource = movies;
            list.DataBind();
            Session["Films"] = movies;
        }

        private static XmlDocument LoadXml(string fileName) {
            var doc = new XmlDocument();
            doc.Load(fileName);
            return doc;
        }

        protected void excelBtnClck(object sender, EventArgs e) {
            var films = (List<Movie>) Session["Films"];
            var pck = ExcelExporter.Export(films);

            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;  filename=Films.xlsx");
            Response.BinaryWrite(pck.GetAsByteArray());
        }

        protected void excelPopularBtnClck(object sender, EventArgs e) {
            var films = (List<Movie>) Session["Films"];
            films = films.Where(_ => _.MovieCodeName != "Regular").ToList();
            var pck = ExcelExporter.Export(films);

            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;  filename=Popular Films.xlsx");
            Response.BinaryWrite(pck.GetAsByteArray());
        }
    }
}