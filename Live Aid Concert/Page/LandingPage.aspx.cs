using Live_Aid_Concert.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Live_Aid_Concert
{
    public partial class LandingPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DisplayConcertDetails(1, lblName1, lblDate1, lblLocation1, lnkBuyTickets1, litGoogleMap1);
                DisplayConcertDetails(2, lblName2, lblDate2, lblLocation2, lnkBuyTickets2, litGoogleMap2);
            }
        }

        private void DisplayConcertDetails(int concertID, Label lblName, Label lblDate, Label lblLocation, HyperLink lnkBuyTickets, Literal litGoogleMap)
        {
            Dictionary<string, string> concertDetails = Database.Concerts.GetConcertDetails(concertID);

            if (concertDetails.Count > 0)
            {
                lblName.Text = concertDetails["Name"];
                lblDate.Text = Convert.ToDateTime(concertDetails["Date"]).ToString("dd MMMM yyyy HH:mm");
                lblLocation.Text = concertDetails["Location"];
                lnkBuyTickets.NavigateUrl = $"TicketDetailPage.aspx?concertID={concertID}";
                litGoogleMap.Text = GetGoogleMapIframe(concertID);
            }
        }

        public string GetGoogleMapIframe(int concertID)
        {
            string iframeSrc = "";

            if (concertID == 2)
            {
                iframeSrc = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3022.56180666332!2d-74.03645082517991!3d40.74966663531072!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x89c25763a393ed69%3A0xe281d1186726696a!2sJohn%20F%20Kennedy%20Stadium!5e0!3m2!1sid!2sid!4v1714679658799!5m2!1sid!2sid";
            }
            else if (concertID == 1)
            {
                iframeSrc = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2480.6657407023454!2d-0.2821926244277055!3d51.55602800715098!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x48761181d57a876d%3A0xa64f9f185de8e097!2sStadion%20Wembley!5e0!3m2!1sid!2sid!4v1714643203232!5m2!1sid!2sid";
            }

            string iframeTag = $"<iframe src='{iframeSrc}' width='100%' height='200' style='border:0;' allowfullscreen='' loading='lazy' referrerpolicy='no-referrer-when-downgrade'></iframe>";

            return iframeTag;
        }

        public string GetConcertImage(int concertID)
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

    }
}
