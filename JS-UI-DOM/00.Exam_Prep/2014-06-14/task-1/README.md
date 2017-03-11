#Task 1: ImagesPreviewer

* Given the HTML `index.html` write JavaScript function `createImagesPreviewer(selector, items)` in file `scripts.js`

  * The function accepts two parameters:
    * **Selector**
      * The selector of the DOM element, where the previewer must be generated in
      * It can be any CSS3 selector (`#id`, `.class`, `NODE_NAME`)
    * **Items** 
      * An array of objects
      * Every object in the array has two mandatory properties:
        * **title** - the title of the image
        * **url** - a path to the image (JPG/PNG)
        
  * The execution of the `createImagesPreviewer(selector, items)` function should result as follows:
    * All images from the items collection must be displayed on the right
      * With their title above them
    * Above the images on the right, there must be a filter box
      * For filtering images
    * The first item from the items collection should be displayed bigger on the left
      * With its title on top
    * _Example_:
      <img src="result/1. initial.png" width="450" />      
      
  * Images in the list (on the right) have some properties:
    * The title and the image must have a parent with class `image-container`
    * When `hovered`
      * They should change their **background color**      
      * _Example:_      
        <img src="result/2. cow-hovered.png" width="450" />
    * When `unhovered`
      * They should return to their **default background color**
    * When `clicked`
      * The **bigger image and its title** (on the left) are **replaced with the clicked image on the left**
      * _Example:_      
        <img src="result/3. hamster-clicked.png" width="450" />
  * The big image and title on the left must have a parent with class `image-preview`
      
  * The filter should provide functionality for **filtering the images** on the list of images (on the right)
    * When the text in the box changes
      * The list of images should be filtered only to those that have a title containing the pattern
      * The pattern matching is case-insensitive
    * When the text in the box is empty
      * All images should be visible
    * _Example:_      
      <img src="result/4. text-in-filter.png" width="450" />
      
  * Constraints:
    * You are allowed only to edit the contents of the file "scripts.js"
    * You are NOT allowed to edit the contents of the HTML and/or the CSS files    


# Steps for building UI Components with JavaScript

## Steps for solving the task:

### Analyze the problem
- Go through the description carefully
    - You should select the element with the provided selector
    - The selected element should contain **2** sections
        - `.image-preview`
            - Contains the image selected for preview and it's title
        - `.image-container`
            - Display all images in a side section with their respective titles and a search bar

- What HTML tags to use?
    - Always favor semantically correct tags
    - For UI components of similar or same type use `UL` or `OL`
    - For bolded, bigger or highlighter text prefer `STRONG`, `H1`, `H2`, etc
    - Make use of semantic tags such as `SECTION`, `ASIDE`, `STRONG`
    - For text fields, search bars, etc, use `INPUT[type=text]` with `LABEL`

### Solving the problem
- Selecting the root - `document.querySelector`
- Creating elements using the input image info
    - Create and customize DOM elements using `document.createElement`, `htmlElement.innerText`,
`htmlElement.style`, `htmlElement.className`, `image.src`
        - Image preview for the left section
        - Images displaying for the sidebar
        - Search bar for the sidebar
- Adding the created elements to the DOM tree with `htmlElement.appendChild`
- Changing the content of a the `.image-preview` section when clicking on a side image
    - Attaching events with `htmlElement.addEventListener`
        - How to access the elemented targeted by the event?
    - Removing the old content from the DOM
    - Adding the new content
- Showing/hiding items on searchbar input
    - Attach a function on the searchbar that executes on input
        - Hide all items that the search input doesn't target
            - Extract the search value
            - Attach styles with JavaScript to hide/show items