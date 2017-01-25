function solve(args) {
    let object = JSON.parse(args[0]),
        template = args[1];

    String.prototype.formatPlaceholders = function(obj) {
        let result = '';
        for (var i = 0; i < this.length; i++) {
            if (this[i] === '#' && this[i + 1] === '{') {
                let index = this.indexOf('}', i),
                    prop = this.substring(i + 2, index);
                result += obj[prop];
                i += prop.length + 2;
            } else {
                result += this[i];
            }
        }

        return result;
    };

    return template.formatPlaceholders(object);
}

// test

console.log(solve([
    '{ "name": "Petko" }',
    "Hello, there! Are you #{name}?"
]));

console.log(solve([
    '{ "name": "John", "age": 13 }',
    "My name is #{name} and I am #{age}-years-old"
]));