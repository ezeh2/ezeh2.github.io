describe("J1", function() {

	var x;
	var y = 2;

 it('should use matchers without issues', function () {

	 expect(2).toEqual(2);
	 expect(3).not.toEqual(2);

     expect(2).toBe(2);

     expect(x).toBeUndefined();
     expect(y).not.toBeUndefined();

     expect("hello word").not.toContain("los");
     expect("hello word").toContain("llo");
 });


  var bla = {
     f1: function () {}
  };

  it('mocks should work', function () {



  });


});