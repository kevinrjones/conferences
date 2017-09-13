
function Person(params){

    var self = this;
    this.age = params.age;
    var name = params.name;
    var age = params.age;

    function show(){
        console.log("Name is: " + name + " and you are " + this.age);
    }

    this.display = function() {
        console.log("Name is: " + name + " and you are " + self.age);
//        show();
    }
}

var kevin = new Person({name: "Kevin", age: 52});
// Person.call({},"Kevin", 52)
kevin.display();
console.log("Age is: " + kevin.age);
console.log("Name is: " + kevin.name);
//kevin.show();

var showKevin = kevin.display;

window.showKevin();


function bind(context, name) {
    return function() {
        return context[name].apply(context, arguments);
    };
}
function bindfn(context, fn) {
    return function() {
        return fn.apply(context, arguments);
    };
}

function Button() {
//    var self = this;
    this.isClicked = false;
    this.click = function click () {
        // use 'this' to update something
//        console.log(self);
        console.log(this);
    };
}

var button = new Button();
button.click();
//$('#clickme').click(button.click);
$('#clickme').click(bind(button, button.click.name));



fn = function(a, b){}

var curried = curry(fn, "foo")

curried("bar");

// fn("foo", "bar")
curried("baz");