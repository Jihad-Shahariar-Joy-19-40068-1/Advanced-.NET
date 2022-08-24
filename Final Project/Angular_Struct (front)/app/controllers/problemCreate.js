app.controller("problemCreate",function($scope,$http){
    $scope.test=function(){
        var data={Id:$scope.id,Name:$scope.name,Problem:$scope.problem,Reason:$scope.reason,Room_no:$scope.room_no};
        $http.post("https://localhost:44364/api/problem/create",data).then(function(rsp){
            alert(rsp.data);
        },function(err){});
    };
    
});