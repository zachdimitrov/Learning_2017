/* globals XMLHttpRequest, console */

var url = "http://localhost:8886/api/people";

function sendHTTPRequest(serviceUrl, method, body, callBack) {
    // 1. Create the xhr
    var xhr = new XMLHttpRequest();

    // 2. Open the xhr
    xhr.open(method, serviceUrl, true); // method, address, async

    // 3. Setup

    // 3.1 Add headers
    xhr.setRequestHeader("Content-Type", "application/json");

    // 4. Attach to ready event
    xhr.onreadystatechange = function() {
        console.log(`State: ${xhr.readyState}`); // this is the property for state
        // State: 0 - not possible to see
        // State: 1 - loading request
        // State: 2 - request is loaded
        // State: 3 - request is sent and precessed by server
        // State: 4 - request is ready and can be used

        // 5. Check state
        if (xhr.readyState !== XMLHttpRequest.DONE) {
            return;
        }

        // 6. Check status code

        switch (0 | (xhr.status / 100)) {
            case 2:
                callBack(JSON.parse(xhr.responseText));
                break;
            case 4:
                console.log(xhr.response);
                break;
            case 5:
                alert(xhr.response);
                break;
        }

        console.log(xhr.responseText);
    };
    // 5 Send the request
    if (body !== null) body = JSON.stringify(body);
    console.log(body);
    xhr.send(body);
}

function getAll() {
    sendHTTPRequest(url, "GET", null, function(data) {
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
    var name = "John" + Math.random(),
        age = (Math.random() * 150);

    sendHTTPRequest(url, "POST", { name, age }, function() {
        getAll();
    });
}

var btn;

window.onload = function() {
    getAll();
    btn = document.getElementById("btn-add");
    btn.addEventListener("click", function() {
        addNew();
    })
}