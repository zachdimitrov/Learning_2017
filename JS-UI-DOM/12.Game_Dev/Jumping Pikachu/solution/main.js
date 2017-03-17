window.addEventListener('load', function() {
    var container = document.getElementById('content'),
        canvas = document.createElement('canvas');
    canvas.id = "canvas";
    canvas.width = 800;
    canvas.height = 500;
    container.appendChild(canvas),
        gravityPull = 0.1,
        friction = 0;

    // var playerCanvas = document.getElementById("player-canvas");
    var playerContext = canvas.getContext('2d'),
        playerImg = document.getElementById("pikachu-sprite"),
        pokeballImg = document.getElementById("pokeball-sprite");

    var frameIndex = 0,
        framesCount = 4,
        loopTicksPerFrame = 5,
        loopTicksCount = 0,
        px = 0,
        py = 0,
        speedX = 5,
        speedY = 5;

    var pikachu = createSprite({
        spriteSheet: playerImg,
        context: playerContext,
        width: playerImg.width / 4,
        height: playerImg.height,
        framesCount: 4,
        loopTicksPerFrame: 5,
    });
    var pikachuBody = createPhysicalBody({
        coords: { x: 0, y: 0 },
        speed: { x: 0, y: 0 },
        width: pikachu.width,
        height: pikachu.height,
        field: { x: canvas.width, y: canvas.height },
    });

    var pokeball = createSprite({
        spriteSheet: pokeballImg,
        context: playerContext,
        width: pokeballImg.width / 18,
        height: pokeballImg.height,
        framesCount: 18,
        loopTicksPerFrame: 5,
    });
    var pokeballBody = createPhysicalBody({
        coords: { x: 100, y: 0 },
        speed: { x: 0, y: 0 },
        width: pokeball.width,
        height: pokeball.height,
        field: { x: canvas.width, y: canvas.height }
    })

    window.addEventListener('keydown', function(ev) {
        console.log(ev.which);
        friction = 0;
        let pikachuGround = canvas.height - pikachuBody.height;
        switch (ev.which) {
            case 37:
                if (pikachuBody.coords.x <= 0) {
                    pikachuBody.coords.x = 0;
                    pikachuBody.speed.x = 0;
                    return;
                }
                pikachuBody.speed.x = -speedX;
                break;
            case 38:
                if (pikachuBody.coords.y < pikachuGround) {
                    return;
                }
                pikachuBody.speed.y = -speedY;
                break;
            case 39:
                pikachuBody.speed.x = speedX;
                break;
            case 40:
                pikachuBody.speed.y = speedY;
                break;
            default:
                pikachuBody.speed.x = 0;
                pikachuBody.speed.y = 0;
                break;
        }
    });

    window.addEventListener('keyup', function(ev) {
        switch (ev.which) {
            case 37:
                friction = 0.1;
                break;
            case 39:
                friction = 0.1;
                break;
            default:
                break;
        }
    });

    function gameLoop() {
        var lastPikachuCoords = pikachuBody
            .gravity(gravityPull)
            .decelerate(friction)
            .move(),
            lastPokeballCoords = pokeballBody.move();

        pikachu
            .render(pikachuBody.coords, lastPikachuCoords)
            .update();

        pokeball
            .render(pokeballBody.coords, lastPokeballCoords)
            .update();
        window.requestAnimationFrame(gameLoop);
    }

    gameLoop();
});