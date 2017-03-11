function solve() {
    const MAX_SYMB = 20,
        MIN_SYMB = 1,
        MAX_VOLT = 20,
        MIN_VOLT = 5;

    const validate = {
        ifNumber: function(val, name) {
            name = name || 'Value';
            if (typeof val !== 'number') {
                throw new Error(name + ' must be a number!');
            }
        },
        ifPositiveNumber: function(val, name) {
            name = name || 'Value';
            validate.ifNumber(val, name);
            if (val <= 0) {
                throw new Error(name + ' must be positive number above zero!');
            }
        },
        ifIsPositiveInteger: function(val, name) {
            name = name || 'Value';
            validate.ifPositiveNumber(val, name);
            if (!Number.isInteger(val)) {
                throw new Error(name + ' must be a positiwe integer above zero!');
            }
        },
        ifNumberBetween(val, v1, v2, name) {
            name = name || 'Value';
            validate.ifPositiveNumber(val, name);
            if (val < v1 || val > v2) {
                throw new Error(name + ' must be between ' + v1 + ' and ' + v2 + '!');
            }
        },
        ifString: function(val, name) {
            name = name || 'Value';
            if (typeof val !== 'string') {
                throw new Error(name + ' must be a string!');
            }
        },
        ifCorrectLength: function(val, name) {
            name = name || 'Value';
            validate.ifString(val, name);
            if (val.length < MIN_SYMB || val.length > MAX_SYMB) {
                throw new Error(name + ' must be between ' + MIN_SYMB + ' and ' + MAX_SYMB + ' symbols long!');
            }
        },
        ifCorrectOpSystem: function(val) {
            validate.ifString(val, 'OperatingSystem');
            if (val.length < MIN_SYMB || val.length > MAX_SYMB / 2) {
                throw new Error('OperatingSystem must be between ' + MIN_SYMB + ' and ' + MAX_SYMB / 2 + ' symbols long!');
            }
        },
        ifCorrectQuality: function(val) {
            validate.ifString(val, 'Quality');
            if (val !== 'high' && val !== 'mid' && val !== 'low') {
                throw new Error('Quality must be one of "high", "mid" or "low!"');
            }
        }
    };

    function clone(obj) {
        if (null === obj || "object" != typeof obj) return obj;
        var copy = {};
        for (var attr in obj) {
            if (obj.hasOwnProperty(attr)) {
                copy[attr] = obj[attr];
            }
        }
        return copy;
    }

    const getId = (function() {
        let id = 0;
        return function() {
            id += 1;
            return id;
        };
    }());

    class Product {
        constructor(manufacturer, model, price) {
            this.count = 0;
            this.id = getId();
            this.manufacturer = manufacturer;
            this.model = model;
            this.price = price;
        }

        get manufacturer() {
            return this._manufacturer;
        }

        set manufacturer(val) {
            validate.ifCorrectLength(val, 'manufacturer');
            this._manufacturer = val;
        }

        get model() {
            return this._model;
        }

        set model(val) {
            validate.ifCorrectLength(val, 'Model');
            this._model = val;
        }

        get price() {
            return this._price;
        }

        set price(val) {
            validate.ifPositiveNumber(val, 'Price');
            this._price = val;
        }

        getLabel() {
            return ' - ' + this.manufacturer + ' ' + this.model + ' - **' + this.price + '**';
        }
    }

    class SmartPhone extends Product {
        constructor(manufacturer, model, price, screenSize, operatingSystem) {
            super(manufacturer, model, price);
            this.count = 0;
            this.id = getId();
            this.screenSize = screenSize;
            this.operatingSystem = operatingSystem;
        }

        get screenSize() {
            return this._screenSize;
        }

        set screenSize(val) {
            validate.ifPositiveNumber(val, 'ScreenSize');
            this._screenSize = val;
        }

        get operatingSystem() {
            return this._operatingSystem;
        }

        set operatingSystem(val) {
            validate.ifCorrectOpSystem(val);
            this._operatingSystem = val;
        }

        getLabel() {
            return 'SmartPhone' + super.getLabel();
        }
    }

    class Charger extends Product {
        constructor(manufacturer, model, price, outputVoltage, outputCurrent) {
            super(manufacturer, model, price);
            this.count = 0;
            this.id = getId();
            this.outputVoltage = outputVoltage;
            this.outputCurrent = outputCurrent;
        }

        get outputVoltage() {
            return this._outputVoltage;
        }

        set outputVoltage(val) {
            validate.ifNumberBetween(val, 5, 20, 'Voltage');
            this._outputVoltage = val;
        }

        get outputCurrent() {
            return this._outputCurrent;
        }

        set outputCurrent(val) {
            validate.ifNumberBetween(val, 100, 3000, 'Current');
            this._outputCurrent = val;
        }

        getLabel() {
            return 'Charger' + super.getLabel();
        }
    }

    class Router extends Product {
        constructor(manufacturer, model, price, wifiRange, lanPorts) {
            super(manufacturer, model, price);
            this.count = 0;
            this.id = getId();
            this.wifiRange = wifiRange;
            this.lanPorts = lanPorts;
        }

        get wifiRange() {
            return this._wifiRange;
        }

        set wifiRange(val) {
            validate.ifPositiveNumber(val, 'WifiRange');
            this._wifiRange = val;
        }

        get lanPorts() {
            return this._lanPorts;
        }

        set lanPorts(val) {
            validate.ifIsPositiveInteger(val, 'LanPorts');
            this._lanPorts = val;
        }

        getLabel() {
            return 'Router' + super.getLabel();
        }
    }

    class Headphones extends Product {
        constructor(manufacturer, model, price, quality, hasMicrophone) {
            super(manufacturer, model, price);
            this.count = 0;
            this.id = getId();
            this.quality = quality;
            this.hasMicrophone = hasMicrophone;
        }

        get quality() {
            return this._quality;
        }

        set quality(val) {
            validate.ifCorrectQuality(val);
            this._quality = val;
        }

        get hasMicrophone() {
            return this._hasMicrophone;
        }

        set hasMicrophone(val) {
            this._hasMicrophone = (val) ? true : false;
        }

        getLabel() {
            return 'Headphones' + super.getLabel();
        }
    }

    class HardwareStore {
        constructor(name) {
            this.name = name;
            this.products = [];
            this.money = 0;
        }

        get name() {
            return this._name;
        }

        set name(val) {
            validate.ifCorrectLength(val, 'Name');
            this._name = val;
        }

        stock(product, quantity) {
            validate.ifIsPositiveInteger(quantity, 'Quantity');
            if (!(product instanceof Product)) {
                throw new Error('Product must be instance of Product!');
            }
            let searched = this.products.find(x => x.id === product.id);
            if (this.products.indexOf(searched) >= 0) {
                searched.count += quantity;
            } else {
                product.count = quantity;
                this.products.push(product);
            }
            return this;
        }

        sell(productId, quantity) {
            validate.ifIsPositiveInteger(quantity, 'Quantity');
            let foundProduct = this.products.find(x => x.id === productId);
            if (foundProduct.count < quantity) {
                throw new Error('Quantity is not enough to cell!');
            }

            let foundIndex = this.products.indexOf(foundProduct);
            if (foundProduct.count === quantity) {
                this.products.splice(foundIndex, 1);
            } else {
                foundProduct.count -= quantity;
            }
            this.money += foundProduct.price * quantity;
            return this;
        }

        getSold() {
            return this.money;
        }

        search(x) {
            if (typeof x === 'string') {
                x = x.toLowerCase();
                return this.products.filter(p => (p.manufacturer.toLowerCase().indexOf(x) >= 0 || p.model.toLowerCase().indexOf(x) >= 0)).map(function(f) {
                    return ({ product: f, quantity: f.count });
                });
            } else if (typeof x === 'object') {
                return this.products
                    .filter(function(p) {
                        let isProduct = true;
                        if (x.hasOwnProperty('manufacturerPattern')) {
                            isProduct = p.manufacturer.toLowerCase().indexOf(x.manufacturerPattern.toLowerCase()) >= 0;
                            if (isProduct === false) return false;
                        }
                        if (x.hasOwnProperty('modelPattern')) {
                            isProduct = p.model.toLowerCase().indexOf(x.modelPattern.toLowerCase()) >= 0;
                            if (isProduct === false) return false;
                        }
                        if (x.hasOwnProperty('type')) {
                            isProduct = p.constructor.name === x.type;
                            if (isProduct === false) return false;
                        }
                        if (x.hasOwnProperty('minPrice')) {
                            isProduct = p.price >= x.minPrice;
                            if (isProduct === false) return false;
                        }
                        if (x.hasOwnProperty('maxPrice')) {
                            isProduct = p.price <= x.maxPrice;
                            if (isProduct === false) return false;
                        }
                        return true;
                    })
                    .map(function(f) {
                        return ({ product: f, quantity: f.count });
                    });
            } else {
                throw new Error('Options are not set properly!');
            }
        }
    }

    return {
        getSmartPhone(manufacturer, model, price, screenSize, operatingSystem) {
            // returns SmarhPhone instance
            return new SmartPhone(manufacturer, model, price, screenSize, operatingSystem);
        },
        getCharger(manufacturer, model, price, outputVoltage, outputCurrent) {
            // returns Charger instance
            return new Charger(manufacturer, model, price, outputVoltage, outputCurrent);
        },
        getRouter(manufacturer, model, price, wifiRange, lanPorts) {
            // returns Router instance
            return new Router(manufacturer, model, price, wifiRange, lanPorts);
        },
        getHeadphones(manufacturer, model, price, quality, hasMicrophone) {
            // returns Headphones instance
            return new Headphones(manufacturer, model, price, quality, hasMicrophone);
        },
        getHardwareStore(name) {
            // returns HardwareStore instance
            return new HardwareStore(name);
        }
    };
}

// Submit the code above this line in bgcoder.com
module.exports = solve; // DO NOT SUBMIT THIS LINE

// tests

const result = solve();

const phone = result.getSmartPhone('HTC', 'One', 903, 5, 'Android');

console.log(phone.getLabel()); // SmartPhone - HTC One - **903**

const headphones = result.getHeadphones('Sennheiser', 'PXC 550 Wireless', 340, 'high', false);
const store = result.getHardwareStore('Magazin');

store.stock(phone, 1)
    .stock(headphones, 15);

console.log(store.search('senn'));
/*
[ { product:
     Headphones { ... },
    quantity: 15 } ]
*/

console.log(store.search({ type: 'SmartPhone', maxPrice: 1000 }));
/*
[ { product:
     SmartPhone { ... },
    quantity: 1 } ]
*/

console.log(store.search({ type: 'SmartPhone', maxPrice: 900 }));
/* [] */

store.sell(headphones.id, 2);
console.log(store.getSold()); // 680