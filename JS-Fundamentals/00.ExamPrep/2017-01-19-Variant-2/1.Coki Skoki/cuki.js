function solve(args) {
    const module = 1024;
    let numbers = args.slice(1).map(Number),
        current,
        result = 0,
        i = 0;

    while (true) {
        if (i === 0) {
            current = numbers[i];
            if (numbers.length === 1) {
                result = current;
                break;
            }
            i++;
        }
        if (numbers[i] % 2 === 0 || numbers[i] === 0) {
            current += numbers[i];
            current = current % module;
            i += 2;
            if (i > numbers.length - 1) {
                result = current;
                break;
            }
        } else if (numbers[i] % 2 !== 0 || numbers[i] === 1) {
            current *= numbers[i];
            current = current % module;
            i++;
            if (i > numbers.length - 1) {
                result = current;
                break;
            }
        }
    }
    console.log(result);
}

// tests
solve([
    '10',
    '1',
    '2',
    '3',
    '4',
    '5',
    '6',
    '7',
    '8',
    '9',
    '0'
]);
console.log('------------');

solve([
    '9',
    '9',
    '9',
    '9',
    '9',
    '9',
    '9',
    '9',
    '9',
    '9'
]);

solve(['2', '2', '2', '2', '2', '2', '2', '2', '2']);