'use strict';

function getParseData(places) {
    var result = [];
    for (var i = 0; i < places.length; i++) {
        if (places[i] !== '') {
            result.push(places[i]);
        }
    }
    return result;
}

function getSelectedPlaceId() {
    var elements = $('.selectedSeat');
    var places = [];
    elements.each(function() {
        places.push(this.id);
    });

    return getParseData(places);
}

;