function createSprite(options) {
    var sprite = {
        spriteSheet: options.spriteSheet,
        context: options.context,
        width: options.width,
        height: options.width,
        framesCount: options.framesCount,
        loopTicksPerFrame: options.loopTicksPerFrame,
        frameIndex: 0,
        loopTicksCount: 0,
        render: render,
        update: update
    };

    function render(drawCoord, clearCoord) {
        this.context.clearRect(clearCoord.x, clearCoord.y, this.width, this.height);
        this.context.drawImage(this.spriteSheet, this.frameIndex * this.width, 0, this.width, this.height, drawCoord.x, drawCoord.y, this.width, this.height);
        return this;
    }

    function update() {
        this.loopTicksCount += 1;

        if (this.loopTicksCount >= this.loopTicksPerFrame) {
            this.frameIndex += 1;
            if (this.frameIndex >= this.framesCount) {
                this.frameIndex = 0;
            }
            this.loopTicksCount = 0;
        }
        return this;
    }

    return sprite;
}