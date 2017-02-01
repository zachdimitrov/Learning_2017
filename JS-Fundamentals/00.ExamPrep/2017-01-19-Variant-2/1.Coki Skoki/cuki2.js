function solve(args) {
    let len = args[0],
        numbers = args.slice(1).map(Number),
        i, result;
    if (numbers[0] % 2 == 1) {
        result = 1;
    } else {
        result = 0;
    }
    for (i = 0; i < len; i += 1) {
        if (numbers[i] % 2 == 1) {
            result = result * numbers[i];
        } else {
            result = result + numbers[i];
            i += 1;
        }
        if (result > 1024) {
            result = result % 1024;
        }
    }
    console.log(result);
}