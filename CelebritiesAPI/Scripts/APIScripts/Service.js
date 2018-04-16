app.service("APIService", ['$http', function ($http) {

    var url = 'api/celebrities';

    this.getCelebs = function () {
        return $http.get(url).then(function (response) {
            return response;
        }); 
    }
    
    this.saveCeleb = function (celeb) {
        return $http({
            method: 'post',
            data: celeb,
            url: url
        });
    }
    this.updateCeleb = function (celeb) {
        return $http({
            method: 'put',
            data: celeb,
            url: url
        });
    }
    this.deleteCeleb = function (celebID) {
        return $http({
            method: 'delete',
            data: celebID,
            url: 'api/celebrities/'+ celebID
        });
    }

}]);
    