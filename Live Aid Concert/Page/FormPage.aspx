<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormPage.aspx.cs" Inherits="Live_Aid_Concert.FormPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../CSS/Form.css" />
    <link rel="stylesheet" href="../Content/bootstrap.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="card1">
            <img src="../Images/liveaid4.jpg" alt="Image Description">
            <h2>Together for Ethiopia!</h2>
        </div>
        <div class="container mt-5">
            <div class="row">
                <div class="col-md-8">
                    <!-- Bagian Form Regist -->
                    <asp:Panel ID="ticketForm" runat="server" Visible="true">
                        <div class="card">
                            <div class="card-body">
                                <h5 class="card-title">Registration</h5>

                                <div class="form-group">
                                    <div class="alert alert-danger" role="alert" runat="server" id="ErrorAlert" visible="false">
                                        <strong>Warning:</strong>
                                        <asp:Label ID="ErrorMessageLabel" runat="server"></asp:Label>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label for="name">Full Name:</label>
                                    <input type="text" class="form-control" id="nameInput" name="name" runat="server">
                                </div>
                                <div class="form-group">
                                    <label for="email">Email:</label>
                                    <input type="email" class="form-control" id="emailInput" name="email" runat="server">
                                </div>
                                <div class="form-group">
                                    <label for="phone">Phone Number:</label>
                                    <input type="tel" class="form-control" id="phoneInput" name="phone" runat="server">
                                </div>
                                <div class="form-group">
                                    <label for="nik">NIK:</label>
                                    <input type="text" class="form-control" id="nikInput" name="nik" runat="server" />
                                </div>
                                <asp:Button ID="SubmitButton" runat="server" Text="Submit" CssClass="btn btn-primary btn-submit" OnClick="SubmitButton_Click" />
                            </div>
                        </div>
                    </asp:Panel>
                     <!-- Bagian Form Regist -->

                    <!--Bagian Form Pembayaran -->
                    <asp:Panel ID="paymentForm" runat="server" Visible="false">
                        <div class="card">
                            <div class="card-body">
                                <h5 class="card-title">Payment</h5>
                                <div class="form-group">
                                    <div class="alert alert-danger" role="alert" runat="server" id="ErrorAlert2" visible="false">
                                        <strong>Warning:</strong>
                                        <asp:Label ID="ErrorMessageLabel2" runat="server"></asp:Label>
                                    </div>
                                </div>
                    
                                <div class="form-group">
                                    <label for="cardNumber">Card Number:</label>
                                    <input type="text" class="form-control" id="cardNumberInput" name="cardNumber" runat="server">
                                </div>
                                <div class="form-group">
                                    <label for="expiryDate">Expiry Date:</label>
                                    <input type="text" class="form-control" id="expiryDateInput" name="expiryDate" placeholder="MM/YY" runat="server">
                                </div>
                                <div class="form-group">
                                    <label for="cvv">CVV:</label>
                                    <input type="text" class="form-control" id="cvvInput" name="cvv" runat="server">
                                </div>
                                <div class="form-group">
                                    <label for="cardHolderName">Card Holder Name:</label>
                                    <input type="text" class="form-control" id="cardHolderNameInput" name="cardHolderName" runat="server">
                                </div>
                                <asp:Button ID="PayButton" runat="server" Text="Pay" OnClick="PayButton_Click" CssClass="btn btn-primary btn-submit" />
                                <div class="text-center">
                                    <div class="back-to-form-title-wrapper">
                                        <a href="#" id="backToFormTitleLink" runat="server" onserverclick="BackToFormTitleLink_ServerClick" class="next-to-payment">
                                            <span>&larr;</span>
                                            <span>Back</span>
                                        </a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                    <!--Bagian Form Pembayaran -->

                    <!-- Bagian Konfirmasi Pembelian -->
                    <asp:Panel ID="confirmationPanel" runat="server" Visible="false">
                        <div class="card confirmation-card">
                            <div class="card-body">
                                <h5 class="card-title">Confirmation Summary</h5>
                                <div class="confirmation-details">
                                    <p>
                                        <strong>Name:</strong>
                                        <asp:Label ID="confirmationName" runat="server"></asp:Label>
                                    </p>
                                    <p>
                                        <strong>Email:</strong>
                                        <asp:Label ID="confirmationEmail" runat="server"></asp:Label>
                                    </p>
                                    <p>
                                        <strong>Phone Number:</strong>
                                        <asp:Label ID="confirmationPhone" runat="server"></asp:Label>
                                    </p>
                                    <p>
                                        <strong>NIK:</strong>
                                        <asp:Label ID="confirmationNik" runat="server"></asp:Label>
                                    </p>
                                    <p>
                                        <strong>Card Number:</strong>
                                        <asp:Label ID="confirmationCardNumber" runat="server"></asp:Label>
                                    </p>
                                    <p>
                                        <strong>Card Holder Name:</strong>
                                        <asp:Label ID="confirmationCardHolderName" runat="server"></asp:Label>
                                    </p>
                                    <p>
                                        <strong>Total Tickets:</strong>
                                        <asp:Label ID="confirmationTotalTickets" runat="server"></asp:Label>
                                    </p>
                                    <p>
                                        <strong>Total Price:</strong>
                                        <asp:Label ID="confirmationTotalPrice" runat="server"></asp:Label>
                                    </p>
                                </div>
                                <div class="confirmation-message">
                                    <p>Please review the above information. Make sure all the information you entered is correct.</p>
                                    <p>If you are sure, press the "Proceed to Payment" button to continue the payment.</p>
                                </div>
                                <!-- Tombol Proceed to Payment -->
                                <asp:Button ID="ProceedToPaymentButton" runat="server" Text="Proceed to Payment" CssClass="btn-proceed" OnClick="ProceedToPaymentButton_Click" />
                                <div class="text-center">
                                    <div class="back-to-form-title-wrapper">
                                        <a href="#" id="backToFormPaymentLink" runat="server" onserverclick="backToFormPaymentLink_ServerClick" class="next-to-payment">
                                            <span>&larr;</span>
                                            <span>Back</span>
                                        </a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                    <!-- Bagian Konfirmasi Pembelian -->
                </div>

                <div class="col-md-4">
                    <!-- Bagian Card Informasi Konser -->
                    <div class="card">
                        <div class="card-body">
                            <h5 class="card-title">
                                <asp:Label ID="concertTitle" runat="server"></asp:Label>
                            </h5>
                            <p class="card-text">
                                <asp:Label ID="concertInformation" runat="server"></asp:Label>
                            </p>
                            <p class="card-text">
                                <asp:Label ID="concertDate" runat="server"></asp:Label>
                            </p>
                        </div>
                    </div>
                    <!-- Bagian Card Informasi Konser -->

                    <!-- Bagian Pilihan Pengguna -->
                    <div class="card mt-3">
                        <div class="card-body">
                            <h5 class="card-title">Your choice</h5>
                            <p class="card-text">
                                Seat Name:
                                <asp:Label ID="selectedSeatsLabel" runat="server"></asp:Label>
                            </p>
                            <p class="card-text">
                                Total Seat:
                                <asp:Label ID="totalTicketsLabel" runat="server"></asp:Label>
                                Seat 
                            </p>
                            <p class="card-text">
                                Total Price:
                                <asp:Label ID="totalPriceLabel" runat="server"></asp:Label>
                            </p>
                        </div>
                    </div>
                    <!-- Bagian Pilihan Pengguna -->
                </div>
            </div>
        </div>
    </form>
</body>
</html>
