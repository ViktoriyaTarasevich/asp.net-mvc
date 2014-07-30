'use strict';
(function ($) {
    jQuery.fn.hallRender = function(reservedSeats, options) {
        var element = this;
        options = $.extend({
            rowCount: 5,
            columnCount: 10,
            vacantSeatLogo: './../../Content/Images/Seats/vacantseat.jpg',
            reservedSeatLogo: './../../Content/Images/Seats/reservedseat.jpg',
            selectedSeatLogo: './../../Content/Images/Seats/selectedseat.jpg',
            startPlaceId: 59,
            setRowPlacesTitle: setRowTitle,
            setScreenForHall: setDefaultScreen,
            setDistanceBetweenRows: setDefaultDistanceBetweenRows
        }, options);

        function setRowTitle(row) {
            if (row === 0 || row === 1) {
                element.append('<span>' + (row + 1) + 'V</span>');
            } else if (row === 4) {
                element.append('<span>' + (row + 1) + 'B</span>');
            } else {
                element.append('<span>' + (row + 1) + 'C</span>');
            }
        }

        function setDefaultScreen() {
            element.append('<p>--------------------------Экран-------------------------</p>');
            element.append('<br/>');
        }

        function setDefaultDistanceBetweenRows() {
            element.append('<br/>');
            if (i % 2) {
                element.append('<br/>');
            }
        }
        
        function isContainsInArray(placeId) {
            if (reservedSeats) {
                for (var k = 0; k < reservedSeats.length; k++) {
                    if (placeId === reservedSeats[k]) {
                        return true;
                    }
                }
            }
            return false;
        }

        options.setScreenForHall();
        var tempId = options.startPlaceId;
        for (var i = 0; i < options.rowCount; i++) {
            options.setRowPlacesTitle(i);
            for (var j = 0; j < options.columnCount; j++) {
                if (isContainsInArray(tempId)) {
                    element.append('<a id = "' +
                        (tempId++) +
                        '" class = "place reservedSeat" title = "' +
                        (j + 1) +
                        '"><img src = "' + options.reservedSeatLogo + '" class = "reservedSeat"/></a>');
                } else {
                    element.append('<a id = "' +
                    (tempId++) +
                    '" class = "place" title = "' +
                    (j + 1) +
                    '"><img src = "' + options.vacantSeatLogo + '" class = "vacantSeat"/></a>');
                }
            }
            options.setRowPlacesTitle(i);
            setDefaultDistanceBetweenRows();
        };

        $(document.body).on('click', '.place', function () {
            var clickElement = $(this);
            if (clickElement.hasClass('selectedSeat')) {
                clickElement.removeClass('selectedSeat');
                clickElement.html('<img src = "' + options.vacantSeatLogo + '" class = "vacantSeat"/>');
                return;
            }
            if (clickElement.hasClass('reservedSeat')) {
                return;
            } else {
                clickElement.addClass('selectedSeat');
                clickElement.find('.vacantSeat').remove();
                clickElement.html('<img src = "'+ options.selectedSeatLogo +'" class = "selectedSeat"/>');
                return;
            }

        });
    };
})(jQuery);