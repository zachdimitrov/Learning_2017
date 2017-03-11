let cols = 15;

let wrapper = document.createElement('div');
wrapper.setAttribute('id', 'wrapper');
document.body.appendChild(wrapper);
let table = document.createElement('table');
table.style.borderCollapse = 'collapse';
wrapper.appendChild(table);

let counter = 0;
let start = 0;

function getRandomColor() {
    var letters = '0123456789ABCDEF';
    var color = '#';
    let j = start;
    for (var i = 0; i < 6; i++) {
        color += letters[j];
        j++;
        if (j >= letters.length) {
            j = 0;
        }
        //color += letters[Math.floor(Math.random() * 16)];
    }
    start++;
    if (start >= letters.length) {
        start = 0;
    }
    return color;
}

function isPrime(n) {
    for (let i = 2; i <= Math.sqrt(n); i++) {
        if (n % i === 0) {
            return false;
        }
    }
    return true;
}

function addElement() {

    let tr = document.createElement('tr');
    for (let i = 0; i < cols; i++) {
        if (isPrime(counter)) {
            let newElement = document.createElement('td');
            newElement.id = 'td' + counter;
            newElement.style.color = getRandomColor();
            newElement.innerHTML = counter + '';
            newElement.style.border = '1px solid black';
            newElement.style.padding = '5px';
            tr.appendChild(newElement);
        } else {
            i--;
        }
        counter++;
    }
    table.appendChild(tr);
}

if (counter < 50000) {
    setInterval(addElement, 1);
}