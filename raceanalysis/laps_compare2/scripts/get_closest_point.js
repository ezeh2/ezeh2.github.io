

define(['jquery'],function($) {

	return function(in_array,in_distance_from_beginning) {

		var min_diff = 100000;
		if (in_distance_from_beginning>min_diff) {
			console.log("get_closest_point: in_distance_from_beginning>min_diff");
		}
		var min_item;

		$.each(in_array, function (i, o) {

		 var item = in_array[i];		
         var diff = Math.abs(item.distance_from_beginning - in_distance_from_beginning);
         if (diff<min_diff) {
         	min_diff = diff;
         	min_item = item;
         }

		});

		if (!min_item) {
			console.log("min_item: undefined");
		}

		return min_item;
	}	

});