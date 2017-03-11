# JavaScript Event Model

### [Full list of all DOM event types](http://www.w3.org/TR/DOM-Level-3-Events/#event-types-list)

# Common Event Types

| **Mouse Events** | **Touch Events** | **Keyboard Events** |
| :--------------: | :--------------: | :-----------------: |
| `click`          | `tap`            | `keypress`          |
| `hover`          | `touchstart`     |  `keydown`           |
| `mouseup`        | `touchend`       |  `keyup`             |
| `mousedown`      | `touchmove`
| `mouseover`      | `touchcancel`
| `mouseout`       | `touchenter`
|                  | `touchleave`

# Common Event Types

| **UI Events**  | **Focus Events**  |
| :------------: | :---------------: |
| `load`         |  `blur`
| `abort`        |  `focus`
| `select`       |  `focusin`
| `resize`       |  `focusout`
| `change`       |
| `input`       |

# Event Handlers

### As HTML Attribute

```html
<button onclick="onButtonClick()">Click Me</button>
```

```js
function onButtonClick() {
  console.log("You clicked the Button");
}
```

#### Using DOM Element Properties

```html
<button id="click-button">Click me</button>
```

```js
var button = document.getElementById("click-button");
button.onclick = function onButtonClick() {
  console.log("You clicked the button");
}
```

### Using DOM Event Listeners - preferred

```js
domElement.addEventListener(eventType, eventHandler, isCaptureEvent);
```

```js
var button = document.getElementById("click-button");
button.addEventListener("click", function () {
  console.log("You clicked me");
}, false);
```

# Event Object  

- The event object contains information about:  
  - The **type** of the event  
  - The **target** of the event  
  - The **key that was pressed** when a keyboard event was fired  
  - The **mouse button that was pressed** when a mouse event was fired  
  - The **position** of the mouse on the screen  

```js
function onButtonClick(event) {
  console.log(event.target);
  console.log(event.type);
  console.log(event.clientX, event.clientY);
}
button.addEventListener("click", onButtonClick, false);
```

# The Event Chain

- When the user clicks on an HTML element, the event is also fired on all of its parents

```html
    <html>
      <body>
        <div>
          <button>
            Click Me
          </button>
        </div>
      </body>
    </html>
```

- The **button is still the target**, but the click event is fired on all of its parents
  - An event is fired on all elements in the chain

### Two Types of Event Chains

- **Bubbling** handlers **bubble up** the chain
 - The first executed handler is on the target
 - Then its parent's, and its parent's, etc…
- **Capturing** handlers **go down** the chain
 - The first executed handler is on the parent of all
 - The last executed handler is on the target