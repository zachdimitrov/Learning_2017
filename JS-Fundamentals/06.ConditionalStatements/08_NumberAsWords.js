function solve(args) {
    var n = +args[0],
        decimals,
        tens,
        hundreds,
        result = '';


    function digitAsWord(digit) {
        var result = "";
        switch (digit) {
            case 0:
                result = "zero";
                break;
            case 1:
                result = "one";
                break;
            case 2:
                result = "two";
                break;
            case 3:
                result = "three";
                break;
            case 4:
                result = "four";
                break;
            case 5:
                result = "five";
                break;
            case 6:
                result = "six";
                break;
            case 7:
                result = "seven";
                break;
            case 8:
                result = "eight";
                break;
            case 9:
                result = "nine";
                break;
        }
        return result;
    }

    function teenAsWord(digit) {
        var result = "";
        switch (digit) {
            case 0:
                result = "";
                break;
            case 1:
                result = "eleven";
                break;
            case 2:
                result = "twelve";
                break;
            case 3:
                result = "thirteen";
                break;
            case 4:
                result = "fourteen";
                break;
            case 5:
                result = "fifteen";
                break;
            case 6:
                result = "sixteen";
                break;
            case 7:
                result = "seventeen";
                break;
            case 8:
                result = "eighteen";
                break;
            case 9:
                result = "nineteen";
                break;
        }
        return result;
    }

    function tensAsWords(digit) {
        var result = "";
        switch (digit) {
            case 0:
                result = "";
                break;
            case 1:
                result = "ten";
                break;
            case 2:
                result = "twenty";
                break;
            case 3:
                result = "thirty";
                break;
            case 4:
                result = "forty";
                break;
            case 5:
                result = "fifty";
                break;
            case 6:
                result = "sixty";
                break;
            case 7:
                result = "seventy";
                break;
            case 8:
                result = "eighty";
                break;
            case 9:
                result = "ninety";
                break;
        }
        return result;
    }

    decimals = n % 10;

    if (n >= 100) {
        hundreds = Math.floor(n / 100) % 10;
        result += digitAsWord(hundreds) + ' hundred';
    }
    if (n >= 10) {
        tens = Math.floor(n / 10) % 10;
        if ((tens > 1) || (tens === 1 && decimals === 0)) {
            if (n > 100) {
                result += ' and ';
            }
            result += tensAsWords(tens);
            if (decimals > 0) {
                result += ' ' + digitAsWord(decimals);
            }
        } else if (tens === 1 && decimals > 0) {
            if (n > 100) {
                result += ' and ';
            }
            result += teenAsWord(decimals);
        } else if (tens === 0 && decimals > 0) {
            result += ' and ' + digitAsWord(decimals);
        }
    } else {
        result = digitAsWord(decimals);
    }

    return result.charAt(0).toUpperCase() + result.slice(1);
}

// Tests

console.log(solve(["0"]));
console.log('Zero');
console.log(solve(["9"]));
console.log('Nine');
console.log(solve(["10"]));
console.log('Ten');
console.log(solve(["12"]));
console.log('Twelve');
console.log(solve(["19"]));
console.log('Nineteen');
console.log(solve(["25"]));
console.log('Twenty five');
console.log(solve(["98"]));
console.log('Ninety eight');
console.log(solve(["273"]));
console.log('Two hundred and seventy three');
console.log(solve(["400"]));
console.log('Four hundred');
console.log(solve(["501"]));
console.log('Five hundred and one');
console.log(solve(["617"]));
console.log('Six hundred and seventeen');
console.log(solve(["711"]));
console.log('Seven hundred and eleven');
console.log(solve(["999"]));
console.log('Nine hundred and ninety nine');