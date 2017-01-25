function solve(args) {
    const EMPTY = '-',
        DEBRI = 'x',
        dir = {
            u: [-1, 0],
            d: [1, 0],
            l: [0, -1],
            r: [0, 1]
        };
    let rowsCols = args[0].split(' '),
        rows = rowsCols[0],
        cols = rowsCols[1],
        debris = args[1].split(';'),
        commands = args.slice(3),
        field = [],
        tanks = [],
        usedTanks = {
            koceto: 4,
            cuki: 4
        };

    for (let i = 0; i < rows; i++) {
        field[i] = [];
        for (let j = 0; j < cols; j++) {
            field[i][j] = EMPTY;
        }
    }

    tanks[0] = { row: 0, col: 0 };
    tanks[1] = { row: 0, col: 1 };
    tanks[2] = { row: 0, col: 2 };
    tanks[3] = { row: 0, col: 3 };
    tanks[4] = { row: rows - 1, col: cols - 1 };
    tanks[5] = { row: rows - 1, col: cols - 2 };
    tanks[6] = { row: rows - 1, col: cols - 3 };
    tanks[7] = { row: rows - 1, col: cols - 4 };

    for (let tank in tanks) {
        field[tanks[tank].row][tanks[tank].col] = tank;
    }

    for (let deb in debris) {
        let d = debris[deb].split(' ');
        field[+d[0]][+d[1]] = DEBRI;

    }

    for (var com in commands) {
        let c = commands[com].split(' ');
        if (c[0] === 'mv') {
            moveTank(+c[1], +c[2], c[3]);
        } else if (c[0] === 'x') {
            shootWithTank(+c[1], c[2]);
        }
    }

    if (usedTanks.koceto === 0) {
        console.log('Koceto is gg');
    }
    if (usedTanks.cuki === 0) {
        console.log('Cuki is gg');
    }

    function moveTank(id, times, drn) {
        let tankRow = tanks[id].row,
            tankColumn = tanks[id].col,
            deltaRow = dir[drn][0],
            deltaCol = dir[drn][1];

        field[tankRow][tankColumn] = EMPTY;

        while (times > 0) {
            let newRow = tankRow + deltaRow;
            let newCol = tankColumn + deltaCol;
            if (newRow < 0 || newRow >= rows || newCol < 0 || newCol >= cols) {
                break;
            }
            if (field[newRow][newCol] !== EMPTY) {
                break;
            }
            tankRow = newRow;
            tankColumn = newCol;
            times--;
        }

        tanks[id].row = tankRow;
        tanks[id].col = tankColumn;
        field[tankRow][tankColumn] = id;
    }

    function shootWithTank(id, drn) {
        let shotRow = tanks[id].row,
            shotCol = tanks[id].col,
            deltaRow = dir[drn][0],
            deltaCol = dir[drn][1],
            newRow = shotRow + deltaRow,
            newCol = shotCol + deltaCol;

        while (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols) {
            if (field[newRow][newCol] === DEBRI) {
                field[newRow][newCol] = EMPTY;
                break;
            } else if (field[newRow][newCol] === EMPTY) {
                newRow += deltaRow;
                newCol += deltaCol;
            } else {
                let killedTank = field[newRow][newCol];
                console.log(`Tank ${killedTank} is gg`);
                field[newRow][newCol] = EMPTY;
                if (killedTank < 4) {
                    usedTanks.koceto--;
                } else {
                    usedTanks.cuki--;
                }
                break;
            }
        }
    }
}

// Tests

console.log('----------- TEST 1 ----------');

solve([
    '5 5',
    '2 0;2 1;2 2;2 3;2 4',
    '13',
    'mv 7 2 l',
    'x 7 u',
    'x 0 d',
    'x 6 u',
    'x 5 u',
    'x 2 d',
    'x 3 d',
    'mv 4 1 u',
    'mv 4 4 l',
    'mv 1 1 l',
    'x 4 u',
    'mv 4 2 r',
    'x 2 d'
]);
console.log('===== output 1 =====');

console.log(`Tank 7 is gg
Tank 6 is gg
Tank 5 is gg
Tank 0 is gg
Tank 4 is gg
Cuki is gg`);

console.log('----------- TEST 2 ----------');

solve([
    '10 10',
    '1 0;1 1;1 2;1 3;1 4;4 1;4 2;4 3;4 4',
    '8',
    'mv 4 9 u',
    'x 4 l',
    'x 4 l',
    'x 4 l',
    'x 0 r',
    'mv 0 9 r',
    'mv 5 1 r',
    'x 5 u'
]);

console.log('===== output 2 =====');

console.log(`Tank 3 is gg
Tank 2 is gg
Tank 1 is gg
Tank 4 is gg
Tank 0 is gg
Koceto is gg`);

console.log('----------- TEST 3 ----------');

solve([
    '10 5',
    '1 0;1 1;1 2;1 3;1 4;3 1;3 3;4 0;4 2;4 4',
    '43',
    'mv 6 5 r',
    'mv 0 6 d',
    'x 0 d',
    'x 0 d',
    'x 6 u',
    'x 6 u',
    'x 6 u',
    'x 6 u',
    'x 6 u',
    'x 7 u',
    'x 7 u',
    'x 7 u',
    'x 7 u',
    'x 7 u',
    'x 3 d',
    'x 3 d',
    'x 3 d',
    'x 3 d',
    'x 3 d',
    'x 4 u',
    'x 4 u',
    'x 4 u',
    'x 4 u',
    'x 4 u',
    'x 0 r',
    'mv 0 6 d',
    'mv 0 9 r',
    'x 0 d',
    'mv 0 1 l',
    'x 0 d',
    'mv 0 1 l',
    'x 0 d',
    'mv 0 1 l',
    'x 0 d',
    'mv 0 1 l',
    'x 0 d',
    'mv 0 1 l',
    'x 0 d',
    'mv 0 1 l',
    'x 0 d',
    'mv 0 1 l',
    'x 0 d',
    'mv 0 1 l',
    'x 0 d'
]);

console.log('===== output 3 =====');

console.log(`Tank 2 is gg
Tank 1 is gg
Tank 5 is gg
Tank 3 is gg
Tank 4 is gg
Tank 6 is gg
Tank 7 is gg
Cuki is gg`);