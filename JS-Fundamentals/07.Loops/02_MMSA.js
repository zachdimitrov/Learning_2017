function s(a) {
    var max = +a[0];
    var min = +a[0];
    var sum = 0;

    a.forEach(function(e) {
        x = +e;
        if (x > max) max = x;
        if (x < min) min = x;
        sum += x;
    }, this);

    var avg = sum / a.length;

    console.log('min=' + min.toFixed(2));
    console.log('max=' + max.toFixed(2));
    console.log('sum=' + sum.toFixed(2));
    console.log('avg=' + avg.toFixed(2));
}

// Tests

s(['2', '-1', '4']);
s(['2', '5', '1']);