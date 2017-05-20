## XML Basics  
- structure and rules  
 - opening tag `<?xml version="1.0" encoding="UTF-8"?>`  
 - root `<root>`  
 - any kind of data and elements (tags)  
 - can have attributes (properties)  
 - all names must be lowercase  

### namespaces
 - avoid name conflicts
 - url-a ne se izpolzva, samo dava unikalno ime na namespace
 - example: 
 ```xml
 <root 
xmlns:h="http://www.w3.org/TR/html4/"
xmlns:f="https://www.w3schools.com/furniture">

<h:table>
  <h:tr>
    <h:td>Apples</h:td>
    <h:td>Bananas</h:td>
  </h:tr>
</h:table>

<f:table>
  <f:name>African Coffee Table</f:name>
  <f:width>80</f:width>
  <f:length>120</f:length>
</f:table>

</root>
 ```
 - default namespace `xmlns="namespaceURI"` no prefixes used

#### XSD (schema)
 - defines rules for XML elements
 - can be automatically generated

#### XML Parsers
- DOM Parser - for small files
- SAX - Simple API for XML
- StAX - Streaming API for XML
- XDocument -> LINQ-to-XML (too slow but best for .NET)

#### XPath
- path to brouse XML file
`/library/book[isbn=""]`
`/catalog/cd[@price<10]`

#### XSL transformations
- creates HTML from XML

## 