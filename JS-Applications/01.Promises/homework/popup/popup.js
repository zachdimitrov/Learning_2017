(function() {
    var content = document.getElementById("popup"),
        message = "Hello, you will be redirected to a fun page after 2 seconds!",
        error = "Sorry, something bad happened!";
    promise = new Promise((resolve, reject) => {
        setTimeout(function() {
            resolve(message);
            reject(error);
        }, 2000);
    });

    // validation, just in case
    if (!content) {
        var newContent = document.createElement("div");
        document.body.appendChild(newContent);
        newContent.id = "content";
        content = newContent;
    }

    // style, just for fun
    content.style.backgroundColor = "black";
    content.style.padding = "15px";
    content.style.color = "white";
    content.style.fontFamily = "arial, sans-serif";
    content.style.fontSize = "24px";
    content.style.display = "inline-block";
    content.style.borderRadius = "15px";
    content.style.boxShadow = "15px 15px 30px 5px grey";
    content.innerText = "A popup message will follow after 2 seconds!";

    // action
    function wait(message) {
        return new Promise((resolve, reject) => {
            setTimeout(function() {
                resolve(message);
                reject(error);
            }, 2000);
        });
    }

    function popupMessage(message) {
        content.style.backgroundColor = "darkred";
        content.innerText = message;
        return message;
    }

    function redirect() {
        window.location.href = "http://9gag.com/";
    }

    // start
    promise // waits for 2 seconds with initial page
        .then(popupMessage) // shows popup message (dark red)
        .then(wait) // waits again for 2 seconds 
        .then(redirect) // redirects to 9gag.com
        .catch(console.log); // shows error message in console
}());