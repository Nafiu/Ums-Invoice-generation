/// <reference path="Services.js" />
var array = [];
app.controller('angcontroller', function ($scope, loadservices) {

    $scope.ProductList = null;
    $scope.product = null;
    $scope.total = 0;
    var q;
    var r;
    $scope.cusid = '';
    $scope.Invoiceid = '';
   // $scope.array = '';
    //get all product
    loadservices.GetProduct().then(function (d) {
        $scope.ProductList = d.data;
    }, function (error) {
        console.log(error);
    });

    //get single product
    $scope.Getsingleproduct = function () {
        loadservices.GetSingleProduct($scope.Pid).then(function (d) {
            $scope.product = d.data;
        }, function (error) {
            alert(error);
        });
    };

    //finding net amount (subtract discount and tax from amount)  
    $scope.netamount = {
        result: function () {
             q = $scope.qua;  r = $scope.product;
            r.amount = q * r.PRate;
            r.netamount = r.amount + (((r.amount / 100) * r.Pdis) - ((r.amount / 100) * r.Ptax));
            return r.netamount;
        }
    };


    //Add to list of table
    $scope.submit = function () {
        var qq = $scope.qua;
        var t = $scope.total;
        var rr = $scope.product;
        var invoice = $scope.Invoiceid;
        var productss =
            {
                Pid:rr.Pid,
                Pname: rr.Pname,
                Rate: rr.PRate,
                Quantity: qq,
                Amount: rr.amount,
                Pdis: rr.Pdis,
                Ptax: rr.Ptax,
                Net: rr.netamount,
                Invoiceid: invoice.ivid
            };

        //Total of all product
        var tot = t + rr.netamount;
        $scope.total = tot;

        //Push data to array
        array.push(productss);
        $scope.produdccc = array;
     

        //count of product
        var cout = array.length;
        $scope.Count = cout;

        //Clear text box
        $scope.Pid = ''; $scope.qua = '';
        rr.PRate = ''; rr.Pdis = ''; rr.Ptax = '';
    };

    //remove from list data
    $scope.removeitem = function (p) {
        var rem = array.indexOf(p);
        array.splice(array.indexOf(p), 1);

        //total of all product
        var t = $scope.total;
        $scope.total = t - p.Net;

        //count of product
        var cout = array.length;
        $scope.Count = cout;
    };


    //Generate invoiceid and get invoice id

    $scope.textchanged = function () {
        loadservices.GenerateInvoiceId($scope.cusid).then(function (d) {
            $scope.Invoiceid = d.data;
            var inv = $scope.Invoiceid;
            for (var i = 0; i < array.length; i++) {
                array[i]['Invoiceid'] = inv.ivid;
            }
        }, function (error) {
            alert('Invoice id not generated');
        })
    };

    //Save to database
    $scope.Save = function () {
        var data = {};
        data.datas = array;
        loadservices.Savetodatabase(array).then(function (d) {
            $scope.produdccc = ''; $scope.cusid = ''; $scope.Count = ''; $scope.total = '';
            $scope.Invoiceid = ''; array = ''; $scope.showbutton = false;
        })
    }
})