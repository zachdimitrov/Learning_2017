"use strict";

import { clone, idGenerator as createId } from "utils";

const records = [],
    idGen = createId();

function add(person) {
    const clonedPerson = clone(person);
    clonedPerson.id = idGen.next().value;
    records.push(clonedPerson);
}

function findById(id) {
    const result = records.find(r => r.id == id);
    return clone(result);
}

function all() {
    return clone(records);
}

export { add, all, findById };