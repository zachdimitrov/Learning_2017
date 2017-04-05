// paste in console
(function() {
    console.log('start');
    var delay = 2000;
    setTimeout(() => {
        console.log('paused for ' + delay + 'ms');
        console.log('middle1');
        setTimeout(() => {
            console.log('paused for ' + delay + 'ms');
            console.log('middle2');
            setTimeout(() => {
                console.log('paused for ' + delay + 'ms');
                console.log('middle3');
            }, delay);
        }, delay);
    }, delay);
}());
// pyramid of death