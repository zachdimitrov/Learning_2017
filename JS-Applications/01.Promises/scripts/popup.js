var myPromise = new Promise((resolve, reject) => {
    setTimeout(function() {
        resolve("this is my message");
        reject("something very bad happened!");
    }, 2000);
})

function popIt(message) {
    alert(message);
}

myPromise.then(msg => popIt(msg));