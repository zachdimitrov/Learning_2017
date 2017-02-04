function solve() {
    // create main module
    var workers = (function() {

        // define modules
        var human, driver;

        // create parent module (human)
        human = (function() {

            // create empty object
            var human = Object.create({});

            // initialise human with properties (data descriptor)
            Object.defineProperty(human, 'init', {
                configurable: false, // optional, false by default
                enumerable: false, // optional, false by default
                value: function(name) {
                    this.name = name;
                    return this;
                },
                writable: false // optional, false by default
            });

            // define precisely each property (accessor descriptor)
            Object.defineProperty(human, 'name', {
                configurable: false, // optional, false by default
                enumerable: false, // optional, false by default
                get: function() {
                    return this._name;
                },
                set: function(val) {
                    // provide validation
                    if (val.length < 1) { throw new Error('Too short name!'); }
                    this._name = val;
                }
            });

            Object.defineProperty(human, 'introduce', {
                value: function() {
                    return this.name;
                }
            });

            // return modified object
            return human;
        }());

        // child module (driver) - inherits human
        driver = (function(parent) {
            var driver = Object.create(parent);

            Object.defineProperty(driver, 'init', {
                value: function(name, category) {
                    // use inherited object method with call()
                    parent.init.call(this, name);
                    this.category = category;
                    return this;
                }
            });

            // define new own property for driver
            Object.defineProperty(driver, 'category', {
                get: function() {
                    return this._category;
                },
                set: function(val) {
                    if (val.length !== 1) { throw new Error('Category must be one symbol!'); }
                    this._category = val;
                }
            })

            Object.defineProperty(driver, 'introduce', {
                value: function() {
                    return parent.introduce.call(this) + ' - ' + this.category;
                }
            });

            // return new child object
            return driver;
        }(human));

        // reveal objects that we want to be visible and created outside
        return {
            getDriver: function(name, category) {
                return Object.create(driver).init(name, category);
            }
        };
    }());

    return workers;
}

// usage 

var myWorkers = solve();
for (var i = 1; i < 10; i++) {
    var currentDriver = myWorkers.getDriver("Driver " + i, 'A');
    console.log(currentDriver.introduce());
}