const print = (msg) => {
    console.log('Function: ' + msg);
};

class Printer {
    print(msg) {
        console.log('Class: ' + msg);
    }
}

module.exports = {
    print,
    Printer,
    getPrinter() {
        return new Printer();
    },
};

// globals.Promise = require('Bluebird');
// do not use this, only in special cases
