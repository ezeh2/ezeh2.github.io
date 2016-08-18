describe("JQuery", function() {

 it("should ", function () {

  expect($).not.toBeUndefined();

});

 describe("JQuery mocked", function() {

 	var jdoc;

  beforeEach(function() {

    jdoc = jQuery(document);

    spyOn(jdoc,'ready');

	});    

   it("should ", function () {

	jdoc.ready(function () {
    	alert('hi');
	});

	});    

 });

});

