function User() {
    this.create = function () {
    }

}

var kevin = new User();

var alice = new User();


function Person(name){
    this.param = name;

    this.setName = function(){

    }
}

function User(){
    Person.call(this, "Kevin")
}

User.prototype = new Person();

var bob = new User();

bob.setName("Bob");
