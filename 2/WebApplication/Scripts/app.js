var app = (function () {


    var handleAddProduct = function () {
        addProduct().then(function (data) { drawSingleProductInGrid(data) });
    };

    var handleGetProducts = function () {

        getProducts().then(function (data) {
            drawProductsInGrid(data);
        });
    };

    var module = {};
    module.handleAddProduct = handleAddProduct;
    module.handleGetProducts = handleGetProducts;

    return module;



    function drawProductsInGrid(products) {
        if (products.length === 0) return;
        clearGrid();
        $.each(products, function (index, value) {
            drawSingleProductInGrid(value);
        });
    }

    function clearGrid() {
        $("#productsGrid").html("");
    }

    function drawSingleProductInGrid(product) {
        $("#productsGrid").append("<tr>" +
            "<th scope='row'>" +
            product.Title +
            "</th ><td>" +
            product.ProductNumber +
            "</td><td> $" +
            product.Price
            + "</td></tr >");
    }

    function getProducts() {
        return $.ajax({
            url: "/api/products",
            headers: { 'storage': $("#storage").val() },
            method: "GET"
        });
    }

    function addProduct() {
        var newProduct = getProductFromDOM();
        return $.ajax({
            url: "/api/product",
            headers: { 'storage': $("#storage").val() },

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

    

}());