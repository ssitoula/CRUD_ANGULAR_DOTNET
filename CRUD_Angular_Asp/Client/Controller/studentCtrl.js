(function () {

    'use strict';

    myApp
    .controller('studentCtrl', studentCtrl);

    studentCtrl.$inject = ['$scope', '$location', 'studentService'];

    function studentCtrl($scope, $location, studentService) {
        /* jshint validthis:true */
        $scope.student = {};
        $scope.CreateStudent = {};
        getStudentDetails();
        function getStudentDetails() {

            studentService.sendStudent().then(function (data) {
                $scope.result = data;  //data is passed to UI

            })
        };





        $scope.add = function (model) {


            studentService.AddStudent(model).then(function (data) {  //addNotices is passed to noticeservices.
                if (data) {
                    $.notify({
                        title: "",
                        message: "Student Successfully Added!",
                        icon: 'fa fa-check'
                    }, {
                        type: "info"
                    });
                    getStudentDetails();
                    $("#myModal2").modal('hide');
                }

            })


        };



        $scope.getStudentById = function (id) {


            studentService.getStudentById(id).then(function (data) {

                if (data != null) {
                    $scope.Student = data;  //data is passed to UI
                    debugger;
                }

            })
        }




        $scope.editStudent = function (model) {

            studentService.updateStudent(model).then(function (data) {
                if (data) {
                    $.notify({
                        title: "",
                        message: "Updated Successfully !",
                        icon: 'fa fa-check'
                    }, {
                        type: "info"
                    });
                    getStudentDetails();
                    $("#myModal").modal('hide');
                }

            })
        };



        $scope.DeleteStudent = function (id) {
            var result = confirm("Are you sure want to delete?");
            if (result) {
               studentService.DeleteStudent(id).then(function (data) {
                    if (data) {
                        $.notify({
                            title: "",
                            message: "Student Successfully Deleted!",
                            icon: 'fa fa-check'
                        }, {
                            type: "info"
                        });
                        getStudentDetails();
                        $("#myModal2").modal('hide');
                    }
                })
            }
        };






    }

})();