// Code goes here
(function() {
  
  var mod1 = angular.module('ngAppDemo',['ngRoute', 'controllers']);
  
  
mod1.config(['$routeProvider',
  function($routeProvider) {
    $routeProvider.
      when('/list', {
        templateUrl: 'list_view.html',
        controller: 'ListController'
      }).
      when('/detail/:id/:edit', {
        templateUrl: 'detail_view.html',
        controller: 'DetailController'
      }).
      when('/detail_new', {
        templateUrl: 'detail_view.html',
        controller: 'DetailController'
      }).
      when('/test1', {
        templateUrl: 'test1_view.html',
        controller: 'Test1Controller'
      }).      
      when('/test2', {
        templateUrl: 'test2_view.html',
        controller: 'Test2Controller'
      }).      
      otherwise({
        redirectTo: '/list'
      });
  }]);  
  


}());

