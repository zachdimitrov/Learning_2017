function initMap() {
    navigator.geolocation.getCurrentPosition(function success(pos) {
        console.log(pos);
        var x, y, z;

        if (true) {
            x = pos.coords.latitude;
            y = pos.coords.longitude;
            z = 17;
        }

        var mapOptions = {
            zoom: z,
            center: new google.maps.LatLng(x, y),
            scrollwheel: false
        };

        // Create a map object and specify the DOM element for display.
        var map = new google.maps.Map(document.getElementById('map'), mapOptions);
    }, function error(data) {
        console.log(data);
    });
}