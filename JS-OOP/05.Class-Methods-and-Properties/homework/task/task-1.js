'use strict';

var validate = {
    ifIndexInRange: function(index, length) {
        if (index < 0 || index > length) {
            throw new Error('Index is out of range!');
        }
    }
};

class listNode {
    constructor(value) {
        this._value = value;
        this._next = null;
        this._previous = null;
    }

    get previous() {
        return this._previous.value;
    }

    set previous(val) {
        // validate
        this._previous = val;
    }

    get next() {
        return this._next.value;
    }

    set next(val) {
        // validate
        this._next = val;
    }

    get value() {
        return this._value;
    }
}

class LinkedList {
    constructor() {
        this._first = null;
        this._last = null;
        this._length = 0;
    }

    get first() {
        return this._first.value;
    }
    set first(val) {
        // validate
        this._first = val;
    }

    get last() {
        return this._last.value;
    }

    set last(val) {
        // validate
        this._last = val;
    }

    get length() {
        return this._length;
    }

    set length(val) {
        // validate
        this._length = val;
    }

    append(...items) {
        for (var i = 0; i < items.length; i++) {
            let item = items[i];
            let current;
            let node = new listNode(item);
            if (this._first === null) {
                this._first = node;
                this._last = node;
            } else {
                current = this._last;
                node._previous = current;
                current._next = node;
                this._last = node;
            }
            this.length++;
        }
        return this;
    }

    prepend(...items) {
        for (var i = items.length - 1; i >= 0; i--) {
            let item = items[i];
            let current;
            let node = new listNode(item);
            if (this._first === null) {
                this._first = node;
                this._last = node;
            } else {
                current = this._first;
                node._next = current;
                current._previous = node;
                this._first = node;
            }
            this.length++;
        }
        return this;
    }

    insert(index, ...items) {
        validate.ifIndexInRange(index, this._length);

        if (index === 0) {
            this.prepend(...items);
            return this;
        } else if (index === this._length) {
            this.append(...items);
            return this;
        }

        for (var i = items.length - 1; i >= 0; i--) {
            let item = items[i];
            let current;
            let node = new listNode(item);

            if (this._first === null) {
                this._first = node;
                this._last = node;
            } else {
                current = this._first;
                for (let j = 0; j < index; j++) {
                    current = current._next;
                }
                node._next = current;
                node._previous = current._previous;
                current._previous._next = node;
                current._previous = node;
            }
            this.length++;
        }
        return this;
    }

    removeAt(index) {
        validate.ifIndexInRange(index, this._length);
        let current;

        if (index === 0) {
            current = this._first;
            let val = current.value;
            this._first = current._next;
            this._first._previous = null;
            this._length--;
            return val;
        } else if (index === this._length - 1) {
            current = this._last;
            let val = current.value;
            this._last = current._previous;
            this._last._next = null;
            this._length--;
            return val;
        } else {
            current = this._first;
            for (let j = 0; j < index; j++) {
                current = current._next;
            }
            let val = current.value;
            current._previous._next = current._next;
            current._next._previous = current._previous;
            this._length--;
            return val;
        }
    }

    at(index, value) {
        validate.ifIndexInRange(index, this._length);
        if (value === undefined) {
            let current = this._first;
            for (let j = 0; j < index; j++) {
                current = current._next;
            }
            return current.value;
        } else {
            this.removeAt(index);
            this.insert(index, value);
            return this;
        }
    }

    [Symbol.iterator]() {
        let index = 0,
            list = this;
        return {
            next: function() {
                let value;
                if (index < list.length) {
                    value = list.at(index);
                }
                let done = index >= list.length;
                index++;
                return { value, done };
            }
        };
    }

    toArray() {
        let arr = [];
        for (let item of this) {
            arr.push(item);
        }
        return arr;
    }

    toString() {
        let node = this._first,
            result = '';

        do {
            if (node._next === null) {
                result += node.value;
            } else {
                result += node.value + ' -> ';
            }
            node = node._next;
        } while (node !== null);

        return result;
    }

}

// tests

const list = new LinkedList(),
    values = [1, 2, false, 3, 4];

list.append(...values);
console.log(list.at(4));
console.log('===========');
console.log(list._length);
console.log('===========');
for (let i of list) {
    console.log(i);
}
console.log('===========');
console.log(list.toString());
list.insert(2, 6, 6, 6);
console.log(list.toString());
console.log('===========');
const list2 = new LinkedList().append(1, 2).insert(0, 3, 4);
list2.insert(list2.length - 1, 'kremikovci');
console.log(list2.toString());

module.exports = LinkedList;

/* // example for Symbol.iterator
let iterable = {
    0: 'a',
    1: 'b',
    2: 'c',
    length: 3,
    [Symbol.iterator]() {
        let index = 0;
        return {
            next: () => {
                let value = this[index];
                let done = index >= this.length;
                index++;
                return { value, done };
            }
        };
    }
};
for (let item of iterable) {
    console.log(item); // 'a', 'b', 'c'
}
*/