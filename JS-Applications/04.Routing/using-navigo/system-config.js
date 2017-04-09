SystemJS.config({
    transpiler: "plugin-babel",
    map: {
        "plugin-babel": "./node_modules/systemjs-plugin-babel/plugin-babel.js",
        "systemjs-babel-build": "./node_modules/systemjs-plugin-babel/systemjs-babel-browser.js",
        "main": "./js/main.js",
        "style": "./js/addStyles.js",
        "utils": "./js/utils.js",
        "jquery": "./bower_components/jquery/dist/jquery.min.js",
        "jquery-ui": "./bower_components/jquery-ui/jquery-ui.min.js",
    }
});