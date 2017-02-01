function solve() {
    var module = (function() {
        var playable, audio, video, validator,
            CONSTANTS = {
                TEXT_MIN_LENGTH: 3,
                TEXT_MAX_LENGTH: 25
            };

        validator = {
            validateIfUndefined: function(val, name) {
                name = name || 'value';
                if (val === undefined) {
                    throw new Error(name + " cannot be undefined!");
                }
            },
            validateString: function(val, name) {
                name = name || 'Value';
                this.validateIfUndefined(val, name);

                if (typeof(val) !== 'string') {
                    throw new Error(name + " must be a string!");
                }

                if (val.length < CONSTANTS.TEXT_MIN_LENGTH || val.length > CONSTANTS.TEXT_MAX_LENGTH) {
                    throw new Error(name + " must be between " + CONSTANTS.TEXT_MIN_LENGTH + " and " + CONSTANTS.TEXT_MAX_LENGTH + " symbols!");
                }
            },
            validatePositiveNumber: function(val, name) {
                name = name || 'value';
                this.validateIfUndefined(val, name);
                if (typeof(val) !== 'number') {
                    throw new Error(name + ' must be a number!');
                }

                if (val <= 0) {
                    throw new Error(name + ' must be positive!');
                }
            }
        };

        playable = (function() {
            var currentPlayableID = 0,
                playable = Object.create({});

            Object.defineProperty(playable, 'init', {
                value: function(title, author) {
                    this.title = title;
                    this.author = author;
                    this._id = ++currentPlayableID;
                }
            });

            Object.defineProperty(playable, 'id', {
                get: function() {
                    return this._id;
                }
            });

            Object.defineProperty(playable, 'title', {
                get: function() {
                    return this._title;
                },
                set: function(val) {
                    validator.validateString(val, 'Playable title');
                    this._title = val;
                }
            });

            Object.defineProperty(playable, 'author', {
                get: function() {
                    return this._author;
                },
                set: function(val) {
                    validator.validateString(val, 'Playable author');
                    this._author = val;
                }
            });

            Object.defineProperty(playable, 'play', {
                value: function() {
                    return this.id + ' ' + this.title + ' - ' + this.author;
                }
            });

            return playable;
        }());

        audio = (function(parent) {
            var audio = Object.create(parent);

            Object.defineProperty(audio, 'init', {
                value: function(title, author, length) {
                    parent.init.call(this, title, author);
                    this.length = length;
                    return this;
                }
            });

            Object.defineProperty(audio, 'length', {
                get: function() {
                    return this._length;
                },
                set: function(val) {
                    validator.validatePositiveNumber(val, 'Audio length');
                    this._length = val;
                }
            });

            Object.defineProperty(audio, 'play', {
                value: function() {
                    return parent.play.call(this) + ' - ' + this.length;
                }
            });

            return audio;
        }(playable));

        video = (function(parent) {
            var video = Object.create(parent);

            Object.defineProperty(video, 'init', {
                value: function(title, author, imdbRating) {
                    parent.init.call(this, title, author);
                    this.imdbRating = imdbRating;
                    return this;
                }
            });

            Object.defineProperty(video, 'imdbRating', {
                get: function() {
                    return this._imdbRating;
                },
                set: function(val) {

                }
            });

            return video;
        }(playable));

        return {
            getPlayer: function(name) {
                // returns new player instance with provided name
            },
            getPlaylist: function(name) {
                // returns a new playlist instance with provided name
            },
            getAudio: function(title, author, length) {
                // returns a new audio instance with provided params
                return Object.create(audio).init(title, author, length);
            },
            getVideo: function(title, author, imdbRating) {
                // returns a new video instance with provided params
            }
        };

    }());

    return module;
}

// TESTS

var module = solve();
for (var i = 1; i < 10; i++) {
    var currentAudio = module.getAudio("Audio " + i, "Author " + i, i * 0.75);
    console.log(currentAudio.play());
}