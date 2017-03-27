function solve() {
    return function(selector) {
        var $options = $(selector + " option");
        var $select = $(selector).hide();
        var $dropDown = $("<div/>")
            .addClass("options-container")
            .css({ "position": "absolute", "display": "none" });

        var $current = $("<div/>")
            .addClass("current")
            .attr("data-value", "")
            .html("Select a value");

        for (var i = 0; i < $options.length; i++) {
            var $element = $($options[i]);
            var $newOption = $("<div/>")
                .addClass("dropdown-item")
                .attr("data-value", $element.val())
                .attr("data-index", i)
                .html($element.html());

            $dropDown.append($newOption);
        }

        var $mainContainer = $("<div/>")
            .addClass("dropdown-list")
            .append($select)
            .append($current)
            .append($dropDown);

        $("body").append($mainContainer);

        $current.on("click", function() {
            var $cur = $(this);
            var storedValue = $cur.html();
            $cur.html("Select a value");
            if ($dropDown.css("display") === "none") {
                $dropDown.css("display", "block");
            } else {
                $dropDown.css("display", "none");
                $cur.html(storedValue);
            }
        });

        $(".dropdown-item").on("click", function() {
            $current.html($(this).html());
            $select.val($(this).attr('data-value'));
            $dropDown.css("display", "none");
        });
    };
}

module.exports = solve;