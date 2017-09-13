'use strict';

function User() {
    this.display = function () {
        console.log("User");
    }
}

function Person(name) {
    this.name = name;
}

Person.prototype = new User();
// prototype = {display: function(){}}
Person.prototype.toString = function(){
    return "Hello I am " + this.name;
}

//Person.prototype.display = function () {
//    console.log("[Prototype] Person is " + this.name);
//}


var kevin = new Person("Kevin");
console.log("About to create a person");
kevin.display();

var rich = new User();

function callDisplay(o) {
    if (o instanceof Person) {
        o.display();
    }
}

callDisplay(kevin);
callDisplay(rich);




