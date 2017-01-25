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
];

var i = data.sort((a, b) => a.age - b.age)
    .find(a => !a.gender);

console.log(i);