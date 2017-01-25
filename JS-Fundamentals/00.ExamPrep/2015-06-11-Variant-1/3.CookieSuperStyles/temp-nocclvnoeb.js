function solve(args) {
    var rules = {},
        props = [],
        isInRule = false,
        noSpace = {
            '+': true,
            '>': true,
            '.': true,
            '#': true,
            '~': true,
            '}': true,
            '{': true
        };

    String.prototype.last = function() {
        return this[this.length - 1];
    };

    for (var i = 0; i < args.length; i++) {
        var line = args[i].trim();
        if (isInRule) {
            let split = line.trim();
            if (split.last() === '}') {
                isInRule = false;
            }
        } else {
            let spl = line.trim().split(/\s+/);

            let selector = '';
            for (let j = 0; j < spl.length; j++) {
                if ((selector === '') || noSpace[spl[j][0]] || noSpace[selector.last()]) {
                    selector += spl[j];
                } else {
                    selector += ' ' + spl[j];
                }
            }
            if (selector.last() === '{') {
                isInRule = true;
            }
            console.log(selector);
        }
    }
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