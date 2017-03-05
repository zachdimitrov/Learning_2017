let counter = 0,
    number = 1000,
    start = 20;
let wrapper = document.createDocumentFragment();

function addElement() {
    let el = document.createElement('div');
    el.innerHTML = counter;
    //el.style.position = 'absolute';
    wrapper.appendChild(el);
    counter++;
}

for (let i = 0; i < number; i++) {
    addElement();
}

document.body.appendChild(wrapper);

let divs = document.querySelectorAll('div'); // static node list
let fragment = document.createDocumentFragment();

for (let i = 0; i < start; i++) {
    fragment.appendChild(divs[i]);
}

document.body.innerHTML = '';
document.body.appendChild(fragment);