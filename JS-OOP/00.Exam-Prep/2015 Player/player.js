function solve() {
    var module = (function() {
        var player, playlist, playable, audio, video, validator,
            CONSTANTS = {
                TEXT_MIN_LENGTH: 3,
                TEXT_MAX_LENGTH: 25,
                IMDB_MIN_RATING: 1,
                IMDB_MAX_RATING: 5
            };

        function indexOfPlayableFromCollecttion(collection, id) {
            var i, len;
            for (i = 0, len = collection.length; i < len; i += 1) {
                if (collection.id === id) {
                    return i;
                }
            }
            return -1;
        }

        function getSortingFunction(firstParameter, secondParameter) {
            return function(first, second) {
                if (first[firstParameter] < second[firstParameter]) {
                    return -1;
                } else if (first[firstParameter] > second[firstParameter]) {
                    return 1;
                }

                if (first[secondParameter] < second[secondParameter]) {
                    return -1;
                } else if (first[secondParameter] > second[secondParameter]) {
                    return 1;
                } else {
                    return 0;
                }
            }
        }

        validator = {
            validateIfUndefined: function(val, name) {
                name = name || 'value';
                if (val === undefined) {
                    throw new Error(name + " cannot be undefined!");
                }
            },
            validateIfObject: function(val, name) {
                if (typeof(val) !== 'object') {
                    throw new Error(name + ' must be an object!');
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
            validateIfNumber: function(val, name) {
                name = name || 'Value';
                if (typeof(val) !== 'number') {
                    throw new Error(name + ' must be a number!');
                }
            },
            validatePositiveNumber: function(val, name) {
                name = name || 'value';
                this.validateIfUndefined(val, name);
                this.validateIfNumber(val, name);
                if (val <= 0) {
                    throw new Error(name + ' must be positive!');
                }
            },
            validateImdbRating: function(val) {
                this.validateIfUndefined(val, 'Imdb rating');
                this.validateIfNumber(val, 'Imdb rating');
                if (val < CONSTANTS.IMDB_MIN_RATING || val > CONSTANTS.IMDB_MAX_RATING) {
                    throw new Error('Imdb rating must be between ' + CONSTANTS.IMDB_MIN_RATING + ' and ' + CONSTANTS.IMDB_MAX_RATING + '!');
                }
            },
            validateId: function(id) {
                this.validateIfUndefined(id, 'Object id');
                if (typeof(id) !== 'number') {
                    id = id.id;
                }

                this.validateIfUndefined(id, 'Object must have id!');
                return id;
            },
            validatePageSize: function(page, size, maxElements) {
                this.validateIfUndefined(page);
                this.validateIfNumber(page);
                this.validateIfUndefined(size);
                this.validateIfNumber(size);
                if (page < 0) {
                    throw new Error('Page must be greater than 0!');
                }

                this.validatePositiveNumber(size, 'Size');
                if (page * size > maxElements) {
                    throw new Error('Page * size too large!');
                }
            }
        };

        player = (function() {
            var currentPlayerId = 0,
                player = Object.create({});

            Object.defineProperty(player, 'init', {
                value: function(name) {
                    this.name = name;
                    this._id = ++currentPlayerId;
                    this._playlists = [];
                    return this;
                }
            });

            Object.defineProperty(player, 'id', {
                get: function() {
                    return this._id;
                }
            })

            Object.defineProperty(player, 'name', {
                get: function() {
                    return this._name;
                },
                set: function(val) {
                    validator.validateString(val, 'Player name');
                    this._name = val;
                }
            });

            Object.defineProperty(player, 'addPlaylist', {
                value: function(playlist) {
                    validator.validateIfUndefined(playlist, 'Playlist does not exist!');
                    if (playlist.id === undefined) {
                        throw new Error('Playlist must have ID!');
                    }
                    this._playlists.push(playlist);
                    return this;
                }
            });

            Object.defineProperty(player, 'getPlaylistById', {
                value: function(id) {
                    var i, len;
                    validator.validateIfUndefined(id, 'Playlist id');
                    validator.validateIfNumber(id, 'Playlist id');
                    var foundIndex = indexOfPlayableFromCollecttion(this._playlists, id);
                    if (foundIndex < 0) {
                        return null;
                    }
                    return this._playlists[foundIndex];
                }
            });

            Object.defineProperty(player, 'contains', {
                value: function(playable, playlist) {
                    validator.validateIfUndefined(playable);
                    validator.validateIfUndefined(playlist);
                    var playableId = validator.validateId(playable.id);
                    var playlistId = validator.validateId(playlist.id);

                    var playlist = this.getPlaylistById(playlistId);
                    if (foundplaylist === null) {
                        return false;
                    }
                    var playable = playlist.getPlayableById(playableId);
                    if (playable === null) {
                        return false;
                    }
                    return true;
                }
            });

            Object.defineProperty(player, 'search', {
                value: function(pattern) {
                    validator.validateString(pattern, 'Pattern');
                    return this._playlists
                        .filter(function(playlist) {
                            return playlist.listPlayables()
                                .some(function(playable) {
                                    return playable.length !== undefined &&
                                        playable
                                        .title
                                        .toLowerCase()
                                        .indexOf(pattern.toLowerCase()) >= 0
                                });
                        })
                        .map(function(playlist) {
                            return {
                                id: playlist.id,
                                name: playlist.name
                            };
                        });
                }
            });

            return player;
        }());

        Object.defineProperty(player, 'removePlaylist', {
            valie: function(id) {
                id = validator.validateId(id);

                var foundIndex = indexOfPlayableFromCollecttion(this._playlists, id);

                if (foundIndex < 0) {
                    throw new Error('Playlist with id ' + id + ' was not found!');
                }
                this._playlists.splise(foundIndex, 1);
                return this;
            }
        });

        Object.defineProperty(player, 'listPlaylists', {
            value: function(page, size) {
                validator.validatePageSize(page, size, this._playlists.length);
                return this._playlists
                    .slice()
                    .sort(getSortingFunction('name', 'id'))
                    .splice(page * size, size);
            }
        });

        playlist = (function() {
            var currentPlaylistId = 0,
                playlist = Object.create({});

            Object.defineProperty(playlist, 'init', {
                value: function(name) {
                    this.name = name;
                    this._id = ++currentPlaylistId;
                    this._playables = [];
                    return this;
                }
            });

            Object.defineProperty(playlist, 'name', {
                get: function() {
                    return this._name;
                },
                set: function(val) {
                    validator.validateString(val, 'Playlist name');
                    this._name = val;
                }
            });

            Object.defineProperty(playlist, 'addPlayable', {
                value: function(playable) {
                    validator.validateIfUndefined(playable, 'Playable');
                    validator.validateIfObject(playable, 'Playable');
                    validator.validateIfUndefined(playable.id, 'Playlist must have id!');

                    this._playables.push(playable);
                    return this;
                }
            });

            Object.defineProperty(playlist, 'getPlayableById', {
                value: function(id) {
                    var i, len;
                    validator.validateIfUndefined(id, 'Playlist id');
                    validator.validateIfNumber(id, 'Playlist id');
                    var foundIndex = indexOfPlayableFromCollecttion(this._playables, id);
                    if (foundIndex < 0) {
                        return null;
                    }
                    return this._playables[foundIndex];
                }
            });

            Object.defineProperty(playlist, 'removePlayable', {
                valie: function(id) {
                    id = validator.validateId(id);

                    var foundIndex = indexOfPlayableFromCollecttion(this._playables, id);

                    if (foundIndex < 0) {
                        throw new Error('Playable with id ' + id + ' was not found!');
                    }
                    this._playables.splise(foundIndex, 1);
                    return this;
                }
            });

            Object.defineProperty(playlist, 'listPlayables', {
                value: function(page, size) {
                    page = page || 0;
                    size = size || Number.MAX_SAFE_INTEGER;
                    validator.validatePageSize(page, size, this._playables.length);
                    return this
                        ._playables
                        .slice()
                        .sort(getSortingFunction('title', 'id'))
                        .splice(page * size, size);
                }
            });

            Object.defineProperty(playlist, 'id', {
                get: function() {
                    return this._id;
                }
            });

            return playlist;
        }());

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
                    validator.validateImdbRating(val);
                    this._imdbRating = val;
                }
            });

            Object.defineProperty(video, 'play', {
                value: function() {
                    return parent.play.call(this) + ' - ' + this.imdbRating;
                }
            });

            return video;
        }(playable));

        return {
            getPlayer: function(name) {
                return Object.create(player).init(name);
                // returns new player instance with provided name
            },
            getPlaylist: function(name) {
                // returns a new playlist instance with provided name
                return Object.create(playlist).init(name);
            },
            getAudio: function(title, author, length) {
                // returns a new audio instance with provided params
                return Object.create(audio).init(title, author, length);
            },
            getVideo: function(title, author, imdbRating) {
                // returns a new video instance with provided params
                return Object.create(video).init(title, author, imdbRating);
            }
        };

    }());

    return module;
}

// TESTS

var module = solve();

var playlist = module.getPlaylist('My playlist');
var player = module.getPlayer('pesho');

for (var i = 1; i < 3; i++) {
    var currentAudio = module.getAudio("Audio " + i, "Author " + i, i * 0.75);
    console.log(currentAudio.play());
    playlist.addPlayable(currentAudio);
}

for (var i = 1; i < 3; i++) {
    var currentVideo = module.getVideo("Video " + i, "Author " + i, 3.5);
    console.log(currentVideo.play());
    playlist.addPlayable(currentVideo);
}
var audio = module.getAudio('ivan', 'ivanov', 4);
playlist.addPlayable(audio);

console.log(playlist);
console.log('------------------')
player.addPlaylist(playlist);
console.log(player.search('van'));