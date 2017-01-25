// simple solution
function solve1(args) {
    console.log(args[0].split("").reverse().join(""));
}

// complex, finds if two consequal chars are large codes and does not reverse them
function solve(args) {
    var str = args[0].split(''),
        chars = [],
        notRev = {},
        result = [],
        keys;

    str.forEach(a => {
        chars.push(a.charCodeAt(0));
    });

    chars = chars.reverse();

    for (let i = 0, len = chars.length; i < len; i += 1) {
        if (chars[i] > 1024) {
            notRev[i] = chars[i];
        }
    }

    keys = Object.keys(notRev).map(Number);

    for (let k = 1, len = keys.length; k < len; k += 1) {
        if (keys[k] - keys[k - 1] === 1) {
            let temp = chars[keys[k - 1]];
            chars[keys[k - 1]] = chars[keys[k]];
            chars[keys[k]] = temp;
        }
    }

    chars.forEach(a => {
        result.push(String.fromCharCode(a));
    });

    console.log(result.join(''));
}

//solve(['abcde']);
//solve(['12345ABCDE9']);
solve(['foo 𝌆 bar mañana mañana']);
solve1(['foo 𝌆 bar mañana mañana']);