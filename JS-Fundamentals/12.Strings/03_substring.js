function solve(args) {
    var s = args[0].toLowerCase(),
        text = args[1].toLowerCase(),
        reg = new RegExp(s, 'g');

    console.log(text.match(reg).length);
}

// test

solve([
    'in',
    'We are living in an yellow submarine. We don\'t have anything else. inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.'
]);