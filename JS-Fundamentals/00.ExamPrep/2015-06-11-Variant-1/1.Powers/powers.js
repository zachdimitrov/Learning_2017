function solve(params) {
    var nk = params[0].split(' ').map(Number),
        s = params[1].split(' ').map(Number),
        result = 0,
        r = [];

    for (j = 0; j < nk[1]; j++) {
        for (let i = 0, len = s.length; i < len; i += 1) {
            let prev, next;
            switch (i) {
                case 0:
                    prev = s[s.length - 1];
                    next = s[i + 1];
                    break;
                case s.length - 1:
                    prev = s[i - 1];
                    next = s[0];
                    break;
                default:
                    prev = s[i - 1];
                    next = s[i + 1];
                    break;
            }

            if (s[i] === 0) {
                r[i] = Math.abs(prev - next);
            } else if (s[i] === 1) {
                r[i] = prev + next;
            } else if (s[i] !== 0 && s[i] !== 1 & s[i] % 2 === 0) {
                r[i] = Math.max(prev, next);
            } else if (s[i] !== 0 && s[i] !== 1 & s[i] % 2 !== 0) {
                r[i] = Math.min(prev, next);
            }
        }
        s = r.slice();
    }
    result = s.reduce((a, b) => a + b);
    console.log(result);
}

// tests

solve(['5 1',
    '9 0 2 4 1'
]);
solve(['10 3',
    '1 9 1 9 1 9 1 9 1 9'
]);
solve(['10 10',
    '0 1 2 3 4 5 6 7 8 9'
]);