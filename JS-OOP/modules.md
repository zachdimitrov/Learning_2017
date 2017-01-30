## Module pattern
 - a closure that hides some variables
 - returns an object with functions or properties
 - expose only public functonality
 - not easy to reuse exposed functions 
 - not easy to change from private to public
```js
const peopleList = (function(){
    const people = [];
    
    return {
        add: function addPerson(name, age, gender) {
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
        },
        get: function() {
            return people.map(p => { 
                return {
                    name: p.name, 
                    age: p.age, 
                    gender: p.gender
                }
            });
        }
    }
})();

peopleList.add('Pesho', 20, true);
console.log(peopleList.get());
```
## Revealing module pattern
- easy to make private to public
- easy to reuse exposed functions 
- better to use
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
    function ageByAYear() {
        people.forEach(p => p.age +=1); // this is not exposed
    }
    return {
        add: addPerson, // easty to add or remove functions
        get: getPeople  // we can use functions privately
    }
})();
```
## Augmenting modules
- can split modules to many files or IIFEs  

module-1.js

```js
var module = module || {} // if module exists
// scope e parametyr koito izvikvame dolu s module
(function(scope) { 
    scope.obj1 = { /* core for obj1 */ };
}(module));
```
module-2.js

```js
var module = module || {} // if module exists
(function(scope) {
    scope.obj2 = { /* core for obj2 */ };
}(module));
```
calculator example  
*file 1*

```js
var calculator = (function(addition) {
    let value = 0;
    function add(x) {
        value += x;
        return this;
    }
    function substract(x) {
        value -= x;
        return this;
    }

    addition.add = add;
    addition.substract = substract;
}(calculator || {}));
```
*file 2*

```js
var calculator = (function(multiplication) {
    let value = 0;
    function multiply(x) {
        value *= x;
        return this;
    }
    function divide(x) {
        value /= x;
        return this;
    }
    function printValue() {
        console.log(value);
    }

    multiplication.multiply = multiply;
    multiplication.divide = divide;
    multiplication.print = printValue;
}(calculator || {}));
```
## ES 2015 modules import-export

#### Import

```js
// import everything from the module
import * as myModule from "my-module";
// import only one member from module
import {myMember} from "my-module";
// rename member
import {veryLongName as short} from "my-modul";
// importvane na vsichko (zaedno s neshtata ot global scope)
import "myModule";
```

#### Export

```js
// export a function
export { myFunction };
// export a constant
export const foo = Math.sqrt(2);
``` 