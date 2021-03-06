

define(['jquery'],function($) {

	var fact_grad_m = 42000000/360;
	
	return function(in_array) {

	var ret = [];
	var distance_from_beginning = 0;
	$.each(in_array, function (i, o) {
		var distance_to_previous_point = 0.0;
		var lat_delta = 0.0;
		var lon_delta = 0.0;
		if (i>0) {
			lat_delta = (in_array[i].lat - in_array[i-1].lat)*fact_grad_m;
			lon_delta = (in_array[i].lon - in_array[i-1].lon)*fact_grad_m;	

			distance_to_previous_point = Math.sqrt(lat_delta*lat_delta + lon_delta*lon_delta);
			distance_from_beginning += distance_to_previous_point;
		}
		
		o.distance_to_previous_point = distance_to_previous_point;
		o.distance_from_beginning = distance_from_beginning;
		
		ret.push(o);
	});

	return ret;	
	}

});