function solve(args) {
    let max = 0,
        current = 1,
        n = +args[0],
        arr = args.slice(1);

    console.log(n + '---' + arr.join('|'));

    for (var i = 0; i < n; i += 1) {
        var previous = +arr[i],
            next = +arr[i + 1];
        if (previous < next) {
            current += 1;
        } else {
            if (current > max) {
                max = current;
            }
            current = 1;
        }
    }
    return max;
}

// tests

console.log(solve(['8', '7', '3', '2', '3', '4', '2', '2', '4']));
console.log(solve(['8', '1', '3', '8', '2', '33', '887', '2212', '3322']));