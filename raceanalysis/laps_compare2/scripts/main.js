


define(['./lap1','./lap2','./add_distance_columns','./correlate_arrays','./Chart'],
	function(lap1,lap2,add_distance_columns,correlate_arrays, na) {

console.log('hallo');

var lap1_2 = add_distance_columns(lap1);
var lap2_2 = add_distance_columns(lap2);
var lap1_3 = correlate_arrays(lap1_2, lap2_2);

// is not null --> successfully integrated
var myChart = Chart;

});

