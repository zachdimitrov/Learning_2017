(function() {
    var content = document.getElementById("content"),
        promise = new Promise((resolve, reject) => {
            navigator.geolocation.getCurrentPosition((position) => resolve(position), (error) => reject(error));
        });

    if (!content) {
        var newContent = document.createElement("div");
        document.body.appendChild(newContent);
        newContent.id = "content";
        content = newContent;
    }

    function parseCoords(pos) {
        var obj = {
            lat: pos.coords.latitude,
            lon: pos.coords.longitude
        };
        console.log(obj);
        return obj;
    }

    function errorMessage(error) {
        console.log(error);
        var heading = document.createElement("h2");

        heading.style.display = "inline-block";
        heading.style.padding = "20px";
        heading.style.fontFamily = "arial, sans-serif";
        heading.style.borderRadius = "15px";
        heading.style.color = "lightgrey";
        heading.style.backgroundColor = "black";

        heading.innerText = `Sorry, location cannot be identified!
         No positioning devise is found.
          Browser cannot verify position!
          Please allow geolocation!`;
        content.appendChild(heading);
    }

    function renderMap(obj) {
        var lon = obj.lon.toFixed(6),
            lat = obj.lat.toFixed(6),
            zoom = 14,
            url = `https://maps.googleapis.com/maps/api/staticmap?center=${obj.lat},${obj.lon}&zoom=${zoom}&size=640x480`,
            zoomValue = document.createElement("span"),
            coordsValue = document.createElement("span"),
            header = document.createElement("div"),
            img = document.createElement("img"),
            zoomInput = document.createElement("input");

        /*
          //test with input coordinates - not working
          
          var coorInput = document.createElement("input");
        
          coorInput.type = "number";
          coorInput.step = 0.000001;
          coorInput.style.backgroundColor = "black";
          coorInput.style.color = "white";
          coorInput.style.border = "none";
          coorInput.style.width = "120px";
          coorInput.style.margin = "3px";
          coorInput.style.paddingLeft = "5px";
          coorInput.style.fontSize = "18px";
          coorInput.style.fontWeight = "bold";
              
          latInput = coorInput.cloneNode(true);
          latInput.id = "lat-input";
          latInput.value = obj.lat || 23.3222

          lonInput = coorInput.cloneNode(true);
          lonInput.id = "lon-input";
          lonInput.value = obj.lon || 42.697626;

          header.appendChild(latInput);
          header.appendChild(lonInput);
        */

        // add styles
        coordsValue.style.color = "white";
        coordsValue.style.margin = "3px";
        coordsValue.style.padding = "0 45px 0 5px";
        coordsValue.style.fontWeight = "bold";

        zoomInput.style.position = "relative";
        zoomInput.style.top = "6px";
        zoomInput.style.width = "200px";

        zoomValue.style.padding = "0 0 0 10px";
        zoomValue.style.color = "white";
        zoomValue.style.fontWeight = "bold";

        content.style.display = "inline-block";
        content.style.padding = "0 25px 25px";
        content.style.backgroundColor = "black";
        content.style.borderRadius = "15px";

        header.style.color = "grey";
        header.style.padding = "10px 0";
        header.style.fontFamily = "arial, sans-serif";

        // setup zoom slider input
        zoomInput.type = "range";
        zoomInput.id = "zoom-input";
        zoomInput.min = 1;
        zoomInput.max = 20;
        zoomInput.value = 13;
        zoomInput.step = 1;

        // add values to elements
        img.src = url;
        coordsValue.innerHTML = `${lat} &nbsp&nbsp ${lon}`;
        zoom = zoomInput.value;
        zoomValue.innerText = zoom;
        header.innerText = `Your coordinates: `;

        // append elements
        header.appendChild(coordsValue);
        header.innerHTML += ` Zoom: `;
        header.appendChild(zoomInput);
        header.appendChild(zoomValue);
        content.appendChild(header);
        content.appendChild(img);

        header.addEventListener("input", function(ev) {
            if (ev.target.id === "zoom-input") {
                zoom = zoomInput.value;
                zoomValue.innerText = zoom;
            }
            url = `https://maps.googleapis.com/maps/api/staticmap?center=${lat},${lon}&zoom=${zoom}&size=640x480`;
            img.src = url;
        });
    }

    // PROMISE EXECUTION //
    promise
        .then(parseCoords)
        .then(renderMap)
        .catch(errorMessage);
}());