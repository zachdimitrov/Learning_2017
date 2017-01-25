function hasProp(object, prop) {
    var contains = false;

    for (var p in object) {
        if (p === prop) {
            contains = true;
        }
    }
    return contains;
}

// test

var o = {
    'style': 'red',
    11: 212,
    'year': 2012
};

console.log(hasProp(o, 'year'));
console.log(hasProp(o, 'small'));