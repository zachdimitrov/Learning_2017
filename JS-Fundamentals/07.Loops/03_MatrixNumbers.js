// nested loops

function s(a) {
    var n = +a[0],
        line = '';
    for (var i = 0; i < n; i++) {
        for (var j = 1; j <= n; j++) {
            line += j + i + ' ';
        }
        console.log(line.trim());
        line = '';
    }
}

// no nested loops

function sn(a) {
    var n = +a[0],
        start = [],
        line = '';

    for (var i = 0; i < n; i++) {
        start[i] = i;
    }

    for (var j = 0; j < n; j++) {
        start.push(start[start.length - 1] + 1);
        start.shift();
        console.log(start.join(' '));
    }
}

// tests

sn(['1']);
sn(['2']);
sn(['3']);