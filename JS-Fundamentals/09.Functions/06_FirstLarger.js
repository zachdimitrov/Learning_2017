function solve(args) {
    let array = args[1].split(' ').map(Number);

    function firstLarger(arr) {
        for (let i = 1, len = arr.length; i < len - 1; i += 1) {
            if (arr[i - 1] < arr[i] && arr[i] > arr[i + 1]) {
                return i;
            }
        }
        return '-1';
    }

    console.log(firstLarger(array));
}

// test

solve(['6', '-26 -25 -28 31 2 27']);
solve(['10', '86 43 21 34 31 30 28 9 8 3']);