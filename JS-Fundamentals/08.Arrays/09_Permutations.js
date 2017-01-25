function permNoRep(a) {
    var n = +a[0],
        seq = [];

    function perm(n, seq) {
        if (seq.length === n) {
            console.log('{ ' + seq.join(', ') + ' }');
            return;
        }

        for (var j = 1; j <= n; j++) {
            if (seq.indexOf(j) >= 0) {
                continue;
            }
            seq.push(j);
            perm(n, seq);
            seq.pop();
        }
    }

    perm(n, seq);
}

// with repetitons

function permRep(a) {
    var n = +a[0],
        seq = [],
        contains = [1, 2, 1],
        sum = contains.reduce((a, b) => a + b, 0),
        count = 0;

    function perm(n, contains, seq) {
        if (seq.length === contains.length) {
            console.log('{ ' + seq.join(', ') + ' }');
            return;
        }

        for (var j = 1, con = contains.length; j <= con; j++) {
            if (contains[j - 1] === 0) {
                continue;
            }

            seq.push(j);
            contains[j - 1]--;
            perm(n, contains, seq);
            contains[j - 1]++;
            seq.pop();
        }
    }

    perm(sum, contains, seq);
}

// iterative

function permIter(a) {
    var n = +a[0],
        perm = [];

    for (let i = 0; i < n; i += 1) {
        perm[i] = i + 1;
    }

    function swap(a, b) {
        let tmp = a;
        a = b;
        b = tmp;
    }

    function next(perm) {
        var i = perm.length - 1;
        while (i > 0) {
            if (perm[i - 1] < perm[i]) {
                break;
            }
            i--;
        }

        if (i === 0) {
            return false;
        }

        for (let j = perm.length - 1;; j -= 1) {
            if (perm[j] > perm[i - 1]) {
                //swap(perm[j], perm[i - 1]);
                let tmp = perm[j];
                perm[j] = perm[i - 1];
                perm[i - 1] = tmp;
                break;
            }
        }

        for (let j = perm.length - 1; i < j; j -= 1, i += 1) {
            //swap(perm[j], perm[i]);
            let tmp = perm[j];
            perm[j] = perm[i];
            perm[i] = tmp;
        }

        return true;
    }

    do {
        console.log('{ ' + perm.join(', ') + ' }');
    } while (next(perm));
}

// tests
console.log('---- without repetitions -----');
permNoRep(['3']);
console.log('------ with repetitions ------');
permRep(['3']);
console.log('---------- iterative ---------');
permIter(['3']);