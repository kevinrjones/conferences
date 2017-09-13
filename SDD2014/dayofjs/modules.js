// a module
// IIFE
// Immediately Invoked Function Expression

var module = (function($){

    function onClick(){
        // do a callback
        console.log("clicked...");
    }

    $('#clickme').click(onClick);

    function setUserName(name){
        $('name').val(name);
    }

    return {
        setName: setUserName
    }

})(jQuery);

var post = (function(){
    return function(){};
})()

new post();

//manageUI();

module = (function(my){

})(module);