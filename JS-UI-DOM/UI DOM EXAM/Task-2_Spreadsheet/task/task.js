function solve() {
    return function(selector, rows, columns) {
        var $root = $(selector);
        var letters = ["A", "B", ]
        console.log($root);
        var $table = $("<table/>");
        $table.addClass("spreadsheet-table");
        $headerRow = $("<tr/>");
        $headerCell = $("<th/>")
            .addClass("spreadsheet-item")
            .addClass("spreadsheet-header");

        $normalCell = $("<td/>")
            .addClass("spreadsheet-item")
            .addClass("spreadsheet-cell")
            .append("<span/>")
            .append("<input/>");

        var letterCode = 65;
        $headerRow.append($headerCell);
        for (var i = 0; i < columns; i++) {
            var letter = String.fromCharCode(letterCode);
            var $letterCell = $headerCell.clone().text(letter);
            $headerRow.append($letterCell);
            letterCode++;
        }

        $normalRow = $("<tr/>");

        for (var j = 0; j < columns; j++) {
            $normalRow.append($normalCell.clone());
        }

        $table.append($headerRow);

        var counter = 1;
        for (var k = 0; k < rows; k++) {
            var $newHeaderCell = $headerCell.clone().text(counter);
            var $newNormalRow = $normalRow.clone().prepend($newHeaderCell);
            $table.append($newNormalRow);
            counter++;
        }
        console.log($table);
        $root.append($table);

        $table.on("dblclick", ".spreadsheet-cell", function() {
            var $this = $(this);
            $this.addClass("editing");
            $this.find("span").text($this.find("input").value);
            $this.on("blur", function() {
                $this.removeClass("editing");
                $this.find("input").text($this.find("span").text());
            });
        });

        $table.on("mousedown", ".spreadsheet-item", function() {
            var $this = $(this);
            $table.find(".spreadsheet-item").removeClass("selected");
            $this.addClass("selected");
            $this.parent().find("th").addClass("selected");
            var $th = $this.closest('table').find('th').eq($this.index());
            $th.addClass("selected");

            if ($this.hasClass("spreadsheet-header") && $this.text() === "") {
                $table.find(".spreadsheet-item").addClass("selected");
            }

            if ($this.hasClass("spreadsheet-header") && typeof(+$this.text()) === "number") {
                $this.parent().find(".spreadsheet-item").addClass("selected");
            }

            if ($this.hasClass("spreadsheet-header") && $this.text() !== "") {
                var heading = $this.text();
                var columnTh = $("table th:contains('heading')");
                var columnIndex = columnTh.index() + 1;
                $('table tr td:nth-child(' + columnIndex + ')').addClass("selected");
                $this.addClass("selected");
            }
        });
    };
}

// SUBMIT THE CODE ABOVE THIS LINE

if (typeof module !== 'undefined') {
    module.exports = solve;
}