using System;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Live_Aid_Concert.Database;

namespace Live_Aid_Concert
{
    public partial class TicketDetailPage : System.Web.UI.Page
    {
        int totalPrice;
        int totalTickets;
        int concertID;
        private string selectedSeatNames;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["concertID"] != null)
                {
                    concertID = Convert.ToInt32(Request.QueryString["concertID"]);
                    DisplaySeats(concertID);
                }
            }
        }

        private void DisplaySeats(int concertID)
        {
            Seats seats = new Seats();
            Dictionary<string, (int Price, string Status)> seatNamesAndPrices = seats.GetSeatNamesAndPrices(concertID);
            int count = 0;

            var concertImage = new Image();
            concertImage.ImageUrl = GetConcertImage(concertID);
            concertImage.CssClass = "img-fluid";
            concertImage.AlternateText = "Concert Image";
            concertImage.Style["max-width"] = "50%";
            phConcertImage.Controls.Add(concertImage);

            foreach (var pair in seatNamesAndPrices)
            {
                if (count < 15)
                {
                    var card = new Panel { CssClass = "card w-50 mt-5" };
                    var cardBody = new Panel { CssClass = "card-body" };

                    var title = new Literal { Text = "<h5 class='card-title'>" + pair.Key + "</h5>" };
                    var text = new Literal { Text = "<p class='card-text'><b>Rp " + pair.Value.Price + "</b></p>" };
                    var text2 = new Literal { Text = "<p class='card-text'>Purchases will close on July 13th</p>" };

                    string statusStyle = pair.Value.Status == "Available" ? "color: green;" : "color: red;";
                    var statusText = new Literal { Text = $"<p class='card-text' style='{statusStyle}'> {(pair.Value.Status == "Available" ? "Available" : "Sold Out")}</p>" };

                    var selectButton = new HtmlButton();
                    selectButton.Attributes["class"] = "btn btn-primary ml-2";
                    selectButton.InnerHtml = "Select";
                    selectButton.Attributes["style"] = "background-color: #003049; border-color: #003049;";
                    selectButton.Attributes["onclick"] = $"updateTicketInfo('{pair.Key}', {pair.Value.Price}); return false;";
                    selectButton.Disabled = pair.Value.Status != "Available";

                    var deleteLink = new HtmlAnchor();
                    deleteLink.ID = "deleteLink_" + pair.Key;
                    deleteLink.Attributes["class"] = "btn btn-danger";
                    deleteLink.InnerText = "Delete";
                    deleteLink.HRef = "javascript:void(0)";
                    deleteLink.Attributes["onclick"] = $"deleteSeat('{pair.Key}', {pair.Value.Price}); return false;";
                    deleteLink.Visible = pair.Value.Status == "Available";

                    cardBody.Controls.Add(title);
                    cardBody.Controls.Add(text);
                    cardBody.Controls.Add(text2);
                    cardBody.Controls.Add(statusText);
                    cardBody.Controls.Add(selectButton);
                    cardBody.Controls.Add(deleteLink);
                    card.Controls.Add(cardBody);
                    phSeats.Controls.Add(card);
                    count++;
                }
                else
                {
                    break;
                }
            }
        }



        private string GetConcertImage(int concertID)
        {
            string imageUrl = "";

            if (concertID == 2)
            {
                imageUrl = "../Images/SeatLayout.png";
            }
            else if (concertID == 1)
            {
                imageUrl = "../Images/SeatLayout2.png";
            }

            return imageUrl;
        }

        protected void OrderNowButton_Click(object sender, EventArgs e)
        {

        }
    }
}
