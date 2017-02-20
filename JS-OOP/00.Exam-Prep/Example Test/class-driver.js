function solve() {
    class Human {
        constructor(name) {
            this._name = name;
        }

        get name() {
            return this._name;
        }

        set name(value) {
            if (value.length < 1) { throw new Error('Too short name!'); }
            this._name = value;
        }

        introduce() {
            return this.name;
        }
    }

    class Driver extends Human {
        constructor(name, category) {
            super(name);
            this._category = category;
        }

        get category() {
            return this._category;
        }

        set category(value) {
            if (value.length !== 1) { throw new Error('Category must be one symbol!'); }
            this._category = value;
        }
    }

    return {
        Human,
        Driver
    }
}

// tusage

var myWorkers = solve();
for (var i = 1; i < 10; i++) {
    var currentDriver = new myWorkers.Driver("Driver " + i, 'A');
    console.log(currentDriver.introduce());
}