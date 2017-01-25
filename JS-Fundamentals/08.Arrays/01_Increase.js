function s(a) {
    var arr = [],
        res = [],
        n = +a[0];

    for (var i = 0; i < n; i++) {
        arr[i] = i * 5;
        console.log(arr[i]);
    }
}

// tets

s(['5']);
s(['7']);