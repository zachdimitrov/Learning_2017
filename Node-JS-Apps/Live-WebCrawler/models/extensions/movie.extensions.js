const { Movie } = require('../movie.model');
const initParser = require('../../dom-parser');
const { DETAILS } = require('../../selectors');

// static
Movie.fromHtml = (html) => {
    return initParser(html)
        .then(($) => {
            const year = $(DETAILS.TITLE_SELECTOR + ' #titleYear a').text();
            let title = $(DETAILS.TITLE_SELECTOR).html();
            title = title.substring(0, title.indexOf('&nbsp;<span '));
            const posterUrl = $(DETAILS.POSTER_IMAGE_URL).attr('src');
            return new Movie(title, year, posterUrl);
        });
};

/*
Movie.prototype.instanceMethod = () => {
    // add instance method
};
*/