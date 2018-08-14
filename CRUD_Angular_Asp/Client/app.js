var myApp = angular.module("myApp", ["ui.router"]);
myApp.config(function ($stateProvider) {
    $stateProvider
.state('students', {
    url: '/student',
    templateUrl: '/Client/View/StudentManagement.html',
    controller: 'studentCtrl',
    controllerAs: 'studentCtrl'

})
});


myApp.constant('serviceBasePath', 'http://localhost:4998');