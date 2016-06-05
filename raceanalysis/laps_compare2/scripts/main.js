


define(['./lap1','./lap2','./add_distance_columns','./correlate_arrays','./Chart','jquery'],
	function(lap1,lap2,add_distance_columns,correlate_arrays, na, jquery) {

console.log('hallo');

var lap1_2 = add_distance_columns(lap1);
var lap2_2 = add_distance_columns(lap2);
var lap1_3 = correlate_arrays(lap1_2, lap2_2);

var d1 = jquery.map(lap1_2, function(val, i) {
	return {
		y: val.speed / 1000,
		x: val.distance_from_beginning,		
	};
});

var d2 = jquery.map(lap1_3, function(val, i) {
	return {
		y: val.speed / 1000,
		x: val.distance_from_beginning,		
	};
});


// is not null --> successfully integrated
var canvasChart1 = document.getElementById("chart1");

var chartConfig = {
    type: 'line',
    options: {
        scales: {
            xAxes: [{
                type: 'linear',
                position: 'bottom'
            }]
        }
    }
};

chartConfig.data = { datasets: [] };

chartConfig.data.datasets.push({
            label: 'Scatter Dataset 1',
            data: d1,
            fill:false,
            borderColor:'#00FF00',
            borderWidth:1,
            radius:0,
            tension:0
        });

chartConfig.data.datasets.push({
            label: 'Scatter Dataset 2',
            data: d2,
            fill:false,
            borderColor:'#FF0000',
            borderWidth:1,
            radius:0
        });


var myChart = new Chart(canvasChart1, chartConfig);

});

