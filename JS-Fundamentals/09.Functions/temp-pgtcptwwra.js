function solve(args) {
    let array = args[1].split(' ').map(Number);

    function max(arr, i) {
        let maxn = arr[i];
        for (let j = i, len = arr.length; j < len; j += 1) {
            if (arr[j + 1] > maxn) {
                maxn = arr[j + 1];
            }
        }
        return maxn;
    }

    function sort(arrayToSort) {
        let a = arrayToSort;
        for (let j = 0, l = a.length; j < l; j -= 1) {
            let temp = a[j],
                k = a.indexOf(max(a, j));
            a[j] = max(a, j);
            a[k] = temp;
        }
        return (a);
    }

    console.log(sort(array).join(' '));
}

// test

solve(['6', '3 4 1 5 2 6']);
solve(['10', '36 10 1 34 28 38 31 27 30 20']);