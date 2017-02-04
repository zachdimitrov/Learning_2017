function solve() {
    var module;
    var validator = {
        validateTitle: function(title) {
            if (title[0].match(/\s/) || title[title.length - 1].match(/\s/)) {
                throw new Error('Titles do not start or end with spaces!');
            }
            if (title.match(/[' ']{2,}/g)) {
                throw new Error('Titles do not have consecutive spaces!');
            }
            if (title.length === 0) {
                throw new Error('Titles have at least one character!');
            }
        },
        validateIfArray: function(arr) {
            if (!(arr instanceof Array)) {
                throw new Error('This must be a collection!');
            }
        },
        validateIfArrayIsEmpty: function(arr) {
            if (arr.length <= 0) {
                throw new Error('Collection should not be empty!');
            }
        },
        validateFullName: function(name) {
            if (!(name.match(/^[A-Z]{1}[a-z]*\s[A-Z]{1}[a-z]*$/))) {
                throw new Error('Student name is not correct!');
            }
        },
        validateIfNumber: function(val) {
            if (typeof(val) !== 'number') {
                throw new Error('Value must be a number!');
            }
        }
    };

    module = (function() {
        var course = Object.create({})

        function indexOfStudent(id) {
            var i, len;
            for (i = 0, len = this._students.length; i < len; i += 1) {
                if (this._students[i].id === id) {
                    return i;
                }
            }
            return -1;
        }

        Object.defineProperty(course, 'init', {
            value: function(title, presentations) {
                this.title = title;
                this.presentations = presentations;
                this._students = [];
                this._results = {};
                this._studentID = 0;
                return this;
            }
        });

        Object.defineProperty(course, 'title', {
            get: function() {
                return this._title;
            },
            set: function(val) {
                validator.validateTitle(val);
                this._title = val;
            }
        });

        Object.defineProperty(course, 'presentations', {
            get: function() {
                return this._presentations;
            },
            set: function(val) {
                let collection = [];
                validator.validateIfArray(val);
                validator.validateIfArrayIsEmpty(val);
                for (let t in val) {
                    let title = val[t];
                    validator.validateTitle(title);
                    collection.push(title);
                }
                this._presentations = collection;
            }
        });

        Object.defineProperty(course, 'addStudent', {
            value: function(fullName) {
                validator.validateFullName(fullName);
                splitName = fullName.split(' ');

                let student = {},
                    result = {};

                student.firstname = splitName[0];
                student.lastname = splitName[1];
                student.id = ++this._studentID;

                this._results[student.id] = {
                    homeworks: [],
                    score: -1
                };

                this._students.push(student);

                return student.id;
            }
        });

        Object.defineProperty(course, 'getAllStudents', {
            value: function() {
                return this._students;
            }
        });

        Object.defineProperty(course, 'submitHomework', {
            value: function(studentID, homeworkID) {
                validator.validateIfNumber(studentID);
                validator.validateIfNumber(homeworkID);
                let foundIndex = indexOfStudent.call(this, studentID);
                if (foundIndex < 0) {
                    throw new Error('No student with id - ' + studentID + ' exists!');
                }
                if (homeworkID > this.presentations.length || homeworkID <= 0) {
                    throw new Error('No homework with id - ' + homeworkID + ' exists!');
                }

                this._results[studentID].homeworks.push(homeworkID);
                return this;
            }
        });

        Object.defineProperty(course, 'pushExamResults', {
            value: function(results) {
                let foundIndex = -1;
                if (results instanceof Array) {
                    for (r = 0; r < results.length; r++) {
                        let currentResult = results[r];
                        let studentID = currentResult.StudentID,
                            score = currentResult.score;

                        for (let i = 0, len = this._students.length; i < len; i += 1) {
                            if (this._students[i].id === studentID) {
                                foundIndex = i;
                            }
                        }

                        console.log(this._students);
                        if (foundIndex < 0) {
                            throw new Error('No student with id - ' + studentID + ' exists!');
                        }
                        validator.validateIfNumber(score);
                        if (this._results[studentID] === undefined) {
                            this._results[studentID] = {};
                        }
                        if (this._results[studentID].score === undefined) {
                            this._results[studentID].score = -1;
                        } else {
                            if (this._results[studentID].score > 0) {
                                throw new Error('This student already has score!');
                            }
                            this._results[studentID].score = score;
                        }
                    }
                } else {
                    throw new Error('Array must be given!');
                }
                return this;
            }
        });

        Object.defineProperty(course, 'getTopStudents', {
            value: function() {
                let best = [];
                for (let i in this._results) {
                    let currentId = this._results[i];

                }
                return best;
            }
        });

        return course;
    }());
    return module;
}

module.exports = solve;