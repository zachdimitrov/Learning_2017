var data = [
        { "firstname": "Gosho", "lastname": "Petkov", "age": 27, "gender": false },
        { "firstname": "Penka", "lastname": "Ivanova", "age": 66, "gender": true },
        { "firstname": "Stoiko", "lastname": "Ganev", "age": 10, "gender": false },
        { "firstname": "John", "lastname": "Smith", "age": 28, "gender": false },
        { "firstname": "Tomas", "lastname": "Anderson", "age": 21, "gender": false },
        { "firstname": "Pete", "lastname": "Sampras", "age": 42, "gender": false },
        { "firstname": "Grigor", "lastname": "Dimitrov", "age": 25, "gender": false },
        { "firstname": "Cecka", "lastname": "Cacheva", "age": 55, "gender": false },
        { "firstname": "Stanka", "lastname": "Zlateva", "age": 15, "gender": true },
        { "firstname": "Ivanka", "lastname": "Ivanova", "age": 45, "gender": true },
        { "firstname": "Zahari", "lastname": "Dimitrov", "age": 35, "gender": false }
    ],
    group = {};

data.forEach(a => {
    let key = a.firstname.substr(0, 1).toLowerCase();
    group[key] = [];
})
data.forEach(a => {
    let key = a.firstname.substr(0, 1).toLowerCase();
    group[key].push(a);
})

console.log(group);

console.log('------------- same with reduce -------------');

var t = data.reduce(
    // Callback functon with accumulator (starting with Initial Value) and current value
    (testGroup, person) => {
        let key = person.firstname.substr(0, 1).toLowerCase();
        if (!(key in testGroup)) {
            testGroup[key] = [];
        }
        testGroup[key].push(person);
        return testGroup;
    }, {} // Initial value
);

console.log(t);