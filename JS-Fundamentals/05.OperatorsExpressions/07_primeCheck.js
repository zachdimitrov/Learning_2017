function solve(args) {
    let number = +args[0],
        i,
        result = "true";

    if (number < 2) {
        result = "false";
    }

    for (i = 2; i < number / 2; i += 1) {
        if (!(number % i)) {
            result = "false";
        }
    }

    console.log(result);
}

// old es

function solve(args) {
    var number = +args[0],
        i,
        result = "true";

    if (number <= 1) {
        result = "false";
    } else if (number <= 3) {
        result = 'true';
    } else {
        for (i = 2; i < number / 2; i += 1) {
            if (number % i === 0) {
                result = "false";
            }
        }
    }

    console.log(result);
}

function debilno(args) {
    var n = +args[0],
        result = (n === 2 ||
            n === 3 || n === 5 || n === 7 || n === 11 ||
            n === 13 || n === 17 || n === 19 || n === 23 ||
            n === 29 || n === 31 || n === 37 || n === 41 ||
            n === 43 || n === 47 || n === 53 || n === 59 ||
            n === 61 || n === 67 || n === 71 || n === 73 ||
            n === 79 || n === 83 || n === 89 || n === 97) ? 'true' : 'false';
    return result;
}

console.log(debilno(['5']));
console.log(debilno(['52']));