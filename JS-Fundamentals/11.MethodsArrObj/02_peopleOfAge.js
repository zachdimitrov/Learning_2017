let info = [
    ['Gosho', 'Petkov', 27, 'm'],
    ['Penka', 'Ivanova', 66, 'f'],
    ['Stoiko', 'Ganev', 19, 'm'],
    ['John', 'Smith', 28, 'male'],
    ['Tomas', 'Anderson', 21, 'm'],
    ['Pete', 'Sampras', 42, 'm'],
    ['Grigor', 'Dimitrov', 25, 'male'],
    ['Cecka', 'Cacheva', 55, 'm'],
    ['Stanka', 'Zlateva', 25, 'female'],
    ['Ivanka', 'Trump', 45, 'f'],
],
people = [];

function makePerson(fname, lname, age = 1, gender = 'f') {

    function getGender(string) {
        g = string.toLowerCase();

        if (g === 'f' || g === 'female') {
            return true;
        }
        else if (g === 'm' || g === 'male') {
            return false;
        }
    }

    let person = {
        firstname: fname,
        lastname: lname,
        age: age,
        gender: getGender(gender),
        tostring: function () {
            let gen = 'male';
            if (this.gender) {
                gen = 'female';
            }
            return `${this.firstname} ${this.lastname}, ${this.age}, ${gen}`;
        }
    };
    return person;
}

for (let i of info) {
    let p = makePerson(i[0], i[1], i[2], i[3]);
    people.push(p);
}

function checkAge(people) {
    x = people.every(person => person.age >= 18);
    if (x) {
        console.log('All people are above 18 years old.');
    } else {
        console.log('There are people under 18 years old!');
        
    }
}

checkAge(people);