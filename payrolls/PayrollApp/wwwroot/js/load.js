var numberTaken = 4;

var totalCount = + $("#holdingCount").val();
 $(function ($) {

    $("#load_more").click(function () {

     
        $.ajax({

            url: "/PayrollAdmin/Holding/LoadMore?skip=" + numberTaken,
            type: "GET",
            success: function (res) {


                $(".table-body").append(res);
                numberTaken += 4;

                if (numberTaken >= totalCount) {

                    $("#load_more").remove();

                }
            }


        })
    });



 });
$(function ($) {

    $("#load_more_department").click(function () {

       
        $.ajax({

            url: "/PayrollAdmin/Department/LoadMore?skip=" + numberTaken,
            type: "GET",
            success: function (res) {


                $(".table-body").append(res);
                numberTaken += 4;

                if (numberTaken >= totalCount) {

                    $("#load_more_department").remove();

                }
            }


        })
    });



});
$(function ($) {

    $("#load_more_store").click(function () {

      
        $.ajax({

            url: "/PayrollAdmin/Store/LoadMore?skip=" + numberTaken,
            type: "GET",
            success: function (res) {


                $(".table-body").append(res);
                numberTaken += 4;

                if (numberTaken >= totalCount) {

                    $("#load_more_store").remove();

                }
            }


        })
    });



});
$(function ($) {

    $("#load_more_position").click(function () {

       
        $.ajax({

            url: "/PayrollAdmin/Position/LoadMore?skip=" + numberTaken,
            type: "GET",
            success: function (res) {


                $(".table-body").append(res);
                numberTaken += 4;

                if (numberTaken >= totalCount) {

                    $("#load_more_position").remove();

                }
            }


        })
    });



});
$(function ($) {

    $("#load_more_company").click(function () {


        $.ajax({

            url: "/PayrollAdmin/Company/LoadMore?skip=" + numberTaken,
            type: "GET",
            success: function (res) {


                $(".table-body").append(res);
                numberTaken += 4;

                if (numberTaken >= totalCount) {

                    $("#load_more_company").remove();

                }
            }


        })
    });



});
$(function ($) {

    $("#load_more_past_position").click(function () {


        $.ajax({

            url: "/PayrollAdmin/PastPosition/LoadMore?skip=" + numberTaken,
            type: "GET",
            success: function (res) {


                $(".table-body").append(res);
                numberTaken += 4;

                if (numberTaken >= totalCount) {

                    $("#load_more_past_position").remove();

                }
            }


        })
    });



});