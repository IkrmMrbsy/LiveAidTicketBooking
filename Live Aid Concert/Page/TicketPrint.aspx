<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TicketPrint.aspx.cs" Inherits="Live_Aid_Concert.TicketPrint" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../CSS/TicketPrint.css" />
    <link rel="stylesheet" href="../Content/bootstrap.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="ticket">
            <div class="ticket-header">
                <h1>Live Aid Concert</h1>
            </div>
            <div class="ticket-body">
                <div class="ticket-info">
                    <%-- <p><strong>Nama:</strong> John Doe</p>
                <p><strong>Kursi:</strong> CAT 1A</p>
                <p><strong>Harga:</strong> Rp 1.000.000</p>
                <p><strong>Lokasi:</strong> Wembley Stadium</p>
                <p><strong>Tanggal:</strong> 25 Mei 2024</p>
                <p><strong>Waktu:</strong> 19.00 WIB</p>--%>

                    <p class="card-text">
                        Name:
     <asp:Label ID="lbNama" runat="server"></asp:Label>
                    </p>

                    <p class="card-text">
                        Seat:
     <asp:Label ID="lbKursi" runat="server"></asp:Label>
                    </p>

                    <p class="card-text">
                        Total Price:
                    <asp:Label ID="lbHarga" runat="server"></asp:Label>
                    </p>

                    <p class="card-text">
                        Location:
     <asp:Label ID="lbLokasi" runat="server"></asp:Label>
                    </p>

                    <p class="card-text">
                        Date:
     <asp:Label ID="lbTanggal" runat="server"></asp:Label>
                    </p>

                </div>
                <div class="ticket-qrcode">
                    <img src="../Images/7 Great Uses For QR Codes & How To Generate Your Own For Free.jpg" alt="QR Code">
                </div>
                <div style="text-align: center; margin-top: 10px;">
                    <p>Don't forget to <b>Screenshot</b> or <b>Download</b> the ticket as proof of your registration.</p>
                </div>
            </div>
            <div class="ticket-footer">
                <p>
                    See you in <b>
                        <asp:Label ID="lbLocationName" runat="server" Text="Wembley" /></b>
                </p>
            </div>
        </div>

        <div style="text-align: center; margin-top: 20px;">
            <asp:Button ID="btnDownloadTicket" runat="server" Text="Download Ticket" CssClass="download-button" OnClick="btnDownloadTicket_Click" />
            <asp:HyperLink ID="lnkBackToLandingPage" runat="server" Text="Let's Go Back!" CssClass="back-link" NavigateUrl="~/Page/LandingPage.aspx"></asp:HyperLink>
        </div>
    </form>
    >
</body>

</html>
