const fetch = require('node-fetch');

fetch('http://localhost:3001/api/people')
    .then((response) => {
        return response.json();
    })
    .then((result) => {
        console.log(result);
    });