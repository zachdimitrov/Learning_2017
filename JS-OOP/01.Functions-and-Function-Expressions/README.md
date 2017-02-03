# Functions
### Functions overview

function properties

```js
function func(x, y, x) {
    return x + y;
}
func.length // pokazva broq na parametrite
func.name   // vryshta imeto na funkciqta ('' ako nqma ime)
```

function methods

```js
console.log(func.toString());
// shte vyrne funckiqta kato string

func.call(this, a, b, c);
// zadavame this na funkciqta (obekta varhu koito se izpalnqva)

func.apply(this, [a, b, c]);
// syshtoto no s masiv ot parametri

var args = [].silce.call(arguments);
// syzdava masiv ot arguments

function maxElement() {
    return Math.max.apply(this, arguments); // ili napravo (...args)
}

let maxElement = (function() {
    var args = [].silce.call(arguments);
    return Math.max.apply(...args);
}).bind({});
// promenq se contexta na funkciqta (this) bez znachenie ot kyde q izvikvame

Array.prototype.callMaxElement = maxElement;
```
manipulate functions   

```js
const modifiers = [
    function(x) { return x + 7; },
    function(x) { return x * 2; },
    function(x) { return 42; }
];
// moje da si manipulirame masiva
modifiers.map(f => f(11)).forEach(x => console.log(x)); 
// f => f(11) e ravnosilno na tova
function applyFunc(f) { return f(11); }
// this v sluchaq e celiq masiv na koito sme zakachili funkciqta
modifiers.someFunc = function() {
    console.log(this[0].toString());
}
console.log(modifiers.someFunc());
```
### define Functions
function declaration

```js
function printMsg(msg) { console.log(msg); } // moje da se izvikva ot vsqkyde
```
function expression

```js
var printMsg = function() { console.log(msg); } // izvikva se samo sled deklariraneto
```
function constructor

```js
var printMsg = new Function("msg", "console.log('msg');"); // ne se izpolzva (samo v specialni sluchai)
```
#### types of function expressions
```js
var sumNumbers = (function(x, y) {console.log(x + y)})(3, 5);
var sumNumbers = (x, y) => console.log(x + y);
```
#### fat arrow (lambda) functions
```js
let modifiers = [
    x => x + 7, // ne biva da se polzva this
    (x, y) = x + y // polzvat se samo pri ednokratno izvikvane
]
```
## Recursion
factorial

```js
function factorial(n) {
    // exit condition - must have
    if(n === 0) { 
        return 1;
    }
    // recursion
    return factorial(n-1) * n;
}
```
fibonacci

```js
function fibonacci(n) {
    if(n === 0 || n === 1) {
        return 1;
    }
    return fibonacci(n - 2) + fibonacci(n - 1);
}
```
dom manipulation

```js
function rotateEl(el) {
    el.style.display = 'block';
    el.style.transform = 'rotate(' + Math.random()*3 - 2 + 'deg)';
}
function manipulateRecursive(el) {
    rotateEl(el);
    [].slice.call(el.children).forEach(manipulateRecursive);
}
manipulateRecursive(document.body);
```
## Nested Functions
ne e dobro reshenie zashtoto vatreshnata funkciq se definira nanovo

```js
function x() {
    function y() {
        /* Solves problems */
    }
}
```
## IIFE

```js
const counter = (function() {
// internal variable
let value = 0;
// internal function
function getNext() {
    value += 1;
    return value;
}
// internal function
function resetCounter() {
    value = 0;
    return 'Counter is reset to 1!';
}
// expose functions
return {
 next: getNext,
 reset: resetCounter
} 
})();

console.log(counter.next()); // returns 1
console.log(counter.next()); // returns 2
console.log(counter.reset()); // resets counter
console.log(counter.next()); // returns 1
```