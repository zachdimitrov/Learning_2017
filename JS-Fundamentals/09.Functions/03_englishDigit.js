function solve(args) {
    var n = +args[0];

    function digitInEnglish(d) {
        var word = '',
            last = d % 10;

        switch (last) {
            case 0:
                word = 'zero';
                break;
            case 1:
                word = 'one';
                break;
            case 2:
                word = 'two';
                break;
            case 3:
                word = 'three';
                break;
            case 4:
                word = 'four';
                break;
            case 5:
                word = 'five';
                break;
            case 6:
                word = 'six';
                break;
            case 7:
                word = 'seven';
                break;
            case 8:
                word = 'eight';
                break;
            case 9:
                word = 'nine';
                break;
        }

        return word;
    }

    console.log(digitInEnglish(args));
}

// tests

solve(['42']);
solve(['98']);