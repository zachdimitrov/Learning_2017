function solve(args) {
    let x = +args[0],
        y = +args[1],
        circle = "inside",
        rectangle = "inside",
        distance = Math.sqrt((x - 1) * (x - 1) + (y - 1) * (y - 1));

    if (distance > 1.5) {
        circle = "outside";
    }

    if (x < -1 || x > 5 || y < -1 || y > 1) {
        rectangle = "outside";
    }

    console.log(`${circle} circle ${rectangle} rectangle`);
}

// old es

function solve(args) {
    var x = +args[0],
        y = +args[1],
        circle = "inside",
        rectangle = "inside",
        distance = Math.sqrt((x - 1) * (x - 1) + (y - 1) * (y - 1));

    if (distance > 1.5) {
        circle = "outside";
    }

    if (x < -1 || x > 5 || y < -1 || y > 1) {
        rectangle = "outside";
    }

    console.log(circle + ' circle ' +  rectangle + ' rectangle');
}