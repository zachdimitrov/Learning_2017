let intNumber = 123;
let realNumber = 12.34;
let string = "Hello, Javascript!";
let correct = true;
let wrong = false;
let nothing = null;
let notDefined = undefined;
let array = [1, 2, 3];
let object = { 1: "one", 10: "two", 20: "three" };
let smallest = -Infinity;
let largest = Infinity;

var result = `
type of "intNumber" = ${typeof(intNumber)}
type of "realNumber" = ${typeof(realNumber)}
type of "string" = ${typeof(string)}
type of "correct" = ${typeof(correct)}
type of "wrong" = ${typeof(wrong)}
type of "nothing" = ${typeof(nothing)}
type of "notDefined" = ${typeof(notDefined)}
type of "array" = ${typeof(array)}
type of "object" = ${typeof(object)}
type of "smallest" = ${typeof(smallest)}
type of "largest" = ${typeof(largest)}
`

console.log(result);