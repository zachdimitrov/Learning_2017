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

function getForecast() {
    var wrapper = document.getElementById('wrapper'),
        openWeatherUrl = 'http://api.openweathermap.org/data/2.5/forecast?id=727011&APPID=87d3861d99d554898a003e70aae49299';
    var fc;
    requester.getJSON(openWeatherUrl)
        .then(function(forecast) {
            console.log(forecast);
            // my funtion on displaying the data here

        });
};