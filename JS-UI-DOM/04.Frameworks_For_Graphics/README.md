# Table of Contents
- KineticJS overview and setup
    - Working with KineticJS
    - Initializing canvas
- Drawing shapes
    - Rects, circles, paths, blobs
- Event handlers
    - Attaching click, drag&drop

# KineticJS
## Overview and Setup

# KineticJS Overview
- KineticJS is a JavaScript framework to work with the Canvas
    - Introduces a refined API for canvas functionality
    - Has stages and layers for better canvas performance
        - Layers contain different sets of objects that can be used together

# KineticJS Setup
- To use KineticJS (cont.):
    - Do the following in the script:

```js
    function initKinetic(){
        var stage = new Kinetic.Stage({
          container: 'canvas-container',
          width: 450,
          height: 350
        });
        var layer = new Kinetic.Layer();
        var rect = new Kinetic.Rect(options);
        var circle = new Kinetic.Circle(options);
        layer.add (rect);
        layer.add (circle);
        stage.add(layer);
    }
```

# Drawing Shapes with KineticJS
## Rects, Circles, Line, etc...

```js
rect = new Kinetic.Rect({
  fill: 'yellowgreen',
  stroke: '# CCCCCC',
  x: 250,
  y: 350,
  width: 57,
  height: 93
});

circle = new Kinetic.Circle({
  radius: 45,
  fill: 'purple',
  stroke: 'blue',
  strokeWidth: 3,
  x: 450,
  y: 350,
});

straight = new Kinetic.Line({
  points: [x1, y1, x2, y2],
  stroke: 'green',
  strokeWidth: 2,
  lineJoin: 'round'
});

curved = new Kinetic.Line({
  points: [x1, y1, x2, y2],
  stroke: 'green',
  strokeWidth: 2,
  tension: 1
});

polygon = new Kinetic.Line({
  points: [ … ]
  stroke: 'green',
  fill: 'yellowgreen'
  strokeWidth: 2,
  closed: true
});

blob = new Kinetic.Line({
  points: [ … ],
  stroke: 'green',
  fill: 'purple',
  closed: true,
  tension: 0.5
});
```