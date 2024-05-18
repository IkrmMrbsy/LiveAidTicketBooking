using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Live_Aid_Concert.Database;

namespace Live_Aid_Concert
{
    public partial class FormPage : System.Web.UI.Page
    {
        protected HtmlInputText nameInput;
        protected HtmlInputGenericControl emailInput;
        protected HtmlInputControl phoneInput;
        protected HtmlInputControl nikInput;
        protected HtmlInputText cardHolderNameInput;
        protected HtmlInputText cardNumberInput;
        protected HtmlInputText cvvInput;
        protected HtmlInputText expiryDateInput;
        protected Label ErrorMessageLabel;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["concertID"] != null && Request.Form["totalTickets"] != null && Request.Form["totalPrice"] != null && Request.Form["selectedSeats"] != null)
                {
                    int concertID = Convert.ToInt32(Request.QueryString["concertID"]);
                    int totalTickets = Convert.ToInt32(Request.Form["totalTickets"]);
                    int totalPrice = Convert.ToInt32(Request.Form["totalPrice"]);
                    string selectedSeats = Request.Form["selectedSeats"];

                    DisplayConcertDetails(concertID);
                    totalTicketsLabel.Text = totalTickets.ToString();
                    totalPriceLabel.Text = "Rp " + totalPrice.ToString();
                    selectedSeatsLabel.Text = selectedSeats;
                }
                else
                {
                    concertTitle.Text = "Invalid data received";
                    concertInformation.Text = "";
                    concertDate.Text = "";
                    totalTicketsLabel.Text = "";
                    totalPriceLabel.Text = "";
                    selectedSeatsLabel.Text = "";
                }
            }
            else
            {
                // Keep the confirmation panel visible
            }
        }

        private void DisplayConcertDetails(int concertID)
        {
            Dictionary<string, string> concertDetails = Concerts.GetConcertDetails(concertID);

            if (concertDetails.Count > 0)
            {
                concertTitle.Text = concertDetails["Name"];
                concertInformation.Text = concertDetails["Location"];

                DateTime concertDateValue;
                if (DateTime.TryParse(concertDetails["Date"], out concertDateValue))
                {
                    concertDate.Text = concertDateValue.ToString("dd MMMM yyyy HH:mm");
                }
                else
                {
                    concertDate.Text = "Invalid date format";
                }
            }
            else
            {
                concertTitle.Text = "Concert not found";
                concertInformation.Text = "Description not available";
                concertDate.Text = "Date not available";
            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            string name = nameInput.Value.Trim();
            string email = emailInput.Value.Trim();
            string phone = phoneInput.Value.Trim();
            string nik = nikInput.Value.Trim();

            string errorMessage = ValidateInputs(name, email, phone, nik);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                ErrorMessageLabel.Text = errorMessage;
                ErrorAlert.Visible = true;
                return;
            }

            ticketForm.Visible = false;
            paymentForm.Visible = true;

            ErrorMessageLabel.Text = "";
            ErrorAlert.Visible = false;
        }

        protected void PayButton_Click(object sender, EventArgs e)
        {
            string cardNumber = cardNumberInput.Value.Trim();
            string expiryDate = expiryDateInput.Value.Trim();
            string cvv = cvvInput.Value.Trim();
            string cardHolderName = cardHolderNameInput.Value.Trim();

            // Validasi nomor kartu kredit
            if (!IsAllDigits(cardNumber))
            {
                ErrorMessageLabel2.Text = "Please enter a valid card number.";
                ErrorAlert2.Visible = true;
                return;
            }

            // Validasi tanggal kadaluarsa
            if (!IsExpiryDateValid(expiryDate))
            {
                ErrorMessageLabel2.Text = "Please enter a valid expiry date (MM/YY format).";
                ErrorAlert2.Visible = true;
                return;
            }

            // Validasi CVV
            if (!IsAllDigits(cvv))
            {
                ErrorMessageLabel2.Text = "Please enter a valid CVV.";
                ErrorAlert2.Visible = true;
                return;
            }

            // Validasi lainnya dan proses pembayaran
            string errorMessage = ValidatePaymentInputs(cardNumber, expiryDate, cvv, cardHolderName);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                ErrorMessageLabel2.Text = errorMessage;
                ErrorAlert2.Visible = true;
                return;
            }

            // Lanjutkan ke tahap konfirmasi dan proses pembelian
            paymentForm.Visible = false;
            confirmationPanel.Visible = true;

            ConfirmPurchase();
        }


        protected void ConfirmPurchase()
        {
            confirmationPanel.Visible = true;

            confirmationName.Text = nameInput.Value.Trim();
            confirmationEmail.Text = emailInput.Value.Trim();
            confirmationPhone.Text = phoneInput.Value.Trim();
            confirmationNik.Text = nikInput.Value.Trim();
            confirmationCardNumber.Text = cardNumberInput.Value.Trim();
            confirmationCardHolderName.Text = cardHolderNameInput.Value.Trim();
            confirmationTotalTickets.Text = totalTicketsLabel.Text;
            confirmationTotalPrice.Text = totalPriceLabel.Text;
        }

        protected void BackToFormTitleLink_ServerClick(object sender, EventArgs e)
        {
            ticketForm.Visible = true;
            paymentForm.Visible = false;

            ErrorMessageLabel.Text = "";
            ErrorAlert.Visible = false;
        }

        protected void backToFormPaymentLink_ServerClick(object sender, EventArgs e)
        {
            paymentForm.Visible = true;
            confirmationPanel.Visible = false;
        }

        protected void ProceedToPaymentButton_Click(object sender, EventArgs e)
        {
            string name = nameInput.Value.Trim();
            string email = emailInput.Value.Trim();
            string phone = phoneInput.Value.Trim();
            string nik = nikInput.Value.Trim();

            string errorMessage = ValidateInputs(name, email, phone, nik);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                ErrorMessageLabel.Text = errorMessage;
                ErrorAlert.Visible = true;
                return;
            }

            int concertID = Convert.ToInt32(Request.QueryString["concertID"]);
            string[] selectedSeatsArray = selectedSeatsLabel.Text.Split(',');
            List<string> selectedSeats = selectedSeatsArray.ToList();

            Seats seatsManager = new Seats();
            seatsManager.DecreaseSeatLimit(concertID, selectedSeats);

            int userID = Users.InsertUser(email, name, phone, nik);

            if (userID > 0)
            {
                paymentForm.Visible = false;
                confirmationPanel.Visible = true;

                ConfirmPurchase();

                string selectedSeatsString = string.Join(",", selectedSeats);
                string totalPrice = totalPriceLabel.Text;

                string concertTitle = this.concertTitle.Text;
                string concertInformation = this.concertInformation.Text;
                string concertDate = this.concertDate.Text;

                decimal price = Convert.ToDecimal(totalPrice.Substring(3));
                DateTime purchaseDate = DateTime.Now;

                int ticketID = Tickets.InsertTicket(userID, concertID, selectedSeatsString, price, purchaseDate);

                if (ticketID > 0)
                {
                    Transactions.InsertTransaction(userID, ticketID, purchaseDate, price);

                    Response.Redirect($"TicketPrint.aspx?nama={name}&kursi={selectedSeatsString}&harga={totalPrice}&lokasi={concertInformation}&tanggal={concertDate}");
                }
                else
                {
                    ErrorMessageLabel.Text = "Failed to create ticket.";
                    ErrorAlert.Visible = true;
                }
            }
            else
            {
                ErrorMessageLabel.Text = "Failed to create user.";
                ErrorAlert.Visible = true;
            }

            ErrorMessageLabel.Text = "";
            ErrorAlert.Visible = false;
        }


        private string ValidateInputs(string name, string email, string phone, string nik)
        {
            if (string.IsNullOrEmpty(name))
            {
                return "Please enter your full name.";
            }

            if (string.IsNullOrEmpty(email))
            {
                return "Please enter your email address.";
            }
            else if (!IsValidEmail(email))
            {
                return "Please enter a valid email address.";
            }

            if (string.IsNullOrEmpty(phone))
            {
                return "Please enter your phone number.";
            }
            else if (!IsValidPhoneNumber(phone))
            {
                return "Please enter a valid phone number.";
            }
            if (string.IsNullOrEmpty(nik))
            {
                return "Please enter your Nik";
            }
            else if (!IsValidNik(nik))
            {
                return "Please enter your valid Nik";
            }

            return null;
        }

        private string ValidatePaymentInputs(string cardNumber, string expiryDate, string cvv, string cardHolderName)
        {
            if (string.IsNullOrEmpty(cardNumber))
            {
                return "Please enter your card number.";
            }

            if (string.IsNullOrEmpty(expiryDate))
            {
                return "Please enter the expiry date of your card.";
            }

            if (string.IsNullOrEmpty(cvv))
            {
                return "Please enter the CVV of your card.";
            }

            if (string.IsNullOrEmpty(cardHolderName))
            {
                return "Please enter the cardholder's name.";
            }

            return null;
        }

        private bool IsAllDigits(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsExpiryDateValid(string expiryDate)
        {
            // Check if the expiry date format is valid (MM/YY)
            if (expiryDate.Length != 5 || expiryDate[2] != '/')
            {
                return false;
            }

            // Additional validation for MM/YY format can be added here if needed

            return true;
        }


        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidPhoneNumber(string phone)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(phone, @"^\d{10,12}$");
        }

        private bool IsValidNik(string nik)
        {
            if (nik.Length != 16)
            {
                return false;
            }

            if (!nik.All(char.IsDigit))
            {
                return false;
            }

            return true;
        }

    }
}
