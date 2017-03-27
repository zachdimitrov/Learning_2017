/* globals document, window, console */

function solve() {
    return function(selector, initialSuggestions) {
        var element = document.querySelector(selector),
            suggList = document.getElementsByClassName("suggestions-list")[0],
            input = document.getElementsByClassName("tb-pattern")[0],
            templateLi = document.createElement("li"),
            templateA = document.createElement("a"),
            arr;

        templateLi.className = "suggestion";
        templateLi.style.display = "none";
        templateA.href = "#";
        templateA.className = "suggestion-link";
        templateLi.appendChild(templateA);

        initialSuggestions = initialSuggestions || [];

        initialSuggestions.forEach(function(s) {
            var listItem = templateLi.cloneNode(true);
            var link = listItem.getElementsByClassName("suggestion-link")[0];
            link.innerHTML = s;
            suggList.appendChild(listItem);
        });

        input.addEventListener("input", function(ev) {
            var x = this.value.toLowerCase();
            console.log(x);
            var suggestions = document.getElementsByClassName("suggestion-link");
            for (var i = 0; i < suggestions.length; i++) {
                var s = suggestions[i];
                if (s.innerHTML.indexOf(x) >= 0) {
                    s.parentNode.style.display = "";
                }
            }
        });
    };
}

module.exports = solve;