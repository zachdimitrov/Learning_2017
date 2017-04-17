var templates = (function() {
    function get(name) {
        var promise = new Promise(function(resolve, reject) {
            var url = `./templates/${name}.handlebars`;
            $.get(url, function(templateHTML) {
                var template = Handlebars.compile(templateHTML);
                resolve(template);
            });
        });
        return promise;
    }

    return {
        get
    };
})();