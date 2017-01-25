function solve(args) {
    return args[0].toLowerCase()
        .slice(0, -1)
        .split(' ')
        .filter(x => x !== '')
        .map(w => {
            let c = w[w.length - 1];
            if (c === '.' || c === '!' || c === '?' || c === ',') {
                return w.slice(0, -1);
            } else {
                return w;
            }
        })
        .filter(word => word === word.split("").reverse().join(""));
}

console.log(solve(['Some words like mastetsam and sometemos are called palindromes. Same word is dooppood. What are wronnorw and texet?']));