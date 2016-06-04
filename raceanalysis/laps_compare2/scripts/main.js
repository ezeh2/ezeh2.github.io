


define(['./lap1','./lap2','./bla','./add_distance_columns'],function(lap1, lap2, bla, add_distance_columns) {

console.log('hallo');
console.log(lap1.length);
console.log(lap2.length);

var lap1_2 = add_distance_columns(lap1);
var lap2_2 = add_distance_columns(lap2);
	
});

