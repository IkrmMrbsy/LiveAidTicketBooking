<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LandingPage.aspx.cs" Inherits="Live_Aid_Concert.LandingPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Landing Page</title>
    <link rel="stylesheet" href="../Content/bootstrap.css" />
    <%--<script src="Scripts/bootstrap.js"></script>--%>
    <link rel="stylesheet" href="../CSS/Landing.css" />
    <script src="https://cdn.jsdelivr.net/npm/countdown@5.1.3/dist/countdown.min.js"></script>

</head>
<body>
    <header>
        <nav>
            <ul>
                <li><a href="#about">About</a></li>
                <li><a href="#artists">Artists</a></li>
                <li><a href="#concerts">Tickets</a></li>
                <li><a href="#terms">Terms & Conditions</a></li>
                <li><a href="#contact">Contact</a></li>
            </ul>
        </nav>
    </header>

    <section id="banner">
        <h1>Welcome to Live Aid Concert</h1>
        <h3>London and Phildelphia</h3>
        <h3>July 13 2024</h3>
    </section>

    <section id="about">
        <img src="../Images/liveaid1.png" alt="Deskripsi gambar">
        <h2>About Live Aid</h2>
        <p>
            Live Aid is a monumental charity concert and enduring music-focused fundraising effort with a core mission to raise funds for <b>Famine relief in Ethiopia</b>. Founded by Bob Geldof and Midge Ure.

This unique event is set to unfold simultaneously at two iconic venues: Wembley Stadium in London, UK, and John F. Kennedy Stadium in Philadelphia, USA. Featuring a stellar lineup of the era's most renowned musicians, including Queen, U2, David Bowie, Led Zeppelin, and many more, Live Aid promises to deliver a musical experience like no other.

With an ambitious fundraising goal and a legacy that continues to inspire philanthropic endeavors, Live Aid stands as a testament to the unifying power of music and the enduring spirit of compassion that defines our humanity.
        </p>
    </section>
    <section id="countdown">
        <div id="countdown-timer">
            <div class="countdown-card">
                <div class="countdown-content">
                    <span id="days">00d</span>
                </div>
                <div class="card-label">Days</div>
            </div>

            <div class="countdown-card">
                <div class="countdown-content">
                    <span id="hours">00h</span>
                </div>
                <div class="card-label">Hours</div>
            </div>

            <div class="countdown-card">
                <div class="countdown-content">
                    <span id="minutes">00m</span>
                </div>
                <div class="card-label">Minutes</div>
            </div>

            <div class="countdown-card">
                <div class="countdown-content">
                    <span id="seconds">00s</span>
                </div>
                <div class="card-label">Seconds</div>
            </div>
        </div>

        <div id="countdown-text">
            <h2>Get Ready for Live Aid Concert!</h2>
            <p>
                Get ready for an unforgettable experience at the Live Aid Concert! From mesmerizing performances to heartwarming moments, it's a night you won't want to miss. Join us as we come together for an evening filled with music, unity, and hope.

            As the countdown begins, anticipation builds for a concert like no other. With artists from around the world taking the stage, get ready to be moved, inspired, and uplifted. Mark your calendar and be part of something truly extraordinary at the Live Aid Concert!
            </p>
        </div>
    </section>

    <section id="artists" class="py-5">
        <div class="container">
            <div class="row">
                <div class="col text-center">
                    <h2>Artists</h2>
                    <p>List of artists who will perform at Live Aid Concert</p>
                </div>
            </div>
            <div class="row">
                <div class="col text-center">
                    <img src="../Images/liveaidposters.jpg" alt="Artist Lineup" class="imgartist">
                </div>
            </div>
        </div>
    </section>

    <section id="seats" class="py-5">
        <div class="container">
            <div class="row">
                <div class="col text-center">
                    <h2>Seats</h2>
                    <p>Choose your seat for Live Aid Concert</p>
                </div>
            </div>
            <div class="row mt-5">
                <div class="col-md-6 d-flex justify-content-center align-items-center">
                    <div class="row">
                        <div class="col-md-12 text-center">
                            <img src="../Images/SeatLayout2.png" alt="Seat 1" class="img-fluid" style="max-width: 100%;">
                        </div>
                        <div class="col-md-12">
                            <p class="text-center">Wembley Stadium</p>
                        </div>
                    </div>
                </div>
                <div class="col-md-6 d-flex justify-content-center align-items-center">
                    <div class="row">
                        <div class="col-md-12 text-center">
                            <img src="../Images/SeatLayout.png" alt="Seat 2" class="img-fluid" style="width: 600px; height: 344px;">
                        </div>
                        <div class="col-md-12">
                            <p class="text-center">F khanedy Stadium</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>







    <section id="concerts" runat="server">
        <h2>Concerts</h2>
        <div class='concert'>
            <div class="concert-details">
                <h3>
                    <asp:Label ID="lblName1" runat="server"></asp:Label></h3>
                <p>
                    Date:
                    <asp:Label ID="lblDate1" runat="server"></asp:Label>
                </p>
                <p>
                    Location:
                    <asp:Label ID="lblLocation1" runat="server"></asp:Label>
                </p>
                <asp:HyperLink ID="lnkBuyTickets1" runat="server" Text="Buy Tickets"></asp:HyperLink>
            </div>
            <div class='map-container'>
                <asp:Literal ID="litGoogleMap1" runat="server"></asp:Literal>
            </div>
        </div>

        <div class='concert'>
            <div class="concert-details">
                <h3>
                    <asp:Label ID="lblName2" runat="server"></asp:Label></h3>
                <p>
                    Date:
                    <asp:Label ID="lblDate2" runat="server"></asp:Label>
                </p>
                <p>
                    Location:
                    <asp:Label ID="lblLocation2" runat="server"></asp:Label>
                </p>
                <asp:HyperLink ID="lnkBuyTickets2" runat="server" Text="Buy Tickets"></asp:HyperLink>
            </div>
            <div class='map-container'>
                <asp:Literal ID="litGoogleMap2" runat="server"></asp:Literal>
            </div>
        </div>
    </section>


    <section id="terms">
        <div class="container">
            <div class="row">
                <div class="col text-center">
                    <h2>Terms & Conditions</h2>
                    <p>Please read the following terms and conditions carefully before purchasing tickets or attending Live Aid Concert.</p>
                    <p>1. By purchasing tickets to Live Aid Concert, you agree to abide by all terms and conditions set forth by the event organizers.</p>
                    <p>2. All ticket sales are final. No refunds or exchanges will be issued except as required by law.</p>
                    <p>3. Attendees must comply with all venue rules and regulations, as well as any instructions given by event staff or security personnel.</p>
                    <p>4. The event organizers reserve the right to refuse entry or remove any attendee from the premises for any reason, including but not limited to unruly behavior or violation of event policies.</p>
                    <p>5. Attendees assume all risk and liability associated with attending Live Aid Concert, including but not limited to injury, loss, or damage to personal property.</p>
                    <p>6. The event organizers are not responsible for any loss or damage to personal belongings.</p>
                    <p>7. Photography, video recording, or audio recording of the event may be prohibited or restricted. Attendees must adhere to any such policies.</p>
                    <p>8. By attending Live Aid Concert, attendees consent to being photographed, filmed, or recorded for promotional and marketing purposes.</p>
                    <p>9. The event organizers reserve the right to make changes to the event schedule, lineup, or any other aspect of the event without prior notice.</p>
                    <p>10. These terms and conditions are subject to change at any time without notice. It is the responsibility of attendees to review and comply with the most current terms and conditions.</p>
                </div>
            </div>
        </div>
    </section>


    <footer id="contact">
        <div class="footer-content">
            <div class="footer-section contact">
                <h2>Contact Us</h2>
                <span><strong>Phone:</strong> 987-654-321</span>
                <span><strong>Email:</strong> info@LiveAid.com</span>
            </div>
            <div class="footer-section about">
                <h2>about us</h2>
                <p>Live Aid is a platform to buy tickets for concerts and live events. We are committed to providing the best experience for music fans around the world.</p>
            </div>
        </div>
        <div class="footer-bottom">
            <p>&copy; 2024 Live Aid. All rights reserved</p>
        </div>
    </footer>
</body>
<script src="../JS/Landing.js"></script>

</html>

