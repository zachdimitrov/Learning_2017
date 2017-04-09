"use strict";

import { add, all, findById as byId } from "data";
import $ from "jquery"; // load all js file
import "jquery-ui";

add({ name: "Pesho", age: "15" });
add({ name: "Mariya", age: "33" });
add({ name: "Gosho", age: "7" });

$("#main-controls").controlgroup();
$("input").css({
    height: 22,
    width: 150,
    marginLeft: 5,
    padding: 5,
    fontSize: 20
});

console.log(all()); // all is working
all()[1] = "magare"; // this will not work
console.log(byId(1)); // mariya did not change

$("#btn-add").on("click", function() {
    const newPerson = {
        name: $("#person-name").val(),
        age: $("#person-age").val()
    };

    add(newPerson);
});

$("#btn-all").on("click", function() {
    let $list = $("#list-all");
    if ($list.hasClass("ui-accordion")) {
        $list.accordion("destroy")
            .sortable("destroy");
    }
    const peopleHtml = all().map(p => `<div><h3>Person with id:${p.id}</h3><div>${p.name} - ${p.age}</div></div>`);
    $list.html(peopleHtml.join("")).accordion({
            collapsible: true,
            header: "> div > h3"
        })
        .sortable({
            axis: "y",
            handle: "h3",
            stop: function(event, ui) {
                // IE doesn't register the blur when sorting
                // so trigger focusout handlers to remove .ui-state-focus
                ui.item.children("h3").triggerHandler("focusout");

                // Refresh accordion to handle new order
                $(this).accordion("refresh");
            }
        });
    $list.css({
        display: "inline-block",
        width: "562px"
    })
});