#### Regex Cheat Sheet - from [RegExr](http://regexr.com/)
**Character classes**
```JS
.	 //any character except newline  
\w \d \s //word, digit, whitespace  
\W \D \S //not word, digit, whitespace  
[abc]    //any of a, b, or c  
[^abc]   //not a, b, or c  
[a-g]    //character between a & g  
```
**Anchors**  
```JS
^abc$  //start / end of the string  
\b \B  //word, not-word boundary  
```
**Escaped characters**  
```JS
\. \* \\ \/   //escaped special characters  
\t \n \r  //tab, linefeed, carriage return  
\u00A9       //unicode escaped ©  
```
**Groups & Lookaround**  
```JS
(abc)    //capture group  
\1	 //backreference to group #1  
(?:abc)  //non-capturing group  
(?=abc)  //positive lookahead  
(?!abc)  //negative lookahead  
```
**Quantifiers & Alternation**  
```JS
a* a+ a?    //0 or more, 1 or more, 0 or 1  
a{5} a{2,}  //exactly five, two or more  
a{1,3}      //between one & three  
a+? a{2,}?  //match as few as possible  
ab|cd       //match ab or cd  
```
#### Use in JavaScript
**regex syntax**
```JS
const literalRegex = /y$/g; // literal syntax
const constructorRegex = new RegExp('^T', 'g'); // function constructor syntax
```
**methods and properties** - [here in MDN](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/RegExp)
- ```RegExp.test``` – searches for a match in a given string. Returns true or false  
- ```RegExp.exec``` - searches for the next match in a given string  
  Returns an array of all captured groups for the found match or null.  
- ```String.match``` – searches for a match in a string  
  Returns an array of information or null on a mismatch  
- ```String.replace``` – replaces the matched substring with a replacement substring   
  Returns the new string
- ```String.split``` – breaks a string into an array of substrings, using a regex or a string search for matches  
  Returns an array
- ```String.search``` – tests for a match in a string  
  It returns the index of the match, or -1 if the search fails 

#### Flags
```g``` - global  
```i``` - case insensitive  
```m``` - multi-line search  
```y``` - perform a "sticky" search   
