/* globals $ */

/* 

Create a function that takes a selector and COUNT, then generates inside a UL with COUNT LIs:   
  * The UL must have a class `items-list`
  * Each of the LIs must:
    * have a class `list-item`
    * content "List item #INDEX"
      * The indices are zero-based
  * If the provided selector does not selects anything, do nothing
  * Throws if
    * COUNT is a `Number`, but is less than 1
    * COUNT is **missing**, or **not convertible** to `Number`
      * _Example:_
        * Valid COUNT values:
          * 1, 2, 3, '1', '4', '1123'
        * Invalid COUNT values:
          * '123px' 'John', {}, [] 
*/

function solve() {
    return function(selector, count) {
        var $element, i;
        if (typeof count !== 'number' || count < 1) {
            throw new Error('Invalid count!');
        }
        if (typeof selector === 'string') {
            $element = $(selector);
        } else {
            throw new Error('Selector is not a string!');
        }

        if (typeof $element !== 'undefined') {
            $('<ul/>')
                .addClass('items-list')
                .appendTo($element);

            for (i = 0; i < count; i++) {
                $('<li/>')
                    .addClass('list-item')
                    .html('List item #' + i)
                    .appendTo('.items-list');
            }
        }
    };
}

module.exports = solve;