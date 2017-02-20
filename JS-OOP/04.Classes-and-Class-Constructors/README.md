## Define Class

```js
class Horse {
    // class constructor
    constructor(name, furColor, age) {
        this._name = name;
        this._furColor = furColor;
        this._age = age;
    }
}
// usage
const horse = new Horse('Trendafil', 'brown', 2);
```

## Class methods

```js
class Cat {
    constructor(name) {
        this._name = name;
    }
    // define method
    meow() {
        console.log(this._name + ' sais: '+ Cat.whatCatsSay() +'!');
    }

    static whatCatsSay() {
        return 'meow';
    }
}
// example
const mariya = new Cat('Mariya');
mariya.meow();
```

## Class getters and setters

```js
class Person {
    constructor(firstname, lastname) {
        this.firstname = firstname; // taka izpolzvame settera v konstructora
        this.lastname = lastname;   // vmseto da viknem this._lastname
    }
    // getter
    get fullname() {
        return this._firstname + ' ' + this._lastname;
    }
    // setters
    set fullname(x) {
        throw new Error('Fullname cannot be set directly, use "firstname" and "lastname" instead!');
    }
    set firstname(value) {
        // validators go here (moje da polzvame obekt s validatori ot izvyn klasa)
        if(typeof value !== 'string')  {
          throw new Error('Name must be string!');
          }
        this._firstname = value;
    }
    set lastname(value) {
        this._lastname = value;
    }
}
// usage
const peter = new Person('peter', 'anderson');
peter.lastname = 'Ivanov'; // izvikva se settera s validaciite
console.log(peter.fullname); // izvikva se gettera kato stoinost
```
### Example with old syntax

```js
function dog(name) {
    this._name = name;
    this._silenced = false;
}

    Dog.prototype.bark = function() {
        if(this._silenced) {
            return;
        }
        console.log(`${this._name} says bark!`);
    };

    Dog.prototype.silence = function() {
        this._silenced = true;
    };

    // static methot - without prototype
```
## Static methods

```js
class Point2D {
    constructor(x, y) {
        this._x = x;
        this._y = y;
    }

    // izvikvame go kato property bez skobi - Point2D.ZERO
    static get ZERO() {
        return new Point2D(0, 0);
    }
    // statichen metod - izpolzva se vyrhu imeto na klasa - Point2D.getDistance(a, b)
    static getDistance(a, b) {
        return Math.sqrt(a._x - b._x) * (a._x - b._x) +
        (a._y - b._y) * (a._y - b._y);
    }
    // preizpolzvame statichniq metod
    distanceTo(otherPoint) {
        return Point2D.getDistance(this, otherPoint);
    }
    // preizpolzvame statichnite method i getter
    get distanceToCenter() {
        return Point2D.getDistance(this, Point2D.ZERO);
    }
}
```

## Prototypes  
- static methods are not connected to instances but to type itself
- statichnite metodi i propertita gi zakacha direktno na obekta
- nestatichnite se zakachat na prototipa (i mogat da se izvikvat ot iznstanciite).
  - vseki pyt kato se syzdade obekta se syzdavat tezi funkcii

```js
// define getters and setters with old syntax
function dog(name) {
    this._name = name;
    this._silenced = false;
}

// getters and setters
Object.defineProperty(Dog.prototype, 'name', {
    get: function() {
        return this._name;
    },
    set: function(value) {
        // validation
        this._name = value;
    }
});

// static getters and setters
Object.defineProperty(Dog, 'whatDoesTheDogSay', {
    get: function() {
        return 'Bark!';
    }
})
```

## Inheritance

[**More examples here**](http://exploringjs.com/es6/ch_classes.html)

```js
class Point {
    constructor(x, y) {
        this.x = x;
        this.y = y;
    }
    toString() {
        return `(${this.x}, ${this.y})`;
    }
}

class ColorPoint extends Point { 
    // use extends to show inheritance
    constructor(x, y, color) {
        super(x, y); 
        // use super() to reuse parents class
        this.color = color;
    }
    toString() {
        return super.toString() + ' in ' + this.color; 
        // use super.method() to call parents method
        // use super.prop ti call parents property
    }
}
```