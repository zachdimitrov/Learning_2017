// Connection string
const mongoDbConnectionStr = 'mongodb://localhost:27017/computers';

// get a pending connection
const mongoose = require('mongoose');
mongoose.connect(mongoDbConnectionStr);

// get notified
// for connection status
const db = mongoose.connection;

db.on('error', (err) => {
    console.log('Connection failed! :(\n' + err);
});

db.once('open', () => {
    console.log('Connection successfully established!');

    // ======================
    // Use database
    // ======================

    // 1. create simple schema
    const modelSchema = mongoose.Schema({
        model: String,
        releaseDate: Date,
        priceInDollars: Number,
        displaySizeInInches: Number,
    });
    console.log('2. created schema');

    // 2. create model
    const modelName = 'Laptop';
    const Laptop = mongoose.model(modelName, modelSchema);

    // 3. create instance
    const asus = new Laptop({
        model: 'Asus G752',
        releaseDate: new Date(2016, 10, 12),
        priceInDollars: 1799,
        displaySizeInInches: 17.3,
    });

    // 4. save instance to DB
    asus.save((err, entry, numAffected) => {
        console.log(entry);
        console.log(numAffected);
    });

    // ======================
    // Nested schemas
    // ======================

    // create schema to nest
    const laptopSchema = mongoose.Schema({
        // use schema from above for laptop
        laptop: modelSchema,
        quantity: Number,
    });

    // create main schema
    const storeModelSchema = mongoose.Schema({
        name: String,
        address: String,
        laptops: [laptopSchema],
    });

    // create models
    const storeName = 'ComputerStore';
    const itemsName = 'Laptops'; // this is not needed
    const ItemModel = mongoose.model(itemsName, laptopSchema);
    const Store = mongoose.model(storeName, storeModelSchema);

    // create instances
    const laptop1 = new Laptop({
        model: 'Asus G752',
        releaseDate: new Date(2016, 10, 12),
        priceInDollars: 1799,
        displaySizeInInches: 17.3,
    });
    const laptop2 = new Laptop({
        model: 'Dell E5445',
        releaseDate: new Date(2012, 8, 22),
        priceInDollars: 799,
        displaySizeInInches: 15.4,
    });
    const laptop3 = new Laptop({
        model: 'Acer Aspire',
        releaseDate: new Date(2015, 6, 11),
        priceInDollars: 1200,
        displaySizeInInches: 15.6,
    });

    const myComputerStore = new Store({
        name: 'My Computer Store',
        address: 'Sofia, Mladost 1',
        laptops: [{
            laptop: laptop1,
            quantity: 19,
        }, {
            laptop: laptop2,
            quantity: 2,
        }, {
            laptop: laptop3,
            quantity: 12,
        }],
    });

    // save to DB
    myComputerStore.save((err, entry, numAffected) => {
        console.log(entry);
        console.log(numAffected);
    });

    // update object in DB
    Store.update({
            _id: '5951f91a0e1fe713b8b0bf95',
        }, {
            name: 'My Computer Store',
            address: 'Sofia, Mladost 1',
        },
        (err, entry) => {
            err ? console.log(err) : console.log('no errors');
            console.log(entry);
        });

    // ======================
    // Instance methods
    // ======================

    // do not use arrow functions (this is different)
    modelSchema.methods.getDescription = function() {
        const description = `
    Description of ${typeof(this)}:
     Model: ${this.model}
     Release date: ${this.releaseDate}
     Price: ${this.priceInDollars}$
     Display size: ${this.displaySizeInInches}`;

        return description;
    };
    console.log('3. created method');

    // create model
    const modelName = 'Laptop';
    const Laptop = mongoose.model(modelName, modelSchema);
    console.log('3.5. created model');

    const macLaptop = new Laptop({
        model: 'AirBook',
        releaseDate: new Date(2012, 6, 7),
        priceInDollars: 3222,
        displaySizeInInches: 15.3,
    });
    console.log('4. created object');

    macLaptop.save((err, entry) => {
            if (err) return console.error(err);
            console.log(entry);
            console.log(entry.getDescription());
            return null;
        })
        .then(() => {
            console.log('5. saved object');
        })
        .then(() => {
            db.close();
            console.log('6. closed connection');
        });

    // =================================
    // virtual properties and validation
    // =================================

    // define constraints
    const nameMatch = /[a-zA-Z1-9]/;
    const types = ['hairy', 'cute', 'big', 'small'];
    const stringValidator = {
        validator: function(val) {
            return ((val.length > 3) && (val.length < 40));
        },
        message: 'The color must be between 3 and 40 symbols long!',
    };

    // create schema
    const hamsterSchema = mongoose.Schema({
        name: {
            type: String,
            match: nameMatch, // regex validator
        },
        color: {
            type: String,
            validate: stringValidator, // use custom validator
        },
        type: {
            type: String,
            required: true,
            enum: types, // enum validator
        },
        kolibka: {
            type: Number,
            require: true, // validator required
            min: 10, // number validator min
            max: 60, // number validator max
        },
        birthDate: {
            type: Date,
            default: new Date(), // default value
        },
    });

    // create virtual property
    hamsterSchema.virtual('CurrentDate')
        .get(function() {
            const now = new Date();
            return (now.toDateString());
        })
        .set(function(date) {
            this.set('CurrentDate', date);
        });

    // create model
    const Hamster = mongoose.model('Hamster', hamsterSchema);

    // create object
    const hamsterObj = new Hamster({
        name: 'Pesho',
        color: 'white',
        type: 'hairy',
        kolibka: 30,
    });

    // save it to DB
    const promiseToSave = new Promise((res, rej) => {
        return hamsterObj.save((err, obj) => {
            if (err) rej(err);
            res(obj);
        });
    });

    // do this after save
    promiseToSave
        .then((obj) => {
            console.log(obj);
            console.log(obj.CurrentDate);
        })
        .then(() => {
            db.close();
            console.log('6. closed connection');
        })
        .catch((err) => {
            console.log(err);
            db.close();
            console.log('6. closed connection due to error');
        });

    // ==================
    // query the database
    // ==================

    // find
    Hamster.find((err, hamsters) => {
        if (err) console.log(err);
        console.log(hamsters);
    });

    // filter
    const filter = {
        color: 'white',
    };

    Hamster.find(filter, (err, hamsters) => {
        if (err) console.log(err);
        console.log(hamsters);
    });

    Hamster.findByIdAndUpdate('5952bc814b71c91460da312f', )
});
console.log('1. open connection');