


define(['./lap1','./lap1','./add_distance_columns','jquery','get_closest_point'],function(lap1,lap2,add_distance_columns,$, get_closest_point) {

console.log('hallo');


var lap1_2 = add_distance_columns(lap1);
var lap2_2 = add_distance_columns(lap2);
	
$.each(lap1_2, function (i, o) {

  var lap1_2_item = lap1_2[i];
  var distance_from_beginning = lap1_2_item.distance_from_beginning;

  var lap2_2_item = get_closest_point(lap2_2, distance_from_beginning);

});

});

