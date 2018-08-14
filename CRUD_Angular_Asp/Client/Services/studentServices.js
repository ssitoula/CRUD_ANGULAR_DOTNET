
(function () {
    'use strict';

    myApp.factory('studentService', studentService);

    studentService.$inject = ['$http', 'serviceBasePath', '$q'];

    function studentService($http, serviceBasePath, $q) {
        var fac = {};
        fac.sendStudent = function () {
            return $http.get(serviceBasePath + '/api/student/getstudentdetails').then(function (response) {
                return response.data;
            })

        }

        fac.AddStudent = function (model) {
            var config = {
                headers: { 'Content-Type': 'application/json' }
            };

            var data = {
                Name: model.name,
                address: model.address

            }

            var deferred = $q.defer();
            $http.post(serviceBasePath + '/api/student/addstudent', data, config).success(function (response) {
                deferred.resolve(response);
            }).error(function (err) {
                console.log(err);
                deferred.reject(err);
            });
            return deferred.promise;

        }


        fac.getStudentById = function (id) {
            var config = {
                headers: { 'Content-Type': 'application/json' }
            };

            var deferred = $q.defer();
            $http.get(serviceBasePath + '/api/student/GetStudentById', { params: { id: id } }, config).success(function (response) {
                deferred.resolve(response);
            }).error(function (err) {
                console.log(err);
                deferred.reject(err);
            });
            return deferred.promise;

        }

        fac.updateStudent = function (model) {
            var config = {
                headers: { 'Content-Type': 'application/json' }
            };
            //var data = {
            //    id :model.id,
            //    Name: model.name,
            //    address :model.address
            //}

            var deferred = $q.defer();
            $http.post(serviceBasePath + '/api/student/updatestudent', model, config).success(function (response) {
                deferred.resolve(response);
            }).error(function (err) {
                console.log(err);
                deferred.reject(err);
            });
            return deferred.promise;

        }


        fac.DeleteStudent = function (id) {

            var config = {
                headers: { 'Content-Type': 'application/json' }
            };
            var deferred = $q.defer();
            $http.post(serviceBasePath + '/api/student/DeleteStudent/', id, config).success(function (response) {
                deferred.resolve(response);
            }).error(function (err) {
                console.log(err);
                deferred.reject(err);
            });
            return deferred.promise;

        }


        return fac;

    }
})();
