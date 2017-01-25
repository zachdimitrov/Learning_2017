// with nested ifs

function solve(args) {
    var a = +args[0],
        b = +args[1],
        c = +args[2],
        d = +args[3],
        e = +args[4],
        result;

    if (a >= b) {
        if (a >= c) {
            if (a >= d) {
                if (a >= e) {
                    result = a;
                } else {
                    result = e;
                }
            } else {
                if (d >= e) {
                    result = d;
                } else {
                    result = e;
                }
            }
        } else {
            if (c >= d) {
                if (c >= e) {
                    result = c;
                } else {
                    result = e;
                }
            } else {
                if (d >= e) {
                    result = d;
                } else {
                    result = e;
                }
            }
        }
    } else {
        if (b >= c) {
            if (b >= d) {
                if (b >= e) {
                    result = b;
                } else {
                    result = e;
                }
            } else {
                if (d >= e) {
                    result = d;
                } else {
                    result = e;
                }
            }
        } else {
            if (c >= d) {
                if (c >= e) {
                    result = c;
                } else {
                    result = e;
                }
            } else {
                if (d >= e) {
                    result = d;
                } else {
                    result = e;
                }
            }
        }
    }

    return result;
}

/*
                     A
                AE <
               /     E
             AD
            /  \     D
           /    DE < 
          /          E
        AC
       /  \          C
      /    \    CE <
     /      \  /     E
    /        CD
   /           \     D
  /             DE < 
 /                   E
AB 
 \                   B
  \             BE <
   \           /     E
    \        BD
     \      /  \     D
      \    /    DE <
       \  /          E
        BC
          \          C
           \    CE <
            \  /     E
             CD
               \     D
                DE < 
                     E
*/

// With recursion

function solveR(args) {
    var index = args.length - 1;

    function getMax(a, i) {
        if (i === 0) return +a[0];
        if (i > 0) {
            if (+a[i] >= getMax(a, i - 1)) {
                return +a[i];
            } else {
                return getMax(a, i - 1);
            }
        }
    }
    return getMax(args, index);
}

// Tests

console.log(solveR(['5', '2', '2', '4', '1'], 4) == 5);
console.log(solveR(['-2', '-22', '1', '0', '0'], 4) == 1);
console.log(solveR(['-2', '4', '3', '2', '0'], 4) == 4);
console.log(solveR(['0', '-2.5', '0', '5', '5'], 4) == 5);
console.log(solveR(['-3', '-0.5', '-1.1', '-2', '-0.1'], 4) == -0.1);
console.log("-----------------------")
console.log(solve(['5', '2', '2', '4', '1']) == 5);
console.log(solve(['-2', '-22', '1', '0', '0']) == 1);
console.log(solve(['-2', '4', '3', '2', '0']) == 4);
console.log(solve(['0', '-2.5', '0', '5', '5']) == 5);
console.log(solve(['-3', '-0.5', '-1.1', '-2', '-0.1']) == -0.1);