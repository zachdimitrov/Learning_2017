# Unity 2D 

### 01. Basics

- Open project, select 2D 
- Project Browser - all files in the project, create folders
- Hierarchy - all game objects and their combinations
    - double click to center on object
    - create empty object to use like folder
- Inspector - all properties of selected game object
    - Transform - change position, rotation and scale
    - Settings of obect (size of camera is 1/2 of height)
    - Components - scripts, rigid body...
- Camera - at least 1 camera (we can have more)
    - Scene - add and manipulate objects
    - Game - camera proportions and preview window
- Layers - ways to separate objects
- Publishing builds
    - Build settings - and Build

**Game objects**
- everything is game object
- default components - Name, Tag, Layer, Transform
    - use Tag for selection
    - sorting layer - will order objects based on their order
- static option - object will not be calculated
- optional components
    - sprite
    - camera
    - animation
    - physics (rigid body 2D)
    - script

**Scripts**

```c#
using UnityEngine;

// "this" is the game object that is manipulated
public class SpeedController: MonoBehaviour
{
    void Start() {
        // do something before start
    }

    void Update() {
        // do before every visualisation
    }

    void FixedUpdate() {

    }
}
```

**Prefabs**
- create custom object that can be dublicated
- make folder "Prefabs" and drag object inside (from Hierarchy)
    - if blue than it is part of prefab
    - break prefab instance - detatch from prefab
- ctrl + D clone objects

### 02. Mathematics