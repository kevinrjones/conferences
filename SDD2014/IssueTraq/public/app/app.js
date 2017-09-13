var app = angular.module('app',
    ['services',
        'ngRoute']);

app.controller('SimpleController', function($scope){

})

app.controller('PeopleController', ['personService', function (personService) {

    var vm = this;

//    vm.person = personService
//        .getPeople().success(function(data){
//            vm.person = data.people[0];
//        }).error();

    vm.person = personService.getPeople();

    vm.date = new Date();
    vm.now = new Date().toLocaleTimeString();

//    setInterval(function () {
//        $scope.$apply(function () {
//            vm.now = new Date().toLocaleTimeString();
//        })
//    }, 1000);
}]);

app.controller('PersonController', ['$scope', 'personService', '$routeParams', function ($scope, personService, $routeParams) {


    $scope.person = personService.getPerson($routeParams.id);

    $scope.save = function (person) {
        console.log("save: " + person.id);
        personService.save(person);
    };


}]);


app.config(function ($routeProvider, $locationProvider) {

    $locationProvider
        .html5Mode(true)
        .hashPrefix('!');

    $routeProvider
        .when("/", {
            templateUrl: "/app/people/index.html",
            controller: "PeopleController",
            controllerAs: 'vm'
        })
        .when("/person/:id", {
            templateUrl: "/app/people/person.html",
            controller: "PersonController"
        })

        .otherwise({redirectTo: '/'});

});

app.directive('sddSimple', function(){
   return {
       restrict: 'AE',
       template: '<div>' +
           '<h2>Hello World</h2>' +
           '<div ng-transclude></div>' +
           '</div>',
       replace: true,
       link: function(scope, element){
           console.log("hello");
       },
       transclude: true
   }
});

app.directive("sddFirstName", function(){
    return {
        restrict: 'E',
        template: '<input type="text" ng-model="person.firstname"><br/>' +
            '<button ng-click="save()">Also Save</button>',
        scope: {
            "person": "=",
            "save": "&"
        }
    }
})

app.directive('sddPersonDetails', function(){
    return {
        restrict: 'E',
        template: '<div>' +
            '<h2 ng-click="show()">Person</h2>' +
            '<div ng-show="isVisible">Person Name: </div>' +
            '</div>',
        replace: true,
        link: function(scope, element){
            scope.show = function(){
                scope.isVisible = !scope.isVisible;
            };
            scope.isVisible = false;
        }
    }
});

var services = angular.module('services', ['ngResource']);

services.service('personService', ['$http', 'Person', function ($http, Person) {
    this.getPeople = function () {
        return $http.get("/api/people");
    };

    this.getPeople = function(){
        return Person.query();
    }

    this.getPerson = function (id) {
        return Person.get({id: id});
    };

    this.save = function(id){
        Person.update(id);
    }
}]);

services.factory("Person", function($resource){
   return $resource('/api/person/:id', {
       id: '@id'
   }, {
       update: {
           method: 'PUT'
       }
   });
});
