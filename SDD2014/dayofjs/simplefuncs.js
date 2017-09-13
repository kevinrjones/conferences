function show(){
    console.log("called");
}


function anotherFunc(callback){
    callback();
}


window.onload = function(){
    console.log("Anonymous function");
};

var showMe = function (){
    console.log("showme");
};


function outer(){
    console.log(typeof outer);
    console.log(typeof inner);
    console.log(typeof inner2);

    function inner() {


        function inner2() {

        }
    }
}

outer();
















