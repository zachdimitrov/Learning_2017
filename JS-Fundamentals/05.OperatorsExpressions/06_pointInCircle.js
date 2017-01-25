function solve(args) {
    let x = +args[0],
        y = +args[1],
        distance = Math.sqrt(x * x + y * y);

    if (distance <= 2) {
        console.log(`yes ${distance.toFixed(2)}`);
    } else {
        console.log(`no ${distance.toFixed(2)}`);
    }
}

// old es

function solve(args) {
    var x = +args[0],
        y = +args[1],
        distance = Math.sqrt(x * x + y * y);

    if (distance <= 2) {
        console.log('yes ' + distance.toFixed(2));
    } else {
        console.log('no ' + distance.toFixed(2));
    }
}