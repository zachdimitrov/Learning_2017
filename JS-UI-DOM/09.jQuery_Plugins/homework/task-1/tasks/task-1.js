function solve() {
    return function(selector) {
        var $options = $(selector + " option");
        var $select = $("<select/>")
            .css("display", "none")
            .attr("id", $(selector).attr("id"))
            .append($options);

        var $newSelect = $("<div/>")
            .addClass("options-container")
            .css({ "position": "absolute", "display": "none" });

        var $current = $("<div/>")
            .addClass("current")
            .attr("data-value", "")
            .html("Option 1");

        for (var i = 0; i < $options.length; i++) {
            var $element = $($options[i]);
            var $newOption = $("<div/>")
                .addClass("dropdown-item")
                .attr("data-value", $element.val())
                .attr("data-index", i)
                .html($element.html());

            $newSelect.append($newOption);
        }

        var $mainContainer = $("<div/>")
            .addClass("dropdown-list")
            .append($select)
            .append($current)
            .append($newSelect);

        $(selector)
            .after($mainContainer)
            .remove();

        $current.on("click", function() {
            var $cur = $(this);
            var storedValue = $cur.html();
            $cur.html("Select a value");
            if ($newSelect.css("display") === "none") {
                $newSelect.css("display", "block");
            } else {
                $newSelect.css("display", "none");
                $cur.html(storedValue);
            }
        });

        $(".dropdown-item").on("click", function() {
            $current.html($(this).html());
            $newSelect.css("display", "none");
        });
    };
}

module.exports = solve;