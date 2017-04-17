var db = function() {
    var items = [{ name: "John", id: 1000 }, { name: "Pesho", id: 1001 }, { name: "Jane", id: 42 }];

    function getAjax() {
        var promise = new Promise((resolve, reject) => {
            $.ajax({
                url: "api/items",
                method: "GET",
                contentType: "application/json",
                success: function(res) {
                    resolve(res);
                },
                error: function(err) {
                    reject(err);
                }
            });
        });

        return promise;
    }

    function get() {
        var promise = new Promise((resolve, reject) => {
            resolve({ result: items, length: items.length });
        });

        return promise;
    }

    function getById(id) {
        id = +id;
        var promise = new Promise(function(resolve, reject) {
            for (var i = 0; i < items.length; i += 1) {
                if (items[i].id === id) {
                    resolve({ result: items[i] });
                    return;
                }
            }
            reject({ msg: "Invalid id!" });
        });

        return promise;
    }

    var lastId = 0;

    function save(item) {
        var promise = new Promise(function(resolve, reject) {
            item.id = lastId += 1;
            items.push(item);
            resolve("Success!");
        });

        return promise;
    }

    return {
        get,
        getById,
        save
    }
}();