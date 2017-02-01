function solve() {

    function getProduct(productType, name, price) {
        let product = {};
        product.productType = productType;
        product.name = name;
        product.price = +price;
        return product;
    }

    function getShoppingCart() {
        let products = [];

        function add(product) {
            if (product.name && product.productType && product.price) {
                products.push(product);
            } else {
                throw "Error";
            }
            return this;
        }

        function remove(product) {
            if (product.hasOwnProperty("productType") && product.hasOwnProperty("name") && product.hasOwnProperty("price")) {
                if (products.indexOf(product) < 0) {
                    throw new Error('No such product in cart!');
                } else {
                    products.splice(products.indexOf(product), 1);
                }
            } else {
                throw new Error('Product is not correct!');
            }
            return this;
        }

        function showCost() {
            let cost = 0;
            for (let p of products) {
                cost += p.price;
            }
            return cost;
        }

        function showProductTypes() {
            let types = [];
            for (let p in products) {
                if (types.indexOf(products[p].productType) < 0) {
                    types.push(products[p].productType);
                }
            }

            types.sort(function(a, b) {
                if (a < b) { return -1; }
                if (a > b) { return 1; }
                return 0;
            });

            return types;
        }

        function getInfo() {
            let info = {};
            let sorted = [];

            info.totalPrice = showCost();

            for (i = 0; i < products.length; i++) {
                let found = false;
                let foundObj;
                for (j = 0; j < sorted.length; j++) {
                    if (products[i].name === sorted[j].name) {
                        found = true;
                        foundObj = sorted[j];
                    }
                }
                if (!found) {
                    sorted.push({
                        name: products[i].name,
                        quantity: 1,
                        totalPrice: products[i].price
                    });
                } else {
                    foundObj.quantity++;
                    foundObj.totalPrice += products[i].price;
                }
            }

            sorted.sort(function(a, b) {
                if (a < b) { return -1; }
                if (a > b) { return 1; }
                return 0;
            });

            info.products = sorted;
            return info;
        }

        return {
            products: products,
            add: add,
            remove: remove,
            showCost: showCost,
            showProductTypes: showProductTypes,
            getInfo: getInfo
        }
    }

    return {
        getProduct: getProduct,
        getShoppingCart: getShoppingCart
    };
}

module.exports = solve();