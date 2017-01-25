function s(d, w, n) {
    var dSmallest = String(d[0]),
        dLargest = String(d[0]),
        wSmallest = String(w[0]),
        wLargest = String(w[0]),
        nSmallest = String(n[0]),
        nLargest = String(n[0]);

    for (var propd in d) {
        let e = String(propd);
        if (e < dSmallest) { dSmallest = e; }
        if (e > dLargest) { dLargest = e; }
    }
    for (var propw in w) {
        let e = String(propw);
        if (e < wSmallest) { wSmallest = e; }
        if (e > wLargest) { wLargest = e; }
    }
    for (var propn in n) {
        let e = String(propn);
        if (e < nSmallest) { nSmallest = e; }
        if (e > nLargest) { nLargest = e; }
    }

    console.log('Smallest in ' + d + ' is:' + dSmallest);
    console.log('Largest in ' + d + ' is:' + dLargest);
    console.log('Smallest in ' + w + ' is:' + wSmallest);
    console.log('Largest in ' + w + ' is:' + wLargest);
    console.log('Smallest in ' + n + ' is:' + nSmallest);
    console.log('Largest in ' + n + ' is:' + nLargest);
}