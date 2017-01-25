function solve(params) {
    var s = params[0].split(" ")
        .map(Number),
        peaks = [],
        groups = [],
        result;
    peaks[0] = true;
    peaks[s.length - 1] = true;
    for (let i = 1; i < s.length - 1; i++) {
        if (s[i - 1] < s[i] && s[i] > s[i + 1]) {
            peaks[i] = true;
        } else {
            peaks[i] = false;
        }
    }
    let p = 0;
    groups[p] = 1;
    for (let j = 1; j < s.length - 1; j++) {
        if (!peaks[j]) {
            groups[p] += 1;
        } else {
            p++;
            groups[p] = 1;
        }
    }
    console.log(Math.max.apply(Math, groups));
}

// TESTS

console.log('--------- TEST 1 ----------');
solve(['5 1 7 4 8']);
console.log('--------- TEST 2 ----------');
solve(['5 1 7 6 3 6 4 2 3 8']);