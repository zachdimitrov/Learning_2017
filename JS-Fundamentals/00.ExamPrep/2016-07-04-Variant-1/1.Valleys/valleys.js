function solve(params) {
    var s = params[0].split(" ")
        .map(Number),
        result = 0,
        sum = s[0];
    for (let i = 1; i < s.length - 1; i++) {
        if (s[i - 1] < s[i] && s[i] > s[i + 1]) {
            sum += s[i];
            if (result < sum) {
                result = sum;
            }
            sum = s[i];
        } else {
            sum += s[i];
            if (i === s.length - 2) {
                sum += s[s.length - 1];
                if (result < sum) {
                    result = sum;
                }
            }
        }
    }
    console.log(result);
}

// TESTS

console.log('--------- TEST 1 ----------');
solve(['5 1 7 4 8']);
console.log('--------- TEST 2 ----------');
solve(['5 1 7 6 5 6 4 2 3 8']);