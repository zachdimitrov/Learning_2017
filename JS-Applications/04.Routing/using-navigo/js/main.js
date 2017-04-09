import { jquery } from "jquery";
import { addStyles } from "style";
import { print, getQueryParams } from "utils";

$(() => {
    let result = $("#result"),
        router = new Navigo(null, false);

    router
        .on("test/:id/:query", (params, query) => {
            print(params);
            console.log(query);
        })
        .on("test/:query", (params, query) => {
            print(params);
            console.log(query);
        })
        .on({
            'book/:id/note/:noteId/:query': (params, query) => {
                print(params);
                console.log(query);
            },
            'book/:id/:query': (params, query) => {
                print(params);
                console.log(query);
            },
            'book/:id': params => print(params),
            'book/:query': (query) => {
                print(query);
            },
            'book/:id/note/:noteId': params => print(params),
            '*': () => print('home')
        })
        .resolve();

    addStyles();
});