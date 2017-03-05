// create aliaces for PIXI objects
var Container = PIXI.Container,
    autoDetectRenderer = PIXI.autoDetectRenderer,
    loader = PIXI.loader,
    resources = PIXI.loader.resources,
    Sprite = PIXI.Sprite,
    TextureCache = PIXI.utils.TextureCache,
    Rectangle = PIXI.Rectangle;

// Create the renderer
var renderer = autoDetectRenderer(500, 256);
// can add 
// {antialias: false, transparent: false, resolution: 1}
// as optional third argument

// if we want canvas renderer use:   renderer = new PIXI.CanvasRenderer(256, 256);
// or if we want to forse use webGL: renderer = new PIXI.WebGLRenderer(256, 256);

// Add the canvas to the DTML document
document.body.appendChild(renderer.view);

// Create a container object called the 'stage'
var stage = new Container();

// Add border and background
renderer.view.style.border = "1px dashed black";
renderer.backgroundColor = 0xf2f2f2;

// resize canvas
//renderer.resize(512, 350);

renderer.view.style.position = "absolute"
renderer.view.style.width = window.innerWidth + "px";
renderer.view.style.height = window.innerHeight + "px";
renderer.view.style.display = "block";

var images = [
    "image/boy.png",
    "image/boyKick.png",
    "image/ball.png",
    "image/tiles.png"
];

PIXI.loader
    .add(images)
    .on("progress", loadProgressHandler)
    .load(setup);

function loadProgressHandler(loader, resource) {
    console.log('loading: ' + resource.url + ' - ' + 'progress: ' + loader.progress + "%");
}

function setup() {
    var texture = TextureCache["image/tiles.png"];
    var rectangle = new Rectangle(0, 0, 32, 32);
    texture.frame = rectangle;
    var boy = new Sprite(
            resources["image/boy.png"].texture
        ),
        ball = new Sprite(
            resources["image/ball.png"].texture
        ),
        boyKick = new Sprite(
            resources["image/boyKick.png"].texture
        ),
        mouse = new Sprite(texture);

    stage.addChild(boy);
    stage.addChild(ball);
    stage.addChild(boyKick);
    stage.addChild(mouse);

    boy.height = 200;
    boy.width = 160;
    boy.x = 30;

    boyKick.scale.x = 0.7;
    boyKick.x = 200;

    // if we want to hide it 
    // boy.visible = false;

    // if we want to delete it 
    // stage.removeChild(boy);

    //ball.anchor.set(0.43, 0.48);
    ball.pivot.set(43, 48);
    ball.position.set(160, 140);
    ball.scale.set(0.6, 0.7);
    ball.rotation = 0.5;

    // Tell the 'renderer' to 'render' the 'stage'
    renderer.render(stage);
}