function solve(args) {
    var arr = args[0].split('/');

    console.log('protocol: ' + arr[0].slice(0, arr[0].length - 1));
    console.log('server: ' + arr[2]);
    console.log('resource: /' + arr.slice(3).join('/'));
}

// test

solve(['http://telerikacademy.com/Courses/Courses/Details/239']);