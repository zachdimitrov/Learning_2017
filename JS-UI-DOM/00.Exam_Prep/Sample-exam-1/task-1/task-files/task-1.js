function createCalendar(selector, events) {
    var WEEKS = 5;
    var MONTH = "June";
    var YEAR = "2015";
    var MAX_MONTH_DAYS = 30;
    var WEEK_DAYS = ["Sat", "Sun", "Mon", "Tue", "Wed", "Thu", "Fri"];

    var preparedEvents = prepareEvents(events);

    var day = document.createElement("div");
    var week = document.createElement("div");
    var dayTittle = document.createElement("h4");
    var dayEvents = document.createElement("p");

    applyDayStyles(day);
    applyWeekStyles(week);
    applyDayTitleStyles(dayTittle);
    applyDayEventStyles(dayEvents);

    var calendar = document.querySelector(selector);
    var month = generateMonth();
    calendar.appendChild(month);

    calendar.addEventListener('click', function(ev) {
        if (ev.target.classList.contains("calendar-day")) {
            ev.target.style.backgroundColor = "white";
        }
    }, true);

    function prepareEvents(events) {
        var result = [];
        for (var i = 0; i < events.length; i++) {
            var currentDate = events[i].date;
            result[currentDate] = events[i];
        }
        return result;
    }

    function generateMonth() {
        var frag = document.createDocumentFragment();
        for (var i = 0; i < WEEKS; i++) {
            var startDay = i * 7 + 1;
            var endDay = startDay + 6;
            var currentWeek = generateWeek(startDay, endDay);
            frag.appendChild(currentWeek);
        }
        return frag;
    }

    function generateWeek(startDay, endDay) {
        var currentWeek = week.cloneNode(true);
        for (var i = startDay; i <= endDay && i <= MAX_MONTH_DAYS; i++) {
            var currentDay = generateDay(i);
            currentWeek.appendChild(currentDay);
        }
        return currentWeek;
    }

    function generateDay(date) {
        var currentDay = day.cloneNode(true);
        var currentDateTitle = generateDateTitle(date);
        currentDay.appendChild(currentDateTitle);
        getCurrentEvent(date, currentDay);
        return currentDay;
    }

    function getCurrentEvent(date, dayElement) {
        var currentDateEvent = preparedEvents[date];
        if (currentDateEvent) {
            var currentDayEvent = dayEvents.cloneNode(true);
            currentDayEvent.innerText = currentDateEvent.hour + "-" + currentDateEvent.duration + "min " + currentDateEvent.title;
            dayElement.appendChild(currentDayEvent);
        }
    }

    function generateDateTitle(date) {
        var currentDayTitle = dayTittle.cloneNode(true);
        var currentDayString = WEEK_DAYS[date % 7];
        currentDayTitle.innerText = currentDayString + " " + date + " " + MONTH + " " + YEAR;
        return currentDayTitle;
    }

    function applyDayStyles(day) {
        day.classList.add("calendar-day");
        day.style.display = "inline-block";
        day.style.width = "130px";
        day.style.height = "130px";
        day.style.border = "1px solid black";
    }

    function applyWeekStyles(week) {
        // 
    }

    function applyDayTitleStyles(dayTitle) {
        dayTitle.classList.add("calendar-day");
        dayTitle.style.backgroundColor = "lightgray";
        dayTitle.style.textAlign = "center";
        dayTitle.style.borderBottom = "1px solid black";
        dayTitle.style.margin = 0;
    }

    function applyDayEventStyles(dayEvents) {
        dayEvents.style.position = "absolute";
        dayEvents.style.width = "120px";
    }
}