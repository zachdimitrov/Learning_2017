var fs = require("fs");

function printdir(dir) {
    var files = fs.readdirSync(dir);

    files.forEach(file => console.log(file));
}

module.exports = printdir;