var calc = (function () {

    var saveResult = function(callback){
        $.ajax({
            url: "/calc/save",
            success: function (data) {
                callback(data);
            }
        });
    }

    var add = function (x, y, callback) {
        var result = x + y;
        if (result == 42) {
            callback();
        }
        return result;
    }

    return {
        add: add,
        saveResult: saveResult
    }
})();
