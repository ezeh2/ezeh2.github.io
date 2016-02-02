
(function() {

var controllers = angular.module('controllers',['baracudaServices']);


var ctr1 = controllers.controller('ListController',function($scope,$window,$log,$http, baracudaService,$location) {

  $scope.ifNotEmpty = function(value,emptytext) {
    
    if (value) {
       return value;
    }
    else {
      return emptytext;
    }
    
  }
  
  $scope.edit_clicked = function(id) {
    $location.path('/detail/' + id + '/true');
  }

  $scope.delete_clicked = function(id) {

    var table1 = baracudaService.getTable('table1');
    
    var query = table1.del({'id': id}).done(function (results) {

        update_list_view($scope, baracudaService);

      }, function (err) {
          $window.alert("WindowsAzure.MobileServiceClient, Error: " + err);
      });  
  }

  update_list_view($scope, baracudaService);
        
  $scope.new_clicked = function() {
    $location.path('/detail_new');
  }

});

function update_list_view($scope, baracudaService) {
  
  $scope.table1Loaded = false;

  var table1 = baracudaService.getTable('table1');
  
  var query = table1.read().done(function (results) {
            
            $scope.$apply(function() {

              $scope.rows = results;
              $scope.table1Loaded = true;
              
            });
            
        }, function (err) {
            $window.alert("WindowsAzure.MobileServiceClient, Error: " + err);
        });  
}

var ctr2 = controllers.controller('DetailController',function($scope,$window,$log,$http, baracudaService,$routeParams,$location) {
 
  $scope.id=$routeParams.id;
  $scope.edit=$routeParams.edit == 'true';
  
  if ($scope.id) {
    $scope.table1Loaded = false;
    var table1 = baracudaService.getTable('table1');
  
    var query = table1.where({'id': $scope.id}).read().done(function (results) {
            
            $scope.$apply(function() {

              if (results.length == 1) {
               $scope.row = results[0];
              }
              else {
                $scope.row = {'found records': results.length};
              }
              $scope.table1Loaded = true;
              
            });
            
    }, function (err) {
        $window.alert("WindowsAzure.MobileServiceClient, Error: " + err);
    });    
  }
  else {
    $scope.row = {'id': null, 'text': null, 'completed':false, 'when': null};
    $scope.edit=true;
    $scope.table1Loaded = true;
  }
        
  $scope.save = function () {

    var table1 = baracudaService.getTable('table1');
    if ($scope.id) {
        
        table1.update($scope.row).done(function (results) {
           
           $scope.$apply(function() {
              $location.path('/list');
           });
  
        }, function (err) {
            $window.alert("WindowsAzure.MobileServiceClient, Error: " + err);
        });   
    }
    else {
      
        table1.insert($scope.row).done(function (results) {
           
           $scope.$apply(function() {
              $location.path('/list');
           });
  
        }, function (err) {
            $window.alert("WindowsAzure.MobileServiceClient, Error: " + err);
        });   
    }
  }

});

var ctr3 = controllers.controller('Test1Controller',function($scope,$window,$log,$http, baracudaService,$routeParams,$location) {

  $scope.test_login = function () {
    
    // doesn't work, on click 'login' following is opened: https://baracuda.azure-mobile.net/login/done#error=Error%3A%20Unable%20to%20obtain%20OAuth%20request%20token%20from%20Twitter.
    // https://baracuda.azure-mobile.net/login/facebook?completion_type=postMessage&completion_origin=http%3A%2F%2Frun.plnkr.co
    var xy = baracudaService.login('facebook');
    
    xy.onError = function() {
      alert('error');
    }
    
    xy.done(function (results) {

        alert('success');           

        }, function (err) {

        alert('error');           

        });   
  }
  
  $scope.test_logout = function () {
    baracudaService.logout();
  }
  
  $scope.show_logged_in = function() {
    $scope.is_logged_in = baracudaService.isLoggedIn;
  }

});

var ctr4 = controllers.controller('Test2Controller',function($scope) {
  
  $scope.XY = 20;
  
});  

}());


