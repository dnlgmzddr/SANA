var app = (function () {


    var handleAddProduct = function () {
        addProduct();
    };

    var handleGetProducts = function () {
        getProducts().then(function (data) {
            drawProductsInGrid(data);
        });
    };

    var module = {};
    module.handleAddProduct = handleAddProduct;
    module.handleGetProducts = handleGetProducts;




    var drawProductsInGrid = function (products) {
        $("#productsGrid").html("");
        $.each(products, function (index, value) {
            $("#productsGrid").append("<tr>" +
                "<th scope='row'>" +
                value.Title +
                "</th ><td>" +
                value.ProductNumber+
                "</td><td>" +
                value.Price
                +"</td></tr >");
        });
    }

    var getProducts = function () {
        return $.ajax({
            url: "/api/products",
            method: "GET"
        });
    }

    var addProduct = function () {
        var newProduct = getProductFromDOM();
        return $.ajax({
            url: "/api/product",
            method: "POST",
            data: newProduct

        });

    }

    function getProductFromDOM() {
        return {
            Title: $("#TitleInput").val(),
            Price: $("#PriceInput").val()
        };
    }

    return module;

}());