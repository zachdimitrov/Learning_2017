#Task 2: Gallery

* Given the HTML (`index.html`), CSS (`styles.css`), JavaScript (`scripts.js` and `jquery.min.js`) and images build a jQuery plugin for a simple gallery control
* The gallery must:
  * Show all available images in a tabular view with rows and columns
  * Columns per row are optional and should be passed as parameter to the plugin
  * If no columns are given to the plugin, the default is 4
  * When the user clicks on an image, the clicked image as well as its previous and next images from the DOM are shown enlarged and fixed at the center of screen
  * When the gallery shows an enlarged image, the background should be blurred and not clickable or usable at all
  * When the user clicks on the already enlarged image, the gallery should return to the initial state and show all available images (allowing the user to click on them again)
  * When the user clicks on the image on the right of the enlarged image, the gallery should enlarge the next image in the DOM
  * If no next image is available, the gallery should show the first image as next
  * When the user clicks on the image on the left of the enlarged image, the gallery should enlarge the previous image in the DOM
  * If no previous image is available, the gallery should show the last image as previous
  * _HINT_
    * Take a closer look at the provided CSS styles.
* To get a better understanding of the gallery, you are provided with visual examples in the result folder
  
  
* Constaints:
  * You must alter only the scripts (JavaScript) and do not touch the HTML structure or the CSS styles
  * You must use jQuery to alter the DOM and build the plugin. You are not allowed to use the native document API
  * You are allowed only to edit the contents of the file "scripts.js"
  * You are NOT allowed to edit the contents of the HTML and/or the CSS files
  
  
* _Examples:_
  * Initial:
    * Three columns:
      * <img src="result/1.1. initial-three-columns.png" width="450" />
    * Five columns:    
      * <img src="result/1.2. initial-five-columns.png" width="450" />
    * Four columns:
      * <img src="result/1.3. initial-four-columns.png" width="450" />    
  * Clicked image:  
    * <img src="result/2. clicked-picture.png" width="450" />
  * Next Image:
    * <img src="result/3. next-picture.png" width="450" />
  * Previous Image:
    * <img src="result/4. previous-picture.png" width="450" />
  

# Steps for building jQuery Plugins

### **Read** the description **Analyze** the problem

1. **Tabular view**
   - function should accept 1 parameter if non provided should default to 4 columns
2. **Click on image**
    - Blur the gallery and make it inactive to clicks
        - How can this be acieved? - useful [link](http://api.jquery.com/on/#event-handler)
    - Click on middle image
        - should change the `src` of `#current-image` to the one of the selected image
        - should change the `src` of `#previous-image` to the previous image in the gallery
        - should change the `src` of `#next-image` to the next image in the gallery
    - Click on first image
        - should show last (`imgs/12.jpg`) image as previous
    - Click on last image
        - should show first (`imgs/1.jpg`) image as next
3. **Click on Prev / Next**
    - Clicking on any of the side images should update all the images in `.selected`
    - If the new current image is `imgs/1.jpg` previous image should be `12.jpg`
    - If the new current image is `imgs/12.jpg` next image should be `1.jpg`


### Review the [.html](tasks/index.html) file
  - `#gallery` contains `.gallery-list` and `.selected` 
    - `.gallery-list` contains all the images
      - `img` tags are nested in `.image-container`
      - `data-info` can be usefull to identify images
    - `.selected` contains the images that should show enlarged and the prev / next images
      - it should be hidden at the beginning


### Review the [.css](tasks/styles.css) file
  - `.gallery` class
      - useful for the tabular view
      - _Note_: Everything is nested inside this class! What is the best html element to attack this class?
  - `.gallery .clearfix` class in [.css](tasks/styles.css) - useful for starting a new row when elements have `float`
  - `.gallery .blurred` class
  - `.gallery .disabled-background` class with `z-index: 100;`
  - `.gallery .selected` class with `z-index: 200;`

### Solve the task
1. **Tabular view**
    - Read the parameters and assign default `4` value if non
    - Add class `.gallery` to the selected element
    - Cycle through all images and assign `.clearfix` when you want to start a new row
        - _Note_: the `img` tags are nested in `div.image-container` elements. Which element should have the `.clearfix` class?
        - _Note_: there should be no `.clearfix` on the first image
    - Hide `.selected` container
    - Append a new hidden element with `.disabled-background` class
        - Where should this element be appended?

2. **Test out** the Tabular display with different parameters 
  
3. **Click events**
  - Image from the gallery
      1. Where should the event handler be attached to?
      1. Get the index of the clicked image from the list of images
      1. Calculate the index of the previous index
          - _Hint_: you can use `(currentIndex - 1 + len) % len`
      1. Calculate the index of the next index
         - _Hint_: you can use `(currentIndex + 1) % len`
         - _Hint_: have a function take care of calculating the indexes
      1. Assign `src` to `#current-image` to be the one of the clicked image
      1. Assign `src` to `#previous-image` to be the one of the image before the clicked image
      1. Assign `src` to `#next-image` to be the one of the image after the clicked image
         - _Hint_: have a function take care of the update, based on the indexes
      1. Blur the gallery - what is the most appropriate element to attach the `.blurred` class?
      1. Show `.disabled-background` - to disable clicks on the gallery
      1. Show `.selected`
  - Current image
      - Hide `.disabled-background` - to enable clicks on the gallery
      - Hide `.selected`
  - Next image
      - Calculate indexes
      - Update `src` of `#previous-image`, `#current-image` and `#next-image`
          - _Hint_: Same as for click on image from gallery without the need to show `.disabled-background` or `.selected`
  - Previous image
      - Calculate indexes
      - Update `src` of `#previous-image`, `#current-image` and `#next-image`
          - _Hint_: Same as for click on image from gallery without the need to show `.disabled-background` or `.selected`

4. **Test out** the click events for all scenarios 

### Format for running tests

```javascript
function solve() {
  $.fn.gallery = function (...) {
    // your solution here
  };
}

module.exports = solve;
```