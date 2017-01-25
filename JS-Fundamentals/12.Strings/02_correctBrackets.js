function solve(args) {
    var s = args[0].split(''),
        bracket = 0;

    for (var i in s) {
        if (s[i] === '(') {
            bracket++;
        }
        if (s[i] === ')') {
            bracket--;
        }
        if (bracket < 0) {
            console.log('Incorrect');
            return;
        }
    }
    if (bracket === 0) {
        console.log('Correct');
    } else {
        console.log('Incorrect');
    }
}

// test

solve(['((a+b)/5-d)']);
solve([')(a+b))']);