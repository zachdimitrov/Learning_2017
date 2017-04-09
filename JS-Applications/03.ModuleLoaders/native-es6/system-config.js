SystemJS.config({
    transpiler: "plugin-babel",
    map: {
        "plugin-babel": "./plugin-babel.js",
        "systemjs-babel-build": "./systemjs-babel-browser.js",
        "jquery": "./jquery.js",
        "app": "./app.js",
        "db": "./db.js"
    }
});