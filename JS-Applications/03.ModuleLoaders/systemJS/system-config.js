(function() {
    SystemJS.config({
        transpiler: "plugin-babel",
        map: {
            "plugin-babel": "./node_modules/systemjs-plugin-babel/plugin-babel.js",
            "systemjs-babel-build": "./node_modules/systemjs-plugin-babel/systemjs-babel-browser.js",
            "jquery": "./bower_components/jquery/dist/jquery.min.js",
            "main": "./app-modules/main.js",
            "data": "./app-modules/data.js",
            "utils": "./app-modules/utils.js",
            "jquery-ui": "./bower_components/jquery-ui/jquery-ui.min.js",
        }
    });
}());