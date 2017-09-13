var fizzBuzz = (function () {

    var loop = function (limit, callback) {
           for(var i = 1; i <= limit; i++){
               callback(calculate(i));
           }
    }

    var calculate = function (value) {
        if (value % 3 == 0 && value % 5 == 0) {
            return "fizzbuzz";
        }
        if (value % 3 == 0) {
            return "fizz";
        }
        if (value % 5 == 0) {
            return "buzz";
        }
        return value;
    }

    return {
        loop: loop
    }
})();
