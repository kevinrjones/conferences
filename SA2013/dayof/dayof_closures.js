var innerFunction;

var $ = {};
// IIFE
(function outer($, _) {
    var inner = "inner value";

    function innerFunc() {
        console.log(inner);
    }

    innerFunction = innerFunc;
})(jQuery, underscore);


setTimeout(innerFunction(), 2000);

//
//function User(params) {
//    this.name = params.name;
//    this.getName = function () {
//        return name;
//    }
//    this.setName = function (newName) {
//        name = newName;
//    }
//
//}
//
//var kevin = new User({name: "Kevin"});
//kevin.setName("alice");
//var bob = new User({name: "Bob"});
//
//kevin.name = 'bob';
//
//console.log(kevin.getName());

//function Button(){
//    var self = this;
//    self.isClicked = false;
//    self.click = function () {
//        self.isClicked = true;
//        alert(button === self);
//    };
//}
//
//var button = new Button();
//var elem = document.getElementById("test");
//elem.addEventListener("click", button.click, false);







