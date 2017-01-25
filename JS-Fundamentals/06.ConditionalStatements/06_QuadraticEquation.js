// es 6 solution

function solve(args) {
    var a = +args[0],
        b = +args[1],
        c = +args[2],
        x1, x2, d, result;

    d = b * b - 4 * a * c;

    if (d === 0) {
        x1 = (-b / (2 * a)).toFixed(2);
        x2 = x1;
        result = `x1=x2=${x1}`;
    }
    if (d > 0) {
        x1 = ((-b + Math.sqrt(d)) / (2 * a)).toFixed(2);
        x2 = ((-b - Math.sqrt(d)) / (2 * a)).toFixed(2);

        // console.log(`x1=${x1}; x2=${x2}`)

        if (+x1 > +x2) {
            let k = x1;
            x1 = x2;
            x2 = k;
        }

        result = `x1=${x1}; x2=${x2}`;
    }
    if (d < 0) {
        result = "no real roots";
    }

    return result;
}

// old es solution

function solveOld(args) {
    var a = +args[0],
        b = +args[1],
        c = +args[2],
        x1, x2, d, result;

    d = b * b - 4 * a * c;

    if (d === 0) {
        x1 = (-b / (2 * a)).toFixed(2);
        x2 = x1;
        result = 'x1=x2=' + x1;
    }
    if (d > 0) {
        x1 = ((-b + Math.sqrt(d)) / (2 * a)).toFixed(2);
        x2 = ((-b - Math.sqrt(d)) / (2 * a)).toFixed(2);

        if (+x1 > +x2) {
            var k = x1;
            x1 = x2;
            x2 = k;
        }

        result = 'x1=' + x1 + '; x2=' + x2;
    }
    if (d < 0) {
        result = 'no real roots';
    }

    return result;
}


// tests

console.log(solveOld(['2', '5', '-3']) == "x1=-3.00; x2=0.50");
console.log(solveOld(['-1', '3', '0']) == "x1=0.00; x2=3.00");
console.log(solveOld(['-0.5', '4', '-8']) == "x1=x2=4.00");
console.log(solveOld(['5', '2', '8']) == "no real roots");
console.log(solveOld(['0.2', '9.572', '0.2']) == "x1=-47.84; x2=-0.02");