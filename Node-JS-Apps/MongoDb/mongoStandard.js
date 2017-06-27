const mongodb = require('mongodb');
const MongoClient = mongodb.MongoClient;

const protocol = 'mongodb:/';
const server = 'localhost:27017';
const databaseName = 'Students';

const connectionString = `${protocol}/${server}/${databaseName}`;

MongoClient.connect(connectionString)
    .then((db) => {
        const collectionNames = 'Names';
        db.collection(collectionNames)
            .insert({
                firstName: 'Georgi',
                lastName: 'Ivanov',
                age: '55',
            });
        return db;
    })
    .then((db) => {
        const names = db.collection('Names')
            .find({})
            .toArray();
        db.close();
        return names;
    })
    .then((result) => {
        console.log(result);
    })
    .catch((error) => {
        console.log(error);
    });

"1.03.53"