## Manage asynchronous tasks
### Using callback  

- each function calls the next one when it finishes
- too much nested code

```js
setTimeout(() => {
        console.log('middle1');
        setTimeout(() => {
            console.log('middle2');
            setTimeout(() => {
                console.log('middle3');
            }, 1000);
        }, 1000);
    }, 1000);
```

### Google API geolocation standard

```js
navigator.geolocation.getCurrentPosition(function success(pos) {
    // will return object with geolocation info (coordinates, height...)
    console.log(pos);
    var img = document.createElement("img");
    img.src = `https://maps.googleapis.com/maps/api/staticmap?center=${pos.coords.latitude},${pos.coords.longitude}&zoom=12&size=400x400`;
    img.style.width = 500;
    document.body.appendChild(img);
}, function error(pos) {
    // Nothing returned, error
});
```
### With Promise

- simple example
```js
var promise = new Promise((resolve, reject) => finction doSomething() {
    resolve("Return result");
    reject("Error message");
});
```

- complex example
```js
var myPromise = new Promise((resolve, reject) => {
    navigator.geolocation
    .getCurrentPosition((pos) => resolve(pos), (error) => reject(error));
});

function parseCoords(pos) {
    return {
        lat: pos.coords.latitude,
        lon: pos.coords.longitude
    };
}

function displayMap(pos) {
    var img = document.createElement("img");
    img.src = `https://maps.googleapis.com/maps/api/staticmap?center=${pos.lat},${pos.lon}&zoom=12&size=400x400`;
    img.style.width = 500;
    document.body.appendChild(img);
    return pos;
}

function wait(time, map) {
    return new Promise((resolve, reject) => {
        setTimeout(() => { resolve(map); }, time);
    });
}

function fadeout(map) {
    map.style.display = "none";
}

myPromise
.then(parseCoords) // what is returned goes to the next function
.then(displayMap)   // if we want to return many things, wrap them in object
.then((map) => wait(1000, map))
.then(fadeout)
.then(console.log);
```

- all code after promise is executed independantly in time (usually before)
- documentation for Promise - [Promises/A+](https://promisesaplus.com/)
- use polyfill if old browser - [BlueBird](http://bluebirdjs.com/docs/getting-started.html)

#### Promise.all

- waits untill all Promises are resolved

```js
var usersPromise = get('users.all');
var postsPromise = get('posts.everyone');

// Wait until BOTH are settled
Promise.all([usersPromise, postsPromise])
    .then((results) => {
        // result is an array of responses
        myController.users = results[0];
        myController.posts = results[1];
    })
    .catch(() => {
        delete myController.users;
        delete myController.posts;
    })
```

#### Promise.race

- returns first Promise that was resolved

```js
function getCourse(courseId) {
    var courses = {
        1: {name: 'Javascript Fundamentals'},
        2: {name: 'Javascript OOP'},
        3: {name: 'Javascript UI & DOM'},
        4: {name: 'Javascript Applications'},
    };
    return Promise.resolve(courses[courseId]);
}

var courseIds = [1,2,3,4];
var promises = [];
for(var i = 0; i < courseIds.length; i+=1) {
    promises.push(getCourse(courseIds[i]));
}

Promise.race(promises)
.then(function(values) {
    console.log(values);
});
```

## Generator functions

- example for task not working properly and need generator
    - first counts all numbers
    - then prints "Hello"

```js
setTimeout(() => console.log("Hello"), 1);
(function foo() { 
    for(var i = 0; i<= 10000; i++) {
        console.log(i);
    }
})();
```

- syntax of generator functions
- stops execution with **yield** and sents value **out**
- takes value back **in** when function is resumed

```js
function *foo() { 
// OR function* foo() {
    // .. yield something
}
```

- example

```js
function *foo() {
    yield 1;
    yield 2;
    yield 'ivan';
    yield {name: 'stamat'};
    return 'finished';
}

var gen = foo();

for (var num of foo()) { console.log(num) };
```

- fibonacci
```js
function* fibonacci() {
    var fn1 = 1, fn2 = 1, current, reset;
    while(true) {
        current = fn1;
        fn1 = fn2;
        fn2 = fn2 + current;
        reset = yield current;
        if(reset) {
            fn1 = 1;
            fn2 = 1;
        }
    }
}

var seq = fibonacci();
sequence.next().value;     // get next number
sequence.next(true).value; // reset
```

- acyncronuous
```js
(function(){
    var async = (function() {
    var sequence,
    run = function(generator) {
        sequence = generator();
        var next = sequence.next();
    },
    resume = function() {
        sequence.next();
    };

    return {
         run: run, 
         resume: resume
       };
    })();

    function pause(delay) {
     setTimeout(function() {
        console.log('paused for ' + delay + 'ms');
        async.resume();
        }, delay);
    }

    function* main() {
        console.log('start');
        yield pause(2000);
        console.log('midde');
        yield pause(2000);
        console.log('end');
    }

    async.run(main);
    main();
}());
```