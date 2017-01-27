var calculator = calculator || {};

(function(multiplication) {
    let value = 0;

    function multiply(x) {
        value *= x;
        return this;
    }

    function divide(x) {
        value /= x;
        return this;
    }

    function printValue() {
        console.log(value);
    }

    multiplication.multiply = multiply;
    multiplication.divide = divide;
    multiplication.print = printValue;
}(calculator));