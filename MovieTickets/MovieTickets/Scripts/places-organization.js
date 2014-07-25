'use strict';

var places = function setPlaces() {
    $('.hall').append('<hr/>');
    for (var i = 0; i < 50; i++) {
        if (i % 10 === 0) {
            $('.hall').append('<br/>');
        }
        if (i % 20 === 0) {
            $('.hall').append('<br/>');
        }
        $('.hall').append('<a id = "' + i + '" class = "place"><img src = "./../../Content/Images/Seats/vacantseat.jpg" class = "vacantSeat"/></a>');
    }
};
$(document.body).on('click', '.place', function () {
    var element = $(this);
    if (element.hasClass('selectedSeat')) {
        element.removeClass('selectedSeat');
        element.html('<img src = "./../../Content/Images/Seats/vacantseat.jpg" class = "vacantSeat"/>');
    }
    else if (element.hasClass('reservedSeat')) {
        
    }
    else {
        element.addClass('selectedSeat');
        element.find('.vacantSeat').remove();
        element.html('<img src = "./../../Content/Images/Seats/selectedseat.jpg" class = "selectedSeat"/>');
    }
});