function solve(args) {
    let number = +args[0],
        result;

    if (!(number % 5) && !(number % 7)) {
        result = "true";
    } else {
        result = "false";
    }
    console.log(`${result} ${number}`);
}

// old es

function solve2(args) {
var number = +args[0],
        result;

    if (number % 5 === 0 && number % 7 === 0) {
        result = "true";
    } else {
        result = "false";
    }
    console.log(result + ' ' + number);
}