import $ from "jquery";
import * as db from "db";

$(() => {
    db.add("Pesho");
    db.add("Gosho");
    db.add("kon");
    db.add("magare");
    showAll();

    $("button").on("click", function() {
        $("#container").html("");
        db.add($("input").val());
        showAll();
    });

    function showAll() {
        let shown = db.showdb();

        shown.forEach(f => {
            $("<li/>")
                .html(`<strong>${f.myid}.</strong> ${f.file}`)
                .appendTo($("#container"));
        })
        $("#container")
            .css({
                listStyle: "none",
                fontFamily: "Calibri, Sans-Serif"
            })
            .appendTo($("body"));
    }
});