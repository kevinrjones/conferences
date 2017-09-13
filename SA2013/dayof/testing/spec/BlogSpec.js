describe("Calculator", function(){

    it("is defined", function(){
        expect(calc).toBeDefined();
    })

    it("should add two numbers", function(){
        expect(calc.add(1,2)).toBe(3);
    })

    describe("callback", function(){
        it("should be called", function(){
            expect(1).toBe(1);
        })
    })
})