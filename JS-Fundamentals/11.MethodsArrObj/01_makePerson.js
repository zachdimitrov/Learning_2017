var group = (function() {
    // Hidden array
    var people = [];
    // Object constructor
    function makePerson(fname, lname, age = 1, gender = 'f') {
        function getGender(string) {
            g = string.toLowerCase();
            if (g === 'f' || g === 'female') {
                return true;
            } else if (g === 'm' || g === 'male') {
                return false;
            }
        }

        let person = {
            firstname: fname,
            lastname: lname,
            age: age,
            gender: getGender(gender),
            tostring: function() {
                let gen = 'male';
                if (this.gender) {
                    gen = 'female';
                }
                return `${this.firstname} ${this.lastname}, ${this.age}, ${gen}`;
            }
        };
        return person;
    }

    // create array of objects
    function add(info) {
        for (let i of info) {
            let p = makePerson(i[0], i[1], i[2], i[3]);
            people.push(p);
        }
    }
    // get array
    function get() {
        return people;
    }

    // expose function
    return {
        add: add,
        get: get
    }
})();

// Data file
let data = [
    ['Gosho', 'Petkov', 27, 'm'],
    ['Penka', 'Ivanova', 66, 'f'],
    ['Stoiko', 'Ganev', 10, 'm'],
    ['John', 'Smith', 28, 'male'],
    ['Tomas', 'Anderson', 21, 'm'],
    ['Pete', 'Sampras', 42, 'm'],
    ['Grigor', 'Dimitrov', 25, 'male'],
    ['Cecka', 'Cacheva', 55, 'm'],
    ['Stanka', 'Zlateva', 25, 'female'],
    ['Ivanka', 'Ivanova', 45, 'f'],
];

let anotherData = [
    ['Zahari', 'Dimitrov', 35, 'm']
]

// create group of people [array]
group.add(data);
group.add(anotherData);
var arr = group.get();
arr.forEach(a => console.log(a.tostring()));

// create JSON file
var json = JSON.stringify(arr);
var fs = require('fs');
fs.writeFile('./11.MethodsArrObj/people.json', json);