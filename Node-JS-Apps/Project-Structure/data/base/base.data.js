class BaseData {
    constructor(db, ModelClass, validator) {
        this.db = db;
        this.validator = validator;
        this.ModelClass = ModelClass;
        this.collectionName = this._getCollectionName();
        this.collection = this.db.collection(this.collectionName);
    }

    getAll() {
        const filter = {};
        const options = {};
        const result = this.collection.find(filter, options)
            .toArray();

        if (this.ModelClass.toViewModel) {
            result
                .then((models) => {
                    return models
                        .map((model) => this.ModelClass.toViewModel(model));
                });
        }

        return result;
    }

    create(model) {
        // call child class model validator
        if (!this._isModelValid(model)) {
            return Promise.reject('Invalid model!');
        }

        return this.collection.insert(model)
            .then(() => {
                return this.ModelClass.toViewModel(model);
            });
    }

    _getCollectionName() {
        return this.ModelClass.name.toLowerCase() + 's';
    }

    _isModelValid(model) {
        return this.validator.isValid(model);
    }
}

module.exports = BaseData;