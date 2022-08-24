var app = angular.module("myApp", ["ngRoute"]);
app.config(["$routeProvider","$locationProvider",function($routeProvider,$locationProvider) {

    $routeProvider
    .when("/", {
        templateUrl : "views/pages/demopage.html"
    })
    .when("/demo", {
        templateUrl : "views/pages/demopage.html",
        controller: 'demo'
    })
    .when("/demo2", {
        templateUrl : "views/pages/demo2.html",
          controller: 'demo2'
    })
    .when("/products", {
        templateUrl : "views/pages/products.html",
        controller: 'products'
    })
    .when("/departments", {
        templateUrl : "views/pages/departments.html",
        controller: 'departments'
    })
    .when("/students", {
        templateUrl : "views/pages/students.html",
        controller: 'students'
    })
    .when("/appointmentList", {
        templateUrl : "views/pages/appointmentList.html",
        controller: 'appointmentList'
    })
    .when("/problemCreate", {
        templateUrl : "views/pages/problemCreate.html",
        controller: 'problemCreate'
    })
    .when("/problemList", {
        templateUrl : "views/pages/problemList.html",
        controller: 'problemList'
    })
    .when("/login", {
        templateUrl : "views/pages/login.html",
        controller: 'login'
    })
    .when("/pdonorGet", {
        templateUrl : "views/pages/pdonorGet.html",
        controller: 'pdonorGet'
    })
    .when("/pdonorCreate", {
        templateUrl : "views/pages/pdonorCreate.html",
        controller: 'pdonorCreate'
    })
    .otherwise({
        redirectTo:"/"
    });
      //$locationProvider.html5Mode(true);
      //$locationProvider.hashPrefix('');
      //if(window.history && window.history.pushState){
      //$locationProvider.html5Mode(true);
  //}

}]);

app.factory("interCeptor",function($q,$location){
    return{
        'request':function(config){
            config.headers.Authorization="Token1";
            console.log("intercepted");
            return config;
        },
        'reponse':function(rejection){
        }
    }
});
app.config(function($httpProvider){
	$httpProvider.interceptors.push("interCeptor");
});
