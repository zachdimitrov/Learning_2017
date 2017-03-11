var Container = PIXI.Container,
    autoDetectRenderer = PIXI.autoDetectRenderer,
    loader = PIXI.loader,
    resources = PIXI.loader.resources,
    Sprite = PIXI.Sprite,
    TextureCache = PIXI.utils.TextureCache,
    Rectangle = PIXI.Rectangle,
    w = 48,
    mapItems,
    state,
    white,
    black,
    mouseRw,
    mouseLw,
    mouseUw,
    mouseDw,
    mouseRb,
    mouseLb,
    mouseUb,
    mouseDb,
    b = new Bump(PIXI);

var renderer = autoDetectRenderer(576, 384),
    stage = new Container(),
    div = document.getElementById("wrapper");

div.appendChild(renderer.view);
renderer.backgroundColor = 0xf2f2f2;

loader
    .add("image/mouses.json")
    .on("progress", loadProgressHandler)
    .load(setup);

function loadProgressHandler(loader, resource) {
    console.log('loading: ' + resource.url + ' - ' + 'progress: ' + loader.progress + "%");
}

function setup() {
    var id = PIXI.loader.resources["image/mouses.json"].textures;

    mouseRw = new Sprite(id["w-mouse-right.png"]);
    mouseLw = new Sprite(id["w-mouse-left.png"]);
    mouseUw = new Sprite(id["w-mouse-up.png"]);
    mouseDw = new Sprite(id["w-mouse-down.png"]);
    mouseRb = new Sprite(id["b-mouse-right.png"]);
    mouseLb = new Sprite(id["b-mouse-left.png"]);
    mouseUb = new Sprite(id["b-mouse-up.png"]);
    mouseDb = new Sprite(id["b-mouse-down.png"]);

    var map = levels.level3;
    mapItems = new Container();

    for (var i = 0; i < map.length; i++) {
        for (var j = 0; j < map[i].length; j++) {
            let part = map[i][j];
            let name = defineElement(part);
            if (name) {
                let e = new Sprite(id[name]);
                e.scale.set(0.5, 0.5);
                e.position.set(j * 48, i * 48);
                mapItems.addChild(e);
            }
        }
    }

    stage.addChild(mapItems);

    let m = [
        mouseRw, // 0 - right
        mouseLw, // 1 - left
        mouseUw, // 2 - up
        mouseDw, // 3 - down
        mouseRb, // right + 4
        mouseLb, // left + 4
        mouseUb, // up + 4
        mouseDb // down + 4
    ];

    m.forEach(function(p) {
        p.scale.set(0.45, 0.45);
    });

    let mice = states.initial();
    black = mice[0];
    white = mice[1];

    // white moise keyboard control
    function changeMice(newMouse) {
        let x = white.x,
            y = white.y;
        stage.removeChild(white);
        white = newMouse;
        white.x = x;
        white.y = y;
        stage.addChild(white);
    }

    var left = keyboard(37),
        up = keyboard(38),
        right = keyboard(39),
        down = keyboard(40);

    left.press = function() {
        changeMice(mouseLw);
        white.vx = -2;
        white.vy = 0;
    }

    left.release = function() {
        white.vx = 0;
    }

    right.press = function() {
        changeMice(mouseRw);
        white.vy = 0;
        white.vx = 2;
    }

    right.release = function() {
        white.vx = 0;
    }

    up.press = function() {
        changeMice(mouseUw);
        white.vx = 0;
        white.vy = -2;
    }

    up.release = function() {
        white.vy = 0;
    }

    down.press = function() {
        changeMice(mouseDw);
        white.vx = 0;
        white.vy = 2;
    }

    down.release = function() {
        white.vy = 0;
    }

    state = states.play;

    gameLoop();
}

function gameLoop() {
    requestAnimationFrame(gameLoop);

    state();

    renderer.render(stage);
}

// states

var states = {
    play: function() {
        moveHero();
        moveEnemy();
    },
    initial: function() {
        white = mouseRw;
        white.position.set(w, w);
        stage.addChild(white);
        white.vx = 0;
        white.vy = 0;

        black = mouseUb;
        black.position.set(10 * w, 7 * w);
        stage.addChild(black);
        black.vx = 0;
        black.vy = -2;
        return [black, white];
    },
    stop: function() {
        white.vx = 0;
        white.vy = 0;
    }
}

function moveHero() {
    if (b.hit(white, mapItems.children[10])) {
        white.x = 385 - 3 * 48;
        white.y = 289;
    }
    if (b.hit(white, mapItems.children[33])) { //52
        white.x = 481;
        white.y = 49;
    }
    let collides = b.hit(white, mapItems.children, true, false, true);
    if (!collides) {
        white.x += white.vx;
        white.y += white.vy;
    }
}

function moveEnemy() {
    let collides = b.hit(black, mapItems.children, true, false, false,
        function(side, platform) {
            //console.log(black.vx + " - " + black.vy + " - " + side + " - " + platform);
            let rand = Math.round(Math.random());
            if (black.vx === 2) {
                if (rand === 0) {
                    move("up");
                } else {
                    move("down");
                }
            } else if (black.vx === -2) {
                if (rand === 0) {
                    move("up");
                } else {
                    move("down");
                }
            } else if (black.vy === 2) {
                if (rand === 0) {
                    move("left");
                } else {
                    move("right");
                }
            } else if (black.vy === -2) {
                if (rand === 0) {
                    move("left");
                } else {
                    move("right");
                }
            }
        });

    function move(dir) {
        switch (dir) {
            case "up":
                changeBMice(mouseUb);
                black.vy = -2;
                black.vx = 0;
                break;
            case "down":
                changeBMice(mouseDb);
                black.vx = 0;
                black.vy = 2;
                break;
            case "left":
                changeBMice(mouseLb);
                black.vy = 0;
                black.vx = -2;
                break;
            case "right":
                changeBMice(mouseRb);
                black.vx = 2;
                black.vy = 0;
                break;
        }
    }

    function changeBMice(newMouse) {
        let x = black.x,
            y = black.y;
        stage.removeChild(black);
        black = newMouse;
        black.x = x;
        black.y = y;
        stage.addChild(black);
    }

    black.x += black.vx;
    black.y += black.vy;
}