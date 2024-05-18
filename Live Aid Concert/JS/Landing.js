var targetDate = new Date("July 13, 2024 00:00:00").getTime();

var countdown = setInterval(function () {
   
    var now = new Date().getTime();

    
    var distance = targetDate - now;

    var days = Math.floor(distance / (1000 * 60 * 60 * 24));
    var hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
    var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
    var seconds = Math.floor((distance % (1000 * 60)) / 1000);

    document.getElementById("days").innerHTML = days.toString().padStart(2, '0');
    document.getElementById("hours").innerHTML = hours.toString().padStart(2, '0');
    document.getElementById("minutes").innerHTML = minutes.toString().padStart(2, '0');
    document.getElementById("seconds").innerHTML = seconds.toString().padStart(2, '0');

    if (distance < 0) {
        clearInterval(countdown);
        document.getElementById("countdown-timer").innerHTML = "The booking has been closed. Thank you for your interest.";

        var buyTicketsLinks = document.querySelectorAll('.concert .concert-details a');
        buyTicketsLinks.forEach(function (link) {
            link.innerHTML = "Sold Out";
            link.setAttribute("disabled", true);
            link.removeAttribute("href");
            link.style.color = "red"; 
            link.style.backgroundColor = "rgba(0, 0, 0, 0.3)";
            link.classList.add("sold-out");
        });
    }
}, 1000);