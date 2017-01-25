function solve(args) {
    let type, number = +args[0]
    if (!(number % 2)) {
        type = "even";
    } else {
        type = "odd";
    }
    console.log(`${type} ${number}`);
}

// old es

function solve(args) {
    var type, number = +args[0]
    if (!(number % 2)) {
        type = "even";
    } else {
        type = "odd";
    }
    console.log(type + ' ' + number);
}