function solve() {
    const CONST = {
        MAX_NAME: 25,
        MIN_NAME: 3,
        MAX_IMDB: 5,
        MIN_IMDB: 1,
    }

    const validate = {
        ifNumberIsCorrect: function(val, name) {
            name = name || 'Value';
            if (typeof(val) !== 'number') {
                throw new Error(`${name} must be a number!`);
            } else if (val < 0) {
                throw new Error(`${name} must be greater than zero!`);
            }
        },
        ifStringIsCorrect: function(val, name) {
            name = name || 'Value';
            if (typeof(val) !== 'string') {
                throw new Error(`${name} must be a string!`);
            } else if (val.length < 3 || val.length > 25) {
                throw new Error(`${name} must be between ${CONST.MIN_NAME} and ${CONST.MAX_NAME} symbols long!`)
            }
        },
        ifImdbIsCorrect: function(val) {
            if (typeof(val) !== 'number') {
                throw new Error('Imdb rating must be a number!');
            } else if (val < 1 || val > 5) {
                throw new Error(`Imdb rating must be between ${CONST.MIN_IMDB} and ${CONST.MAX_IMDB}!`);
            }
        }
    }

    const getId = (function() {
        let id = 0;
        return function() {
            id += 1;
            return id;
        };
    }());

    class Playable {
        constructor(title, author) {
            this.id = getId();
            this.title = title;
            this.author = author;
        }

        get title() {
            return this._title;
        }

        set title(val) {
            validate.ifStringIsCorrect(val, 'Title');
            this._title = val;
        }

        get author() {
            return this._author;
        }

        set author(val) {
            validate.ifStringIsCorrect(val, 'Author');
            this._author = val;
        }

        play() {
            return `${this.id}. ${this.title} - ${this.author}`;
        }
    }

    class Audio extends Playable {
        constructor(title, author, length) {
            super(title, author);
            this.length = length;
        }

        get length() {
            return this._length;
        }

        set length(val) {
            validate.ifNumberIsCorrect(val, 'Length');
            this._length = val;
        }

        play() {
            return super.play() + ` - ${this.length}`;
        }
    }

    class Video extends Playable {
        constructor(title, author, imdbRating) {
            super(title, author);
            this.imdbRating = imdbRating;
        }

        get imdbRating() {
            return this._imdbRating;
        }

        set imdbRating(val) {
            validate.ifImdbIsCorrect(val);
            this._imdbRating = val;
        }

        play() {
            return super.play() + ` - ${this.imdbRating}`
        }
    }

    class Player {
        constructor(name) {
            this.name = name;
        }

        get name() {
            return this._name;
        }

        set name(val) {
            validate.ifStringIsCorrect();
            shis._name = val;
        }


    }

    var module = {
        getPlayer: function(name) {
            // returns a new player instance with the provided name
        },
        getPlaylist: function(name) {
            //returns a new playlist instance with the provided name
        },
        getAudio: function(title, author, length) {
            return new Audio(title, author, length);
        },
        getVideo: function(title, author, imdbRating) {
            return new Video(title, author, imdbRating);
        }
    };
    return module;
}

module.exports = solve;

/*
let audio = module.getAudio('Klasika', 'Ivan', 4);
console.log(audio.play());
let video = module.getVideo('Film', 'Kopola', 4);
console.log(video.play());
*/