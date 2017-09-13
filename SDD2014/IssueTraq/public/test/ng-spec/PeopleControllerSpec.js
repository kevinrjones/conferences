describe("People Controller", function(){

    beforeEach(module('app'));

    var simpleController;
    beforeEach(inject(function($controller, $rootScope){
        var scope = $rootScope.$new();

        simpleController = $controller('SimpleController', {$scope: scope})

    }));

    it("should exist", function(){
        expect(simpleController).toBeDefined();
    });

    var peopleController;
    beforeEach(inject(function($controller){

        var personService = jasmine.createSpyObj('personService', ['getPeople']);

        personService.getPeople.and.returnValue({firstname: "Fred"});

        peopleController = $controller('PeopleController', {personService: personService})

    }));

    it("should exist", function(){
        expect(peopleController).toBeDefined();



    });

    it("should have a person", function(){
        expect(peopleController.person.firstname).toBe("Fred");

    });

})
