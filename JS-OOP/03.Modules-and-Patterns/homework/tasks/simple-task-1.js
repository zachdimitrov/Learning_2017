function solve() {
    var course = (function() {

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

        function init(title, presentations) {
            validator.validateTitle(title);
            validator.validateIfArrayIsEmpty(presentations);
            for (let i = 0, len = presentations.length; i < len; i += 1) {
                validator.validateTitle(presentations[i]);
            }

            this.title = title;
            this.presentations = presentations;
            this.studentID = 0;
            this.students = [];
            this.results = {};
            return this;
        }

        function addStudent(fullName) {
            validator.validateFullName(fullName);
            let names = fullName.split(' ');

            let student = {
                firstname: names[0],
                lastname: names[1],
                id: ++this.studentID
            };

            this.students.push(student);
            return student.id;
        }

        function getAllStudents() {
            return this.students;
        }

        function submitHomework(studentID, homeworkID) {
            validator.validateIfNumber(studentID);
            validator.validateIfNumber(homeworkID);

            function indexOfStudent(id, collection) {
                var i, len;
                for (i = 0, len = collection.length; i < len; i += 1) {
                    if (collection[i].id === id) {
                        return i;
                    }
                }
                return -1;
            }

            let foundIndex = indexOfStudent(studentID, this.students);

            if (foundIndex < 0) {
                throw new Error('No student with id - ' + studentID + ' exists!');
            }
            if (homeworkID > this.presentations.length || homeworkID <= 0) {
                throw new Error('No homework with id - ' + homeworkID + ' exists!');
            }

            if (this.results[studentID] === undefined) {
                this.results[studentID] = {};
            }
            if (this.results[studentID].homeworks === undefined) {
                this.results[studentID].homeworks = [];
            }
            this.results[studentID].homeworks.push(homeworkID);
            return this;
        }

        function pushExamResults(examResults) {
            if (examResults instanceof Array) {
                let foundIndex = -1;
                for (r = 0; r < examResults.length; r++) {
                    let currentResult = examResults[r];
                    let studentID = currentResult.StudentID,
                        score = currentResult.score;

                    for (let i = 0, len = this.students.length; i < len; i += 1) {
                        if (this.students[i].id === studentID) {
                            foundIndex = i;
                        }
                    }

                    if (foundIndex < 0) {
                        throw new Error('No student with id - ' + studentID + ' exists!');
                    }

                    validator.validateIfNumber(score);

                    if (this.results[studentID] === undefined) {
                        this.results[studentID] = {};
                    }
                    if (this.results[studentID].score === undefined) {
                        this.results[studentID].score = -1;
                    } else {
                        if (this.results[studentID].score > 0) {
                            throw new Error('This student already has score!');
                        }
                    }
                    this.results[studentID].score = score;

                    console.log(this.results);
                }
            } else {
                throw new Error('Array must be given!');
            }
            return this;
        }

        function getTopStudents() {
            let best = [];
            for (let i in this.results) {
                const maxScore = 6;
                let currentId = this.results[i];
                let homeworks = currentId.homeworks;
                let allHW = this.presentations.count;
                let score = currentId.score;
                let points = (homeworks.count / allHW) * 25 + score / maxScore * 75;

            }
            return best;
        }

        return {
            init: init,
            addStudent: addStudent,
            getAllStudents: getAllStudents,
            submitHomework: submitHomework,
            pushExamResults: pushExamResults,
            getTopStudents: getTopStudents
        };
    }());
    return course;
}

module.exports = solve;