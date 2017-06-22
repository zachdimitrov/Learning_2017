/* globals __dirname */

const fs = require('fs'); // load internal module

// load custom module, always use ./
const printerModule = require('./utils/printer');

// another way to load
const {
    getPrinter1,
    Printer,
} = require('./utils/printer');

// load index.js file
const utils = require('./utils');
const { getPrinter2 } = require('./utils');

// a way to use the first load
const printer = printerModule.getPrinter();

fs.readdirSync(__dirname)
    .forEach((file) => {
        console.log(file);
        console.log('---------------');
        console.log(printer.print(file));
    });