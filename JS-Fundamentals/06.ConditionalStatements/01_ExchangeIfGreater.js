function solve(args) {
    let a = +args[0],
        b = +args[1],
        c;

    if (a > b) {
        c = a;
        a = b;
        b = c;
    }

    console.log(`${a} ${b}`);
}

// old es solution

function solveOld(args) {
    var a = +args[0],
        b = +args[1],
        c;

    if (a > b) {
        c = a;
        a = b;
        b = c;
    }

    console.log(a + ' ' + b);
}