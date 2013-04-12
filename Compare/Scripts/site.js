
$(function () {
    $(".taginput").focusout(function () {

        var $textBox = $(this);
        $.post("/Home/ValidateUser", { tag: $textBox.val() }, function (data) {
            if (data == 'False') {
                $textBox.addClass("invalidtag");

            }
            else {
                $textBox.removeClass("invalidtag");
            }
        });
    });

    $("table#summaryScores").tablesorter();

    $("table#detailGames").tablesorter({
        headers: {
            0: {
                sorter: false
            }
        }
    });
});