let fib = {
    [Symbol.iterator]() {
        let prev = 1,
            current = 0;

        return {
            next() {
                let valueToReturn = {
                    value: current,
                    done: false
                };
                [prev, current] = [current, prev + current];
                return valueToReturn;
            }
        };
    }
};

let index = 0;

for (let fn of fib) {
    if (index >= 100) {
        break;
    }
    index += 1;

    console.log(fn);
}