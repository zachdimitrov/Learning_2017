function solve(args) {
    let rowsCols = args[0].split(' '),
        rows = +rowsCols[0],
        cols = +rowsCols[1],
        debriCoords = args[1].split(';'),
        commands = args.slice(3),
        debris = [],
        tanks = [],
        dir = {
            u: [-1, 0],
            d: [1, 0],
            l: [0, -1],
            r: [0, 1]
        },
        field = [];

    for (let f = 0; f < rows; f++) {
        field[f] = [];
        for (let ff = 0; ff < cols; ff++) {
            field[f][ff] = ' ';
        }
    }


    // create Koceto tanks
    for (let j = 0; j < 4; j++) {
        tanks[j] = { row: 0, col: j };
        field[0][j] = j;
    }

    // create Cuki tanks
    for (let j = cols - 1; j > cols - 5; j--) {
        tanks[cols - j + 3] = { row: rows - 1, col: j };
        field[rows - 1][j] = cols - j + 3;
    }

    // create debris
    for (d = 0; d < debriCoords.length; d++) {
        let deb = debriCoords[d].split(' ').map(Number);
        let singleDebri = { row: deb[0], col: deb[1] };
        let used = false;
        for (let dii in debris) {
            if (debris[dii].row === singleDebri.row && debris[dii].col === singleDebri.col) {
                used = true;
                break;
            }
        }
        if (!used) {
            debris.push(singleDebri);
        }
        field[deb[0]][deb[1]] = 'x';
    }
    console.log(debris);
    // initiate commands
    for (let c in commands) {
        com = commands[c].split(' ');
        if (com[0] === 'mv') {
            //console.log(com);
            //console.log(dir[com[3]]);
            //console.log('M ' + com[1] + ': ' + tanks[com[1]].row + '-' + tanks[com[1]].col);
            tanks[com[1]] = move(tanks[+com[1]], com[2], com[3]);
            //console.log('     ' + tanks[com[1]].row + '-' + tanks[com[1]].col);
        } else if (com[0] === 'x') {
            //console.log('S-' + com[1] + ': ' + tanks[com[1]].row + '-' + tanks[com[1]].col);
            shootWithTank(tanks[+com[1]], com[2]);
        }
        //printField(field);
        //console.log('-----------------------------------------------------');
    }

    // all tanks of Koceto killed
    if (!tanks['0'] && !tanks['1'] && !tanks['2'] && !tanks['3']) {
        console.log('Koceto is gg');
    }

    // all tanks of Cuki killed
    if (!tanks['4'] && !tanks['5'] && !tanks['6'] && !tanks['7']) {
        console.log('Cuki is gg');
    }

    // move tank
    function move(tk, tm, d) {
        let t = {},
            times = +tm;
        t.row = tk.row;
        t.col = tk.col;
        while (times > 0) {
            t.row += dir[d][0];
            t.col += dir[d][1];
            if (t.row >= rows || t.row < 0 || t.col >= cols || t.col < 0) {
                break;
            } else if (collide(t, tanks)) {
                break;
            } else if (collide(t, debris)) {
                break;
            }
            times--;
        }
        field[tk.row][tk.col] = ' ';
        tk.row = t.row;
        tk.col = t.col;
        field[tk.row][tk.col] = tanks.indexOf(tk);
        return tk;
    }

    // shoot With Tank
    function shootWithTank(tank, d) {
        let proj = {};
        let coor = dir[d],
            di, t;
        proj.row = tank.row;
        proj.col = tank.col;
        while (true) {
            proj.row += coor[0];
            proj.col += coor[1];
            if (proj.row >= rows || proj.row < 0 || proj.col >= cols || proj.col < 0) {
                break;
            } else if (collide(proj, debris)) {
                di = collide(proj, debris);
                //console.log(di);
                //console.log(debris[di]);
                field[debris[di].row][debris[di].col] = ' ';
                debris[di].row = -1;
                debris[di].col = -1;
                //console.log(debris[di]);
                break;
            } else if (collide(proj, tanks)) {
                t = collide(proj, tanks);
                field[tanks[t].row][tanks[t].col] = ' ';
                tanks[t].row = -1;
                tanks[t].col = -1;
                console.log('Tank ' + t + ' is gg');
                break;
            }
        }
    }

    // collide 2 objects
    function collide(p, t) {
        for (let i in t) {
            if (p.row === t[i].row && p.col === t[i].col) {
                return i;
            }
        }
    }

    // print matrix
    function printField(m) {
        for (let i in m) {
            let line = '| ';
            for (let j in m[i]) {
                line += m[i][j] + ' | ';
            }
            console.log(line);
        }
    }
    // TESTS REMOVE BEFORE UPLOAD
    //console.log(debris);
    //console.log(tanks);
}

// tests 
/*
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
*/

console.log('----------- TEST 4 ----------');

solve(['35 20',
    '15 0;19 3;22 4;19 13;20 13;12 19;33 16;24 1;2 6;10 17;17 7;12 9;3 8;11 18;16 5;12 3;4 17;33 17;14 2;20 6;19 13;31 8;4 18;27 13;30 10;18 3;29 9;7 1;24 1;3 4;31 12;7 5;11 3;30 1;28 17;23 18;24 19;12 16;16 18;12 2;21 13;2 18;26 3;11 12;23 18;6 6;1 7;14 18;16 12;4 18;2 14;28 0;29 11;16 18;6 7;20 16;25 19;21 5;20 5;18 3;29 5;14 17;23 7;31 6;19 8;13 17;26 8;3 17;28 19;3 3;23 7;15 6;12 6;19 1;26 2;11 4;3 18;3 14;11 18;12 9;23 2;12 14;33 14;1 6;29 14;15 12;7 6;17 9;28 1;18 6;28 17;19 8;3 3;26 16;12 7;20 17;22 12;17 10;2 14;11 12;11 4;7 1;24 14;1 14;15 12;30 4;14 0;21 16;20 18;22 16;32 3;33 10;5 10;33 11;28 19;14 2;25 17;1 12;22 10;25 7;5 0;13 14;16 6;16 12;33 13;32 2;2 9;23 2;8 13;31 3;25 8;31 9;6 15;17 10;33 19;6 1;6 6;23 18;27 5;2 15;3 6;20 2;1 5;4 5;8 17;14 19;20 11;21 14;4 18;19 14;29 18;22 19;18 17;33 14;27 14;12 19;21 2;4 8;28 15;16 18;22 4;11 2;20 3;16 12;23 19;28 17;24 6;32 2;23 11;20 2;10 6;15 9;18 8;12 9;16 4;29 6;15 13;2 12;21 10;14 7;14 7;2 16;31 9;9 5;7 19;24 4;7 6;20 6;26 16;20 3;28 19;5 9;4 9;15 0;11 6;17 3;7 4;24 18;10 12;19 0;6 1;10 9;16 12;5 1;2 14;28 15;31 4;18 8;8 11;25 8;1 4;33 17;16 11;2 18;21 13;1 3;10 10;33 15;24 13;1 9;12 7;33 11;16 14;8 18;24 5;24 14;29 2;2 19;3 8;1 18;20 4;16 7;24 13;17 7;10 14;24 10;19 5;3 13;8 8;14 15;11 1;8 6;32 6;10 2;17 0;24 5;23 1;30 2;30 12;29 15;7 16;23 19;19 3;6 11;3 7;24 13;1 4;20 9;33 2;15 7;13 7;29 5;1 8;29 9;13 18;25 12;18 12;19 9;15 4;26 15;5 13;2 2;10 0;9 8;17 8;6 15;7 9;14 16;32 8;32 2;10 13;8 2;21 2;5 8;23 1;2 14;12 13;9 13;11 14;33 19;7 8;33 19;26 19;15 1;7 14;18 0;9 12;16 9;16 18;17 3;30 16;25 7;13 8;14 10;8 14;17 4;15 19;31 16;23 5;12 13;23 1;8 18;19 0;16 14;6 15;7 7;9 15;4 7;24 12;20 7;19 17;28 9;8 6;19 5;24 12;27 4;20 16;17 15;21 16;28 6;32 13;12 8;17 2;32 13;30 11;5 1;23 19;4 15;9 14;24 4;16 3;1 10;33 19;27 8;10 6;26 18;26 5;13 17;18 7;33 2;13 18;14 2;16 14;18 11;24 14;18 17;4 11;29 15;23 16;16 10;11 10;13 11;27 4;10 8;21 5;9 17;25 11;29 11;26 17;3 4;16 4;24 11;26 17;27 3;14 12;6 14;30 9;28 16;18 16;11 4;15 2;33 8;16 12;4 10;25 6;1 15;25 4;2 1;27 16;27 18;15 2;33 0;3 10;33 5;26 0;1 18;19 16;26 6;9 5;3 3;26 5;15 2;20 7;32 13;14 14;2 14;2 8;27 6;5 19;12 18;22 16;25 14;10 1;8 18;15 14;28 10;25 12;5 2;23 17;14 13;19 6;29 0;33 5;31 2;2 8;6 5;30 2;17 18;18 14;28 10;6 0;8 13;30 9;33 7;9 12;23 5;19 13;13 6;32 14;26 0;6 1;30 0;18 11;21 11;5 4;21 19;2 17;19 10;4 3;5 9;10 10;29 7;26 18;24 4;26 3;33 16;31 16;12 1;5 4;5 6;29 7;9 0;2 14;8 13;4 16;8 15;21 5;24 12;8 10;9 12;29 7;28 18;9 16;2 4;18 9;13 17;1 15;21 17;9 16;12 1;23 0;5 18;32 3;7 13;3 14;28 12;32 10;16 9;19 6;27 4;23 19;6 12;15 7;25 16;22 16;13 8;5 3;32 16;9 18;33 1;20 7;6 16;22 14;31 10;11 3;12 19;1 2;13 14;29 10;16 12;15 7;33 5;12 8;17 15;19 12;8 13;11 15;21 5;27 7;32 13;15 4;17 10;16 8;13 0;28 4;33 14;14 7;21 4;13 17;15 4;9 3;32 13;31 13;22 5;17 1;31 9;19 15;6 3;29 9;26 19;2 9;31 7;21 9;8 18;5 7;30 18;31 14;15 5;10 16;20 15;25 2;18 14;11 10;6 12;8 8;12 18;4 9;6 15;8 11;3 8;15 14;5 2;6 19;20 16;12 18;30 1;30 19;7 18;31 3;2 2;11 12;23 14;2 0;28 8;19 13;2 14;25 2;12 19;33 8;20 6;31 7;10 6;18 5;1 2;10 5;29 0;18 19;5 16;2 8;3 3;6 3;9 13;29 3;11 15;21 4;31 10;21 14;7 19;10 7;7 14;33 14;5 6;27 0;6 15;1 10;32 11;12 8;5 15;3 12;16 6;33 4;16 1;11 7;14 16;26 3;18 13;8 6;6 9;2 19;30 16;1 11;25 2;9 7;5 4;20 8;29 13;31 17;26 15;8 1;33 8;21 7;33 16;32 5;13 0;9 13;25 2;24 12;11 8;16 7;27 19;8 4;8 7;11 17;25 7;19 8;9 19;33 9;8 13;19 18;6 19;33 2;32 18;23 14;33 5;19 7;10 17;8 0;7 8;5 12;18 2;18 0;16 16;14 14;5 5;15 12;29 11;7 16;33 2;9 6;22 11;29 9;27 4;5 7;25 19;9 16;18 18;13 0;16 19;22 2;17 18;20 14;28 18;17 14;22 8;2 2;6 16;33 19;8 0;8 4;24 0;33 3;33 12;4 18;6 3;13 19;16 2;27 14;32 2;22 17;24 8',
    '190',
    'mv 7 14 l',
    'mv 6 7 l',
    'mv 5 3 l',
    'mv 3 15 r',
    'mv 2 11 r',
    'mv 2 2 d',
    'mv 1 5 r',
    'x 6 u',
    'x 6 u',
    'x 6 u',
    'x 6 u',
    'x 6 u',
    'mv 6 9 u',
    'mv 6 3 u',
    'mv 6 3 u',
    'mv 6 3 u',
    'mv 6 3 u',
    'mv 6 3 u',
    'mv 7 6 u',
    'x 7 u',
    'x 7 u',
    'mv 7 6 u',
    'x 7 r',
    'mv 7 8 r',
    'x 5 u',
    'mv 5 7 u',
    'x 3 d',
    'x 3 d',
    'x 3 d',
    'x 3 d',
    'x 3 d',
    'x 3 d',
    'x 3 d',
    'x 3 d',
    'x 3 d',
    'x 3 d',
    'x 3 d',
    'x 3 d',
    'x 3 d',
    'x 3 d',
    'x 3 d',
    'x 3 d',
    'x 3 d',
    'x 3 d',
    'x 3 d',
    'x 3 d',
    'x 3 d',
    'x 3 d',
    'x 3 d',
    'x 3 d',
    'x 3 d',
    'x 3 d',
    'x 3 d',
    'mv 4 1 l',
    'x 3 d',
    'x 5 u',
    'x 5 u',
    'mv 5 3 u',
    'x 5 l',
    'x 5 l',
    'mv 5 4 l',
    'x 5 u',
    'x 5 u',
    'mv 5 3 u',
    'x 1 d',
    'x 1 d',
    'x 1 d',
    'mv 1 21 d',
    'x 0 d',
    'x 0 d',
    'x 0 d',
    'x 0 d',
    'x 0 d',
    'x 0 d',
    'mv 0 21 d',
    'x 7 r',
    'mv 7 1 r',
    'mv 7 2 u',
    'x 7 u',
    'x 7 u',
    'x 7 u',
    'mv 7 4 u',
    'x 0 d',
    'mv 0 9 d',
    'mv 0 4 r',
    'x 0 d',
    'x 0 d',
    'x 0 d',
    'x 0 d',
    'x 0 d',
    'x 0 d',
    'x 0 d',
    'x 0 d',
    'x 0 d',
    'x 0 d',
    'mv 7 1 l',
    'x 7 u',
    'x 1 d',
    'x 1 d',
    'x 1 d',
    'x 1 d',
    'x 1 d',
    'x 1 d',
    'mv 1 22 d',
    'x 1 r',
    'mv 1 1 r',
    'x 1 d',
    'mv 1 1 d',
    'x 1 l',
    'mv 1 1 l',
    'x 1 d',
    'mv 1 1 d',
    'x 1 r',
    'mv 1 1 r',
    'mv 1 1 u',
    'mv 1 1 l',
    'mv 1 1 d',
    'mv 1 1 r',
    'mv 1 1 u',
    'mv 1 1 l',
    'mv 1 1 d',
    'mv 1 1 r',
    'mv 1 1 u',
    'mv 1 1 l',
    'mv 1 1 d',
    'mv 1 1 r',
    'mv 1 1 u',
    'mv 1 1 l',
    'x 1 d',
    'x 1 d',
    'x 1 d',
    'x 1 d',
    'x 1 d',
    'x 1 d',
    'x 1 d',
    'x 1 d',
    'x 1 d',
    'x 1 d',
    'x 1 r',
    'x 1 r',
    'x 1 r',
    'x 1 r',
    'x 1 r',
    'x 1 r',
    'x 1 r',
    'x 1 r',
    'x 1 l',
    'x 1 l',
    'x 1 l',
    'x 1 l',
    'x 1 l',
    'mv 1 16 d',
    'mv 7 2 r',
    'x 7 d',
    'x 6 u',
    'x 6 r',
    'x 6 l',
    'x 6 d',
    'mv 6 4 u',
    'x 5 u',
    'mv 5 1 u',
    'mv 5 1 l',
    'x 6 u',
    'x 6 u',
    'mv 3 23 d',
    'mv 6 2 u',
    'x 3 l',
    'x 3 l',
    'x 3 l',
    'x 6 r',
    'mv 6 2 r',
    'x 6 u',
    'x 6 u',
    'x 6 u',
    'x 6 u',
    'mv 6 1 r',
    'x 6 u',
    'x 6 u',
    'x 6 u',
    'x 6 u',
    'x 6 u',
    'x 6 u',
    'x 6 u',
    'x 6 u',
    'x 6 u',
    'x 6 u',
    'x 6 u',
    'x 6 u',
    'x 6 u',
    'x 6 u'
]);
console.log('===== output 3 =====');
console.log(`Tank 4 is gg
Tank 0 is gg
Tank 1 is gg
Tank 5 is gg
Tank 3 is gg
Tank 2 is gg
Koceto is gg`);