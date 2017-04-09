var db = [],
    id = 1;

function add(file) {
    let myid = id++;
    db.push({ myid, file });
}

function showdb() {
    var result = db.slice().map(f => JSON.stringify(f)).join("\n");
    console.log(result);
    return db.slice();
}

export { add, showdb };