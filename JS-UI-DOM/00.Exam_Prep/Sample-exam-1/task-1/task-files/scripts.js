function createCalendar(selector, events) {
    var element = document.querySelector(selector),
        div = document.createElement('div'),
        header = document.createElement('div'),
        span = document.createElement('span'),
        i;
    div.style.display = 'inline-block';
    div.style.width = '180px';
    div.style.height = '180px';
    div.style.border = '1px solid black';
    div.style.padding = 0;
    div.style.margin = 0;
    div.className = 'date';
    div.style.position = 'relative';

    header.style.borderBottom = '1px solid black';
    header.style.padding = '0 20px';
    header.style.textAlign = 'center';
    header.style.margin = '0';
    header.className = 'date-header';
    header.style.backgroundColor = 'lightgrey';

    //hack to fix the jumping of the empty boxes
    span.innerHTML = '&nbsp;';


    div.appendChild(header);
    div.appendChild(span);
    var firstDate = new Date(2014, 5, 1);

    for (let i = 0; i < 31; i++) {
        var newDate = addDays(firstDate, i);
        div.firstElementChild.innerHTML = newDate.toDateString();
        element.appendChild(div.cloneNode(true));
    }

    var allDates = document.getElementsByClassName('date');

    for (let i in events) {
        let event = events[i];
        allDates[event.date - 1].getElementsByTagName('span')[0].innerHTML += event.hour + ' ' + event.title;
    }

    element.addEventListener('mouseover', function(ev) {
        if (ev.target.className === 'date') {
            ev.target.firstElementChild.style.backgroundColor = 'yellow';
        }
    });
    element.addEventListener('click', function(ev) {
        if (ev.target.className === 'date') {
            // ev.target.style.backgroundColor === '' ? ev.target.style.backgroundColor = 'lightgreen' : ev.target.style.backgroundColor = '';
            for (let i = 0; i < allDates.length; i++) {
                allDates[i].style.backgroundColor = '';
            }
            ev.target.style.backgroundColor = 'lightgreen';
        }
    });
    element.addEventListener('mouseout', function(ev) {
        if (ev.target.className === 'date') {
            ev.target.firstElementChild.style.backgroundColor = 'lightgrey';
        }
    });
}

function addDays(date, days) {
    var newDate = new Date(date);
    newDate.setDate(newDate.getDate() + days);
    return newDate;
}