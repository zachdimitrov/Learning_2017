const { Movie } = require('../models/movie.model');
require('../models/extensions');

const parseMovie = (url) => {
    return fetch(url)
        .then((response) => {
            if (!response.ok) {
                throw new Error('Invalid url');
            }

            return response.text();
        })
        .then((html) => {
            const movie = Movie.fromHtml(html);
            return movie;
        });
};

module.exports = { parseMovie };