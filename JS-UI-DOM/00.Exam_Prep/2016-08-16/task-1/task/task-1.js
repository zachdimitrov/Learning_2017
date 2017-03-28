/* globals document, window, console */

function solve() {
    return function(selector, initialSuggestions) {
        var container = document.querySelector(selector),
            input = container.getElementsByClassName("tb-pattern")[0],
            button = container.getElementsByClassName("btn-add")[0],
            list = container.getElementsByClassName("suggestion-list");

        var itemTemplate = document.createElement("li");
        itemTemplate.className = "suggestion";
        var itemLinkTemplate = document.createElement("a");
        itemLinkTemplate.href = "#";
        itemLinkTemplate.className = "suggestion-link";
        itemTemplate.appendChild(itemLinkTemplate);

        initialSuggestions = initialSuggestions || [];
        for (var i = 0; i < initialSuggestions.length; i++) {
            var suggestion = initialSuggestions[i];
            var li = itemTemplate.cloneNode(true);
            var item = li.getElementsByClassName("suggestion-link")[0];
            item.innerHTML = suggestion;
            container.appendChild(li);
        }


    };
}

module.exports = solve;