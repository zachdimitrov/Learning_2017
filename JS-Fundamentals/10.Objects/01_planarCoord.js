function solve(args) {
    let L1 = {
            A: {
                x: +args[0],
                y: +args[1]
            },
            B: {
                x: +args[2],
                y: +args[3]
            }
        },
        L2 = {
            A: {
                x: +args[4],
                y: +args[5]
            },
            B: {
                x: +args[6],
                y: +args[7]
            }
        },
        L3 = {
            A: {
                x: +args[8],
                y: +args[9]
            },
            B: {
                x: +args[10],
                y: +args[11]
            }
        },
        len1, len2, len3;

    function getLength(L) {
        return Math.sqrt((L.A.x - L.B.x) * (L.A.x - L.B.x) + (L.A.y - L.B.y) * (L.A.y - L.B.y));
    }

    len1 = getLength(L1);
    len2 = getLength(L2);
    len3 = getLength(L3);

    console.log(len1.toFixed(2));
    console.log(len2.toFixed(2));
    console.log(len3.toFixed(2));

    if (len1 + len2 > len3 && len1 + len3 > len2 && len2 + len3 > len1) {
        console.log('Triangle can be built');
    } else {
        console.log('Triangle can not be built');
    }
}

// tests

solve([
    '5', '6', '7', '8',
    '1', '2', '3', '4',
    '9', '10', '11', '12'
]);

solve([
    '7', '7', '2', '2',
    '5', '6', '2', '2',
    '95', '-14.5', '0', '-0.123'
]);