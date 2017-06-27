const fs = require('fs');
const readline = require('readline'); // this is for readin line by line

// sync reading
const filesInDir = fs.readdirSync('Modules');
console.log(filesInDir);
const fileContent = fs.readFileSync('Modules/app.js', 'utf8');
console.log(fileContent);

// async reading
// same as sync with callback as third parameter
// errors are saved in "err"
fs.readFile('Modules/fetch-test.js', 'utf8', (err, content) => {
    if (err) {
        throw err;
    }
    console.log(content);
});
console.log(new Date());

// write files
// sync writing

const content = {
    name: 'Pesho',
    age: 3,
    born: new Date(1983, 3, 13),
    ismale: true,
};

fs.writeFileSync('./ReadWriteFiles/new-file.json',
    JSON.stringify(content), 'utf8');