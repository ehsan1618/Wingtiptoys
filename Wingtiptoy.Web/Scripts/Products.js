function getProductsByCategory(apiUrl) {
    $.getJSON(apiUrl,
        function (data) {
            $('#Products').empty(); // Clear table body.  

            // Loop through the list of products.  
            $.each(data, function (key, val) {
                // Add a table row for the products.  
                var row = "<tr><td><a href='TODOurl/" + val.ProductID + "'><img border = '1' height = '75' src = 'Assets/" + val.ImagePath + "' width = '100'></a></td ><td>" + val.ProductName + "<br><span class='ProductPrice'><strong>Price:</strong>$" + val.UnitPrice + "<input type='hidden' id='productId" + val.ProductID + "' name='custId" + val.ProductID + "' value='" + val.ProductID + "'></span></td></tr>";
                $("#Products").append(row);
            });
        });
}
//$(document).ready(getProductsByCategory);