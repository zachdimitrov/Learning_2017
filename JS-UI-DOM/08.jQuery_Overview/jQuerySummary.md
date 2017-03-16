#### Install jQuery
- download from [jQuery website](https://code.jquery.com/jquery/) and attach to html
- use CDN
```html
<script
  src="https://code.jquery.com/jquery-3.1.1.min.js"
  integrity="sha256-hVVnYaiADRTO2PzUGmuLJr8BLUSjGIZsDYGmIJLv2b8="
  crossorigin="anonymous">
</script>
```
- use [bower](https://bower.io/) 

#### Select elements
- uses CSS3 syntax for selectors
- selects like `document.querySelectorAll()`
- always returns collection
 
```js
// by tag
$("div")
// by class
$(".menu-item")
// by id
$("#navigation")
// by any combination of CSS3 selectors
$("ul.menu li")
```

#### Useful jQuery methods
```js
// events
$element.on("event", function(){}); // adds event
$elm.val(); // gets value of input
$elm.val("value"]); // sets value of input
$(function() {}); // executed when page is loaded - window.on("load")

// selection
$element.prev(); // selects previous element
$element.next(); // selects next element
$element.first(); // first child
$element.last(); // last child
$element.parent(); // selects parent
$element.parents("selector"); // searchest for the closest parent 
$element.closest("selector"); // not very useful
$element.eq(3); // selects element with index
$list.find("li"); // selects in current element (not whole html)

// class manipulation
$element.hasClass("class"); // checks for class
$element.addClass("class"); // adds class, interval is not needed
$element.removeClass("class"); // removes class
$element.toggleClass("class"); // switches between add and remove
$element.attr("id"); // shows selected attribute  

// visibility
$element.show(); // shows element if is hidden
$element.hide(); // hides element if shown
$element.fade(); // fade effect
$element.animate() // animation

// style
$elm.css("color", "#eee"); // sets color
$elm.css("color"); // returns color

// manipulation of DOM
$element.html(); // returns innerHTML of element
$element.html("content"); // sets the innerHTML 
$elm.text("content"); // adds innerText
$el1.append(el2); // appends el2 at the end of el1
$el1.appendTo(el2); // appends el1 at the end of el2
$("<h1/>").appendTo("body"); // dynamically create element and add
$(".btn").remove(); // removes selected elements

// iterating
$items.each(function(index, node) { // do sth. });
```

#### Use events with jQuery
```js
$(".btn").on("click", function() {
  var $heading = $("h1");
  if($heading.hasClass("hidden")) {
    $heading.removeClass("hidden");
  } else {
    $heading.hide(); // hides element if shown
    $heading.addClass("hidden");
  }
  $(this).remove(); // will remove clicked button
});
```
usung input
```html
<div class="content">Content</div>
<input type="text" class="tb-username" />
<p class="result"><a class="btn">Delete</a></p>
```
```js
// set style
$(".content").on("enter", function() {
  $(this).css("background-color", "green")
});

// clear inline styles
$(".content").on("mouseout", function() {
  $(this).css("background-color", "")
});

// use value of input
$(".tb-username").on("input", function() {
  var $this = $(this);
  $(".result").html($this.val());
});

// invoke event children elements 
$(".result").on("click", ".btn", function() {
   $(this) // (this) is the .btn element
    .parents(".result")
    .remove();
});
```