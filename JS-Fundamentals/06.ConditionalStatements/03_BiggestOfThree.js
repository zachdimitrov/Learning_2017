function solve(args) {
    let a = +args[0],
        b = +args[1],
        c = +args[2],
        result;

    if (a >= b) {
        if (a >= c) {
            result = a;
        } else {
            result = c;
        }
    } else {
        if (b >= c) {
            result = b;
        } else {
            result = c;
        }
    }

    console.log(result);
}