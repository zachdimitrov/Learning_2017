function solve(args) {
    function sayHello(name) {
        console.log(`Hello, ${name}!`);
    }
    sayHello(args);
}

// tests

solve(['Ivan']);
solve(['Gosho']);