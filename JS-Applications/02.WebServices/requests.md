## requests with native API

- paste this in console when [github.com](https://github.com/) is open
- if use in other site CORS will prevent request

```js
// 1. Create the xhr
var xhr = new XMLHttpRequest();

// 2. Open the xhr
var url = "https://github.com/zachdimitrov/Learning_2017/tree/master/JS-Applications/02.WebServices";
xhr.open("GET", url, true); // method, address, async (false is not good)

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

    console.log(xhr.status);
    console.log(xhr.statusText);   

    // 6. Check status code
    switch (0 | (xhr.status / 100)) {
        case 2:         
            console.log(xhr.responseText);
            break;
        case 4:
            console.log(xhr.response);
            break;
        case 5:
            alert(xhr.response);
            break;
    }
}

// 6. Send the request
xhr.send();
```
## requests with jQuery

- get JSON request

```js
$.getJSON(url, function(data) {
    // do stuff with data
});
```

- POST request

```js
$.ajax({
        url: url,
        method: "POST",
        "contentType": "application/json",
        data: JSON.stringify({ name, age }),
        success: function(data) {
            getAll();
        }
    });
```