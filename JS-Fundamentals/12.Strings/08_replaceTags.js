function solve(args) {
    let text = args[0],
        tag = {},
        res = '';

    for (let i = 0, len = text.length; i < len; i += 1) {
        if (text[i] === '<') {
            if (text[i + 1] === 'a') {
                let p = text.indexOf('>', i);
                tag.pos = i;
                tag.adres = text.substring(i, p + 1);
                i += tag.adres.length;

                if (tag.adres) {
                    tag.name = '';
                    for (var j = i; j < text.length; j++) {
                        if (text[j] === '<') {
                            break;
                        } else {
                            tag.name += text[j];
                        }
                    }
                    //console.log(tag.name);
                    i += tag.name.length - 1;
                }
            } else if (text[i + 1] === '/' && text[i + 2] === 'a') {
                res += `[${tag.name}](${tag.adres.split('"')[1]}) `;
                i += 4;
            } else {
                res += text[i];
            }
            //console.log(tag);
        } else {
            res += text[i];
        }
    }
    return res;
}

// test

console.log(solve(['<p>Please visit <a href="http://academy.telerik.com">our site</a> to choose a training course. Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>']) ===
    '<p>Please visit [our site](http://academy.telerik.com) to choose a training course. Also visit [our forum](www.devbg.org) to discuss the courses.</p>'
);