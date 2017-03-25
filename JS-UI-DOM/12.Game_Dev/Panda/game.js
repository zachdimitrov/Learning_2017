// create aliaces for PIXI objects
var Container = PIXI.Container,
    autoDetectRenderer = PIXI.autoDetectRenderer,
    loader = PIXI.loader,
    resources = PIXI.loader.resources,
    Sprite = PIXI.Sprite,
    TextureCache = PIXI.utils.TextureCache,
    Rectangle = PIXI.Rectangle;

// Create the renderer
var renderer = new PIXI.CanvasRenderer(512, 256, { transparent: true });

// Add the canvas to the HTML document
var content = document.getElementById('content');
content.appendChild(renderer.view);

// Create a container object called the 'stage'
var stage = new Container();

// Load resources and start
loader
    .add('assets/panda.json')
    .on("progress", loadProgressHandler)
    .load(setup);

// progress handler - not necessary
function loadProgressHandler(loader, resource) {
    console.log('loading: ' + resource.url + ' - ' + 'progress: ' + loader.progress + "%");
}

// setup function
function setup() {
    // var id = resources["assets/panda.json"].textures,
    frames = [];

    for (let i = 6; i < 10; i++) {
        let val = i < 10 ? '0' + i : i;
        frames.push(PIXI.Texture.fromFrame("panda_" + val + ".png"));
    }

    console.log(frames);

    // create animation
    panda = new PIXI.extras.MovieClip(frames);
    panda.animationSpeed = 0.2;
    panda.play();
    stage.addChild(panda);
    panda.position.x = 200;
    panda.position.y = 150;
    gameLoop();
}

// main function
function gameLoop() {
    panda.rotation += 0.01;
    renderer.render(stage);
    requestAnimationFrame(gameLoop);
}