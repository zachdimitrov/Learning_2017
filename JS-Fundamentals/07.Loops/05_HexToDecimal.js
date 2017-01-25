function s(a) {
    var h = a[0],
        k,
        digit = 1,
        mul = 1,
        result = 0;

    for (var i = h.length - 1; i >= 0; i -= 1) {
        k = h[i];
        switch (k) {
            case 'A':
                digit = 10;
                break;
            case 'B':
                digit = 11;
                break;
            case 'C':
                digit = 12;
                break;
            case 'D':
                digit = 13;
                break;
            case 'E':
                digit = 14;
                break;
            case 'F':
                digit = 15;
                break;
            default:
                digit = +k;
                break;
        }

        result += digit * mul;
        mul *= 16;
    }

    console.log(result);
}

// tests

s(['FE']);
console.log(254);
s(['1AE3']);
console.log(6883);
s(['4ED528CBB4']);
console.log(338583669684);