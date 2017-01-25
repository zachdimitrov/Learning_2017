function solve(args) {
    var rules = {},
        props = [],
        isInRule = false,
        orderIn = 0,
        currentSelector = null,
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
    Array.prototype.last = function() {
        return this[this.length - 1];
    };

    for (var i = 0; i < args.length; i++) {
        var line = args[i].trim();
        if (isInRule) {
            let split = line.replace(/\s+/g, '').split(':');

            if (split.last() === '}') {
                isInRule = false;
            } else {
                let property = { name: split[0], value: split[1].replace(';', '') };
                let properties = rules[currentSelector].props;
                for (let k = 0; k < properties.length; k += 1) {
                    if (properties[k].name === property.name) {
                        properties.splice(k, 1);
                        break;
                    }
                }
                properties.push(property);
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
                if (!rules[selector]) {
                    rules[selector] = {
                        props: [],
                        order: orderIn
                    };
                    orderIn++;
                }
                currentSelector = selector;
            }
            //console.log(selector);
        }
    }
    let ordered = [];


    for (const propName in rules) {
        let properties = rules[propName]
            .props
            .map(nvp => nvp.name + ':' + nvp.value)
            .join(';');

        let finishedSelector = propName + properties + '}';
        //console.log(finishedSelector);

        let index = rules[propName].order;
        ordered[index] = finishedSelector;
    }
    console.log(ordered.join(''));
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
    '#trene all{',
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