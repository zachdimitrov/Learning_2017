let scroll;
let fontSize = 24;
let colors = [];
for (let i = 0; i < 255; i += 8) {
    colors.push(`rgb(${i}, 0, 0)`)
}
let colorIndex = 0;
let coords = {
    x: 20,
    y: 50
}
let deltaX = fontSize / 4,
    deltaY = fontSize / 4;

let arrow = {
    left: false,
    right: false,
    up: false,
    down: false
}

window.addEventListener('load', function() {
    scroll = document.getElementById('scrollable');
    scroll.style.display = 'block';
    scroll.style.position = 'absolute';
    scroll.style.fontFamily = 'sans-serif';
    scroll.style.fontStyle = 'bold';
    scroll.style.fontSize = fontSize + 'px';
    console.log(scroll.style.fontSize);

    window.addEventListener('wheel', function(e) {
        if (e.deltaY < 0) {
            fontSize++;
            colorIndex--;
            if (colorIndex < 0) {
                colorIndex = colors.length - 1;
            }
        } else if (e.deltaY > 0) {
            fontSize--;
            colorIndex++;
            if (colorIndex >= colors.length) {
                colorIndex = 0;
            }
        }
        scroll.style.color = colors[colorIndex];
        scroll.style.fontSize = fontSize + 'px';
    });

    window.addEventListener('keydown', function(e) {
        switch (e.which) {
            case 37:
                arrow.left = true;
                break;
            case 39:
                arrow.right = true;
                break;
            case 38:
                arrow.up = true;
                break;
            case 40:
                arrow.down = true;
                break;
        }
    });

    window.addEventListener('keyup', function(e) {
        switch (e.which) {
            case 37:
                arrow.left = false;
                break;
            case 39:
                arrow.right = false;
                break;
            case 38:
                arrow.up = false;
                break;
            case 40:
                arrow.down = false;
                break;
        }
    });

    setInterval(mainLoop, 1000 / 30);

    function mainLoop() {
        if (arrow.left) {
            coords.x -= deltaX; // move left
        }
        if (arrow.right) {
            coords.x += deltaX; // move right
        }
        if (arrow.up) {
            coords.y -= deltaY; // move up
        }
        if (arrow.down) {
            coords.y += deltaY; // move down
        }

        scroll.style.top = coords.y + 'px';
        scroll.style.left = coords.x + 'px';
    }

});

/*
123
left 37
right 39
up 38
down 40
*/