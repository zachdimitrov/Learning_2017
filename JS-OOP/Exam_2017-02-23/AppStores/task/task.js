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
            this._uploaded = 0;
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
                this.version = options.version;

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
                return this;
            } else if (typeof options === 'number') {
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
            this._uploaded = 0;
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
                .filter(app => app.name === name)
                .sort((a, b) => b.version - a.version)[0];
            if (typeof foundApp === 'undefined') {
                throw new Error('App is not found in app stores!');
            } else {
                if (this.apps.indexOf(foundApp) < 0) {
                    this.apps.push(foundApp);
                }
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
            return this;
        }

        listInstalled() {
            let list = [];
            list = this.apps
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
            return list;
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
                    app.version = foundApp.version;
                    app.description = foundApp.description;
                    app.rating = foundApp.rating;
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
// bad idea
let o = +new Date().getTime();
console.log(o);

setTimeout(function(){ 
	console.log('now-----------');
	console.log( +new Date().getTime());
 }, 3000);
*/

// test

const s = solve();

// create test app for release 
let app1 = s.createApp('app1', 'testrelease', 1, 3);
console.log('----------initial app');
console.log(app1);

console.log('----------release with version only');
console.log(app1.release(3));

console.log('----------release with all options');
console.log(app1.release({ version: 5, description: 'newDescription', rating: 4 }));

console.log('----------release with 2 options');
console.log(app1.release({ version: 6, rating: 1 }));

console.log('----------release version as option');
console.log(app1.release({ version: 8 }));

// create apps for stores
let ivan1 = s.createApp('fsdf', '3', 1, 1);
let ivan2 = s.createApp('ivan', 'iqko', 2, 5);
let ivan3 = s.createApp('ivan', 'iqko', 3, 6);
let joroA = s.createApp('joroA', 'metala', 3, 2);
let joroB = s.createApp('joroB', 'metala', 3, 5);
let joroC = s.createApp('joroC', 'metala', 3, 6);
let ivan4 = s.createApp('ivan', 'iqko', 8, 8);
let ivan5 = s.createApp('ivanA', 'iqko', 2, 5);
let ivan6 = s.createApp('ivanB', 'iqko', 3, 6);
let joroD = s.createApp('joroD', 'metala', 3, 2);
let joroE = s.createApp('joroB', 'metala', 6, 5);
let joroF = s.createApp('joroC', 'metala', 5, 6);

//create apps for device
let ivan11 = s.createApp('ivan', 'iqko', 1, 1);
let joroAA = s.createApp('joroC', 'metala', 1, 1);

// create stores
let store1 = s.createStore('s1', 'Ivani', 1, 3);
let store2 = s.createStore('s2', 'Jorovci', 2, 9);

// upload apps to store 1
store1.uploadApp(ivan2)
    .uploadApp(ivan3)
    .uploadApp(joroC)
    .uploadApp(joroA)
    .uploadApp(joroB)
    .uploadApp(ivan5)
    .uploadApp(ivan6)
    .uploadApp(joroE)
    .uploadApp(joroF)
    .uploadApp(joroD);

console.log('----------create store');
console.log(store1);

console.log('----------all');
console.log(store1.search('iv'));

console.log('-----------most resent');
console.log(store1.listMostRecentApps(4));

console.log('-----------most popular');
console.log(store1.listMostPopularApps());

// upload apps to store 2
store2.uploadApp(ivan4)
    .uploadApp(ivan5)
    .uploadApp(ivan6)
    .uploadApp(joroE)
    .uploadApp(joroF)
    .uploadApp(joroD);

// create device
let dev = s.createDevice('kancho', [joroAA, store1, store2]);

console.log('----------search');
console.log(dev.search('ivan'));

console.log('----------show all');
console.log(dev);

console.log('----------install first time');
console.log(dev.install('ivan'));

console.log('----------try to install secon time');
console.log(dev.install('ivan'));

console.log('-----------list');
console.log(dev.listInstalled());

console.log('-----------uninstall');
console.log(dev.uninstall('ivan'));

console.log('-----------uninstall');
console.log(dev.install('joroD'));

console.log('-----------uninstall store');
console.log(dev.uninstall('s2'));

console.log('-----------update');
console.log(dev.update());

console.log('-----------search');
console.log(dev.search('jo'));

console.log('-----------ununstall last store');
console.log(dev.uninstall('s1'));