function solve(args) {
    let a = +args[0],
        b = +args[1],
        c = +args[2],
        z;

    if (a <= b) {
        z = a;
        a = b;
        b = z;
    }
    if (a <= c) {
        z = a;
        a = c;
        c = z;
    }
    if (b <= c) {
        z = b;
        b = c;
        c = z;
    }

    console.log(`${a} ${b} ${c}`);
}

// old es solution

function solve(args) {
    var a = +args[0],
        b = +args[1],
        c = +args[2],
        z;

    if (a <= b) {
        z = a;
        a = b;
        b = z;
    }
    if (a <= c) {
        z = a;
        a = c;
        c = z;
    }
    if (b <= c) {
        z = b;
        b = c;
        c = z;
    }

    console.log(a + ' ' + b + ' ' + c);
}

// Tests

solve(['5', '1', '2']);
solve(['-2', '4', '3']);
solve(['0', '-2.5', '5']);
solve(['-1.1', '-0.5', '-0.1']);
solve(['10', '20', '30']);
solve(['1', '1', '1']);
solve(['3', '6', '2']);