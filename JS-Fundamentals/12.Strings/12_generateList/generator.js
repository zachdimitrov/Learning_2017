var template = document.getElementById('list-item');
var ul = document.createElement("ul");
var li = document.createElement("li");
var person, parts, i, j, p, prop;

template.setAttribute("style", "display: none");
parts = template.children;

for (i in people) {
    person = people[i];
    l = li.cloneNode(true);

    dv = template.cloneNode(true);
    dv.setAttribute("id", "list-item-" + i);
    dv.setAttribute("style", "display: block");
    dvParts = dv.children;

    for (j = 0; j < parts.length; j++) {
        p = parts[j].innerText;
        prop = p.slice(2, p.length - 2);

        if (person.hasOwnProperty(prop)) {
            dvParts[j].innerText = person[prop];
        }
    }

    l.appendChild(dv);
    ul.appendChild(l);
}
document.body.appendChild(ul);