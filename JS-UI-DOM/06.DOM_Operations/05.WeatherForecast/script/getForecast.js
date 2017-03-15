(function() {
    var requester = (function() {
        var core = {
            getJSON: function getJSON(url) {
                var promise = new Promise(function(resolve, rejext) {
                    var client = new XMLHttpRequest(),
                        response,
                        jsonResponse;

                    client.open('GET', url, true);
                    client.send();

                    client.onload = function() {
                        if (this.status >= 200 && this.status < 300) {
                            resolve(JSON.parse(this.response));
                        } else {
                            reject(this.statusText);
                        }
                    };

                    client.onerror = function() {
                        reject(this.statusText);
                    };
                });

                return promise;
            }
        };

        return {
            getJSON: core.getJSON,
        };
    })();

    function getForecast(selectedCity) {
        let city = {
            sofia: 727011,
            varna: 726050,
            burgas: 732770,
            pleven: 728203,
            plovdiv: 728193
        };
        var wrapper = document.getElementById('wrapper'),
            openWeatherUrl = 'http://api.openweathermap.org/data/2.5/forecast?id=' + city[selectedCity] + '&APPID=87d3861d99d554898a003e70aae49299';
        var fc;
        requester.getJSON(openWeatherUrl)
            .then(function(data) {
                console.log(data);
                process(data); // processData.js
            });
    }

    document.forms[0].addEventListener('change', function() {
        let e = document.getElementById('selected');
        let selectedCity = e.options[e.selectedIndex].value;
        console.log(selectedCity);
        getForecast(selectedCity);
    });

}());