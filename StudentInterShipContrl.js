var app = angular.module('MyApp', []);
debugger;
app.controller('StudentController', function ($scope, FileUploadService) {
    debugger;
    $scope.$watch('Intership.$valid', function (newVal) {
        debugger;
        $scope.IsFormValid = newVal;
    });

    //File Validation
    $scope.ChechFileValid = function (file) {
        debugger;
        var isValid = false;
        if ($scope.SelectedFileForUpload != null) {///|| file.type == 'image/jpeg' || file.type == 'image/gif' //&& file.size <= (512 * 1024)
            debugger;
            if ((file.type == 'application/vnd.openxmlformats-officedocument.wordprocessingml.document' || file.type == 'image/jpeg' || file.type == 'image/gif' && file.size <= (512 * 1024))) {
                $scope.fileinvalidmessage = "";
                isValid = true;
            }
            else {
                $scope.fileinvalidmessage = "selected file is invalid. (only file type docx, pdf...!!!)";
            }
        }
        else {
            $scope.FileInvalidMessage = "Upload Resume required!";
        }
        $scope.IsFileValid = isValid;
    };

    //File Select event 
    $scope.selectFileforUpload = function (file) {
        $scope.SelectedFileForUpload = file[0];
    }

    //Save File
    $scope.DetailsAdd = function () {
        debugger;
        $scope.IsFormSubmitted = true;
        $scope.Message = "";
        $scope.ChechFileValid($scope.SelectedFileForUpload);
        if ($scope.IsFormValid && $scope.IsFileValid) {
            FileUploadService.UploadFile(

                //$scope.FileDescription,
                $scope.Name,
                $scope.MobileNo,
                $scope.Email,
                $scope.CollegeName,
                $scope.SelectValue,
                $scope.SSCMark,
                $scope.HscDiplomaMark,
                $scope.GraduateMark,
                $scope.PGMark,
                $scope.AcceptTermAndCondition,
                $scope.SelectedFileForUpload
                //$scope.file

                ).then(function (d) {
                    alert(d.Message);
                    //ClearForm();
                }, function (e) {
                    alert(e);
                });
        }
        else {
            $scope.Message = "All the fields are required.";
        }
    };

})


.factory('FileUploadService', function ($http, $q) { // explained abour controller and service in part 2
    debugger;
    var fac = {};
    fac.UploadFile = function (Name, MobileNo, Email, CollegeName, SelectValue, SSCMark, HscDiplomaMark, GraduateMark, PGMark, AcceptTermAndCondition, file) {
        var formData = new FormData();
        formData.append("file", file);
        //We can send more data to server using append         
        //formData.append("description", description);
        formData.append("Name", Name);
        formData.append("MobileNo", MobileNo);
        formData.append("Email", Email);
        formData.append("CollegeName", CollegeName);
        formData.append("SelectValue", SelectValue);
        formData.append("SSCMark", SSCMark);
        formData.append("HscDiplomaMark", HscDiplomaMark);
        formData.append("GraduateMark", GraduateMark);
        formData.append("PGMark", PGMark);
        formData.append("AcceptTermAndCondition", AcceptTermAndCondition);

        var defer = $q.defer();
        $http.post("/Home/SaveFiles", formData,
            {
                withCredentials: true,
                headers: { 'Content-Type': undefined },
                transformRequest: angular.identity
            })
        .success(function (d) {
            defer.resolve(d);
        })
        .error(function () {
            defer.reject("Authentication problem and please your check internet connection..!! File Upload Sending Failed!!");
        });

        return defer.promise;

    }
    return fac;

});

































    //$scope.DetailsAdd1 = function () {
    //    debugger;
        

    //}

    //$scope.DetailsAdd = function () {
       
    //    debugger;
    //    if ($scope.IsFormValid) {
    //        debugger;
    //        var Add = {

    //            StudentName: $scope.Name,
    //            MobailNumber: $scope.MobileNo,
    //            EmailID: $scope.Email,
    //            Current_And_Last_College_Name: $scope.CollegeName,
    //            Education_Type: $scope.SelectValue,
    //            SSC_mark: $scope.SSCMark,
    //            HSC_And_Deploma_mark: $scope.HscDiplomaMark,
    //            Graduate_mark: $scope.GraduateMark,
    //             PG_mark: $scope.PGMark,
    //            //Resumes: $scope.myFile,
    //            Term_And_Condition: $scope.AcceptTermAndCondition
    //        };
    //        $scope.Action = "ADD";
    //        var getAction = $scope.Action;
    //        if (getAction == "ADD") {

    //            var getData = Myservice.AddDetails(Add);
    //            getData.then(function (msg) {
    //                debugger;
    //                alert(msg.data);
                   
    //                notificationService.displayError('Error in adding record');
    //            }, function () {
    //                notificationService.displayError('Error in adding record');
    //              alert('Error in adding record');
    //            });
    //        }
    //    }
    //    else {
    //        $scope.ErrorMassage = "Field Shold Be Not Empty";

    //    }
    //}
  

//})


  //.service('Myservice', function ($http) {
  //    debugger;

  //    this.AddDetails = function (Add) {
  //        debugger;
  //        var response = $http({
  //            method: "post",
  //            url: "/Home/InsertDetails",
  //            data: JSON.stringify(Add),
  //            dataType: "json"
  //        });
  //        return response;
  //    }
  //});
app.factory('notificationService', notificationService);

function notificationService() {


    toastr.options = {
        "debug": false,
        "positionClass": "toast-top-right",
        "onclick": null,
        "fadeIn": 300,
        "fadeOut": 1000,
        "timeOut": 3000,
        "extendedTimeOut": 1000
    };

    var service = {
        displaySuccess: displaySuccess,
        displayError: displayError,
        displayWarning: displayWarning,
        displayInfo: displayInfo
    };

    return service;

    function displaySuccess(message) {
        toastr.success(message);
    }

    function displayError(error) {
        if (Array.isArray(error)) {
            error.forEach(function (err) {
                toastr.error(err);
            });
        } else {
            toastr.error(error);
        }
    }

    function displayWarning(message) {
        toastr.warning(message);
    }

    function displayInfo(message) {
        toastr.info(message);
    }

}



