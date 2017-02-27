# Handlebars.js

## Syntax and usage of built-in functionality

#### Simple notation (if we have oproperty title in the object)

```tpl
<h1>{{title}}</h1>   - Simple expression placeholder, we need JS object with property *title*
```

#### Dot seperated expression (for article property that has tutle sub-property)

```tpl
<h1>{{article.title}}</h1>
```

#### Iterating an array (iterates over each item of array)

```htpl
{{#each}}
  <div>
    {{body}}
  </div>
{{/each}}
```

#### Iterating an object (iterates over each property)

```tpl
{{#each objectName}}
  <div>
    {{this}} // this is the current element
  </div>
{{/each}}
```

#### Using current Index

```tpl
{{#each array}}
  {{@index}}: {{this}}
{{/each}}
```

#### Using current Object Key

```tpl
{{#each array}}
  {{@key}}: {{this}}
{{/each}}
```

#### Block parameters

```tpl
{{#each users as |user userId|}}
  Id: {{userId}} Name: {{user.name}}
{{/each}}
```

#### Segment-Literal Iteration Notation (same as ```articles[10]['#comments']``` in JS)

```tpl
{{#each articles.[10].[#comments]}}
  <h1>{{subject}}</h1>
  <div>
    {{this.body}}
  </div>
{{/each}}
```

#### Using **if** statement

```tpl
{{#if isActive}}
  <img src="star.gif" alt="Active">
{{else}}           // this is optional can be changed with {{^}}
  <img src="cry.gif" alt="Inactive">
{{/if}}
```

#### Unless Statement (inverse of if)

```tpl
<div class="entry">
  {{#unless license}}
  <h3 class="warning">WARNING: This entry does not have a license!</h3>
  {{/unless}}
</div>
```

## How to create and use templates 

#### Wrap template in the HTML file

```tpl
<script id="entry-template" type="text/x-handlebars-template">  - use this to wrap templates in HTML file
{{{body}}} - if we don't want to escape html symbols - this returns working html
new Handlebars.SafeString(result) - another way to not escape HTML
``` 
#### Handlebars compilation

```js
var source = $("#entry-template").html(); //getting the template objec
var template = Handlebars.compile(source);  //compiling
var context = {title: "My New Post", body: "This is my first post!"}; //getting the info object
var html = template(context); //display the info wrapped in the template
```

## Subexpressions

#### Remove whitespaces on desired side of helper

```tpl
{{~ property}} // omits whitespaces to the left of helper
{{helper ~}}   // or to the right
{{~ other ~}}  // and both sides
```

#### Other expressions

```tpl
{{../parent}}  // calls the parent property
{{this.name}}  // use the name property in current context
{{!-- comment --}}  // comment - does not render
{{agree_button "My Text" class="my-class" visible=true counter=4}} // literals of helpers (parameter is a literal)
```

## Custom helpers

#### Generating new helper

```js
Handlebars.registerHelper('link', function(obj) {
  text = Handlebars.Utils.escapeExpression(this.text); // escape manually
  url  = Handlebars.Utils.escapeExpression(this.url);  // because the result does not escape HTML
  var result = '<a href="' + url + '">' + text + '</a>';
  return new Handlebars.SafeString(result);
});
```
##### This is executed this way

```tpl
{{{link story}}}
// or if we have multiple objects
{{#each data}}
    <li>{{link url text}}</li>
{{/each}} 
// if statement 
{{#if author}}
    <h1>{{link story}}</h1>
{{/if}}
```
#### Using **options.fn** to create a helper - takes this as a regular template and uses it in the helper

```js
Handlebars.registerHelper('bold', function(options) {
  return new Handlebars.SafeString(
      '<div class="mybold">'
      + options.fn(this)
      + '</div>');
});

// use it like this
{{#bold}}{{body}}{{/bold}}
```

#### Using **with** helper

```js
Handlebars.registerHelper('with', function(context, options) {
  return options.fn(context);
});

// use it like this
{{#with story}}
    <div class="intro">{{{intro}}}</div>
    <div class="body">{{{body}}}</div>
{{/with}}
```

## Partials

#### Basic usage

```js
Handlebars.registerPartial('myPartial', '{{name}}');

// use it like this
{{> myPartial }}   // same as {{name}}
```

#### More complex partials
```tpl
{{> (whichPartial) }}  // used as parameter which must be a functions that defines the partial to use

{{> myPartial myOtherContext }}  //  execute in other context

{{> myPartial parameter=value }}

{{#> layout }}
  My Content
{{/layout}}

{{> @partial-block }}

{{#*inline "myPartial"}}
  My Content
{{/inline}}
{{#each children}}
  {{> myPartial}}
{{/each
```