const ItemsData = require('./items.data');
const Item = require('../models/item.model');

const init = (db) => {
    return Promise.resolve({
        items: new ItemsData(db, Item),
    });
};

module.exports = { init };