describe("Calculator", function () {

    var calc;

    beforeEach(function () {
        calc = new Calculator();
    });

    it("should exist", function () {
        expect(Calculator).toBeDefined();
    });

    describe("should do basic operations", function () {
        it("should add two numbers", function () {
            var result = calc.add(2, 3);
            expect(result).toBe(5);
        })

        it("should subtract two numbers", function () {
            var result = calc.subtract(4, 3);
            expect(result).toBe(1);
        })
    })
});
