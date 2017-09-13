var data = [];

var callback = function(item){
    data.push(item);
}

module("Fizzbuzz tests", {
    setup: function(){

    }
});

test("Simple Test", function() {
    ok(true == true, "Hopefully!")
})

test("1 returns 1", function(){
    fizzBuzz.loop(1, callback);
    equal(data[0], 1, "One should return one")
})


//test("2 returns 2", function(){
//    var ans = fizzBuzz.calculate(2);
//    equal(ans, 2, "two should return two")
//})
//
//test("9 returns fizz", function(){
//    var ans = fizzBuzz.calculate(9);
//    equal(ans, "fizz", "Nine should return fizz")
//})