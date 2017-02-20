/* globals module */

function solve() {
    const CONST = {
        MIN_STR_LENGTH: 2,
        MAX_NAME_LENGTH: 40,
        MAX_GENRE_LENGTH: 20,
        MIN_RATING: 1,
        MAX_RATING: 5,
        ISBN: [10, 13]
    };

    const getId = (function() {
        let id = 0;

        return function() {
            id += 1;
            return id;
        };
    }());

    const validate = {
        numberGreaterThanZero(val) {
            if (typeof(val) !== 'number' || val <= 0) {
                throw new Error('Number must be greater then zero!');
            }
        },
        rating(val) {
            if (typeof(val) !== 'number' || val < CONST.MIN_RATING || val > CONST.MAX_RATING) {
                throw new Error(`Rating must be between ${CONST.MIN_RATING} and ${CONST.MAX_RATING}!`)
            }
        },
        ifIsNonEmptyString: function(val, name) {
            name = name || 'Value';
            if (typeof(val) !== 'string' || val.length === 0) {
                throw new Error(nae + ' must be a non empty string!');
            }
        },
        name: function(val) {
            if (typeof(val) !== 'string' || val.length < CONST.MIN_STR_LENGTH || val.length > CONST.MAX_NAME_LENGTH) {
                throw new Error(`Name must be string between ${CONST.MIN_STR_LENGTH} and ${CONST.MAX_NAME_LENGTH} symbols!`);
            }
        },
        genre: function(val) {
            if (typeof(val) !== 'string' || val.length < CONST.MIN_STR_LENGTH || val.length > CONST.MAX_GENRE_LENGTH) {
                throw new Error(`Name must be string between ${CONST.MIN_STR_LENGTH} and ${CONST.MAX_GENRE_LENGTH} symbols!`);
            }
        },
        isbn: function(val) {
            if (typeof(val) !== 'string' || (val.length !== CONST.ISBN[0] && val.length !== CONST.ISBN[1])) {
                throw new Error(`Isbn must be exactly ${CONST.ISBN[0]} or ${CONST.ISBN[1]} symbols!`);
            }
        }
    };
    // ITEM
    class Item {
        constructor(description, name) {
                this._id = getId();
                this.description = description;
                this.name = name;
            }
            // increment id
        static incrementId() {
                if (this._lastId === undefined) {
                    this._lastId = 1;
                } else {
                    this._lastId++;
                }
                return this._lastId;
            }
            // id
        get id() {
            return this._id;
        }

        // description
        get description() {
            return this._description;
        }
        set description(val) {
            validate.ifIsNonEmptyString(val, 'Description');
            this._description = val;
        }

        // name
        get name() {
            return this._name;
        }

        set name(val) {
            validate.name(val);
            this._name = val;
        }
    }

    // Book
    class Book extends Item {
        constructor(name, isbn, genre, description) {
            super(description, name);
            this.isbn = isbn;
            this.genre = genre;
        }

        get isbn() {
            return this._isbn;
        }

        set isbn(val) {
            validate.isbn(val);
            this._isbn = val;
        }

        get genre() {
            return this._genre;
        }

        set genre(val) {
            validate.genre(val);
            this._genre = val;
        }
    }

    // Media
    class Media extends Item {
        constructor(name, rating, duration, description) {
            super(description, name);
            this.duration = duration;
            this.rating = rating;
        }

        get duration() {
            return this._duration;
        }

        set duration(val) {
            validate.numberGreaterThanZero(val);
            this._duration = val;
        }

        get rating() {
            return this._rating;
        }

        set rating(val) {
            validate.rating(val);
            this._rating = val;
        }
    }

    class Catalog {
        constructor(name) {
            this._id = getId();
            this.name = name;
            this.items = [];
        }

        get id() {
            return this._id;
        }

        get name() {
            return this._name;
        }

        set name(val) {
            validate.name(val);
            this._name = val;
        }

        add(...items) {
            if (items.length === 0) {
                throw new Error(`No items were passed to store in ${this.name}!`);
            }

            if (Array.isArray(items[0])) {
                items = items[0];
            }

            // if (items.some(x => typeof(x) !== 'Item')) {
            //     throw new Error(`One or more items is not an Item instance!`)
            // }

            items.forEach(x => this.items.push(x));
            return this;
        }

        find(value) {
            if (typeof(value) === 'number' && value >= 0) {
                let id = value;
                for (let i in this.items) {
                    if (this.items[i].id === value) {
                        return this.items[i];
                    }
                }
            } else if (value !== null && typeof(value) === 'object') {
                /*
                return this.items.filter(function(x) {
                    let foundId = true,
                        foundName = true;
                    if (value.id !== undefined) {
                        foundId = x.id === value.id;
                    }
                    if (value.name !== undefined) {
                        foundName = x.name === value.name;
                    }
                    return foundId && foundName;
                });
                */
                return this.items.filter(function(item) {
                    return Object.keys(value).every(function(prop) {
                        return value[prop] === item[prop];
                    });
                });
            } else {
                throw new Error('No valid options given!');
            }
            return null;
        }

        search(pattern) {
            validate.ifIsNonEmptyString(pattern);
            let result = this.items.filter(x => x.name.indexOf(pattern) >= 0 || x.description.indexOf(pattern) >= 0);
            return result;
        }
    }

    class BookCatalog extends Catalog {
        constructor(name) {
            super(name);
        }

        add(...books) {
            if (books.length === 0) {
                throw new Error(`No items were passed to store in ${this.name}!`);
            }

            if (Array.isArray(books[0])) {
                books = books[0];
            }

            if (books.some(x => !(x instanceof Book))) {
                throw new Error(`One or more items is not a Book instance!`)
            }

            return super.add(...books);
        }

        getGenres() {
            let genres = {};
            this.items.forEach(function(item) {
                genres[item.genre] = true;
            });
            return Object.keys(genres);
        }

        find(options) {
            return super.find(options);
        }
    }

    class MediaCatalog extends Catalog {
        constructor(name) {
            super(name);
        }

        add(...medias) {
            if (medias.length === 0) {
                throw new Error(`No items were passed to store in ${this.name}!`);
            }

            if (Array.isArray(medias[0])) {
                medias = medias[0];
            }

            if (medias.some(x => !(x instanceof Media))) {
                throw new Error(`One or more items is not a Book instance!`)
            }

            return super.add(...medias);
        }

        getTop(count) {
            validate.numberGreaterThanZero(count);
            let top = [];
            this.items
                .sort((x, y) => x.rating - y.rating)
                .slice(0, count)
                .forEach(function(item) {
                    let itemObj = {};
                    itemObj.id = item.id;
                    itemObj.name = item.name;
                    top.push(itemObj);
                });
            return top;
        }

        getSortedByDuration() {
            return this.items
                .sort((x, y) => y.duration - x.duration === 0 ? x.id - y.id : y.duration - x.duration);
        }

        find(options) {
            return super.find(options);
        }
    }

    return {
        getBook: function(name, isbn, genre, description) {
            return new Book(name, isbn, genre, description);
        },
        getMedia: function(name, rating, duration, description) {
            return new Media(name, rating, duration, description);
        },
        getBookCatalog: function(name) {
            return new BookCatalog(name);
        },
        getMediaCatalog: function(name) {
            return new MediaCatalog(name);
        }
    };
}

module.exports = solve;