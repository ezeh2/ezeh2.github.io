

define(['jquery'],function($) {
	
	return function(in_array) {

	var firstAbsoluteMiliseconds;

	var ret = [];
	$.each(in_array, function (i, o) {

		// the number of milliseconds since 1970/01/01
		var absoluteMiliseconds = new Date(o.date);
		absoluteMiliseconds.setMilliseconds(o.milisecond);

		if (i == 0) {
			firstAbsoluteMiliseconds = absoluteMiliseconds;
		}

		o.relativeMiliseconds = absoluteMiliseconds - firstAbsoluteMiliseconds
		ret.push(o);
	});

	return ret;	
	}

});