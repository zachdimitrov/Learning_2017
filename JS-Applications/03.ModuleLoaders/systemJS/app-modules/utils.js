"use strict";

function clone(obj) {
    return JSON.parse(JSON.stringify(obj));
}

function* idGenerator() {
    let currentId = 0;
    while (true) {
        yield currentId;
        currentId += 1;
    }
}

function popup(message) {
    alert(message);
}

export { clone, popup, idGenerator };