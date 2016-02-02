// Code goes here
(function() {
  
  var mod1 = angular.module('ngAppDemoServices',[]);
  
  mod1.factory('baracuda', function () {
    
    // configure CORS "run.plnkr.co" in "https://baracuda.azure-mobile.net"
    // please note: Custom API is not needed to read/write tables
    
    var MobileServiceClient = WindowsAzure.MobileServiceClient;
    var client = new MobileServiceClient('https://baracuda.azure-mobile.net/', 'CjvMxVJcepqVrhnrFcMUzBkFZYcuhK76');
    
    return client;
    
  });

}());

