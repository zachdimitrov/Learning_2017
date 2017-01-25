function solve(args) {
    let width = +args[0],
    height = +args[1], 
    area = width * height, 
    perimeter = 2*(width+height);

    console.log(`${area} ${perimeter}`);
}

// old es

function solve2(args) {
    var width = +args[0],
    height = +args[1], 
    area = width * height, 
    perimeter = 2*(width+height);

    console.log(area.toFixed(2) + ' ' + perimeter.toFixed(2));
}