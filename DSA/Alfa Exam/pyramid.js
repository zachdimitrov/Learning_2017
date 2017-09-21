function solve(x) {
    let n = parseInt(x, 10);
    let y = x * (x + 1) / 2;
    let c = -2 * n;
    r1 = (1 + Math.sqrt(1 - 4*c))/2;
    r2 = (1 + Math.sqrt(1 - 4*c))/2;
    console.log(Math.floor(r1- 1));
}

solve(5);
solve(8);
solve(25);
