$.fn.colorpicker = function() {

    // button
    var buttonUrl = "./imgs/icon.jpg",
        closeUrl = "./imgs/close.png",
        pickerUrl = "./imgs/color-picker.png",
        cursorUrl = "./imgs/cursor.png";

    var $button = $("<img/>", { "src": buttonUrl });
    $button.attr("id", "start-button")
        .css({
            "display": "inline-block",
            "border": "2px solid darkgrey",
            "border-radius": "4px",
            "width": "30px",
            "box-shadow": "1px 1px 5px #888",
            "position": "absolute"
        });
    $button.hover(function() {
        $button.css("border", "2px solid black");
    }, function() {
        $button.css("border", "2px solid darkgrey");
    });

    // create color colorpicker
    var $close = $("<img/>", { "src": closeUrl })
        .width(30)
        .css({
            "position": "absolute",
            "margin": "10px"
        });

    var $picker = $("<canvas/>", { "id": "color-picker" })
        .width(256)
        .height(256)
        .attr("id", "picker")
        .css({
            "margin": "40px 0 0 60px",
            "border-radius": "50px",
            "background-color": "white"
        });

    var $results = $("<div/>")
        .css({
            "margin": "20px 20px 0 40px",
            "display": "inline-block",
            "width": "130px"
        });

    var $inputHex = $("<input/>")
        .width(120)
        .css({
            "margin": "2px",
            "font-family": "sans-serif"
        })
        .appendTo($results);

    var $inputRgb = $("<input/>")
        .width(120)
        .css({
            "margin": "2px",
            "font-family": "sans-serif"
        })
        .appendTo($results);

    var $color = $("<canvas/>")
        .width(120)
        .height(50)
        .css({
            "margin": "20px 40px 0 20px",
            "float": "right",
            "background-color": "white"
        });

    var $container = $("<div/>", { "id": "container" })
        .css({
            "margin": "50px",
            "display": "inline-block",
            "width": "380px",
            "height": "400px",
            "background-color": "#636262",
            "border-radius": "15px"
        })
        .append($close)
        .append($picker)
        .append($results)
        .append($color);

    // append container and button to all
    $(this)
        .append($button)
        .append($container);

    var canvas = document.getElementById("picker");
    console.log(canvas);
    var ctx = canvas.getContext("2d");
    var img = new Image();
    img.onload = function() {
        ctx.drawImage(this, 0, 0);
    };
    img.src = pickerUrl;

    // create events
    $picker.hover(function() {
        $(this).css('cursor', 'url(' + cursorUrl + '), auto');
    }, function() {

    }).click(function() {

    });

    $button.on("click", function() {
        $container.toggle();
    });
    $close.on("click", function() {
        $container.hide();
    });
}