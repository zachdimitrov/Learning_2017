window.addEventListener('load', function() {
    var container = document.getElementById('content'),
        canvas = document.createElement('canvas'),
        pokeballCanvas = document.createElement('canvas');
    canvas.id = "player-canvas";
    canvas.width = 800;
    canvas.height = 500;
    container.appendChild(canvas);

    pokeballCanvas.id = "pokeball-canvas";
    pokeballCanvas.width = 800;
    pokeballCanvas.height = 500;
    container.appendChild(pokeballCanvas);

    var gravityPull = 0.2,
        friction = 0;

    // var playerCanvas = document.getElementById("player-canvas");
    var playerContext = canvas.getContext('2d'),
        pokeballContext = pokeballCanvas.getContext('2d'),
        playerImg = document.getElementById("pikachu-sprite"),
        pokeballImg = document.getElementById("pokeball-sprite");

    var frameIndex = 0,
        framesCount = 4,
        loopTicksPerFrame = 5,
        loopTicksCount = 0,
        px = 0,
        py = 0,
        speedX = 3,
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
        coords: { x: 20, y: canvas.height - pikachu.height },
        speed: { x: 0, y: 0 },
        width: pikachu.width,
        height: pikachu.height,
        field: { x: canvas.width, y: canvas.height },
    });

    function createPokeball() {
        var pokeball = createSprite({
            spriteSheet: pokeballImg,
            context: pokeballContext,
            width: pokeballImg.width / 18,
            height: pokeballImg.height,
            framesCount: 18,
            loopTicksPerFrame: 5,
        });
        var pokeballBody = createPhysicalBody({
            coords: { x: canvas.width, y: canvas.height - pokeball.height },
            speed: { x: -3, y: 0 },
            width: pokeball.width,
            height: pokeball.height,
            field: { x: canvas.width, y: canvas.height }
        })

        return {
            sprite: pokeball,
            body: pokeballBody
        }
    }

    window.addEventListener('keydown', function(ev) {
        console.log(ev.which);
        friction = 0;
        let pikachuGround = canvas.height - pikachu.height;
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
                if (pikachuBody.coords.y < pikachuGround - pokeballImg.height || pikachuBody.speed.y > 0) {
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
        friction = gravityPull;
    });
    var pokeballs = [];

    function gameLoop() {
        var lastPikachuCoords = pikachuBody
            .gravity(gravityPull)
            .decelerate(friction)
            .move();

        pikachu
            .render(pikachuBody.coords, lastPikachuCoords)
            .update();


        for (i = 0; i < pokeballs.length; i += 1) {
            var pokeball = pokeballs[i];
            if (pokeball.body.coords.x < pokeball.body.width.x) {
                pokeballs.splice(i, 1);
                console.log(pokeballs.length);
                continue;
            }
            var lastPokeballCoords = pokeball.body.move();

            pokeball.sprite
                .render(pokeball.body.coords, lastPokeballCoords)
                .update();

            if (pikachuBody.collidesWith(pokeball.body)) {
                playerContext.drawImage(
                    document.getElementById("dead-player"),
                    100, 200
                );
                return;
            }
        }

        if (Math.random() < 0.003) {
            pokeballs.push(createPokeball());
        }
        window.requestAnimationFrame(gameLoop);
    }

    gameLoop();
});