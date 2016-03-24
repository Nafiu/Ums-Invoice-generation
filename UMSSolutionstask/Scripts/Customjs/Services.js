app.service('loadservices', function ($http) {
    var fac = {};
    fac.GetProduct = function () {
        return $http.get('/Home/GetProducts');
    }
    fac.GetSingleProduct = function (Pid) {
        return $http.get('/Home/GetSingleProduct?Pid=' + Pid);
    }

    fac.GenerateInvoiceId = function (id) {
        return $http.post('/Home/GenerateInvoiceId?ivid=' + id);
    }
    fac.Savetodatabase = function (array) {
        return $http.post('/Home/SaveDb',array);
    }
  
    return fac;
})