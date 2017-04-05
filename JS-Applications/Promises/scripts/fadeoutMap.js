window.addEventListener("load", function() {
    (function() {
        var myPromise = new Promise((resolve, reject) => {
            navigator.geolocation.getCurrentPosition((pos) => {
                resolve(pos);
            }, (error) => { reject(error); });
        });

        function parseCoords(pos) {
            var obj = {
                lat: pos.coords.latitude,
                lon: pos.coords.longitude
            };
            console.log("Step 1 returns:", obj);
            return obj;
        }

        function displayMap(pos) {
            var img = document.createElement("img");
            var content = document.getElementById("content");
            var footer = document.createElement("strong");
            footer.innerHTML = "The map will be here for 2 seconds!";
            var key = "&key=AIzaSyA66MMq38FBzDEA_RZoDBX_rTvUcYE-VPA";
            img.src = `https://maps.googleapis.com/maps/api/staticmap?center=${pos.lat},${pos.lon}&zoom=15&size=400x400`;
            img.style.width = 500;
            content.appendChild(img);
            content.appendChild(footer);
            console.log("Step 2 returns:", img);
            return img;
        }

        function wait(time, img) {
            return new Promise((resolve) => {
                setTimeout(() => {
                    console.log("Step 3 returns:", img);
                    resolve(img);
                }, time);
            });
        }

        function fadeout(mapEl) {
            mapEl.style.display = "none";
            var footer = document.getElementsByTagName("strong")[0];
            footer.innerHTML = "The map disappeared now!";
            console.log("Step 4 returns:", mapEl);
            return mapEl;
        }

        myPromise
            .then((geoLoc) => parseCoords(geoLoc)) // what is returned goes to the next function
            .then(pos => displayMap(pos)) // if we want to return many things, wrap them in object
            .then((img) => wait(2000, img))
            .then((mapEl) => fadeout(mapEl))
            .catch((error) => console.log(error));
    }());
});