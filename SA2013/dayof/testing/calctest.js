module("Simple");
test("hello world", function () {
    ok(1 == 1, "One equals one")
})


module("Calculator", {
    setup: function(){
    },
    teardown: function(){
        sinon.restore(jQuery.ajax);
    }
})


test("add two numbers", function () {
    var result = calc.add(2, 3);
    // ==
    equal(result, 5, "2 + 3 should be 5")
});

test("add two other numbers", function () {
    var result = calc.add(27, 31);
    // ===
    deepEqual(result, 58, "27 + 31 should be 58")
});

test("callback is called when answer is 42", function () {
    var callback = sinon.spy();
    var result = calc.add(2, 40, callback);
    ok(callback.called, "Answer is 42")
});


test("result is saved", function () {
    var callback = sinon.spy();
    sinon.stub(jQuery, "ajax").yieldsTo("success", [1, 2, 3]);

    calc.saveResult(callback);

    ok(jQuery.ajax.calledWithMatch({url: "/calc/save"}))
    ok(callback.calledWith([1,2,3]))

});
