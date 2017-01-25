function s(a) {
    var x = '' + a[0],
        y = '' + a[1],
        result = '=';

    x = x.toLowerCase();
    y = y.toLowerCase();

    var len = x.length > y.length ? x.length : y.length;

    for (var i = 0; i < len; i += 1) {
        if (x[i] < y[i]) {
            result = '<';
        } else if (x[i] > y[i]) {
            result = '>';
        } else if (x[i] = y[i]) {
            continue;
        }
    }
    if (x.length !== y.length && result === '=') {
        result = x.length > y.length ? '>' : '<';
    }
    console.log(result);
}

// working solution

function solveR(args) {
    var text1 = String(args[0]);
    var text2 = String(args[1]);
    var result = '=';

    if (text1 > text2) {
        result = '>';
    } else if (text1 < text2) {
        result = '<';
    }
    return result;
}

// tests

s(['hello', 'halo']);
s(['food', 'food']);
s(['bitka', 'batka']);