function solve() {
    const validate = {
        ifIsString: function(val) {
            if (typeof val !== 'string') {
                throw new Error('Value must be a string!');
            }
        },
        ifStringIsCorrectLength: function(val, low, high) {
            validate.ifIsString(val);
            if (val.length < low || val.length > high) {
                throw new Error('String must be between ' + low + ' and ' + high + ' symbols long!');
            }
        },
        ifNameHasCorrectSymbols: function(val) {
            validate.ifIsString(val);
            if (val.match(/[^a-zA-Z\s\d]/)) {
                throw new Error('String has wrong symbols!');
            }
        },
        ifNumber: function(val) {
            if (typeof val !== 'number') {
                throw new Error('Value must be a number!');
            }
        },
        ifPositive: function(val) {
            validate.ifNumber(val);
            if (val <= 0) {
                throw new Error('Number must be positive!');
            }
        },
        ifNumberBetween: function(val, low, high) {
            validate.ifNumber(val);
            if (val < low || val > high) {
                throw new Error('Number must be between ' + low + ' and ' + high + '!');
            }
        }
    };

    const uploaded = (function() {
        let time = 0;
        return function() {
            time++;
            return time;
        };
    }());

    class App {
        constructor(name, description, version, rating) {
            this.name = name;
            this.description = description;
            this.version = version;
            this.rating = rating;
            this._uploaded = uploaded();
        }

        get name() {
            return this._name;
        }

        set name(val) {
            validate.ifStringIsCorrectLength(val, 1, 24);
            validate.ifNameHasCorrectSymbols(val);
            this._name = val;
        }

        get description() {
            return this._description;
        }

        set description(val) {
            validate.ifIsString(val);
            this._description = val;
        }

        get version() {
            return this._version;
        }

        set version(val) {
            validate.ifPositive(val);
            this._version = val;
        }

        get rating() {
            return this._rating;
        }

        set rating(val) {
            validate.ifNumberBetween(val, 1, 10);
            this._rating = val;
        }

        release(options) {
            if (typeof options === 'object') {
                // chnage version if found, if not throw
                if (typeof options.version === 'undefined') {
                    throw new Error('Version must be specified when Options Object is used!');
                }
                validate.ifPositive(options.version);
                if (this.version >= options.version) {
                    throw new Error('New version must be greater than old one!');
                }
                this.version = options.versions;

                // change description if found
                if (typeof options.description !== 'undefined') {
                    validate.ifIsString(options.description);
                    this.description = options.description;
                }

                // change rating if found
                if (typeof options.rating !== 'undefined') {
                    validate.ifNumberBetween(options.rating, 1, 10);
                    this.rating = options.rating;
                }
            } else {
                validate.ifPositive(options);
                if (this.version >= options) {
                    throw new Error('New version must be greater than old one!');
                }
                this.version = options;
                return this;
            }
        }
    }

    class Store extends App {
        constructor(name, description, version, rating) {
            super(name, description, version, rating);
            this.apps = [];
        }

        uploadApp(app) {
            if (!(app instanceof App) || app instanceof Store) {
                throw new Error('App must be an instance of App!');
            }

            let exists = this.apps.find(a => a.name === app.name);
            if (typeof exists === 'undefined') {
                app._uploaded = uploaded();
                this.apps.push(app);
            } else {
                if (exists.version >= app.version) {
                    throw new Error('New version must be greater than old one!');
                }
                exists._uploaded = uploaded();
                exists.version = app.version;
                exists.description = app.description;
                exists.rating = app.rating;
            }
            return this;
        }

        takedownApp(name) {
            let exists = this.apps.find(a => a.name === name);
            if (typeof exists !== 'undefined') {
                let i = this.apps.indexOf(exists);
                this.apps.splice(i, 1);
            } else {
                throw new Error('App is not found in store!');
            }
            return this;
        }

        search(pattern) {
            if (typeof pattern !== 'string' || pattern === '') {
                throw new Error('Search pattern should be a non-empty string');
            }

            return this.apps.filter(function(item) {
                return item.name.indexOf(pattern) >= 0;
            }).sort(function(a, b) {
                var nameA = a.name.toUpperCase(); // ignore upper and lowercase
                var nameB = b.name.toUpperCase(); // ignore upper and lowercase
                if (nameA < nameB) {
                    return -1;
                }
                if (nameA > nameB) {
                    return 1;
                }
                // names must be equal
                return 0;
            });
        }

        listMostRecentApps(count) {
            count = count || 10;
            if (count > this.apps.length) {
                count = this.apps.length;
            }
            return this.apps
                .sort((a, b) => b._uploaded - a._uploaded)
                .slice(0, count);
        }

        listMostPopularApps(count) {
            count = count || 10;
            return this.apps.sort((a, b) => (b.rating - a.rating === 0) ? b._uploaded - a._uploaded : b.rating - a.rating)
                .slice(0, count);
        }
    }

    class Device {
        constructor(hostname, apps) {
            this.hostname = hostname;
            this.apps = apps;
        }

        get hostname() {
            return this._hostname;
        }

        set hostname(val) {
            validate.ifStringIsCorrectLength(val, 1, 32);
            this._hostname = val;
        }

        get apps() {
            return this._apps;
        }

        set apps(val) {
            if (!Array.isArray(val)) {
                throw new Error('Invalid array of apps!');
            }
            val.forEach(app => {
                if (!(app instanceof App || app instanceof Store)) {
                    throw new Error('App must be an instance of App!');
                }
            });
            this._apps = val;
        }

        search(pattern) {
            let result = [];
            let resultObj = {};
            let finalResult = [];
            let stores = this.apps.filter(app => app instanceof Store);
            stores.forEach(s => {
                let found = s.search(pattern);
                result.push(...found);
            });
            result.forEach(app => {
                if (typeof resultObj[app.name] === 'undefined') {
                    resultObj[app.name] = app;
                } else {
                    if (resultObj[app.name].version < app.version) {
                        resultObj[app.name] = app;
                    }
                }
            });
            for (let prop in resultObj) {
                finalResult.push(resultObj[prop]);
            }
            return finalResult.sort(function(a, b) {
                var nameA = a.name.toUpperCase(); // ignore upper and lowercase
                var nameB = b.name.toUpperCase(); // ignore upper and lowercase
                if (nameA < nameB) {
                    return -1;
                }
                if (nameA > nameB) {
                    return 1;
                }
                // names must be equal
                return 0;
            });
        }

        install(name) {
            let foundApp = this.search(name)
                .filter(app => app.name = name)
                .sort((a, b) => b.version - a.version)[0];

            if (typeof foundApp === 'undefined') {
                throw new Error('App is not found in app stores!');
            } else {
                this.apps.push(foundApp);
            }
            return this;
        }

        uninstall(name) {
            let foundApp = this.apps.filter(app => app instanceof App).find(a => a.name === name);
            if (typeof foundApp === 'undefined') {
                throw new Error('App is not installed in device!');
            } else {
                let i = this.apps.indexOf(foundApp);
                this.apps.splice(i, 1);
            }
        }

        listInstalled() {
            return this.apps
                .filter(app => app instanceof App && !(app instanceof Store))
                .sort(function(a, b) {
                    var nameA = a.name.toUpperCase(); // ignore upper and lowercase
                    var nameB = b.name.toUpperCase(); // ignore upper and lowercase
                    if (nameA < nameB) {
                        return -1;
                    }
                    if (nameA > nameB) {
                        return 1;
                    }
                    // names must be equal
                    return 0;
                });
        }

        update() {
            this.listInstalled().forEach(app => {
                let foundApps = [];
                this.apps
                    .filter(a => a instanceof Store)
                    .forEach(store => {
                        let bestInStore = store.apps
                            .filter(sapp => sapp.name === app.name)
                            .sort((a, b) => b.version - a.version)[0];
                        if (typeof bestInStore !== 'undefined') {
                            foundApps.push(bestInStore);
                        }
                    });

                let foundApp = foundApps.sort((a, b) => b.version - a.version)[0];
                if (typeof foundApp !== 'undefined' && foundApp.version > app.version) {
                    app = foundApp;
                }
            });
            return this;
        }
    }

    // end of classes
    return {
        createApp(name, description, version, rating) {
            // returns a new App object
            return new App(name, description, version, rating);
        },
        createStore(name, description, version, rating) {
            // returns a new Store object
            return new Store(name, description, version, rating);
        },
        createDevice(hostname, apps) {
            // returns a new Device object
            return new Device(hostname, apps);
        }
    };
}

// Submit the code above this line in bgcoder.com
module.exports = solve;

/*
let o = +new Date().getTime();
console.log(o);

setTimeout(function(){ 
	console.log('now-----------');
	console.log( +new Date().getTime());
 }, 3000);
*/

// test

const s = solve();

let ivan1 = s.createApp('ivan', 'iqko', 1, 1);
let ivan2 = s.createApp('ivan', 'iqko', 2, 5);
let ivan11 = s.createApp('ivan', 'iqko', 1, 1);
let ivan22 = s.createApp('ivan', 'iqko', 2, 5);
let ivan3 = s.createApp('ivan', 'iqko', 3, 6);
let joroA = s.createApp('joroA', 'metala', 3, 2);
let joroB = s.createApp('joroB', 'metala', 3, 5);
let joroC = s.createApp('joroC', 'metala', 3, 6);

let ivan4 = s.createApp('ivan', 'iqko', 8, 1);
let ivan5 = s.createApp('ivanA', 'iqko', 2, 5);
let ivan6 = s.createApp('ivanB', 'iqko', 3, 6);
let joroD = s.createApp('joroD', 'metala', 3, 2);
let joroE = s.createApp('joroB', 'metala', 6, 5);
let joroF = s.createApp('joroC', 'metala', 5, 6);


let store1 = s.createStore('s1', 'Ivani', 1, 3);
let store2 = s.createStore('s2', 'Jorovci', 2, 9);
store1.uploadApp(ivan1)
    .uploadApp(ivan2)
    .uploadApp(joroC)
    .uploadApp(joroA)
    .uploadApp(joroB)
    .takedownApp('ivan');

store2.uploadApp(ivan4)
    .uploadApp(ivan5)
    .uploadApp(ivan6)
    .uploadApp(joroE)
    .uploadApp(joroD);

let dev = s.createDevice('kancho', [ivan11, ivan22, joroA, store1, store2]);

console.log(dev.install('joroD'));