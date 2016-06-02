
google.charts.load('current', {'packages':['table']});
      google.charts.setOnLoadCallback(drawTable);

	  var fact_grad_m = 42000000/360;
	  
      function drawTable() {
        var data = new google.visualization.DataTable();
        data.addColumn({'type':'datetime','label':'date','width':'200' });
        data.addColumn({'type':'number','label':'milisecond' });		
        data.addColumn({'type':'number','label':'speed' });				
        data.addColumn({'type':'number','label':'lat' });
        data.addColumn({'type':'number','label':'lon' });
        data.addColumn({'type':'number','label':'distance_to_previous_point' });		
        data.addColumn({'type':'number','label':'distance_from_beginning' });				
		
		var lap = lap1;
		
		lap = add_distance_props(lap);
		
		var lap_arr_els = [];
		$.each(lap, function (i, o) {
			lap_arr_els.push([new Date(o.date), o.milisecond, o.speed, o.lat,o.lon, o.distance_to_previous_point, o.distance_from_beginning]);
		});
		
		data.addRows(lap_arr_els);

        var table = new google.visualization.Table(document.getElementById('table_div'));

        table.draw(data, {showRowNumber: true, width: '100%', height: '100%'});
	  }

	  
