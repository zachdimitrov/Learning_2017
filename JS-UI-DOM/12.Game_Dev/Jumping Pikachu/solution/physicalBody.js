function createPhysicalBody(options) {
    'use strict';
    var physicalBody = {
        coords: options.coords,
        speed: options.speed,
        height: options.height,
        width: options.width,
        field: options.field,
        move: move,
        collidesWith: collidesWith,
        gravity: gravity,
        decelerate: decelerate
    };

    function move() {
        var lastCoords = { x: this.coords.x, y: this.coords.y };

        // decelerate takes care of X
        this.coords.x += this.speed.x;
        // gravity takes care of Y
        this.coords.y += this.speed.y;

        return lastCoords;
    }

    function collidesWith(otherBody) {
        var thisRadius = (this.width + this.height) / 4,
            otherRadius = (otherBody.width + otherBody.height) / 4,
            x1 = this.coords.x + this.width / 2,
            y1 = this.coords.y + this.height / 2,
            x2 = otherBody.coords.x + otherBody.width / 2,
            y2 = otherBody.coords.y + otherBody.height / 2,
            distance = Math.sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
        return distance <= thisRadius + otherRadius;
    }

    function decelerate(gravity) {
        if (this.coords.x < 0) {
            this.coords.x = 0;
        }
        if (this.coords.x > this.field.x - this.width) {
            this.coords.x = this.field.x - this.width;
        }
        if (this.speed.x > 0) {
            this.speed.x -= gravity;
            if (this.speed.x < 0) {
                this.speed.x = 0;
            }
        }
        if (this.speed.x < 0) {
            this.speed.x += gravity;
            if (this.speed.x > 0) {
                this.speed.x = 0;
            }
        }
        return this;
    }

    function gravity(gravity) {
        let floor = this.field.y - this.height / 2;
        if (this.coords.y === floor) {
            return this;
        }
        if (this.coords.y > floor) {
            this.coords.y = floor;
            this.speed.y = 0;
            return this;
        }
        if (this.coords.y < floor) {
            this.speed.y += gravity;
        }
        return this;
    }

    return physicalBody;
}