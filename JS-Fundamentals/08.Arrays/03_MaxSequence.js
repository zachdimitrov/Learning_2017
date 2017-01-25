function s(a) {
    var temp = 1,
        max = 1,
        l = +a[0];

    for (var i = 2; i < l; i++) {
        if (a[i] === a[i - 1]) {
            temp += 1;
        } else {
            if (temp > max) {
                max = temp;
            }
            temp = 1;
        }
    }
    console.log(max);
}

// tests

s(['10', '2', '1', '1', '2', '3', '3', '2', '2', '2', '1']);
s(['1', '1', '1', '2', '2', '4']);