app.controller("pdonorCreate",function($scope,$http){
    $scope.test=function(){
        var data={
            Id:$scope.id,
            Name:$scope.name,
            Age:$scope.age,
            Gender:$scope.gender,
            Phone_no:$scope.phone_no,
            Blood_group:$scope.blood_group,
            Organ_type:$scope.organ_type,
            Blood_pressure:$scope.blood_pressure,
            Diabetes:$scope.diabetes,
            Allergy:$scope.allergy,
            Asthama:$scope.asthama,
            Approval:$scope.approval,
            Approved_by:$scope.approved_by,
            Location:$scope.location            
        };
        $http.post("https://localhost:44364/api/donor/patient/create",data).then(function(rsp){
            alert(rsp.data);
        },function(err){});
    };
    
});