function deepCopy(object) {
    if (typeof object === 'object') {
        var copy = array.isArray(object) ? [] : {};
        for (let i in object) {
            copy[i] = deepCppy(object[i]);
        }
        return copy;
    } else {
        return object;
    }
}

// another way

// JSON.parse(JSON.stringify(obj));
// but not working with date