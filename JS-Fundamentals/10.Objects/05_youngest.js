function solve(args) {
    var people = [];

    for (var i = 0, len1 = args.length; i < len1; i += 3) {
        people.push({
            firstname: args[i],
            lastname: args[i + 1],
            age: +args[i + 2]
        });
    }

    var minAge = people[0].age,
        index = 0;

    for (var j = 0, len2 = people.length; j < len2; j += 1) {
        if (people[j].age < minAge) {
            minAge = people[j].age;
            index = j;
        }
    }
    console.log(people[index].firstname + ' ' + people[index].lastname);
}

// tests

solve([
    'Gosho', 'Petrov', '32',
    'Bay', 'Ivan', '81',
    'John', 'Doe', '42'
]);

solve([
    'Penka', 'Hristova', '61',
    'System', 'Failiure', '88',
    'Bat', 'Man', '16',
    'Malko', 'Kote', '72'
]);