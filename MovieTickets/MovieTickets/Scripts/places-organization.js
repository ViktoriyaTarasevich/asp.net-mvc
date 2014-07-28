'use strict';

var setPlaces = function (arg) {
    var reservedSeats = arg;
    $('.hall').append('<p>--------------------------Экран-------------------------</p>');
    $('.hall').append('<br/>');
    var k = 59;
    for (var i = 0; i < 5; i++) {
        if (i === 0 || i === 1) {
            $('.hall').append('<span>' + (i + 1) + 'V</span>');
        } else if (i === 4) {
            $('.hall').append('<span>' + (i + 1) + 'B</span>');
        }
        else {
            $('.hall').append('<span>' + (i + 1) + 'C</span>');
        }
        for (var j = 0; j < 10; j++) {
            if (k.toString in reservedSeats) {
                $('.hall').append('<a id = "' +
                   (k++) +
                   '" class = "place" title = "' +
                   (j + 1) +
                   '"><img src = "./../../Content/Images/Seats/reservedseat.jpg" class = "reservedSeat"/></a>');
            } else {
                $('.hall').append('<a id = "' +
                    (k++) +
                    '" class = "place" title = "' +
                    (j + 1) +
                    '"><img src = "./../../Content/Images/Seats/vacantseat.jpg" class = "vacantSeat"/></a>');

            }
            
        }
        if (i === 0 || i === 1) {
            $('.hall').append('<span>' + (i + 1) + 'V</span>');
        }else if (i === 4) {
            $('.hall').append('<span>' + (i + 1) + 'B</span>');
        }
        else {
            $('.hall').append('<span>' + (i + 1) + 'C</span>');
        }
        $('.hall').append('<br/>');
        if (i % 2) {
            $('.hall').append('<br/>');
        }
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