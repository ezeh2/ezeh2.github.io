// Code goes here
(function() {
  
  var mod1 = angular.module('ngAppDemo',['ngAppDemoServices']);
  
  var ctr1 = mod1.controller('contr1',function($scope,$window,$log,$http, baracuda) {
      $scope.text1="<nothing set >>";
      $scope.button1 = function () {
        $scope.text1="Button1 pressed";
        $scope.xItems1 = [{a:'1', b:'2'},{a:'70', b:'20'},{a:'123', b:'-4'},{a:'99', b:'3'}];
      };
      $scope.button2 = function () {
        $scope.text1="Button2 pressed";
        $scope.xItems2 = {a:'1', b:'2',c:'70', d:'20'};
      };
      $scope.button3 = function () {
        $scope.text1="Button3 pressed";
        
        var table1 = baracuda.getTable('table1');
        table1.insert({
          
        }).done(function (results) {
            $window.alert(JSON.stringify(results));
        }, function (err) {
            $window.alert("WindowsAzure.MobileServiceClient, Error: " + err);
        });
        
      };
      $scope.button4 = function () {
        $scope.text1="Button4 pressed";
        $log.log('logging stuff');
        
        var table1 = baracuda.getTable('table1');

        var query = table1.read().done(function (results) {
            $window.alert(JSON.stringify(results));
        }, function (err) {
            $window.alert("WindowsAzure.MobileServiceClient, Error: " + err);
        });
        
      };
      
  });


}());

