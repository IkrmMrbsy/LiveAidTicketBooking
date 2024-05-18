using System;
using System.IO;
using System.Web.UI;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;

namespace Live_Aid_Concert
{
    public partial class TicketPrint : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string nama = Request.QueryString["nama"];
                string kursi = Request.QueryString["kursi"];
                string harga = Request.QueryString["harga"];
                string lokasi = Request.QueryString["lokasi"];
                string tanggal = Request.QueryString["tanggal"];

                lbNama.Text = nama;
                lbKursi.Text = kursi;
                lbHarga.Text = harga;
                lbLokasi.Text = lokasi;
                lbTanggal.Text = tanggal;
                lbLocationName.Text = lokasi;
            }
        }

        protected void btnDownloadTicket_Click(object sender, EventArgs e)
        {
            byte[] ticketFile = GenerateTicket();

            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment;filename=Ticket.pdf");
            Response.BinaryWrite(ticketFile);
            Response.End();
        }

        private byte[] GenerateTicket()
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                Document document = new Document(PageSize.A4, 50f, 50f, 50f, 50f);
                PdfWriter.GetInstance(document, memoryStream);
                document.Open();

                Paragraph header = new Paragraph("Live Aid Concert Ticket");
                header.Alignment = Element.ALIGN_CENTER;
                document.Add(header);

                Paragraph ticketInfo = new Paragraph();
                ticketInfo.Add("Name: " + lbNama.Text + "\n");
                ticketInfo.Add("Seat: " + lbKursi.Text + "\n");
                ticketInfo.Add("Total Price: " + lbHarga.Text + "\n");
                ticketInfo.Add("Location: " + lbLokasi.Text + "\n");
                ticketInfo.Add("Date: " + lbTanggal.Text + "\n\n");
                document.Add(ticketInfo);

                iTextSharp.text.Image qrCodeImage = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Images/7 Great Uses For QR Codes & How To Generate Your Own For Free.jpg"));
                qrCodeImage.Alignment = Element.ALIGN_CENTER;
                qrCodeImage.ScaleAbsolute(150f, 150f);
                document.Add(qrCodeImage);

                document.Close();
                return memoryStream.ToArray();
            }
        }
    }
}
