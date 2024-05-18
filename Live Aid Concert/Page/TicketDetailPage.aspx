<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TicketDetailPage.aspx.cs" Inherits="Live_Aid_Concert.TicketDetailPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../CSS/TicketDetail.css" />
    <link rel="stylesheet" href="../Content/bootstrap.css" />
    <link rel="stylesheet" href="https://cdn.remixicon.com/releases/v2.0.1/remixicon.css">
</head>
<body>
    <form id="form1" runat="server">
        <div class="card1">
            <img src="../Images/liveaid2.jpg" alt="Image Description">
            <h2>Feed The World!</h2>
        </div>

        

        <div class="card2">
            <asp:PlaceHolder ID="phConcertImage" runat="server"></asp:PlaceHolder>
            <div class="custom-card">
                <div class="custom-card-header">
                    <h4>Selected Tickets</h4>
                </div>
                <div class="custom-card-body">
                    <h5 id="subtotalTitle" runat="server" class="custom-card-title">Subtotal (0 Seat)</h5>
                    <p id="subtotalSeatName" runat="server" class="custom-card-text">Your Seat Name</p>
                    <p id="subtotalPrice" runat="server" class="custom-card-text">Rp 0</p>
                     <p id="errorMessage" runat="server" class="error-message" style="color: red;"></p>
                    <a href="#" id="orderNowBtn" class="custom-btn" onclick="OrderNow();">Order Now</a>
   
                </div>
            </div>

            <h2>Choose Ticket</h2>
            <asp:PlaceHolder ID="phSeats" runat="server"></asp:PlaceHolder>
        </div>
    </form>
    <script src="JavaScript.js"></script>
    <script src="../JS/TicketDetail.js"></script>
</body>
</html>
