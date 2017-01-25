function solve(args) {
    var r = '';
    for (i = 1; i <= +args[0]; i += 1) { r += ' ' + i; }
    return r.trim();
}