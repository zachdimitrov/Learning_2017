function solve(args) {
    var people = [],
        ages = {};

    for (let i = 0, len = args.length; i < len; i += 3) {
        people.push({
            firstname: args[i],
            lastname: args[i + 1],
            age: +args[i + 2]
        });
    }

    ages = group(people);
    console.log(ages);

    function group(arr) {
        var sort = {};
        for (let i = 0, len = arr.length; i < len; i += 1) {
            var index = arr[i].age;
            sort[index] = [];
            for (let j = 0, len = arr.length; j < len; j += 1) {
                if (arr[j].age === index) {
                    sort[index].push(arr[j]);
                }
            }
        }
        return sort;
    }
}

// tests

solve([
    'Penka', 'Hristova', '72',
    'System', 'Failiure', '88',
    'Bat', 'Man', '88',
    'Malko', 'Kote', '72',
    'Gosho', 'Petrov', '32',
    'Bay', 'Ivan', '72',
    'John', 'Doe', '32'
]);