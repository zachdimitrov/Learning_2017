/* globals module */

"use strict";

function solve() {
    class Product {
        constructor(productType, name, price) {
            this._productType = productType;
            this._name = name;
            this._price = price;
        }

        get productType() {
            return this._productType;
        }

        get name() {
            return this._name;
        }

        get price() {
            return this._price;
        }
    }

    class ShoppingCart {
        constructor() {
            this._products = [];
        }

        get products() {
            return this._products;
            // return this._products.slice() // za da vyrne kopie
        }

        add(product) {
            this.products.push(product);
            return this;
        }

        remove(product) {
            const index = this.products.findIndex(p => p.name === product.name && p.productType === product.productType && p.price === product.price);
            if (index < 0) {
                throw new Error("Produst not found in cart!");
            } else {
                this.products.splice(index, 1);
            }
            return this;
        }

        showCost() {
            return this.products.reduce((cost, b) => cost + b.price, 0);
        }

        showProductTypes() {

            const uniqTypesObj = {};
            this.products.forEach(p => uniqTypesObj[p.productType] = true);
            return Object.keys(uniqTypesObj).sort();
        }

        getInfo() {
            const groupedByName = {};

            this.products.forEach(p => {
                if (groupedByName.hasOwnProperty(p.name)) {
                    groupedByName[p.name].quantity += 1;
                    groupedByName[p.name].totalPrice += p.price;
                } else {
                    groupedByName[p.name] = {
                        name: p.name,
                        totalPrice: p.price,
                        quantity: 1
                    };
                }
            });

            return {
                products: Object.keys(groupedByName).map(k => groupedByName[k]).sort(x => x.name),
                totalPrice: this.showCost()
            };
        }
    }

    return {
        Product: Product,
        ShoppingCart: ShoppingCart
    };
}

// BG Coder to here

module.exports = solve;

// tests

let { Product, ShoppingCart } = solve();

let cart = new ShoppingCart();

let pr1 = new Product("Sweets", "Shokolad Milka", 2);
cart.add(pr1);
console.log(cart.showCost());
//prints `2`

let pr2 = new Product("Groceries", "Salad", 0.5);
cart.add(pr2);
cart.add(pr2);
console.log(cart.showCost());
//prints `3`

console.log(cart.showProductTypes());
//prints ["Sweets", "Groceries"]

console.log(cart.getInfo());
/* prints
{
    totalPrice: 3
    products: [{
        name: "Salad",
        totalPrice: 1,
        quantity: 2
    }, {
       name: "Shokolad Milka",
       totalPrice: 2,
       quantity: 1 
    }]
}
*/

cart.remove({ name: "Salad", productType: "Groceries", price: 0.5 })
console.log(cart.getInfo());
/* prints
{
    totalPrice: 2.5
    products: [{
        name: "Salad",
        totalPrice: 0.5,
        quantity: 1
    }, {
       name: "Shokolad Milka",
       totalPrice: 2,
       quantity: 1 
    }]
}
*/