/* globals $ */

/* 

Create a function that takes an id or DOM element and:
  Create a function that takes an id or DOM element and:
* If an id is provided, select the element
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
  * The provided DOM element is non-existant
  * The id is neither a string nor a DOM element

*/

function solve() {
    return function(selector) {
        var elm;
        if (typeof selector === 'string') {
            elm = document.getElementById(selector);
        } else if (selector instanceof HTMLElement) {
            elm = selector;
        } else {
            throw new Error('Object is not HTML Element');
        }

        if (elm === null) {
            throw new Error('Nothing is selected!');
        }

        let all = elm.childNodes;

        for (let i = 0; i < all.length; i++) {
            let node = all[i];
            if (node.className === 'button') {
                node.innerHTML = 'hide';
            }
        }

        elm.addEventListener('click', function(ev) {
            let button = ev.target;
            if (button.className === 'button') {
                let nextContent = button.nextElementSibling;
                if (nextContent.className === 'content' && nextContent.nextElementSibling.className === 'button') {
                    button.innerHTML = button.innerHTML === 'hide' ? 'show' : 'hide';
                    nextContent.style.display = nextContent.style.display === 'none' ? '' : 'none';
                }
            }
        }, false);
    };
}

module.exports = solve;