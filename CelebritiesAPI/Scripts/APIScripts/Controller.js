app.controller('APIController', ['$scope', '$log','APIService', function ($scope, $log, APIService) {
   
    getAll();

    // getAll
    function getAll() {
        var servCall = APIService.getCelebs();
        servCall.then(function (d) {
            $scope.celeb = d.data;
        }, function (error) {
            $log.error('Oops! Something went wrong while fetching the data.');
        });
    }  

    //save
    $scope.saveCeleb = function () {
        var celeb = {
            Name: $scope.name,
            Age: $scope.age,
            Country: $scope.country
        };
        var saveCeleb = APIService.saveCeleb(celeb);
        saveCeleb.then(function (d) {
            clearForm();
            getAll();
        }, function (error) {
                console.log('Oops! Something went wrong while saving the data.')
            })
    }; 

    //update
    $scope.updateCeleb = function (celeb,eve , param) {
       
        if (param==="name"){
            celeb.name = eve.currentTarget.innerText;
        }
        else if (param === "age"){
            celeb.age = eve.currentTarget.innerText;
        }
        else if (param === "country"){
            celeb.country = eve.currentTarget.innerText;
        }
        var upd = APIService.updateCeleb(celeb);
        upd.then(function (d) {
            getAll();
        }, function (error) {
                console.log('Oops! Something went wrong while updating the data.')
            })  
    }

    // delete
    $scope.deleteCeleb = function (celebID) {
        var dltCeleb = APIService.deleteCeleb(celebID);
        dltCeleb.then(function (d) {
            getAll();
        }, function (error) {
            console.log('Oops! Something went wrong while deleting the data.')
        })
    }

    $scope.makeEditable = function (obj) {
        obj.target.setAttribute("contenteditable", true);
        obj.target.focus();
    };   

    function clearForm() {
        $("#name").val("");
        $("#age").val("");
        $("#country").val("");
    }  
    

}]);


