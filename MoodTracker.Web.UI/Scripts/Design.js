$(document).ready(function () {
    if($("form").hasClass("public-form"))
    {
        $("body").addClass("public-form");
    }
    else
    {
        $("body").removeClass("public-form");
    }
});