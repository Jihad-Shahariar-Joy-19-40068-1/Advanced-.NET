app.controller("appointmentList",function($scope,$http){
    $http.get("https://localhost:44364/api/appointment/doctor").then(
        function(rsp){
            debugger;
            $scope.apts = rsp.data;
        },
        function(err){

        }
    )
});