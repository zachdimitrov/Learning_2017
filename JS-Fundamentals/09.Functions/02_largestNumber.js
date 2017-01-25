function solve(args) {
    var n = args[0].split(' ').map(Number);

    function getMax(a, b) {
        if (a >= b) { return a; } else { return b; }
    }

    console.log(getMax(getMax(n[0], n[1]), n[2]));
}

// tests

solve(['4 5 3']);
solve(['6534 3754 14532']);