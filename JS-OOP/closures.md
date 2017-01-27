## Scope
- global scope   
  - in browsers this is **window**
  - every tab has it's own scope
  - v NODE.js ima scope za vseki file
 ```js
 var variable = 4; // accessible from everywhere
 pesho = 9; // definira se izvyn scope na vsichki funkcii da se izbqgva
 // fix this wit 'use strict' on top
 ```
- function scope
  - function parapeters are also local
 ```js
 function func() {
    var variable = 4; // only accessible in function
 }
 ```
- block scope
  - pri **let** promenlivata syshtestvuva ot tam kydeto e deklarirana
  - pri **var** promenlivite se deklarirat nai-gore sas stoinost 'undefined'
```js
if(true) {
    var x = 'pesho';  // shte se vijda i sled if-a
    const z = 7;      // nedostapni sled
    let sum = 1 + 2;  // kadravite skobi
}
```
## Closure
- simple counter
```js
function counterCreator(arr) {
    let counter = 0; // prodaljava da sashtestvuva
    // informaciqta e hide-nata i moje da se promenq samo s funkciqta po-dolu
    return  function() {
        counter += 1;
        return counter;
    }
}

let counter = counterCreator();
console.log(counter()); // 1
console.log(counter()); // 2
console.log(counter()); // 3
```
- another example - **module**
  - encapsulate information
  - return only desired functionality
```js
var school = (function() {
    var students = []; // not accesible outside
    var teachers = []; // not accesible outside
    function addtudent(name, grade) {....}
    function addTeacher(name, speciality) {....}
    function getTeachers(speciality) {....}
    function getStundents(grade) {....}
    return {
        addStudent: addStudent,
        addTeacher: addTeacher,
        getTeachers: getTeachers,
        getStundents: getStundents
    };
})();
```
 - people
```js
const peopleList = (function(){
    const people = [];
    function addPerson(name, age, gender) {
        if(typeof name != 'string') {
            throw 'Invalid name!';
        }
        if(!name.match(/^[A-Z][a-z]*$/)) {
            throw 'Wrong name!';
        }
        people.push({
            name: name,
            age: age,
            gender: gender
        });
    }
    function getPeople() {
        return people.map(p => { 
            return {
                name: p.name, 
                age: p.age, 
                gender: p.gender
            }
        });
    }
    return {
        add: addPerson,
        get: getPeople
    }
})();

peopleList.add('Pesho', 20, true);
console.log(peopleList.get());
```