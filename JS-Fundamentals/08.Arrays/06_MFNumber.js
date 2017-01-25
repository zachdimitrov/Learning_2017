// most frequent number
function solve(args) {
    let n = +args[0],
        arr = args.slice(1),
        rep = 1,
        max = 0,
        result;

    for (var i = 0; i < n - 1; i += 1) {
        for (var j = i + 1; j < n; j += 1) {
            if (+arr[i] === +arr[j]) {
                rep += 1;
            }
        }
        if (max < rep) {
            max = rep;
            result = arr[i];
        }
        rep = 1;
    }
    console.log(`${result} (${max} times)`);
}

// tests

solve(['13', '4', '1', '1', '4', '2', '3', '4', '4', '1', '2', '4', '9', '3']);
console.log('4 (5 times)');

solve(['13', '4', '1', '1', '4', '2', '3', '1', '4', '1', '1', '1', '9', '1']);