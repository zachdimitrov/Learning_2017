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

    function personToStr(person) {
        let gen = 'male';
        if (person.gender) {
            gen = 'female';
        }
        return `${person.firstname} ${person.lastname}, ${person.age}, ${gen}`;
    }

    let person = {
        firstname: fname,
        lastname: lname,
        age: age,
        gender: getGender(gender),
        tostring: personToStr(this)
    };
    return person;
}

let info = [
['Gosho', 'Petkov', 27, 'm'],
['Penka', 'Ivanova', 66, 'f'],
['Stoiko', 'Ganev', 10, 'm'],
['John', 'Smith', 28, 'male'],
['Tomas', 'Anderson', 21, 'm'],
['Pete', 'Sampras', 42, 'm'],
['Grigor', 'Dimitrov', 25, 'male'],
['Cecka', 'Cacheva', 55, 'm'],
['Stanka', 'Zlateva', 25, 'female'],
['Ivanka', 'Trump', 45, 'f'],
];

let people = [];

for (let i of info) {
        let p = makePerson(i[0], i[1], i[2], i[3]);
        people.push(p);
}

console.log(people);
people.forEach(p => console.log(p.tostring));