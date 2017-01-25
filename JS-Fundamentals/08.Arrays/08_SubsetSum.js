function s(a) {
    let find = +a[0],
        arr = a.slice(1),
        result = 'no',
        sum = 0;

    console.log(arr);
    console.log(find);

    for (let i = 0, len = arr.length; i < len; i += 1) {
        for (let j = i, len = arr.length; j < len; j += 1) {
            sum += +arr[i];
            if (sum === find) {
                result = 'yes';
                return result;
            }
        }
        sum = 0;
    }
    return result;
}

// test 

console.log(s(['66', '1', '3', '6', '4', '3', '7', '11', '3', '9', '2']));
console.log(s(['21', '1', '3', '6', '4', '3', '7', '11', '3', '9', '2']));
console.log(s(['10', '1', '3', '6', '4', '3', '7', '11', '3', '9', '2']));