let chatWrapper = document.getElementById('chat');
console.log(chatWrapper);

function displayMsg() {
    let input = document.getElementById('inputMsg');
    console.log(input.value);
    let msg = document.createElement('div');
    msg.innerHTML = input.value;
    chatWrapper.appendChild(msg);
}

setInterval(displayMsg, 800);