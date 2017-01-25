/* Task description */
/*
	Write a function that finds all the prime numbers in a range
		1) it should return the prime numbers in an array
		2) it must throw an Error if any on the range params is not convertible to `Number`
		3) it must throw an Error if any of the range params is missing
*/

function solve() {
    return function findPrimes(a, b) {
        let result = [];
        if (arguments.length < 2) {
            throw 'Error';
        }
        for (var num = +a; num <= +b; num++) {
            let isPrime = true;
            if (num === 1 || num === 0) {
                continue;
            } else if (num === 2) {
                result.push(num);
                continue;
            } else if (num > 2) {
                for (var i = 2; i <= Math.sqrt(num); i++) {
                    if (num % i === 0) {
                        isPrime = false;
                    }
                }
            }
            if (isPrime) { result.push(num); }
        }
        return result;
    }
}

module.exports = solve;