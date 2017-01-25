function solve(args) {
    let result = args.map(function(line) {
            let indexOfCurly = line.indexOf('{');
            if (indexOfCurly === -1) {
                return line.replace(/\s/g, '');
            }
            let selectors = line.substr(0, indexOfCurly).trim();
            selectors = selectors
                .replace(/\s*([>~+ ])\s/g, '$1');

            return selectors + '{';
        }).join('')
        .replace(/;}/g, '}');

    console.log(result);
}

// tests

solve([
    '#the-big-b{',
    ' color: yellow;',
    ' size: big;',
    '}',
    '.muppet{',
    ' powers: all;',
    ' skin: fluffy;',
    '}',
    '  .water-spirit {',
    ' powers: water;',
    '      alignment : not-good;',
    '}',
    'all{',
    ' meant-for: nerdy-children;',
    '}',
    '.muppet {',
    '   powers: everything;',
    '}',
    'all  .muppet {',
    ' alignment : good ;',
    '}',
    '.muppet+ .water-spirit{',
    ' power: everything-a-muppet-can-do-and-water;',
    '}'
]);