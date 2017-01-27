var calculator = calculator || {};

(function(addition) {
    let value = 0;

    function add(x) {
        value += x;
        return this;
    }

    function substract(x) {
        value -= x;
        return this;
    }

    addition.add = add;
    addition.substract = substract;
}(calculator));