$(function() {
    var url1 = "http://api.openweathermap.org/data/2.5/forecast?id=727011&APPID=87d3861d99d554898a003e70aae49299",
        url2 = "http://trello.com/c/08jCJ0zI/112-sgs-1701-negley-development",
        url3 = "http://arch-zach.blogspot.bg/",
        url4 = "../jQuerySummary.md",
        url5 = "https://restcountries.eu/rest/v2/name/bul";
    $.getJSON(url1, function(data) {
        console.log(data);
        // use data
    });

    $("#content").load(url5);
});