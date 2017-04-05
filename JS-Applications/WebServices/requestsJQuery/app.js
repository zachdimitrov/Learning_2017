/* globals XMLHttpRequest, console */

var url = "http://localhost:8886/api/people";

function getAll() {
    $.getJSON(url, function(data) {
        var people = data.data;
        var itemTemplate = document.createElement("li");
        var list = document.createElement("ul");

        people.forEach(p => {
            var li = itemTemplate.cloneNode(true);
            li.innerHTML = p.name;
            list.appendChild(li);
        });

        var container = document.getElementById("print")
        container.innerHTML = "";
        container.appendChild(list);
    });
}

function addNew() {
    var name = "Petko" + Math.random(),
        age = (Math.random() * 150);

    $.ajax({
        url: url,
        method: "POST",
        "contentType": "application/json",
        data: JSON.stringify({ name, age }),
        success: function(data) {
            getAll();
        }
    })
}

var btn;

window.onload = function() {
    getAll();
    btn = document.getElementById("btn-add");
    btn.addEventListener("click", function() {
        addNew();
    });

    $("#test-partial").load("./partial.html");
}