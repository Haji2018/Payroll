var numberTaken = 4;

var totalCount = + $("#holdingCount").val();
$(function ($) {

    $("#load_more_employee").click(function () {


        $.ajax({

            url: "/PayrollHr/Employee/LoadMore?skip=" + numberTaken,
            type: "GET",
            success: function (res) {


                $(".table-body").append(res);
                numberTaken += 4;

                if (numberTaken >= totalCount) {

                    $("#load_more_employee").remove();

                }
            }


        })
    });



});

$(function ($) {

    $("#load_more_past").click(function () {
      

        $.ajax({

            url: "/PayrollHr/PastEmployment/LoadMore?skip=" + numberTaken,
            type: "GET",
            success: function (res) {


                $(".table-body").append(res);
                numberTaken += 4;

                if (numberTaken >= totalCount) {

                    $("#load_more_past").remove();
                   

                }
            }


        })
    });



});

$(function ($) {

    $("#load_more_worker").click(function () {

      
        $.ajax({

            url: "/PayrollHr/Worker/LoadMore?skip=" + numberTaken,
            type: "GET",
            success: function (res) {


                $(".table-body").append(res);
                numberTaken += 4;

                if (numberTaken >= totalCount) {

                    $("#load_more_worker").remove();


                }
            }


        })
    });



});


$(function ($) {

    $("#load_more_absent").click(function () {


        $.ajax({

            url: "/PayrollHr/Absent/LoadMore?skip=" + numberTaken,
            type: "GET",
            success: function (res) {


                $(".table-body").append(res);
                numberTaken += 4;

                if (numberTaken >= totalCount) {

                    $("#load_more_absent").remove();


                }
            }


        })
    });



});

$(function ($) {

    $("#load_more_vacation").click(function () {


        $.ajax({

            url: "/PayrollHr/Vacation/LoadMore?skip=" + numberTaken,
            type: "GET",
            success: function (res) {


                $(".table-body").append(res);
                numberTaken += 4;

                if (numberTaken >= totalCount) {

                    $("#load_more_vacation").remove();


                }
            }


        })
    });



});

$(function ($) {

    $("#load_more_xitam").click(function () {


        $.ajax({

            url: "/PayrollHr/Xitam/LoadMore?skip=" + numberTaken,
            type: "GET",
            success: function (res) {


                $(".table-body").append(res);
                numberTaken += 4;

                if (numberTaken >= totalCount) {

                    $("#load_more_xitam").remove();


                }
            }


        })
    });



});