import $ from "jquery";

function print(obj) {
    $("#result").html("");
    let res = JSON.stringify(obj);
    console.log(res);
    if (typeof obj === "object") {
        let $ul = $("<ul/>");
        for (var key in obj) {
            $("<li/>")
                .html(`<strong>${key}</strong> : ${obj[key]}`)
                .appendTo($ul);
        }
        $("#result").append($ul);
    } else {
        $("#result").html(`<strong>${obj}</strong>`);
    }
}

function getQueryParams(query) {
    let hash, vars = {},
        hashes = query.substr(1)
        .split('&').forEach(val => {
            hash = val.split('=');
            vars[hash[0]] = hash[1];
        });
    return vars;
}

export { print, getQueryParams };