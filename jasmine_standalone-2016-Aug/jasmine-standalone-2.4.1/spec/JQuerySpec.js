describe("JQuery", function() {

  	var jq;

	beforeEach(function() {
	jq = $;

	// defined in "SpecRunner2.html"
	setUpHTMLFixture();
	});

	it("should find html-elements with id", function() {

	    expect(jq).not.toBeUndefined();

	    expect(jq('form').length).toEqual(1);
	    expect(jq('form button').length).toEqual(2);
	    expect(jq('form h1').html()).toEqual('Test Form');

	});

	it("should insert text", function() {    

		expect(jq('#pMsg').html()).toEqual('');

		jq('#pMsg').html('ha_text');

		expect(jq('#pMsg').html()).toEqual('ha_text');

	});

	it("should show text", function() {    

		expect(jq('#pMsg').html()).toEqual('');
		jq('#btnShowMessage').trigger('click')
		expect(jq('#pMsg').html()).toEqual('Hello World!');

	});

	it("should hide text", function() {    

		jq('#pMsg').html('text before');
		jq('#btnHideMessage').trigger('click')
		expect(jq('#pMsg').html()).toEqual('');

	});

});




