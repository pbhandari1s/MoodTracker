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

$(document).on('submit', 'form', function (e) {
    var isPageValid = true;
    var buttons = $(this).find('[type="submit"]');
    var initialText = "";
    var initialInnerText = "";
    if (buttons.length > 0) {
        initialText = buttons[0].value;
        initialInnerText = buttons[0].innerText;
    }

    if ($(this).valid() && isPageValid) {
        if (!buttons.hasClass("no-loading")) {
            if (buttons.hasClass("btn-disabled")) {
                e.preventDefault();
            }
            else {
                buttons.addClass("btn-disabled");
            }

            buttons.each(function (btn) {
                if (!buttons.hasClass("btn-no-change")) {
                    $(buttons[btn]).prop('disabled', true);

                    $(buttons[btn]).val("Please Wait..");
                }
                else {
                    $(buttons[btn]).text("Please Wait..");
                }
            });
        }
    } else {
        buttons.each(function (btn) {
            if (!buttons.hasClass("btn-no-change")) {
                $(buttons[btn]).prop('disabled', false);

                $(buttons[btn]).val(initialText);
            }
            else {
                $(buttons[btn]).text(initialInnerText);
            }
        });
        if (isPageValid == true) {
            alert("Please look for the required field(s) to continue.")
        }
    }
});