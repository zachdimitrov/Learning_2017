# Document Object Model

###[The HTML DOM Document Object](http://www.w3schools.com/jsref/dom_obj_document.asp)
###[The HTML DOM Element Object](http://www.w3schools.com/jsref/dom_obj_all.asp)
###[The HTML DOM Attribute Object](http://www.w3schools.com/jsref/dom_obj_attributes.asp)
###[HTML DOM Events](http://www.w3schools.com/jsref/dom_obj_event.asp)
###[HTML DOM Style Object](http://www.w3schools.com/jsref/dom_obj_style.asp)

### Select DOM Elements

```js
document.documentElement // <html>
document.body // body of the page
  HTMLLIElement // li
  HTMLAudioElement // audio
  HTMLAnchorElement // <a> has href property
  HTMLImageElement // <img> has src property
  HTMLInputElement // has value property
document // the entry point for the DOM API
innerHTML // returns full content as string (without the element)
outerHTML // returns full content as strung including the element
innerText / textContent // return as string the text content without the tags
```
#### single element selection

```js
var header = document.getElementById('header');
```
#### select collection of elements

```js
var inputs = document.getElementsByTagName('li');
var posts = document.getElementsByClassName('post-item');
var radiosGroup = document.getElementsByName('genders');
```
#### predefined collections of elements

```js
var links = document.links;
var forms = document.forms;
```
#### using quiery Selector

```js
var header = document.querySelector('#header'); //the element with id="header"
var navItems = document.querySelectorAll('#main-nav li'); //li elements contained in element with id=main-nav
```
#### chain element selection

```js
var wrapper = document.getElementById('wrapper');
var divsInWrapper = wrapper.getElementsByTagName('div'); // returns all div elements inside the element with id "wrapper"
```
### Node Lists

**A NodeList is a collection returned by the DOM selector methods:**
- getElementsByTagName(tagName)
- getElementsByName(name)
- getElementsByClassName(className)
- querySelectorAll(selector)

```js
var divs = document.getElementsByTagName('div');
for(var i = 0, length = divs.length; i < length; i += 1){
   // do stuff with divs[i]…
}
```
### Static and Live node lists

- getElementsBy methods return a LiveNodeList - keeps track of elements all the time
- querySelectorAll returns a StaticNodeList - stores the elements az they were in the begining

# DOM Operations

**DOM element** it a JS object that has the same properties as the HTML element  

```js
  selectedDiv.innerHTML = "changed";  //changes the content of the div
  selectedDiv.style.background = "#456"; // promqnata na stilovete vliza kato inline stilove
  var div = document.createElement("div"); // taka sazdavame element
  var list = div.children[0]; // dava parvoto dete na elementa (ako ima)
  var node = document.createElement("LI");                 // Create a <li> node
  var textnode = document.createTextNode("Water");         // Create a text node
  node.appendChild(textnode);                              // Append the text to <li>
  document.getElementById("myList").appendChild(node);     // Append <li> to <ul> with id="myList"
  var x = document.getElementById("item1").nextSibling.innerHTML; // Gives the second element "item2"
```
**Example**

```js
function iterateList (listId) {
    var trainersList = document.getElementById(listId);
    var parent = trainersList.parentNode;
    log("parent of trainers-list: " + parent.nodeName +
        " with id: " + parent.id);

    var children = trainersList.childNodes;
    log("elements in trainers-list: " + children.length);
    log("element in trainers-list");

    for (var i = 0, len = children.length; i < len; i+=1) {
      var subItem = children[i];
      log(subItem.nodeName + " content: " +
          subItem.innerText);
    }
}
```
**Creating elements**

```js
var liElement = document.createElement("li");
console.log(liElement instanceof HTMLLIElement); //true
document.body.appendChild(studentsList); // dobavq go v kraq na DOM elementa
// trqbva da dobavim elementa kym DOM darvoto - inache e samo edin JS obekt
list.insertBefore(studentsList, list.childNodes[0]); // dobavq v nachaloto ili na izbrana poziciq
```
**Removing elements**

```js
  var trainers = document.getElementsByTagName("ul")[0];
  var trainer = trainers.getElementsByTagName("li")[0];
  trainers.removeChild(trainer); //remove a selected element
  var selectedElement = //select the element
  selectedElement.parentNode.removeChild(selectedElement);
  list.outerHtml = ''; list.innerHtml = ''; // podobno no malko kato hack
```
*HTML elements are unique and element is the same even if it changes its position or apearance.*
**Altering style**

```js
  var div = document.getElementById("content");
  div.style.display = "block";
  div.style.width = "123px";
```
**Optimisations**

```js
frag = document.createDocumentFragment('li'); //used to store ready-to-append elements 
list.appendChild(frag); //and append them at once to the DOM
var clonedNode = li.cloneNode(true); // clonira elementa
frag.appendChild(clonedNode); // zakachame elementa kum fragmenta
```

# Event Model in JS

`window.onload = function() {}`
`inpit.onkeyup = function() {}`

```js
input.addEventListener('keyup', function() {}); // zakacha events, moje da zakachish poveche ot edin
let button = document.getElementBiID('button');
button.addEventListener('click', function() {}, true); // dobavqne na event kym proizvolen elemenrt
// true oznachava che ne se buble-va
input.removeEventListener('keyup'); // premava event
```

