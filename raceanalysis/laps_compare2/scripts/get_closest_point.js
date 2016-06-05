

define(['jquery'],function($) {

	return function(in_array,in_distance_from_beginning) {

		var min_diff = 100;
		var min_item;

		$.each(in_array, function (i, o) {

		 var item = in_array[i];		
         var diff = Math.abs(item.distance_from_beginning - in_distance_from_beginning);
         if (diff<min_diff) {
         	min_diff = diff;
         	min_item = item;
         }

		});

		return min_item;
	}	

});