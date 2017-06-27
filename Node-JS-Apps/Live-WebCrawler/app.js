require('./polyfills');
const { DETAILS } = require('./selectors');
const { Movie } = require('./models/movie.model');
require('./models/extensions');

// get the movies and add them to queue
const searchUrl = 'https://www.imdb.com/genre/';
const genres = ['action', 'animation', 'fantasy',
    'horror', 'drama', 'comedy', 'adventure',
];
const writeJsonFile = require('write-json-file');
const { parseGenre } = require('./parsers/genre.parser');
const { parseMovie } = require('./parsers/movie.parser');

const movies = [];

const loadMovie = (queue) => {
    if (queue.isEmpty()) {
        return Promise.resolve();
    }
    const id = queue.pop();
    const url = 'https://www.imdb.com/title/' + id;
    return parseMovie(url)
        .then((movie) => {
            movies.push(movie);
            return loadMovie(queue);
        });
};

const loadMovies = (queue) => {
    const PARALEL_LOADS = 4;
    return Promise.all(
            Array.from({ length: PARALEL_LOADS })
            .map((_) => loadMovie(queue)))
        .then(() => {
            writeJsonFile('movies.json', movies);
        })
        .then(() => {
            console.log('movies.json file was created successfully!');
        });
};

const queue = require('./queue').getQueue();

Promise.all(genres.map((genreUrl) => {
        const url = searchUrl + genreUrl;
        return parseGenre(url)
            .then((genre) => {
                queue.pushMany(...genre.moviesIds);
            });
    }))
    .then(() => {
        return loadMovies(queue);
    });