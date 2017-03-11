# jQuery Plugin
- A Plugin is just a method that extends the jQuery objects prototype
  - Enabling all jQuery objects to use this method
- Once a plugin is imported, it is used as regular jQuery method
  - Like `addClass()`, `fadeout()` and `hide()`

- jQuery has many ready-to-use plugins
  - A library jQueryUI for UI controls
- Plugins for UI
  - Tabs
```javascript
$("#tabs-holder").tabs();
```
  - Arrangeable elements
```javascript
$("#grid" ).sortable();
```

# Creating jQuery Plugins
- jQuery has an easy way to extend the initial functionality with plugins
  - Just create a regular JavaScript method and attach it to **jQuery.fn** object

```javascript
(function($){
  $.fn.zoom = function(){    
    var $this = $(this);
    $this.on("mouseover", function() {
      //zoom in element
    });
    $this.on("mouseout", function() {
      //zoom out element
    });
  }
}(jQuery));
```

<span class="balloon fragment" style="top:85%; left:48%">`$(".image").zoom();`</span>

# Chaining in Plugins 
- Chaining is pretty good and useful feature
  - Better to be implemented in our plugins
  - Done easy, just return **this** at the end of the plugin function

```javascript
(function($){
  $.fn.zoom = function(){    
    var $this = $(this);
    $this.on('mouseover', function() {…});
    $this.on('mouseout', function() {…});
    return $this;
  }
}(jQuery));
```

<span class="balloon fragment" style="top:75%; left:48%; width:250px">
`$('.image')`<br/>`.zoom()`<br/>`.addClass('zoom');`</span>

# Plugins with Options
- Plugins can also be provided with options
  - Just pass regular function parameters

```javascript
(function($){
  //zoom with size percents
  $.fn.zoom = function(size){    
    var $this = $(this);
    $this.on('mouseover', function() {…});
    $this.on('mouseout', function() {…});
    return $this;
  }
}(jQuery));
```

# Plugins Options
- Yet the options sometimes become too many
  - When too many arguments, just use a options object
  - Give the options as a JSON-like object