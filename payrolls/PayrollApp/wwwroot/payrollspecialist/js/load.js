var numberTaken = 4;

var totalCount = + $("#holdingCount").val();
$(function ($) {

    $("#load_more_payment").click(function () {


        $.ajax({

            url: "/PayrollSpecialist/Payment/LoadMore?skip=" + numberTaken,
            type: "GET",
            success: function (res) {


                $(".table-body").append(res);
                numberTaken += 4;

                if (numberTaken >= totalCount) {

                    $("#load_more_payment").remove();

                }
            }


        })
    });



});

$(function ($) {

    $("#load_more_result_salary").click(function () {


        $.ajax({

            url: "/PayrollSpecialist/Payment/LoadMoreResultSalary?skip=" + numberTaken,
            type: "GET",
            success: function (res) {


                $(".table-body").append(res);
                numberTaken += 4;

                if (numberTaken >= totalCount) {

                    $("#load_more_result_salary").remove();

                }
            }


        })
    });



});