function solve(args) {
    let res = '',
        intag = false;

    for (let i in args) {
        let line = args[i].trim();
        for (let j = 0, len = line.length; j < len; j += 1) {
            if (line[j] == '<') {
                intag = true;
            }
            if (line[j - 1] == '>') {
                intag = false;
            }
            if (!intag) {
                res += line[j];
            }
        }
        intag = false;
    }
    console.log(res);
}

// test

solve([
    '<html>',
    '  <head>',
    '    <title>Sample site</title>',
    '  </head>',
    '  <body>',
    '    <div>text',
    '      <div>more text</div>',
    '      and more...',
    '    </div>',
    '    in body',
    '  </body>',
    '</html>'
]);