'use strict';

angular.module('myApp.view1', ['ngRoute','EmmitClient'])

.config(['$routeProvider', function($routeProvider) {
  $routeProvider.when('/view1', {
    templateUrl: 'view1/view1.html',
    controller: 'View1Ctrl'
  });
}])

.controller('View1Ctrl', ['$scope','Emmit',function($scope,Emmit) {
    $scope.message = "Waiting for Stock market to open...";
    var proxy = null;
    
    
     Emmit.createProxy({
            emitter:'StockEmitter',
            path:'http://localhost:8181/emmit',
            listeners:{
                'onStockOpen':function(){
                    $scope.message = 'Stock opened!';
                    $scope.$apply();
                },
                'onStockClosed':function(){
                    $scope.message = 'Stock market closed!';
                    $scope.$apply();
                },
                'onStockUpdated':function(update){
                    $scope.message = 'Stock ' + update.Symbol + ' updated to ' + update.Value;
                    $scope.$apply();
                }
            },
            onError:function(){
            },
            onDisconnected:function(){
            }
        }).then(function(newProxy){
            proxy = newProxy;
        });
}]);