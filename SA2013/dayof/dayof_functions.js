//function foo() {
//
//}
//
//console.log(typeof(foo));
//console.log(foo.name);
//
//var bar = function () {
//}
//
//console.log(typeof(bar));
//console.log(bar.name);
//
//
//console.log("before")
//console.log(typeof (outer));
//function outer() {
//
//    console.log(typeof (outer));
//    console.log(typeof (inner));
//
//    bar();
//    function inner() {
//
//    }
//
//    function bar() {
//        console.log("inner bar")
//    }
//}
//
//console.log(typeof (inner));
//
//function bar() {
//    console.log("outer foo")
//}
//
//outer()
//
//
//function doSomething(name){
//    console.log(name);
//}
//
//doSomething("Kevin");
//doSomething("Alice", "Bob");
//doSomething();
//
//

//var create = function(){
//    console.log("created");
//    console.log(this);
//}
//
//create();
//
//var user = {
//    foo: create
//};
//
//user.create = create;
//
//user.create()


//function user(name) {
//
//    var self = this;
//
//    var _name = name;
//
//    this.saveMe = function(){
//        console.log(_name);
//    }
//}
//
////var alice = User();
//var bob = new User("Bob");
//
//bob.saveMe();
//
//var alice = new User("Alice");
//
//alice.saveMe();
//
//console.log(alice._name);

//function callMe(a, b) {
//    console.log(this);
//    console.log(arguments);
//}
//
//var user = {};
//callMe(1, 2);
//callMe.apply(user, [3, 4]);
//callMe.call(user, 5, 6);

//var data = [
//    {name: "a"},
//    {name: "b"},
//    {name: "c"}
//]
//
//function forEach(items, callback) {
//    for (var ndx = 0; ndx < items.length; ndx++) {
//        callback.call(items[ndx], items[ndx], ndx);
//    }
//}
//
//function printItem(item, ndx) {
//    console.log(this.name);
//}
//
//forEach(data, function(){
//    console.log(this.name);
//});


function fibonacci(value) {
    fibonacci.answers = fibonacci.answers || {};
    if (fibonacci.answers[value] != null) {
        return fibonacci.answers[value];
    }
    var val = 0;
    var next = 0;
    var nextnext = 1;

    if(value == 1){
        return 1;
    }

    for (var i = 1; i < value; i++) {
        val = next + nextnext;
        next = nextnext;
        nextnext = val;
    }
    return fibonacci.answers[value] = val;
}


console.log(fibonacci(6));
console.log(fibonacci(8));
console.log(fibonacci(8));

var alice = {};
var bob = {};
alice.fib = fibonacci;
bob.fib = fibonacci;

alice.fib(8);










