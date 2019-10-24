var numberTaken = 4;

var totalCount = + $("#bonusCount").val();
$(function ($) {

    $("#load_more_store_bonus").click(function () {
     

        $.ajax({

            url: "/PayrollDepartmentHead/StoreBonus/LoadMore?skip=" + numberTaken,
            type: "GET",
            success: function (res) {


                $(".table-body").append(res);
                numberTaken += 4;

                if (numberTaken >= totalCount) {

                    $("#load_more_store_bonus").remove();

                }
            }


        })
    });



});
$(function ($) {

    $("#load_more_worker_bonus").click(function () {


        $.ajax({

            url: "/PayrollDepartmentHead/WorkerBonus/LoadMore?skip=" + numberTaken,
            type: "GET",
            success: function (res) {


                $(".table-body").append(res);
                numberTaken += 4;

                if (numberTaken >= totalCount) {

                    $("#load_more_worker_bonus").remove();

                }
            }


        })
    });



});
$(function ($) {

    $("#load_more_worker_penalty").click(function () {


        $.ajax({

            url: "/PayrollDepartmentHead/WorkerPenalty/LoadMore?skip=" + numberTaken,
            type: "GET",
            success: function (res) {


                $(".table-body").append(res);
                numberTaken += 4;

                if (numberTaken >= totalCount) {

                    $("#load_more_worker_penalty").remove();

                }
            }


        })
    });



});