function stringFormat(frmt, ...args) {
    var places = frmt.match(/{[\d]+}/g).map(x => {
            return +x.slice(1, x.length - 1);
        }),
        res = '';
    console.log(places);
    for (var i = 0, len = frmt.length; i < len; i++) {
        if (frmt[i] === '{') {
            let end = frmt.indexOf('}', i),
                val = +frmt.substring(i + 1, end);
            for (let p in places) {
                if (val === places[p]) {
                    res += args[places[p]];
                    break;
                }
            }
            i = end;
        } else {
            res += frmt[i];
        }
    }
    return res;
    // console.log(...args);
}

// test

var frmt = '{0}, {1}, {0} text {2}';
var str = stringFormat(frmt, 1, 'Pesho', 'Gosho');
console.log(str);