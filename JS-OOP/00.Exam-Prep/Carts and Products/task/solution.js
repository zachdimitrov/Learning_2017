function solve() {
    const validate = {
        ifString: function(val, name) {
            name = name || 'Value';
            if (typeof val !== 'string') {
                throw new Error(name + ' must be a string!');
            }
        },
        ifNumber: function(val, name) {
            name = name || 'Value';
            if (typeof val !== 'number') {
                throw new Error(name = ' must be a number!');
            }
        },
        ifIsProductLike: function(val) {
            ['productType', 'name', 'price'].forEach(prop => {
                if (typeof val[prop] === 'undefined') {
                    throw new Error('Value must be product or product-like!');
                }
            });
        }
    }
    class Product {
        constructor(productType, name, price) {
            this.productType = productType;
            this.name = name;
            this.price = price;
        }

        get productType() {
            return this._productType;
        }

        set productType(val) {
            validate.ifString(val);
            this._productType = val;
        }

        get name() {
            return this._name;
        }

        set name(val) {
            validate.ifString(val);
            this._name = val;
        }

        get price() {
            return this._price;
        }

        set price(val) {
            validate.ifNumber(val);
            this._price = val;
        }
    }

    class ShoppingCart {
        constructor() {
            this.products = [];
        }

        add(product) {
            validate.ifIsProductLike(product);
            this.products.push(product);
            return this;
        }

        remove(product) {
            validate.ifIsProductLike(product);
            let i = this.products.indexOf(product);
            if (i < 0) {
                throw new Error('Product is not in the shopping cart!');
            }
            this.products.splice(i, 1);
        }

        showCost() {
            let result = 0;
            this.products.map(p => result += p.price);
            return result;
        }

        showProductTypes() {
            let types = [];
            this.products.map(p => {
                if (types.indexOf(p.productType) < 0) {
                    types.push(p.productType);
                }
            });
            return types.sort();
        }

        getInfo() {
            let info = {};
            info.products = [];
            info.totalPrice = 0;
            this.products.forEach(p => {
                let pushed = info.products.find(prod => prod.name === p.name);
                if (info.products.length === 0 || typeof pushed === 'undefined') {
                    info.products.push({
                        name: p.name,
                        totalPrice: p.price,
                        quantity: 1
                    });
                    info.totalPrice += p.price;
                } else {
                    pushed.totalPrice += p.price;
                    pushed.quantity++;
                    info.totalPrice += p.price;
                }
            });
            return info;
        }
    }

    return {
        Product,
        ShoppingCart
    };
}

module.exports = solve;