/*You have to include this js file into Views/Book
/Index.cshtml to make the actions on that page works*/

$(document).ready(function () {
    getBooks();
});

// Declare a variable to check when the action is Insert or Update
var isUpdateable = false;

// Get Book list, by default, this function will be run first for the page load
function getBooks() {
    $.ajax({
        url: '/FabricBooks/GetBooks/',
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            var rows = '';
            $.each(data, function (i, item) {
                rows += "<tr>"
                rows += "<td>" + item.Id + "</td>"
                rows += "<td>" + item.Name + "</td>"
                rows += "<td>" + item.Name + "</td>"
                rows += "<td><button type='button' id='btnEdit' class='btn btn-default' onclick='return getBookById(" + item.Id + ")'>Edit</button> <button type='button' id='btnDelete' class='btn btn-danger' onclick='return deleteBookById(" + item.Id + ")'>Delete</button></td>"
                rows += "</tr>";
                $("#listBooks tbody").html(rows);
            });
        },
        error: function (err) {
            alert("Error: " + err.responseText);
        }
    });
}

// Get book by id
function getBookById(id) {
    $("#title").text("Book Detail");
    $.ajax({
        url: '/FabricBooks/Get/' + id,
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            $("#Id").val(data.Id);
            $("#Name").val(data.Name);
            isUpdateable = true;
            $("#bookModal").modal('show');
        },
        error: function (err) {
            alert("Error: " + err.responseText);
        }
    });
}


// Insert/ Update a books
$("#btnSave").click(function (e) {

    var data = {
        Id: $("#Id").val(),
        Name: $("#Name").val(),
    }

    if (!isUpdateable) {
        $.ajax({
            url: '/FabricBooks/Create/',
            type: 'POST',
            dataType: 'json',
            data: data,
            success: function (data) {
                getCategories();
                $("#bookModal").modal('hide');
                clear();
            },
            error: function (err) {
                alert("Error: " + err.responseText);
            }
        })
    }
    else {
        $.ajax({
            url: '/FabricBooks/Update/',
            type: 'POST',
            dataType: 'json',
            data: data,
            success: function (data) {
                getCategories();
                isUpdateable = false;
                $("#bookModal").modal('hide');
                clear();
            },
            error: function (err) {
                alert("Error: " + err.responseText);
            }
        })
    }
});

// Delete book by id
function deleteBookById(id) {
    $("#confirmModal #title").text("Delete BookS");
    $("#confirmModal").modal('show');
    $("#confirmModal #btnOk").click(function (e) {
        $.ajax({
            url: "/FabricBooks/Delete/" + id,
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
