function solve(args) {
    let rowsCols = args[0].split(' ').map(Number);
    let rows = rowsCols[0];
    let cols = rowsCols[1];
    let maze = [];
    let start = 0;

    for (var i = 0; i < rows; i++) {
        let argsRow = args[i + 1].split(' ').map(Number);
        maze.push(argsRow);
    }
    let startRow = rows / 2 - 0.5;
    let startCol = cols / 2 - 0.5;

    let pos = { row: startRow, col: startCol };
    let lastMove;
    position = maze[pos.row][pos.col];
    let trys = 4;

    while (true) {
        let dirsRaw = position.toString(2);
        let pad = "0000";
        let directions = pad.substring(0, pad.length - dirsRaw.length) + dirsRaw;
        let dir = directions.split('').reverse();
        //console.log(dir);

        for (let d = 0; d < dir.length; d++) {
            if (dir[d] === '1') {
                if (trys === 0) {
                    console.log(`No JavaScript, only rakiya ${pos.row} ${pos.col}`);
                    return;
                }

                if (Math.abs(lastMove - d) === 2) {
                    trys--;
                    continue;
                } else {
                    trys = 4;
                }

                newRow = pos.row;
                newCol = pos.col;

                switch (d) {
                    case 0:
                        newRow--;
                        lastMove = 0;
                        break;
                    case 1:
                        newCol++;
                        lastMove = 1;
                        break;
                    case 2:
                        newRow++;
                        lastMove = 2;
                        break;
                    case 3:
                        newCol--;
                        lastMove = 3;
                        break;
                }

                pos.row = newRow;
                pos.col = newCol;

                if (pos.row === 0 || pos.row === rows.length - 1 || pos.col === 0 || pos.col === cols.length - 1) {
                    console.log(`No rakiya, only JavaScript ${pos.row} ${pos.col}`);
                    return;
                }
                position = maze[pos.row][pos.col];
                //console.log(position);
                //console.log(lastMove);
                break;
            }
        }
    }
}


// tests

solve([
    '5 7',
    '9 5 3 11 9 5 3',
    '10 11 10 12 4 3 10',
    '10 10 12 7 13 6 10',
    '12 4 3 9 5 5 2',
    '13 5 4 6 13 5 6'
]);
console.log('---------');
solve([
    '7 5',
    '9 3 11 9 3',
    '10 12 4 6 10',
    '12 3 13 1 6',
    '9 6 11 12 3',
    '10 9 6 13 6',
    '10 12 5 5 3',
    '12 5 5 5 6'
]);