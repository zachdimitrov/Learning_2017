# Node.js applications
### Setup Node.js
- use NVM - change versions
- VS code plugins
    - auto import
    - CSSLint 
    - install ESLint 
        - `npm install -g eslint babel-eslint eslint-config-google`
        - install VS code package
        - add `.eslintrs` file
        - use `"files.eol": "\n"` in VS code settings to change CRLF to LF
    - ESLint - `eslint . --fix` fixes errors
- use `npm` to install external dependancies
    - npm init to create `package.json`
- use `yarn` - topologically sort dev dependancies 
    - globally install `npm install -g yarn`
    - install globally other packages `yarn global add http-server`
    - local packages `yarn add package` 
    - remove with yarn `yarn remove package`

## Modules in Node.js
- export modules
```js
module.exports = {
    print,
    Printer,
    getPrinter() {
        return new Printer();
    },
};
```

- import modules
```js
/* globals __dirname */

// load internal module
const fs = require('fs');

// load custom module, always use ./
const printerModule = require('./utils/printer');

// another way to load
const {
    getPrinter1,
    Printer,
} = require('./utils/printer');

// load index.js file
const utils = require('./utils');
const { getPrinter2 } = require('./utils');

// a way to use the first load
const printer = printerModule.getPrinter();

// use modules
fs.readdirSync(__dirname)
    .forEach((file) => {
        console.log(file);
    });
```
