function solve(args) {
    var dataFile = JSON.parse(args[0]),
        template = args[1],
        result = '',
        bobj = [],
        cont = {};

    var binds = template.match(/(data-bind-)(\w+)(=")\w+"/g);

    for (var g in binds) {
        var e = binds[g];
        var ind = e.indexOf('=');
        var part = {};

        part.property = e.substring(10, ind);
        part.value = e.split('"')[e.split('"').length - 2];
        bobj.push(part);
    }
    var parts = template.split("></");

    result += parts[0];
    for (var j in bobj) {
        for (var i in dataFile) {
            if (i === bobj[j].value && bobj[j].property !== 'content') {
                result += ' ' + bobj[j].property + '="' + dataFile[i] + '"';
            }
            if (bobj[j].property === 'content') {
                cont = bobj[j];
            }
        }
    }
    result += '>';
    if (cont) {
        result += dataFile[cont.value];
    }
    result += '</' + parts[1];
    return result;
}

// test

console.log(solve([
    '{ "name": "Steven" }',
    '<div data-bind-content="name"></div>'
]));

console.log(solve([
    '{ "name": "Elena", "link": "http://telerikacademy.com" }',
    '<a data-bind-content="name" data-bind-href="link" data-bind-class="name"></а>'
]));