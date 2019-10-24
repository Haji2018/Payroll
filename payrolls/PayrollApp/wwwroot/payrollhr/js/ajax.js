
//Employee Search

function addNewEmployees(datas) {
    var maintr = $("#trEmployee").clone();
    $("table.employees tbody").html(maintr);
    for (var data of datas) {
        var tr = $("#trEmployee").clone();
        tr.removeClass("d-none");
        tr.removeAttr('id');

        tr.find("td:nth-child(1)").text(data.name);

        $("table.employees tbody").append(tr);
    }
}
$("#employeeName").keyup(function () {
    var name = $(this).val();

    $.ajax({
        url: "/PayrollHr/Employee/EmployeeSearch",
        method: "Get",
        data: { name: name, },
        success: function (res) {
            if (res.status == 200) {
                addNewEmployees(res.data);
            }
        }
    });
});


let companyIdd, deletedEmployee;

$(document).on("click", ".deleteEmployee", function (e) {
    companyIdd = $(this).data("id");
    deletedEmployee = $(this).parents();
    if (companyIdd) {
        $.ajax({
            url: "/PayrollHr/Employee/Delete",
            method: "Get",
            data: { id: companyIdd },
            success: function (respons) {
                if (respons.message == 200) {
                    $("#nameEmployee").val(respons.companyDb.name)


                    $('#delete').modal('show')
                }
            },
         
        });
    }
});
$(document).on("click", ".deleteSave", function (e) {
    e.preventDefault();
   
    var ajax = ({
        url: "/PayrollHr/Employee/DeletePost",
        method: "POST",
        async: true,
        data: { id: companyIdd },
        success: function (respons) {
            if (respons.message == 200) {
                $(deletedEmployee).parents("tr").remove();
            }
        }
    });

   

    $.ajax(ajax);
});

$(document).on("click", ".detailEmployee", function (e) {


    companyIdd = $(this).data("id");

    if (companyIdd) {
        $.ajax({

            url: "/PayrollHr/Employee/Details",
            method: "Get",
            data: { id: companyIdd },
            success: function (respons) {
                if (respons.message == 200) {

                    $("#fatherEmployee").val(respons.companyDb.patronymic)
                    $("#dateEmoloyee").val(respons.companyDb.birthday)
                    $("#addressEmployee").val(respons.companyDb.livingPlace)
                    $("#qeydiyyatEmployee").val(respons.companyDb.districtRegistration)
                    
                    $("#seriaEmployee").val(respons.companyDb.identityCardNumber)
                    $("#expireDateEmployee").val(respons.companyDb.identityCardExpireDate)
                    $('#detail').modal('show')
                }
            },
            error: function (xhr, status, error) {
                console.log(xhr.status);
                console.log(status);
                console.log(error);
            }
        });
    }
});


//Search PastEmployment 




$(document).on("click", ".deletePast", function (e) {
    companyIdd = $(this).data("id");
    deletedEmployee = $(this).parents();
    if (companyIdd) {
        $.ajax({
            url: "/PayrollHr/PastEmployment/Delete",
            method: "Get",
            data: { id: companyIdd },
            success: function (respons) {
                if (respons.message == 200) {
                    $("#namePast").val(respons.companyDb.company)


                    $('#delete').modal('show')
                }
            },

        });
    }
});
$(document).on("click", ".delete_Save", function (e) {
    e.preventDefault();

    var ajax = ({
        url: "/PayrollHr/PastEmployment/DeletePost",
        method: "POST",
        async: true,
        data: { id: companyIdd },
        success: function (respons) {
            if (respons.message == 200) {
                $(deletedEmployee).parents("tr").remove();
                window.location.reload(true);
            }
        }
    });



    $.ajax(ajax);
});



//Search Worker 

function addNewWorker(datas) {
    var maintr = $("#trEmployee").clone();
    $("table.employees tbody").html(maintr);
    for (var data of datas) {
        var tr = $("#trEmployee").clone();
        tr.removeClass("d-none");
        tr.removeAttr('id');

        tr.find("td:nth-child(1)").text(data.employee.name );
      

        $("table.employees tbody").append(tr);
    }
}
$("#workerName").keyup(function () {
    var name = $(this).val();

    $.ajax({
        url: "/PayrollHr/Worker/WorkerSearch",
        method: "Get",
        data: { name: name, },
        success: function (res) {
            if (res.status == 200) {
                addNewWorker(res.data);
            }
        }
    });
});


$(document).on("click", ".deleteWorker", function (e) {
    companyIdd = $(this).data("id");
    deletedEmployee = $(this).parents();
   
    if (companyIdd) {
        $.ajax({
            url: "/PayrollHr/Worker/Delete",
            method: "Get",
            data: { id: companyIdd },
            success: function (respons) {
                if (respons.message == 200) {
                    $("#nameWorker").val(respons.companyDb.employeeId)
                   


                    $('#delete').modal('show')
                }
            },

        });
    }
});


$(document).on("click", ".delete_Save_", function (e) {
    e.preventDefault();

    var ajax = ({
        url: "/PayrollHr/Worker/DeletePost",
        method: "POST",
        async: true,
        data: { id: companyIdd },
        success: function (respons) {
            if (respons.message == 200) {
                $(deletedEmployee).parents("tr").remove();
                window.location.reload(true);
            }
        }
    });



    $.ajax(ajax);
});



//Search Absent 




$(document).on("click", ".deleteAbsent", function (e) {
    companyIdd = $(this).data("id");
    deletedEmployee = $(this).parents();

    if (companyIdd) {
        $.ajax({
            url: "/PayrollHr/Absent/Delete",
            method: "Get",
            data: { id: companyIdd },
            success: function (respons) {
                if (respons.message == 200) {
                    $("#nameAbsent").val(respons.companyDb.workerId)



                    $('#delete').modal('show')
                }
            },

        });
    }
});


$(document).on("click", ".deleteSave_Absent", function (e) {
    e.preventDefault();

    var ajax = ({
        url: "/PayrollHr/Absent/DeletePost",
        method: "POST",
        async: true,
        data: { id: companyIdd },
        success: function (respons) {
            if (respons.message == 200) {
                $(deletedEmployee).parents("tr").remove();
                window.location.reload(true);
            }
        }
    });



    $.ajax(ajax);
});



//Search Vacation 




$(document).on("click", ".deleteVacation", function (e) {
    companyIdd = $(this).data("id");
    deletedEmployee = $(this).parents();

    if (companyIdd) {
        $.ajax({
            url: "/PayrollHr/Vacation/Delete",
            method: "Get",
            data: { id: companyIdd },
            success: function (respons) {
                if (respons.message == 200) {
                    $("#nameAbsent").val(respons.companyDb.workerId)



                    $('#delete').modal('show')
                }
            },

        });
    }
});


$(document).on("click", ".deleteSave_Vacation", function (e) {
    e.preventDefault();

    var ajax = ({
        url: "/PayrollHr/Vacation/DeletePost",
        method: "POST",
        async: true,
        data: { id: companyIdd },
        success: function (respons) {
            if (respons.message == 200) {
                $(deletedEmployee).parents("tr").remove();
                window.location.reload(true);
            }
        }
    });



    $.ajax(ajax);
});












//Search Xitam 




$(document).on("click", ".deleteXitam", function (e) {
    companyIdd = $(this).data("id");
    deletedEmployee = $(this).parents();

    if (companyIdd) {
        $.ajax({
            url: "/PayrollHr/Xitam/Delete",
            method: "Get",
            data: { id: companyIdd },
            success: function (respons) {
                if (respons.message == 200) {
                    $("#nameXitam").val(respons.companyDb.workerId)



                    $('#delete').modal('show')
                }
            },

        });
    }
});


$(document).on("click", ".deleteSave_Xitam", function (e) {
    e.preventDefault();

    var ajax = ({
        url: "/PayrollHr/Xitam/DeletePost",
        method: "POST",
        async: true,
        data: { id: companyIdd },
        success: function (respons) {
            if (respons.message == 200) {
                $(deletedEmployee).parents("tr").remove();
                window.location.reload(true);
            }
        }
    });



    $.ajax(ajax);
});