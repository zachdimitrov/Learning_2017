(function(x) {
    let line = 1;
    let printElement = function(elm, indent) {
        let text = '';
        let spaces = '';
        let l = document.createElement('div');
        l.style.fontFamily = 'consolas';
        for (let i = 0; i < indent; i += 1) {
            spaces += '.';
        }

        if (elm.tagName) {
            console.log(line + '.' + spaces + '<' + elm.tagName.toLowerCase() + '>');
            l.innerText = line + '.' + spaces + '<' + elm.tagName.toLowerCase() + '>' + '\n';
            document.body.appendChild(l);
            line++;
        }

        for (let i = 0, len = elm.childNodes.length; i < len; i += 1) {
            printElement(elm.childNodes[i], indent + 4);
        }

        if (elm.tagName) {
            console.log(line + '.' + spaces + '</' + elm.tagName.toLowerCase() + '>');
            l.innerText = line + '.' + spaces + '</' + elm.tagName.toLowerCase() + '>' + '\n';
            document.body.appendChild(l);
            line++;
        }
    }

    return printElement(x, 1);
}(document.body));