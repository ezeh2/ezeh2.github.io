// Code goes here
(function() {
  
  var mod1 = angular.module('baracudaServices',[]);
  
  mod1.factory('baracudaService', function () {
    
    // configure CORS "run.plnkr.co" in "https://baracuda.azure-mobile.net"
    // please note: Custom API is not needed to read/write tables
    
    // doc: https://github.com/Azure/azure-mobile-services/blob/master/sdk/Javascript/src/MobileServices.intellisense.js
    
    var MobileServiceClient = WindowsAzure.MobileServiceClient;
    var client = new MobileServiceClient('https://baracuda.azure-mobile.net/', 'CjvMxVJcepqVrhnrFcMUzBkFZYcuhK76');
    
    return client;
    
  });

}());

