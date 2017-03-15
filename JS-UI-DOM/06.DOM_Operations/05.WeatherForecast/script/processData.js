function process(data) {
    Handlebars.registerHelper("temp", function(value) {
        return new Handlebars.SafeString((value - 273.15).toFixed(1) + '°C');
    });

    Handlebars.registerHelper("date", function(dt) {
        let date = new Date(dt);
        let value = '<strong>' + dayFromNumber(date.getDay()) + '</strong>' +
            '</br>' +
            date.getDate() + ' ' +
            monthFromNumber(date.getMonth()) +
            '</br>' +
            date.getHours() + ':00';
        return new Handlebars.SafeString(value);
    });

    Handlebars.registerHelper("cut", function(string, symbols) {
        return new Handlebars.SafeString(string.slice(0, string.length - symbols));
    });

    Handlebars.registerHelper("percent", function(number) {
        return new Handlebars.SafeString((number * 100).toFixed(0) + '%');
    });

    Handlebars.registerHelper("direction", function(number) {
        let dir = 'North';
        let cl = 22.5;
        if (number > cl && number < 3 * cl) dir = 'Northeast';
        if (number > 3 * cl && number < 5 * cl) dir = 'East';
        if (number > 5 * cl && number < 7 * cl) dir = 'Southeast';
        if (number > 7 * cl && number < 9 * cl) dir = 'South';
        if (number > 9 * cl && number < 11 * cl) dir = 'Southwest';
        if (number > 11 * cl && number < 13 * cl) dir = 'West';
        if (number > 13 * cl && number < 15 * cl) dir = 'Northwest';
        return new Handlebars.SafeString(dir);
    });

    var source = document.getElementById("entry-template").innerText;
    var template = Handlebars.compile(source);
    let container = document.getElementById('wrapper');
    container.innerHTML = template(data);
    let weather = document.getElementById('weather-list');

    container.addEventListener('click', function(ev) {
        let detailContainer = document.createElement('div');
        detailContainer.className = 'details';
        let index;
        if (ev.target.hasAttribute('data-index')) {
            index = ev.target.getAttribute('data-index');
        } else {
            index = ev.target.parentElement.getAttribute('data-index');
        }

        if (index === null || index === undefined) {
            console.log('nothing selected');
            /* detailContainer.innerHTML = '<p class="detinfo"><strong>No weather period selected! Please try again!</strong></p>';
            container.appendChild(detailContainer);
            setTimeout(function() {
                container.removeChild(detailContainer);
            }, 2000);*/
        } else {
            let selectedDay = data.list[index];
            console.log(selectedDay);
            detailContainer.innerText = JSON.stringify(selectedDay);

            weather.style.display = 'none';
            container.appendChild(detailContainer);

            var detSource = document.getElementById("details-template").innerText;
            var detTemplate = Handlebars.compile(detSource);
            detailContainer.innerHTML = detTemplate(selectedDay);
        }
    }, false);

    container.addEventListener('click', function(ev) {
        if (ev.target.className === 'details' || ev.target.parentElement.className === 'details') {
            container.removeChild(ev.target);
            weather.style.display = '';
        }
    });

    function dayFromNumber(day) {
        switch (day) {
            case 0:
                return 'Monday';
            case 1:
                return 'Tuesday'
            case 2:
                return 'Wednesday'
            case 3:
                return 'Thursday'
            case 4:
                return 'Friday'
            case 5:
                return 'Saturday'
            case 6:
                return 'Sunday'
        }
    }

    function monthFromNumber(month) {
        switch (month) {
            case 0:
                return 'January';
            case 1:
                return 'February';
            case 2:
                return 'March';
            case 3:
                return 'April';
            case 4:
                return 'May';
            case 5:
                return 'June';
            case 6:
                return 'July';
            case 7:
                return 'August';
            case 8:
                return 'September';
            case 9:
                return 'October';
            case 10:
                return 'November';
            case 11:
                return 'December';
        }
    }
}