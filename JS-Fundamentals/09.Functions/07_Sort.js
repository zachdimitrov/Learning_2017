function solve(args) {
    let array = args[1].split(' ').map(Number);

    console.log(sort(array).reverse().join(' '));

    function sort(arr) {
        for (let i = 0, len = arr.length; i < len; i += 1) {
            let index = max(arr, i),
                temp = arr[i];

            arr[i] = arr[index];
            arr[index] = temp;
        }
        return arr;
    }

    function max(arr, i) {
        let maxElement = Number.NEGATIVE_INFINITY,
            index = i;
        if (i >= arr.length - 1) {
            return arr.length - 1;
        }

        for (let j = i, len = arr.length; j < len; j += 1) {
            if (arr[j] > maxElement) {
                maxElement = arr[j];
                index = j;
            }
        }
        // console.log(maxElement); // REMOVE BEFORE
        return index;
    }
}

// test

solve(['6', '3 4 1 5 2 6']);
solve(['10', '36 10 4 34 28 38 31 27 30 20']);
solve(['5', '-1 2 1 -4 5 1']);
solve(['5', '1 -2 -10 -4 5 -11']);