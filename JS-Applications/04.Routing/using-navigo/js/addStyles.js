import $ from "jquery";
import "jquery-ui";

function addStyles() {
    // style
    $("#accordion")
        .accordion({
            collapsible: true,
            header: "> h3"
        })
        .css({
            display: "inline-block",
            width: 300
        })
    $("#output")
        .css({
            fontFamily: "Calibri, Arial, sans-serif",
            margin: "0 0 20px 0",
            padding: 0
        })
    $("#result")
        .css({
            fontFamily: "Calibri, Arial, sans-serif",
            fontSize: "20px",
            margin: "10px 0"
        })
    $("#final")
        .css({
            display: "inline-block",
            margin: "10px 0 0 15px",
            padding: 10,
            width: 300,
            border: "1px solid #eeeeee",
            borderRadius: 5,
            position: "absolute",
            top: 0
        });
}

export { addStyles };