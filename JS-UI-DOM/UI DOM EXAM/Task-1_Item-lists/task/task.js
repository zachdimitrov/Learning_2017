function solve() {

    return function(selector, defaultLeft, defaultRight) {
        var root = document.querySelector(selector),
            fragment = document.createDocumentFragment(),
            input = document.createElement("input"),
            button = document.createElement("button"),
            container = document.createElement("div"),
            column = document.createElement("div"),
            select = document.createElement("div"),
            radio = document.createElement("input"),
            list = document.createElement("ol"),
            leftColumn,
            rightColumn;

        defaultLeft = defaultLeft || [];
        defaultRight = defaultRight || [];

        var li = document.createElement("li");
        li.className += "entry";

        var img = document.createElement("img");
        img.className += "delete";
        img.src = "imgs/Remove-icon.png";
        li.appendChild(img);

        button.type = "button";
        button.innerText = "Add";

        input.size = 40;

        radio.type = "radio";
        radio.name = "radio-name";
        var label = document.createElement("label");
        label.innerHTML = "Add here";
        select.className += "select";
        select.appendChild(radio);
        select.appendChild(label);

        column.className += "column";
        column.appendChild(select);
        column.appendChild(list);

        container.className += "column-container";

        leftColumn = fillColumn(defaultLeft);
        var leftButton = leftColumn.getElementsByTagName("input")[0];
        leftButton.checked = "checked";
        leftButton.id = "left-button";
        var leftLabel = leftColumn.getElementsByTagName("label")[0];
        leftLabel.setAttribute("for", "left-button");

        rightColumn = fillColumn(defaultRight);
        var rightButton = rightColumn.getElementsByTagName("input")[0];
        rightButton.id = "right-button";
        var rightLabel = rightColumn.getElementsByTagName("label")[0];
        rightLabel.setAttribute("for", "right-button");

        container.appendChild(leftColumn);
        container.appendChild(rightColumn);

        fragment.appendChild(container);
        fragment.appendChild(input);
        fragment.appendChild(button);

        root.appendChild(fragment);

        root.addEventListener("click", function(ev) {
            if (ev.target.className === "delete") {
                var liToRemove = ev.target.parentElement;
                input.value = liToRemove.innerText;
                liToRemove.parentElement.removeChild(liToRemove);
            }
        });

        button.addEventListener("click", function() {
            if (input.value.trim() !== '') {
                var columns = root.getElementsByClassName("column");
                for (var i = 0; i < columns.length; i++) {
                    var currentColumn = columns[i];
                    var currentList = currentColumn.getElementsByTagName("ol")[0];
                    if (currentColumn.getElementsByTagName("input")[0].checked) {
                        var text = escapeHtml(input.value.trim());
                        var newLi = li.cloneNode(true);
                        newLi.innerHTML += text;
                        currentList.appendChild(newLi);
                    }
                }
            }
        });

        function fillColumn(leftOrRight) {
            var col = column.cloneNode(true);
            var newList = col.getElementsByTagName("ol")[0];
            for (var i = 0; i < leftOrRight.length; i++) {
                var text = leftOrRight[i];
                var newLi = li.cloneNode(true);
                newLi.innerHTML += text;
                newList.appendChild(newLi);
            }

            return col;
        }

        function escapeHtml(unsafe) {
            return unsafe
                .replace(/&/g, "&amp;")
                .replace(/</g, "&lt;")
                .replace(/>/g, "&gt;")
                .replace(/"/g, "&quot;")
                .replace(/'/g, "&#039;");
        }
    };
}

// SUBMIT THE CODE ABOVE THIS LINE

if (typeof module !== 'undefined') {
    module.exports = solve;
}