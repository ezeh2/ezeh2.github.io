


define(['./lap1','./lap2','./add_distance_columns','jquery','get_closest_point','correlate_arrays'],
	function(lap1,lap2,add_distance_columns,$, get_closest_point, correlate_arrays) {

console.log('hallo');

var lap1_2 = add_distance_columns(lap1);
var lap2_2 = add_distance_columns(lap2);
var lap1_3 = correlate_arrays(lap1_2, lap2_2);

});

