function solve(args) {
    var arr = args.slice(1),
        s = args[0],
        sum = 0,
        result = [],
        count = 0;

    for (let j = 0, len = arr.length; j < len; j += 1) {
        if (sum < s) {
            sum += arr[j];
            result.push(arr[j]);
            count++;
            if (sum === s) {
                console.log(result.join(', '));
                return;
            }
        } else {
            sum = arr[j];
            result = [];
            j = j - count + 1;
            count = 0;
        }
    }
    console.log('no array with that sum exists');
}


// tests

solve([12, 4, 3, 1, 4, 2, 5, 8]);