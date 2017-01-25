// with Sieve of Eratostehnes algorithm

function sieveAlg(args) {
    var n = +args,
        sqrtn = Math.sqrt(n),
        prime = [];

    for (let i = 2; i <= n; i++) {
        prime[i] = true;
    }

    for (let i = 2; i <= sqrtn; i++) {
        if (prime[i]) {
            for (j = i * i; j <= n; j += i) {
                prime[j] = false;
            }
        } else continue;
    }

    for (let k = n; k >= 2; k--) {
        if (prime[k]) {
            return k;
        }
    }
}

// with divisions

function solve(args) {

    var number = +args[0],
        isPrime;

    for (var i = number; i >= 2; i -= 1) {
        isPrime = true;
        for (var j = 2; j <= Math.sqrt(number); j += 1) {
            if (i % j === 0) {
                isPrime = false;
                break;
            }
        }
        if (isPrime) {
            return i;
        }
    }
    return '-1';
}

// tests

var time1 = Date.now();
console.log(sieveAlg(['10000000']));
console.log(Date.now() - time1 + ' ms');

var time2 = Date.now();
console.log(solve(['10000000']));
console.log(Date.now() - time2 + ' ms');