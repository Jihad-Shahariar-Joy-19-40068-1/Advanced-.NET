app.controller("pdonorGet",function($scope,$http){
    $http.get("https://localhost:44364/api/donor/patient").then(
        function(rsp){
            debugger;
            $scope.apts = rsp.data;
        },
        function(err){

        }
    )
});