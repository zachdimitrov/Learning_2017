let chatWrapper, input;

function init() {
    chatWrapper = document.getElementById('chat');
    input = document.getElementById('inputMsg');

    let button = chatWrapper.getElementsByTagName('button')[0];
    button.addEventListener('click', displayMsg);

    chatWrapper.addEventListener('keypress', function(event) {
        console.log(event.which);
        if (event.which === 13) {
            displayMsg();
        }
    });
}

function displayMsg() {
    let message = input.value.trim();
    message = message
        .replace(/&/g, '&amp;')
        .replace(/</g, '&lt;')
        .replace(/>/g, '&gt;')
        .trim();
    if (message !== '') {
        let name = document.getElementById('name').value;
        let msg = document.createElement('div');
        let strong = document.createElement('strong');
        strong.innerHTML = `${name}: `;
        msg.appendChild(strong);
        msg.innerHTML += message;
        chatWrapper.appendChild(msg);
        input.value = '';
    }
}

window.onload = init;

// 45:00