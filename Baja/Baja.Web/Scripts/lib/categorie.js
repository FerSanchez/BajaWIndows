/*You have to include this js file into Views/Categorie/Index.cshtml to make the actions on that page works*/

$(document).ready(function () {
    getCategories();
});

// Declare a variable to check when the action is Insert or Update
var isUpdateable = false;

// Get Categorie list, by default, this function will be run first for the page load
function getCategories() {
    $.ajax({
        url: '/FabricCategories/GetCategories/',
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            var rows = '';
            $.each(data, function (i, item) {
                rows += "<tr>"
                rows += "<td>" + item.Id + "</td>"
                rows += "<td>" + item.Name + "</td>"
                rows += "<td><button type='button' id='btnEdit' class='btn btn-default' onclick='return geCategorieById(" + item.Id + ")'>Edit</button> <button type='button' id='btnDelete' class='btn btn-danger' onclick='return deleteCategorieById(" + item.Id + ")'>Delete</button></td>"
                rows += "</tr>";
                $("#listCategories tbody").html(rows);
            });
        },
        error: function (err) {
            alert("Error: " + err.responseText);
        }
    });
}

// Get Categorie by id
function geCategorieById(id) {
    $("#title").text("Categorie Detail");
    $.ajax({
        url: '/FabricCategories/Get/' + id,
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            $("#Id").val(data.Id);
            $("#Name").val(data.Name);
            isUpdateable = true;
            $("#categorieModal").modal('show');
        },
        error: function (err) {
            alert("Error: " + err.responseText);
        }
    });
}

// Insert/ Update a Categorie
$("#btnSave").click(function (e) {

    var data = {
        Id: $("#Id").val(),
        Name: $("#Name").val(),
    }

    if (!isUpdateable) {
        $.ajax({
            url: '/FabricCategories/Create/',
            type: 'POST',
            dataType: 'json',
            data: data,
            success: function (data) {
                getCategories();
                $("#categorieModal").modal('hide');
                clear();
            },
            error: function (err) {
                alert("Error: " + err.responseText);
            }
        })
    }
    else {
        $.ajax({
            url: '/FabricCategories/Update/',
            type: 'POST',
            dataType: 'json',
            data: data,
            success: function (data) {
                getCategories();
                isUpdateable = false;
                $("#categorieModal").modal('hide');
                clear();
            },
            error: function (err) {
                alert("Error: " + err.responseText);
            }
        })
    }
});

// Delete categorie by id
function deleteCategorieById(id) {
    $("#confirmModal #title").text("Delete Categorie");
    $("#confirmModal").modal('show');
    $("#confirmModal #btnOk").click(function (e) {
        $.ajax({
            url: "/FabricCategories/Delete/" + id,
            type: "POST",
            dataType: 'json',
            success: function (data) {
                getCategories();
                $("#confirmModal").modal('hide');
            },
            error: function (err) {
                alert("Error: " + err.responseText);
            }
        });

        e.preventDefault();
    });
}

// Set title for create new
$("#btnCreate").click(function () {
    $("#title").text("Create New");
})

// Close modal
$("#btnClose").click(function () {
    clear();
});

// Clear all items
function clear() {
    $("#Id").val("");
    $("#Name").val("");
}