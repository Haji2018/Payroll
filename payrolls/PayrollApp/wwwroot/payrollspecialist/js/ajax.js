//Delete Payment 


let companyIdd, deletedEmployee;

$(document).on("click", ".deletePayment", function (e) {
    companyIdd = $(this).data("id");
    deletedEmployee = $(this).parents();

    if (companyIdd) {
        $.ajax({
            url: "/PayrollSpecialist/Payment/Delete",
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


$(document).on("click", ".deleteSave_Payment", function (e) {
    e.preventDefault();

    var ajax = ({
        url: "/PayrollSpecialist/Payment/DeletePost",
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









//Delete Result


$(document).on("click", ".deleteSalaryResult", function (e) {
    companyIdd = $(this).data("id");
    deletedEmployee = $(this).parents();

    if (companyIdd) {
        $.ajax({
            url: "/PayrollSpecialist/Payment/DeleteSalary",
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


$(document).on("click", ".deleteSave_ResultSalary", function (e) {
    e.preventDefault();

    var ajax = ({
        url: "/PayrollSpecialist/Payment/DeletePostSalary",
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