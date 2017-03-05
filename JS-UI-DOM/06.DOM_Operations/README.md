#### Finding HTML Elements

Method | Description
--- | ---
`document.getElementById(id)`	| Find an element by element id
`document.getElementsByTagName(name)`|	Find elements by tag name
`document.getElementsByClassName(name)`|	Find elements by class name

#### Navigating Between Nodes  

- parentNode
- childNodes[nodenumber]
- firstChild
- lastChild
- nextSibling
- nextElementSibling
- previousSibling
- nodeValue
- nodeType

```js
element.parentNode.removeChild(element); //workaround to remove an element without knowing the parent
input.value // pokazva teksta v input pole
element.cloneNode(true) // syzdava deep copie
```

#### Changing HTML Elements

Method|	Description
---|---
`element.innerHTML =  new html content`|	Change the inner HTML of an element
`element.attribute = new value`|	Change the attribute value of an HTML element
`element.setAttribute(attribute, value)`|	Change the attribute value of an HTML element
`element.style.property = new style`|	Change the style of an HTML element

#### Adding and Deleting Elements

Method|	Description
---|---
`document.createElement(element)`|	Create an HTML element
`parent.removeChild(element)`|	Remove an HTML element
`parent.appendChild(element)`|	Add an HTML element at the end
`parent.replaceChild(element)`|	Replace an HTML element
`document.write(text)`|	Write into the HTML output stream
`parent.insertBefore(element)` | Add HTML element at the beginning

#### Adding Events Handlers

Method|	Description
---|---
`document.getElementById(id).onclick = function(){code}`|	Adding event handler code to an onclick event

#### Finding HTML Objects

Property|	Description	DOM
---|---
`document.anchors` |	Returns all \<a\> elements that have a name attribute
`document.applets` |	Returns all \<applet\> elements (Deprecated in HTML5)
`document.baseURI` |	Returns the absolute base URI of the document
`document.body` |	Returns the \<body\> element
`document.cookie` |	Returns the document's cookie
`document.doctype` |	Returns the document's doctype
`document.documentElement` |	Returns the <html> element
`document.documentMode` |	Returns the mode used by the browser
`document.documentURI` |	Returns the URI of the document
`document.domain` |	Returns the domain name of the document server
`document.domConfig` |	Obsolete. Returns the DOM configuration
`document.embeds` |	Returns all <embed> elements
`document.forms` |	Returns all \<form\> elements
`document.head` |	Returns the \<head\> element
`document.images` |	Returns all \<img\> elements
`document.implementation` |	Returns the DOM implementation
`document.inputEncoding` |	Returns the document's encoding (character set)
`document.lastModified` |	Returns the date and time the document was updated
`document.links` |	Returns all \<area\> and <a> elements that have a href attribute
`document.readyState` |	Returns the (loading) status of the document
`document.referrer` |	Returns the URI of the referrer (the linking document)
`document.scripts` |	Returns all \<script\> elements
`document.strictErrorChecking` |	Returns if error checking is enforced
`document.title` |	Returns the \<title\> element
`document.URL` |	Returns the complete URL of the document
