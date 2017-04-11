# Simple Forum Workshop

## Sammy JS

- load sammy as dependency
```html
<script src="./bower_components/sammy/lib/sammy.js"></script>
```
- add HTML items
```html
<a href="#/">Home</a> // home link
<a href="#/items">Items</a> // items link
<div id="content"></div> // content of page
```
- create and execute sammy
```js
var sammyApp = Sammy("#content", function() { // create and return sammy object
    this.get("#/", function() { // routing 
        console.log("HOME");
        this.redirect("#/home"); // redirect to home
    });

    this.get("#/home", function() {
        // do nothing
    });

    this.get("#/items", function() {
        var items = ["1", "2", "3", "4"];
        var page = this.params.page,
            size = this.params.size;

        console.log(page, size);
        items.forEach(item => {
            $("<a />")
                .css("display", "block")
                .attr("href", "#/items/" + item)
                .html("Go to  item " + item)
                .appendTo("#content");
        });
    });

    this.get("#/items/:id", function() {
        $("#content").html("Item with id " + this.params.id);
    });
});
// run sammy
$(() => {
    sammyApp.run("#/");
});
```