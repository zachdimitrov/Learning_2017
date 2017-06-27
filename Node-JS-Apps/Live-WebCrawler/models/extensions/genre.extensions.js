const { Genre } = require('../genre.model');
const initParser = require('../../dom-parser');
const { DETAILS } = require('../../selectors');

// static
Genre.fromHtml = (html) => {
    return initParser(html)
        .then(($) => {
            const name = $('#header h1').html();
            const ids = [];
            const movieIds = $('table.results tbody td.image a')
                .each((index, el) => {
                    const href = $(el).attr('href');
                    const id = href.substr('/title/'.length);
                    ids.push(id);
                });
            return new Genre(name, ids);
        });
};