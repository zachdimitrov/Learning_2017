function solve() {
    function getProduct(productType, name, price) {
        // validations
        return {
            productType: productType,
            name: name,
            price: price
        };
    }

    function getShoppingCart() {
        const products = [];

        function add(product) {
            products.push(getProduct(product.name, product.productType, product.price));
            return this;
        }

        function remove(product) {
            const index = products.findIndex(p => p.name === product.name && p.productType === product.productType && p.price === product.price);
            if (index < 0) {
                throw new Error("Produst not found in cart!");
            } else {
                products.splice(index, 1);
            }
            return this;
        }

        function showCost() {
            return products.reduce((cost, b) => cost + b.price, 0);
        }

        function showProductTypes() {
            /* 
            const uniqTypes = [];
             for (const p of products) {
                 if (uniqTypes.indexOf(p.productType) < 0) {
                     uniqTypes.push(p.productType);
                 }
             }
             return uniqTypes.sort();
             */

            /*
            return products.map(p => p.productType)
                .sort()
                .filter((p, i, ps) => i === 0 || p !== ps[i - 1]);
            */

            const uniqTypesObj = {};
            products.forEach(p => uniqTypesObj[p.productType] = true);
            return Object.keys(uniqTypesObj).sort();
        }

        function getInfo() {
            /*
            const uniqNames = products.map(p => p.name)
                .sort()
                .filter((p, i, ps) => i === 0 || p !== ps[i - 1])
                .map(name => {
                    const thisName = products.filter(p => p.name === name);
                    return {
                        name: name,
                        quantity: thisName.length,
                        totalPrice: thisName.reduce((cost, b) => cost + b.price, 0)
                    };
                });   

            return {
                products: uniqNames,
                totalPrice: showCost()
            }
            */

            const groupedByName = {};

            products.forEach(p => {
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

            /*
            finalProducts = Object.keys(groupedByName)
                .sort()
                .map(n => {
                    return {
                        name: n,
                        quantity: groupedByName[n].quantity,
                        totalPrice: groupedByName[n].totalPrice
                    };
                });
            */

            return {
                products: Object.keys(groupedByName).map(k => groupedByName[k]).sort(x => x.name),
                // Object.values(groupedByName).sort(x => x.name) // not working with not current node.js
                totalPrice: showCost()
            }
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

/*
const result = solve();
const cart = result.getShoppingCart();
cart.add(result.getProduct("shokolad", "milka", 2))
    .add(result.getProduct("vafla", "mura", 1))
    .add(result.getProduct("meso", "svinsko", 5))
    .remove(result.getProduct("meso", "svinsko", 5));
console.log(cart);
*/