function solve(args) {
    let digit = +args[0],
        result = "";

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
        default:
            result = "not a digit";
            break;
    }

    console.log(result);
}

// tests

solve(['2']);
solve(['0']);
solve(['5']);
solve(['8']);
solve(['9']);
solve(['3']);
solve(['12']);