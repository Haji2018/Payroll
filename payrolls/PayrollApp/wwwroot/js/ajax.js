




var _selectedCompany = null;
var _selectedDepartment = null;

$("select#holding_selectbox").change(function () {
    _selectedCompany = $(this).children("option:selected").val();
});
$("select#company_selectbox").change(function () {
    _selectedDepartment = $(this).children("option:selected").val();
});

let companyIdd, deletedCompany;
//Search Holding and Modals
$(document).on("click", ".deleteEmployee", function (e) {
    companyIdd = $(this).data("id");
    deletedCompany = $(this).parents();
    if (companyIdd) {
        $.ajax({
            url: "/PayrollAdmin/Holding/Delete",
            method: "Get",
            data: { id: companyIdd },
            success: function (respons) {
                if (respons.message == 200) {
                    $("#companyName").val(respons.companyDb.holdingName)
                  

                    $('#delete').modal('show')
                }
            },
          
        });
    }
});
$(document).on("click", ".deleteSave", function (e) {
    e.preventDefault();
    
    var ajax = ({
        url: "/PayrollAdmin/Holding/DeletePost",
        method: "POST",
        async: true,
        data: { id: companyIdd },
        success: function (respons) {
            if (respons.message == 200) {
                $(deletedCompany).parents("tr").remove();
            }
        }
    });

  

    $.ajax(ajax);
});
$(document).on("click", ".editHolding", function (e) {
    

    companyIdd = $(this).data("id");

    if (companyIdd) {
        $.ajax({

            url: "/PayrollAdmin/Holding/Edit",
            method: "Get",
            data: { id: companyIdd },
            success: function (respons) {
                if (respons.message == 200) {

                    $("#nn").val(respons.companyDb.holdingName)
                    $("#holdingAddress").val(respons.companyDb.address)
                    $("#holdingPhone").val(respons.companyDb.phone)
                    $("#holdingAbout").val(respons.companyDb.about)
                 
                    $('#edit').modal('show')
                }
            },
         
        });
    }
});
$(document).on("click", ".editSave", function (e) {
 
    e.preventDefault();
    var Holding = {

        HoldingName:$("#nn").val(),
        Address: $("#holdingAddress").val(),
        Phone: $("#holdingPhone").val(),
        About: $("#holdingAbout").val(),
    }

    var model = {

        "Holding": Holding,
    };

 
    
        var ajax = ({
            url: "/PayrollAdmin/Holding/EditPost",
            method: "POST",

            data: { id: companyIdd, model: Holding },
            success: function (respons) {

               
                if (respons.message == 200) {

                    window.location.reload(true);
                }
            }
        });
    
   

    $.ajax(ajax);
});



function addNewHolding(datas) {
    var maintr = $("#trEmployee").clone();
    $("table.employees tbody").html(maintr);
    for (var data of datas) {
        var tr = $("#trEmployee").clone();
        tr.removeClass("d-none");
        tr.removeAttr('id');

        tr.find("td:nth-child(1)").text(data.holdingName);     
        $("table.employees tbody").append(tr);
    }
}


$("#holdingName").keyup(function () {
    var name = $(this).val();

    $.ajax({
        url: "/PayrollAdmin/Holding/HoldingSearch",
        method: "Get",
        data: { name: name, },
        success: function (res) {
            if (res.status == 200) {
                addNewHolding(res.data);
            }
        }
    });
});




//Search Company and Modals

function addNewEmployee(datas) {
    var maintr = $("#trEmployee").clone();
    $("table.employees tbody").html(maintr);
    for (var data of datas) {
        var tr = $("#trEmployee").clone();
        tr.removeClass("d-none");
        tr.removeAttr('id');

        tr.find("td:nth-child(1)").text(data.companyName);

        $("table.employees tbody").append(tr);
    }
}
$("#companyName").keyup(function () {
    var name = $(this).val();

    $.ajax({
        url: "/PayrollAdmin/Company/CompanySearch",
        method: "Get",
        data: { name: name, },
        success: function (res) {
            if (res.status == 200) {
                addNewEmployee(res.data);
            }
        }
    });
});



$(document).on("click", ".deleteCompany", function (e) {
  
    companyIdd = $(this).data("id");
    deletedCompany = $(this).parents();
    if (companyIdd) {
        $.ajax({
            url: "/PayrollAdmin/Company/Delete",
            method: "Get",
            data: { id: companyIdd },
            success: function (respons) {
                if (respons.message == 200) {
                    $("#nameCompany").val(respons.companyDb.companyName)


                    $('#delete').modal('show')
                }
            },
          
        });
    }
});
$(document).on("click", ".deleteSave", function (e) {
    e.preventDefault();

    var ajax = ({
        url: "/PayrollAdmin/Company/DeletePost",
        method: "POST",
        async: true,
        data: { id: companyIdd },
        success: function (respons) {
            if (respons.message == 200) {
                $(deletedCompany).parents("tr").remove();
            }
        }
    });

  

    $.ajax(ajax);
});

$(document).on("click", ".editCompany", function (e) {


    companyIdd = $(this).data("id");

    if (companyIdd) {
        $.ajax({

            url: "/PayrollAdmin/Company/AddOrEdit",
            method: "Get",
            data: { id: companyIdd },
            success: function (respons) {
                if (respons.message == 200) {

                    $("#aa").val(respons.companyDb.companyName)
                    $("#bb").val(respons.companyDb.address)
                    $("#cc").val(respons.companyDb.phone)
                    $("#dd").val(respons.companyDb.about)
                    _selectedCompany = $(this).children("option:selected").val();
                    $("#holding_selectbox").val(respons.companyDb.holdingId)
                    $('#edit').modal('show')
                }
            },
       
        });
    }
});
$(document).on("click", ".editSave", function (e) {
  
    e.preventDefault();
    
    var Company = {

        CompanyName: $("#aa").val(),
        Address: $("#bb").val(),
        Phone: $("#cc").val(),
        About: $("#dd").val(),
        HoldingId: _selectedCompany,
    }

    var model = {

        "Company": Company,
    };

    var ajax = ({
        url: "/PayrollAdmin/Company/EditPost",
        method: "POST",

        data: { id: companyIdd, model: Company },
      
        success: function (respons) {


            if (respons.message == 200) {
               
                window.location.reload(true);
            }
        },
     
    });

 

    $.ajax(ajax);
});






//Search Department and Modals


function addNewDepartment(datas) {
    var maintr = $("#trEmployee").clone();
    $("table.employees tbody").html(maintr);
    for (var data of datas) {
        var tr = $("#trEmployee").clone();
        tr.removeClass("d-none");
        tr.removeAttr('id');

        tr.find("td:nth-child(1)").text(data.departmentName);

        $("table.employees tbody").append(tr);
    }
}
$("#departmentName").keyup(function () {
    var name = $(this).val();
   
    $.ajax({
        url: "/PayrollAdmin/Department/DepartmentSearch",
        method: "Get",
        data: { name: name, },
        success: function (res) {
            if (res.status == 200) {
                addNewDepartment(res.data);
            }
        }
    });
});


$(document).on("click", ".deleteDepartment", function (e) {

    companyIdd = $(this).data("id");
    deletedCompany = $(this).parents();
    if (companyIdd) {
        $.ajax({
            url: "/PayrollAdmin/Department/Delete",
            method: "Get",
            data: { id: companyIdd },
            success: function (respons) {
                if (respons.message == 200) {
                    $("#nameDepartment").val(respons.companyDb.departmentName)


                    $('#delete').modal('show')
                }
            },
        
        });
    }
});
$(document).on("click", ".deleteSave", function (e) {
    e.preventDefault();

    var ajax = ({
        url: "/PayrollAdmin/Department/DeletePost",
        method: "POST",
        async: true,
        data: { id: companyIdd },
        success: function (respons) {
            if (respons.message == 200) {
                $(deletedCompany).parents("tr").remove();
            }
        }
    });

    

    $.ajax(ajax);
});




// Store Search



function addNewStore(datas) {
    var maintr = $("#trEmployee").clone();
    $("table.employees tbody").html(maintr);
    for (var data of datas) {
        var tr = $("#trEmployee").clone();
        tr.removeClass("d-none");
        tr.removeAttr('id');

        tr.find("td:nth-child(1)").text(data.storeName);

        $("table.employees tbody").append(tr);
    }
}
$("#storeName").keyup(function () {
    var name = $(this).val();

    $.ajax({
        url: "/PayrollAdmin/Store/StoreSearch",
        method: "Get",
        data: { name: name, },
        success: function (res) {
            if (res.status == 200) {
                addNewStore(res.data);
            }
        }
    });
});


$(document).on("click", ".deleteStore", function (e) {

    companyIdd = $(this).data("id");
    deletedCompany = $(this).parents();
    if (companyIdd) {
        $.ajax({
            url: "/PayrollAdmin/Store/Delete",
            method: "Get",
            data: { id: companyIdd },
            success: function (respons) {
                if (respons.message == 200) {
                    $("#nameStore").val(respons.companyDb.storeName)


                    $('#delete').modal('show')
                }
            },
       
        });
    }
});
$(document).on("click", ".deleteSave", function (e) {
    e.preventDefault();

    var ajax = ({
        url: "/PayrollAdmin/Store/DeletePost",
        method: "POST",
        async: true,
        data: { id: companyIdd },
        success: function (respons) {
            if (respons.message == 200) {
                $(deletedCompany).parents("tr").remove();
            }
        }
    });

  

    $.ajax(ajax);
});



// Position Search


function addNewPosition(datas) {
    var maintr = $("#trEmployee").clone();
    $("table.employees tbody").html(maintr);
    for (var data of datas) {
        var tr = $("#trEmployee").clone();
        tr.removeClass("d-none");
        tr.removeAttr('id');

        tr.find("td:nth-child(1)").text(data.positionName);

        $("table.employees tbody").append(tr);
    }
}
$("#positionName").keyup(function () {
    var name = $(this).val();

    $.ajax({
        url: "/PayrollAdmin/Position/PositionSearch",
        method: "Get",
        data: { name: name, },
        success: function (res) {
            if (res.status == 200) {
                addNewPosition(res.data);
            }
        }
    });
});


$(document).on("click", ".deletePosition", function (e) {

    companyIdd = $(this).data("id");
    deletedCompany = $(this).parents();
    if (companyIdd) {
        $.ajax({
            url: "/PayrollAdmin/Position/Delete",
            method: "Get",
            data: { id: companyIdd },
            success: function (respons) {
                if (respons.message == 200) {
                    $("#namePosition").val(respons.companyDb.positionName)


                    $('#delete').modal('show')
                }
            },
       
        });
    }
});
$(document).on("click", ".deleteSave", function (e) {
    e.preventDefault();

    var ajax = ({
        url: "/PayrollAdmin/Position/DeletePost",
        method: "POST",
        async: true,
        data: { id: companyIdd },
        success: function (respons) {
            if (respons.message == 200) {
                $(deletedCompany).parents("tr").remove();
            }
        }
    });

    

    $.ajax(ajax);
});




// Role 




$(document).on("click", ".addRole", function (e) {

    $('#add').modal('show')
});
$(document).on("click", ".addSave_Role", function (e) {


    deletedCompany = $(this).parents();
    var EditRoleViewModel = {

        RoleName: $("#nn").val(),
       
        
    }

    var model = {

        "EditRoleViewModel": EditRoleViewModel,
    };


    var ajax = ({
        url: "/PayrollAdmin/Role/AddPost",
        data: { model: EditRoleViewModel },
        method: "Post",
        error: function (request, error) {

            alert("Xanalari Doldurun ");
        },
        success: function (respons) {
            if (respons.message == 200) {
                $(deletedCompany).parents("div").add();
                window.location.reload(true);
            }
        }
    })


 


    $.ajax(ajax);
});













// PastPosition Search


function addNewPastPosition(datas) {
    var maintr = $("#trEmployee").clone();
    $("table.employees tbody").html(maintr);
    for (var data of datas) {
        var tr = $("#trEmployee").clone();
        tr.removeClass("d-none");
        tr.removeAttr('id');

        tr.find("td:nth-child(1)").text(data.pastpositionName);

        $("table.employees tbody").append(tr);
    }
}
$("#pastpositionName").keyup(function () {
    var name = $(this).val();

    $.ajax({
        url: "/PayrollAdmin/PastPosition/PastPositionSearch",
        method: "Get",
        data: { name: name, },
        success: function (res) {
            if (res.status == 200) {
                addNewPosition(res.data);
            }
        }
    });
});


$(document).on("click", ".deletePastPosition", function (e) {

    companyIdd = $(this).data("id");
    deletedCompany = $(this).parents();
    if (companyIdd) {
        $.ajax({
            url: "/PayrollAdmin/PastPosition/Delete",
            method: "Get",
            data: { id: companyIdd },
            success: function (respons) {
                if (respons.message == 200) {
                   


                    $('#delete').modal('show')
                }
            },

        });
    }
});
$(document).on("click", ".deleteSave_PastPosition", function (e) {
    e.preventDefault();

    var ajax = ({
        url: "/PayrollAdmin/PastPosition/DeletePost",
        method: "POST",
        async: true,
        data: { id: companyIdd },
        success: function (respons) {
            if (respons.message == 200) {
                $(deletedCompany).parents("tr").remove();
            }
        }
    });



    $.ajax(ajax);
});


