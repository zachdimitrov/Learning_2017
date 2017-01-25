/*
function solve1(args) {
    var text = args[0],
        symb = args[0].split(''),
        res = [],
        exp = [],
        isTag = false,
        isEndTag = false,
        count = 0,
        result = '';

    exp[count] = {};
    exp[count].tag = '';

    for (let i = 0, len = symb.length; i < len; i += 1) {
        if (symb[i] === '<') {
            isTag = true;
            if (symb[i + 1] === '/') {
                isEndTag = true;
                exp[count].endIndex = i;
                i++;
            }
            i++;
        }
        if (symb[i] === '>') {
            isTag = false;
            if (!isEndTag) {
                exp[count].startIndex = i + 1;
            }
            if (isEndTag) {
                isEndTag = false;
                count++;
                exp[count] = {};
                exp[count].tag = '';
            }
            i++;
        }
        if (!isTag && !isEndTag) {
            res.push(symb[i]);
        }
        if (isTag && !isEndTag) {
            exp[count].tag += symb[i];
        }
    }

    for (let i in exp) {
        let t = exp[i].tag,
            start = exp[i].startIndex,
            end = exp[i].endIndex;

        if (t === '') {
            break;
        }

        for (var k = start; k < end; k++) {
            switch (t) {
                case 'upcase':
                    symb[k] = symb[k].toUpperCase();
                    break;
                case 'lowcase':
                    symb[k] = symb[k].toLowerCase();
                    break;
                default:
                    break;
            }
        }
    }

    isTag = false;
    isEndTag = false;

    for (let i = 0, len = symb.length; i < len; i += 1) {
        if (symb[i] === '<') {
            isTag = true;
            if (symb[i + 1] === '/') {
                isEndTag = true;
                i++;
            }
            i++;
        }
        if (symb[i] === '>') {
            isTag = false;
            if (isEndTag) {
                isEndTag = false;
            }
            i++;
        }
        if (!isTag && !isEndTag) {
            result += symb[i];
        }
    }

    //console.log(text);
    //console.log(exp);
    console.log(result);
}

// Solution 2

function solve2(args) {
    var text = args[0],
        arr = text.split(/[<>]/);

    arr = arr.filter(x => x !== '');
    for (let i = 0, len = arr.length; i < len; i += 1) {
        if (arr[i] === 'orgcase' || arr[i] === '/orgcase') {
            arr.splice(i, 1);
            i--;
        }
        if (arr[i] === 'upcase') {
            let h = i + 1;
            while (arr[h] !== '/upcase') {
                if (arr[h] !== 'orgcase' &&
                    arr[h] !== '/orgcase' &&
                    arr[h] !== 'lowcase' &&
                    arr[h] !== '/lowcase') {
                    arr[h] = arr[h].toUpperCase();
                }
                h++;
            }
            arr.splice(i, 1);
            i--;
        }
        if (arr[i] === '/upcase') {
            arr.splice(i, 1);
            i--;
        }

        if (arr[i] === 'lowcase') {
            let h = i + 1;
            while (arr[h] !== '/lowcase') {
                if (arr[h] !== 'orgcase' &&
                    arr[h] !== '/orgcase' &&
                    arr[h] !== 'upcase' &&
                    arr[h] !== '/upcase') {
                    arr[h] = arr[h].toLowerCase();
                }
                h++;
            }
            arr.splice(i, 1);
            i--;
        }
        if (arr[i] === '/lowcase') {
            arr.splice(i, 1);
            i--;
        }
    }
    console.log(arr.join(''));
}

// Solution 3

function solve3(args) {
    var text = args[0],
        len = text.length,
        res = '';

    for (i = 0; i < len; i++) {
        if (text[i] === '<') {
            if (text[i + 1] === 'u') {
                i += 8;
                while (text[i] !== '<') {
                    res += text[i].toUpperCase();
                    i++;
                }
                if (text[i + 1] === '/' && text[i + 2] === 'u') {
                    i += 8;
                }
            }
            if (text[i + 1] === 'l') {
                i += 9;
                while (text[i] !== '<') {
                    res += text[i].toLowerCase();
                    i++;
                }
                if (text[i + 1] === '/' && text[i + 2] === 'l') {
                    i += 9;
                }
            }
            if (text[i + 1] === 'o') {
                i += 9;
                while (text[i] !== '<') {
                    res += text[i];
                    i++;
                }
                if (text[i + 1] === '/' && text[i + 2] === 'o') {
                    i += 9;
                }
            }
        } else {
            res += text[i];
        }
    }
    console.log(res);
}
*/

// Solution 4 WORKING

function solve(args) {
    var t = args[0],
        res = '',
        oper = [];

    for (let i = 0, len = t.length; i < len; i += 1) {
        if (t[i] === '<') {
            if (t[i + 1] === 'o') {
                oper.push('o');
                i += 8;
            } else if (t[i + 1] === 'u') {
                oper.push('u');
                i += 7;
            } else if (t[i + 1] === 'l') {
                oper.push('l');
                i += 8;
            } else if (t[i + 1] === '/' && t[i + 2] === 'o') {
                oper.pop();
                i += 9;
            } else if (t[i + 1] === '/' && t[i + 2] === 'u') {
                oper.pop();
                i += 8;
            } else if (t[i + 1] === '/' && t[i + 2] === 'l') {
                oper.pop();
                i += 9;
            }

        } else {
            let o = oper[oper.length - 1];
            if (o === 'u') {
                res += t[i].toUpperCase();
            } else if (o === 'l') {
                res += t[i].toLowerCase();
            } else if (o === 'o') {
                res += t[i];
            } else {
                res += t[i];
            }
        }
    }
    console.log(res);
}

// test

solve(['We are <orgcase>liViNg</orgcase> in a <upcase>yellow submarine</upcase>. We <orgcase>doN\'t</orgcase> have <lowcase>anything</lowcase> else.']);

solve(['Hello <lowcase>this is just a <upcase>test for the <orgcase>prGGGram</orgcase> i wrote</upcase> NoW </lowcase>']);