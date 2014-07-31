'use strict';
(function($) {
    jQuery.fn.hallRender = function(reservedSeats, options) {
        var element = this;
        options = $.extend({
            rowCount: 5,
            columnCount: 10,
            vacantSeatLogo: './../../Content/Images/Seats/vacantseat.jpg',
            reservedSeatLogo: './../../Content/Images/Seats/reservedseat.jpg',
            selectedSeatLogo: './../../Content/Images/Seats/selectedseat.jpg',
            startPlaceId: 1,
            setRowPlacesTitle: setRowTitle,
            setScreenForHall: setDefaultScreen,
            setDistanceBetweenRows: setDefaultDistanceBetweenRows
        }, options);

        var SELECTED_SEAT = 'selectedSeat';
        var VACANT_SEAT = 'vacantSeat';
        var RESERVED_SEAT = 'reservedSeat';

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

        function createPlace(column, logo, className) {
            element.append('<a id = "' +
                (tempId++) +
                '" class = "place ' + className + '" title = "' +
                (column + 1) +
                '"><img src = "' + logo + '" class = "' + className + '"/></a>');
        }

        options.setScreenForHall();
        var tempId = options.startPlaceId;
        for (var i = 0; i < options.rowCount; i++) {
            options.setRowPlacesTitle(i);
            for (var j = 0; j < options.columnCount; j++) {
                if (isContainsInArray(tempId)) {
                    createPlace(j, options.reservedSeatLogo, RESERVED_SEAT);
                } else {
                    createPlace(j, options.vacantSeatLogo, VACANT_SEAT);
                }
            }
            options.setRowPlacesTitle(i);
            setDefaultDistanceBetweenRows();
        }

        $(document.body).on('click', '.place', function() {
            var clickElement = $(this);
            if (clickElement.hasClass(SELECTED_SEAT)) {
                clickElement.removeClass(SELECTED_SEAT);
                clickElement.html('<img src = "' + options.vacantSeatLogo + '" class = "' + VACANT_SEAT + '"/>');
                return;
            }
            if (clickElement.hasClass(RESERVED_SEAT)) {
                return;
            } else {
                clickElement.addClass(SELECTED_SEAT);
                clickElement.find('.' + VACANT_SEAT).remove();
                clickElement.html('<img src = "' + options.selectedSeatLogo + '" class = "' + SELECTED_SEAT + '"/>');
                return;
            }
        });
    };
})(jQuery);