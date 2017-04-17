/* globals Sammy */

var sammyApp = Sammy("#content", function() {
    this.get("#/", function() {
        console.log("HOME");
        this.redirect("#/home");
    });

    this.get("#/home", function() {
        $("#content").html("");
    });

    this.get("#/items", function() {
        var items;
        db.get()
            .then(function(res) {
                items = res.result;
                return templates.get("items");
            })
            .then(function(html) {
                var template = Handlebars.compile(html);
                $("#content").html(template({ items: items }));
            });
    });

    this.get("#/items/add", function(context) {
        templates.get("item-add")
            .then(function(html) {
                var template = Handlebars.compile(html);
                $("#content")
                    .html(template())
                    .on("click", "#btn-add", function() {
                        var name = $("#name-input").val();
                        db.save({ name: name })
                            .then(context.redirect("#/"));
                    });
            });
    });

    this.get("#/items/:id", function() {
        var item;
        db.getById(this.params.id)
            .then(function(res) {
                item = res.result;
                return templates.get("item-details");
            })
            .then(function(html) {
                var template = Handlebars.compile(html);
                $("#content").html(template(item));
            });
    });
});

$(() => {
    sammyApp.run("#/");
});