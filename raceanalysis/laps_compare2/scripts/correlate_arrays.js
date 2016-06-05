define(['get_closest_point'], function(get_closest_point) {

    return function(in_array1, in_array2) {

		var out_array = [];
			
		$.each(in_array1, function (i, o) {

		  var in_array1_item = in_array1[i];
		  var distance_from_beginning = in_array1_item.distance_from_beginning;

		  var out_item = get_closest_point(in_array2, distance_from_beginning);
		  out_array.push(out_item);

		});

    	return out_array;
    };

});