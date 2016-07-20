


define(['./lap_selector','./add_distance_columns','./correlate_arrays','./Chart','jquery','add_time_difference_columns'],
	function(lap_selector,add_distance_columns,correlate_arrays, na, jquery, add_time_difference_columns) {

console.log('hallo');

var lap1 = add_distance_columns(lap_selector.lap1);
var lap1 = add_time_difference_columns(lap1);
var lap2 = add_distance_columns(lap_selector.lap2);
var lap2 = add_time_difference_columns(lap2);
var lap = correlate_arrays(lap1, lap2);

var d1 = jquery.map(lap1, function(val, i) {
    if (val) {
    	return {
    		y: val.speed / 1000,
    		x: val.distance_from_beginning
    	};
    } else {
        console.log(i);
    }
});

var d2 = jquery.map(lap, function(val, i) {
    if (val) {    
    	return {
    		y: val.speed / 1000,
    		x: val.distance_from_beginning
    	};
    } else {
        console.log(i);
    }    
});

var d3 = jquery.map(lap1, function(val, i) {
    return {
        y: (val.relativeMiliseconds - lap[i].relativeMiliseconds) / 1000,
        x: val.distance_from_beginning
    };
});

var d4 = jquery.map(lap1, function(val, i) {
    return {
        y: val.relativeMiliseconds / 1000,
        x: val.distance_from_beginning
    };
});

var d5 = jquery.map(lap, function(val, i) {
    return {
        y: val.relativeMiliseconds / 1000,
        x: val.distance_from_beginning
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
                position: 'bottom',
                scaleLabel: {
                    display: true,
                    labelString: '[m]'
                }
            }],
            yAxes: [{
                id: 'y1',
                type: 'linear',
                position: 'left',
                scaleLabel: {
                    display: true,
                    labelString: '[km/h]'
                }
            },
            {
                id: 'y2',                
                type: 'linear',
                position: 'left',
                scaleLabel: {
                    display: true,
                    labelString: '[s]'
                }
            },
            {
                id: 'y3',                
                type: 'linear',
                position: 'right',
                scaleLabel: {
                    display: true,
                    labelString: '[s]'
                }
            }]
        },
        tooltips: {
        	mode: 'label',
        	caretSize: 20
        }
    },
    onClick: function() {
    	alert('as');
    }
};

chartConfig.data = { datasets: [] };

var legend = function() {
    return '( idxTrace=' + this[0].idxTrace + ', date='+ this[0].date+' )';
}

lap1.legend = legend;
lap2.legend = legend;

chartConfig.data.datasets.push({
            label: 'lap1 [km/h] ' + lap1.legend(),
            yAxisID: 'y1',
            data: d1,
            fill:false,
            borderColor:'#0000FF',
            borderWidth:1,
            radius:0,
            tension:0
        });

chartConfig.data.datasets.push({
            label: 'lap2 [km/h]' + lap2.legend(),
            yAxisID: 'y1',            
            data: d2,
            fill:false,
            borderColor:'#FF0000',
            borderWidth:1,
            radius:0
        });

chartConfig.data.datasets.push({
            label: 'lap1 [s]',
            yAxisID: 'y2',            
            data: d4,
            fill:false,
            borderColor:'#0000FF',
            borderWidth:1,
            borderDash: [15,15],
            radius:0
        });


chartConfig.data.datasets.push({
            label: 'lap2 [s]',
            yAxisID: 'y2',            
            data: d5,
            fill:false,
            borderColor:'#FF0000',
            borderWidth:1,
            borderDash: [15,15],            
            radius:0
        });

chartConfig.data.datasets.push({
            label: 'time difference (lap1-lap2) [s]',
            yAxisID: 'y3',            
            data: d3,
            fill:false,
            borderColor:'#00FF00',
            borderWidth:1,
            radius:0
        });

var myChart = new Chart(canvasChart1, chartConfig);

});

