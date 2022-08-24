app.controller("problemList",function($scope,$http){
    $http.get("https://localhost:44364/api/problemlist").then(
        function(rsp){
            debugger;
            $scope.pts = rsp.data;
        },
        function(err){

        }
    )
});