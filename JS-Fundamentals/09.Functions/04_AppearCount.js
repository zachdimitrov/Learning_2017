function solve(args) {
    let ar = args.split('\n'),
        n = +ar[0],
        numbers = ar[1].split(' '),
        x = +ar[2];

    // console.log(n + '\n' + numbers + '\n' + x);

    function appearInArray(f, arr) {
        let count = 0;
        for (let i = 0, len = arr.length; i < len; i += 1) {
            if (+arr[i] === f) {
                count += 1;
            }
        }
        return count;
    }

    console.log(appearInArray(x, numbers));
}

solve('8\n28 6 21 6 -7856 73 73 -56\n73');