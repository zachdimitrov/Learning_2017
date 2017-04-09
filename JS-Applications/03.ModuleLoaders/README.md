# Module Loaders

## System JS

### Steps for confuguration of SystemJS

- Create package.json - **```npm init```**
- Install SystemJS and Babel plugin - **```npm install systemjs systemjs-plugin-babel --save```**
- Load SystemJS in HTML
```html
<script src="./node_modules/systemjs/dist/system.js"></script>
```
- Configure SystemJS (better create seperate config file)
```js
SystemJS.config({
            transpiler: "plugin-babel",
            map: {
                "plugin-babel": "./node_modules/systemjs-plugin-babel/plugin-babel.js",
                "systemjs-babel-build": "./node_modules/systemjs-plugin-babel/systemjs-babel-browser.js", 
                "main": "./app-modules/main.js", // main file
                "module-1": "./app-modules/module-1.js", // modules
                "module-2": "./app-modules/module-2.js"  // modules
            }
        });
```
- Load main file and config file in HTML
```html
<script src="./system-config.js"></script>
<script> System.import("main"); </script>
```
- Export modules (functions) from js file (for example math.js)
```js
function add(x, y) {
    return x + y;
}

function multiply(x, y) {
    return x * y;
}

export { add, multiply }; // can be exported both or separately or with 'export' in front of function
```

- Import modules in other js file (path from where module was exported is added in SystemJS config file)
```js
import { add, multiply as mul } from "math"; // can be loaded both or separately in different locations
// now we use 'multiply' function with 'mul'
import * as math from "math"; 
// now we use functions like this 'math.add', 'math.multiply';
import "jquery";
// used for libraries when we do not know what is exported
```

### Other configurations

- use path aliases in ```system-config.js``` file
```js
SystemJS.config({
            //...,
            paths: {
                "npm:*": "./node_modules/*",
                "mod:*": "./app-modules/*"
            }
            map: {
                "jquery": 'npm:jquery/dist/jquery.js', 
                //...,
                "main": "mod:main.js",
                //...,
            }
        });
```