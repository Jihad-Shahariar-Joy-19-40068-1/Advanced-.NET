app.controller("login",function($scope,$http){
    $scope.test=function(){
        var data={Email:$scope.email,Password:$scope.password};
        $http.post("https://localhost:44364/api/login/doctor",data).then(function(rsp){
            alert(rsp.data);
        },function(err){});
    };
    
});