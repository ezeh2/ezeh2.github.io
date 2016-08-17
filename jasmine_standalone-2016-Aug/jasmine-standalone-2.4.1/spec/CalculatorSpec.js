describe("Calculator", function() {

  var calculator;

  beforeEach(function() {
    calculator = new Calculator();
  });

  it("should calculate sum (with integer type)", function() {
  	expect(calculator.add(4,4)).toEqual(8);

  	expect(calculator.add(-8,41)).toEqual(33);
  });

  it("should calculate sum (with integer float)", function() {
  	expect(calculator.add(4.2,1.3)).toEqual(5.5);

  	expect(calculator.add(0.1,0.3)).toEqual(0.4);
  });

  describe("play with spyOn.and.callThrough", function() {

	    beforeEach(function() {

	       spyOn(calculator,'add').and.callThrough();;
	    });

	  it("play with toHaveBeenCalled", function() {
	    
		expect(calculator.add(-1,2)).toEqual(1);

		expect(calculator.add).toHaveBeenCalled();
		expect(calculator.add).toHaveBeenCalledWith(-1,2);

	  });

  });

  describe("play with spyOn.and.returnValue", function() {

	    beforeEach(function() {

	       spyOn(calculator,'add').and.returnValue(34);;
	    });

	  it("play with toHaveBeenCalled", function() {
	    
		expect(calculator.add(-1,2)).toEqual(34);

		expect(calculator.add).toHaveBeenCalled();
		expect(calculator.add).toHaveBeenCalledWith(-1,2);

	  });

  });


});


