console.log('I am utils');

const { Printer } = require('./printer');
module.exports = {
    getPrinter() {
        return new Printer();
    },
};
