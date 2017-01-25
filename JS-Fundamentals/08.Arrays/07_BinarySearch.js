function solve(args) {
    let n = +args[0],
        x = +args[n + 1],
        arr = args.slice(1, n + 1),
        middle = 0,
        left = 0,
        right = n - 1;

    while (left <= right) {
        middle = Math.floor((right + left) / 2);

        if (+arr[middle] === x) {
            return middle;
        }

        if (x < +arr[middle]) {
            right = middle - 1;
        } else {
            left = middle + 1;
        }
    }
    return '-1';
}

// tests

console.log(solve(['10', '1', '2', '4', '8', '16', '31', '32', '64', '77', '99', '16']));
console.log(['1', '2', '4', '8', '16', '31', '32', '64', '77', '99']);