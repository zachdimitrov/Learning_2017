function solve(params) {
    const rows = +args[0],
        cols = +args[1],
        board = args.slice(2, rows + 2);
    let moves = args.slice(rows + 3)
        .map(m => {
            var parts = m.split(" ");
            return {
                fromRow: getRowIndex(parts[0][1]),
                fromCol: getColIndex(parts[0][0]),
                toRow: getRowIndex(parts[1][1]),
                toCol: getColndex(parts[1][0])
            };
        });
    moves.forEach(move => {
        let piece = moard[move.fromRow][move.fromCol];

        if (isQueen(piece)) {
            if (checkQueen(move)) {
                console.log('yes');
            } else {
                console.log('no');
            }
        } else if (isKnight(piece)) {
            if (checkKnight(move)) {
                console.log('yes');
            } else {
                console.log('no');
            }
        } else {
            console.log('no');
        }
    });

    function checkKnight(move) {

    }

    function checkQueen(move) {

    }

    function getRowIndex(rowName) {
        return rows - rowName;
    }

    function getColndex(colName) {
        let val = colName.charCodeAt(0);
        return val - 'a'.charCodeAt(0);
    }
}

solve([
    '5',
    '5',
    'Q---Q',
    '-----',
    '-B---',
    '--R--',
    'Q---Q',
    '10',
    'a1 a1',
    'a1 d4',
    'e1 b4',
    'a5 d2',
    'e5 b2',
    'b3 d5',
    'b3 a2',
    'b3 d1',
    'b3 a4',
    'c2 c5'
]);