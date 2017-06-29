/* globals console require */

'use strict';

const listMoviesUrl = 'http://www.imdb.com/genre/action';

const genres = ['fantasy', 'horror', 'comedy', 'action'];

// const http = require('http'); // too hard
const request = require('request');
const jsdom = require('jsdom');
const { JSDOM } = jsdom;

request(listMoviesUrl, (err, res, body) => {
    const dom = new JSDOM(body);
    const $ = require('jquery')(dom.window);
    $('body').html(body);
    console.log($('body').html());
});
