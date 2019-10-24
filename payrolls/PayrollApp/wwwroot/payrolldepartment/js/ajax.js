





// StoreBonus



let companyIdd, deletedEmployee;

$(document).on("click", ".deleteStoreBonus", function (e) {
    
    companyIdd = $(this).data("id");
    deletedEmployee = $(this).parents();
    if (companyIdd) {
        $.ajax({
            url: "/PayrollDepartmentHead/StoreBonus/Delete",
            method: "Get",
            data: { id: companyIdd },
            success: function (respons) {
                if (respons.message == 200) {
                    $("#nameStoreBonus").val(respons.companyDb.amount)


                    $('#delete').modal('show')
                }
            },

        });
    }
});
$(document).on("click", ".deleteSave_Store_Bonus", function (e) {
    e.preventDefault();

    var ajax = ({
        url: "/PayrollDepartmentHead/StoreBonus/DeletePost",
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



// WorkerBonus




$(document).on("click", ".deleteWorkerBonus", function (e) {

    companyIdd = $(this).data("id");
    deletedEmployee = $(this).parents();
    if (companyIdd) {
        $.ajax({
            url: "/PayrollDepartmentHead/WorkerBonus/Delete",
            method: "Get",
            data: { id: companyIdd },
            success: function (respons) {
                if (respons.message == 200) {
                    $("#nameWorkerBonus").val(respons.companyDb.amount)


                    $('#delete').modal('show')
                }
            },

        });
    }
});
$(document).on("click", ".deleteSave_Worker_Bonus", function (e) {
    e.preventDefault();

    var ajax = ({
        url: "/PayrollDepartmentHead/WorkerBonus/DeletePost",
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



// WorkerPenalty






$(document).on("click", ".deleteWorkerPenalty", function (e) {

    companyIdd = $(this).data("id");
    deletedEmployee = $(this).parents();
    if (companyIdd) {
        $.ajax({
            url: "/PayrollDepartmentHead/WorkerPenalty/Delete",
            method: "Get",
            data: { id: companyIdd },
            success: function (respons) {
                if (respons.message == 200) {
                    $("#nameWorkerPenalty").val(respons.companyDb.amount)


                    $('#delete').modal('show')
                }
            },

        });
    }
});
$(document).on("click", ".deleteSave_Worker_Penalty", function (e) {
    e.preventDefault();

    var ajax = ({
        url: "/PayrollDepartmentHead/WorkerPenalty/DeletePost",
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