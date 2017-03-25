function solve() {
    return function() {
        $.fn.listview = function(data) {
            var selector = this.attr('data-template');
            var source = $('#' + selector).html();
            var template = handlebars.compile(source);
            var content = '';
            for (var i = 0, len = data.length; i < len; i += 1) {
                content += template(data[i]);
            }
            this.html(content);
        };
    };
}

module.exports = solve;