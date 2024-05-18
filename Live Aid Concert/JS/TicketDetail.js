var currentURL = window.location.href;

function getParameterByName(name, url) {
    if (!url) url = window.location.href;
    name = name.replace(/[\[\]]/g, "\\$&");
    var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
        results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, " "));
}

var concertID = getParameterByName('concertID', currentURL);

var totalTickets = 0;
var totalPrice = 0;
var selectedSeats = [];

function updateTicketInfo(seatName, price) {

    if (totalTickets >= 3) {
        document.getElementById("errorMessage").innerText = "You can only select a maximum of 3 seats.";
        setTimeout(function () {
            document.getElementById("errorMessage").innerText = "";
        }, 5000);
        return;
    }

    
    totalTickets++;
    totalPrice += price;

    
    updateOrderInfo(seatName, price);

    
    selectedSeats.push(seatName);

    document.getElementById('subtotalSeatName').innerText = selectedSeats.join(', ');
}

function deleteSeat(seatName, price) {
    
    var index = selectedSeats.indexOf(seatName);
    if (index !== -1) {
        
        selectedSeats.splice(index, 1);

        totalTickets--;
        totalPrice -= price;

       
        updateOrderInfo();

        return false; 
    }
}

function OrderNow() {
 
    if (totalTickets === 0) {
        
        errorMessage.innerText = "Please select at least one seat before placing the order.";
    } else if (totalTickets > 3) {
        setTimeout(function () {
            errorMessage.innerText = "";
        }, 5000); 
        errorMessage.innerText = "You can only select a maximum of 3 seats.";
        setTimeout(function () {
            errorMessage.innerText = "";
        }, 5000); 
    } else {
        
        var form = document.createElement('form');
        form.method = 'POST';
        form.action = 'FormPage.aspx?concertID=' + concertID; 

        var inputTotalTickets = document.createElement('input');
        inputTotalTickets.type = 'hidden';
        inputTotalTickets.name = 'totalTickets';
        inputTotalTickets.value = totalTickets;
        form.appendChild(inputTotalTickets);

        var inputTotalPrice = document.createElement('input');
        inputTotalPrice.type = 'hidden';
        inputTotalPrice.name = 'totalPrice';
        inputTotalPrice.value = totalPrice;
        form.appendChild(inputTotalPrice);

        var inputSelectedSeats = document.createElement('input');
        inputSelectedSeats.type = 'hidden';
        inputSelectedSeats.name = 'selectedSeats';
        inputSelectedSeats.value = selectedSeats.join(',');
        form.appendChild(inputSelectedSeats);

        
        document.body.appendChild(form);
        form.submit();
    }
}


function updateOrderInfo() {
    
    document.getElementById('subtotalTitle').innerText = "Subtotal (" + totalTickets + " Seat)";
    document.getElementById('subtotalPrice').innerText = "Rp " + totalPrice;

    document.getElementById('subtotalSeatName').innerText = selectedSeats.join(', ');
}
