define(['lap1','lap2','lap11','lap12'], function(lap1, lap2, lap11, lap12) {

	var lapIndex = 1;

   var url = window.document.URL;
   var hashIndex = url.indexOf('#');
   if (hashIndex != -1) {
	   var numberAfterHash = url.substring(hashIndex + 1, url.length);
	   lapIndex = parseInt(numberAfterHash);
	}

    var ret = [
		{
	      'lap1': lap1,
	      'lap2': lap2
   		}
   		,
		{
	      'lap1': lap11,
	      'lap2': lap12
   		}   		
    ];

   return ret[lapIndex - 1];

});

