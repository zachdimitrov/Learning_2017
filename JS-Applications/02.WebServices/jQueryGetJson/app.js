var url = "./test-trello.json";
var url3 = "https://status.github.com/api/status.json"

/*
var $script = $("<script/>");
$script.attr("type", "text/javascript");
$script.attr("src", (url3 + "?callback=my_callback"));
$script.appendTo($("body"));


function my_callback(data) {
    console.log(data);
    $("#result")
        .append(new Array(50).join('-'))
        .append(JSON.stringify(data));
}
*/

$.ajax({
    url: url3,
    dataType: "jsonp",
    success: function(data) {
        console.log(data);
        $("#result")
            .append(new Array(50).join('-') + "<br/>")
            .append(JSON.stringify(data));
    }
})


$.ajax({
    url: url,
    cors: true,
    contentType: "application/json",
    success: function(data) {
        var $ul = $("<ul/>"),
            $res = $("#result");
        for (var key in data) {
            if (data.hasOwnProperty(key)) {
                var el = data[key];
                $("<li/>")
                    .html(`<strong> ${key}: <strong/> ${el}`)
                    .appendTo($ul);
            }
        }
        $ul.appendTo($res);
    }
});