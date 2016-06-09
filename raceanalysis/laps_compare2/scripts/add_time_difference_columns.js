

define(['jquery'],function($) {
	
	return function(in_array) {

	var ret = [];
	$.each(in_array, function (i, o) {

		var y1 = o.date;
		var y2 = o.milisecond;

		o.absolute_time = 12;
		
		ret.push(o);
	});

	return ret;	
	}

});