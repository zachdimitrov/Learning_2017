function solve(n) {
    let k = n[0].split('');
    for(let i = 1; i <= 10; i++) {
        let len = k.length;
        let dig = k[len - 1];
        for(let j = len - 1; j >= 0; j--) {
            if(+dig < 9) {
                k[j] = +dig + 1; 
                console.log(k.join(''));
                break;
            } else {
                k[j] = '0';
                if(j == 0) {
                    k = ('1' + k.join('')).split('');
                    console.log(k.join(''));
                break;
                
                } else {
                    dig = k[j - 1];
                }
            }
        }
    }
}

solve(['97']);
