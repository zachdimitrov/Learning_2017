function solve(args) {
    let n = +args[0],
        numbers = args[1].split(' '),
        result;

    function larger(arr) {
        let count = 0;

        for (let i = 1, len = arr.length; i < len - 1; i += 1) {
            if (+arr[i - 1] < +arr[i] && +arr[i] > +arr[i + 1]) {
                count += 1;
            }
        }

        return count;
    }
    result = larger(numbers);
    console.log(result);
}

// tests

solve(['6', '-26 -25 -28 31 2 27']);
solve(['10', '86 43 21 34 31 30 28 9 8 3']);