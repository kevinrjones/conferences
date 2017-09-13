var sdd = {

};

sdd.show = function (a, b) {
    console.log(this);
    //var args = Array.prototype.slice.call(arguments);
    console.log(a, b);
    console.log("Shown");
}

function showPerson() {
    console.log(this.nameOf);
}
//show();

var person = {
    nameOf: "Kevin",
    age: 33,
    showMe: showPerson
};

var yasf = person.showMe;


var sdd = sdd || {};


function Person(name, age) {
    this.name = name;
    this.age = age;

    this.showDetails = function () {
        console.log("name: " + this.name + " age: " + this.age);
    }
}

var michael = new Person("michael", 41);
var kevin = new Person("kevin", 52);

var people = [michael, kevin];

forEach(people, function (ndx, item) {
    console.log(this);
    console.log(this.name);
});

function forEach(items, callback) {
    for (var i = 0; i < items.length; i++) {
        callback.call(items[i], i, items[i]);
    }
}














