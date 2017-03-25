/* globals $ */

/*
Create a function that takes a selector and:
* Finds all elements with class `button` or `content` within the provided element
  * Change the content of all `.button` elements with "hide"
* When a `.button` is clicked:
  * Find the topmost `.content` element, that is before another `.button` and:
    * If the `.content` is visible:
      * Hide the `.content`
      * Change the content of the `.button` to "show"       
    * If the `.content` is hidden:
      * Show the `.content`
      * Change the content of the `.button` to "hide"
    * If there isn't a `.content` element **after the clicked `.button`** and **before other `.button`**, do nothing
* Throws if:
  * The provided ID is not a **jQuery object** or a `string` 

*/
function solve() {
    return function(selector) {
        if (selector !== null && selector !== undefined && typeof selector === 'string') {
            $parent = $(selector);
            if ($parent.length === 0) {
                throw Error('invalid element not found');
            }
        } else {
            throw new Error('invalid selector!');
        }

        $('.button').html('hide');

        $parent.on('click', '.button', function() {
            var $nextEl = $(this).nextAll('.content').first();
            if ($nextEl.nextAll('.button').length !== 0) {
                if ($(this).html() === 'hide') {
                    $(this).html('show');
                } else {
                    $(this).html('hide');
                }
            }
            if ($nextEl.css("display") === "none") {
                $nextEl.css("display", "");
            } else {
                $nextEl.css("display", "none");
            }
        });
    };
}

module.exports = solve;