define(['services/myservice'], function(myservice){
    console.log("util loaded");
   return {
       help: function(text){
           console.log(text)
       }
   }
});

