window.onload = function() {
    var can = document.getElementById("the-canvas");
    var canCtx = can.getContext("2d");

    canCtx.lineWidth = "3";
    canCtx.fillStyle = "red";
    canCtx.fillRect(10, 10, 50, 75);
    canCtx.strokeRect(70, 10, 50, 75);
}