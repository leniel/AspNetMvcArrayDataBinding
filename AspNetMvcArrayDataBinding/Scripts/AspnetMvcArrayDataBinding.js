$(function () { // Equivalent to $(document).ready(...)

    // Check if buttons should be enabled/disabled on page loading
    enableDisableButtons();

    // Force first option selected
    //$("select").find('option:first').prop('selected', true);

    // Event fired whenever the user selects an option
    $("select").change(function () {

        enableDisableButtons();
    });

    function numberOfColorsSelected() {

        // Check each dropdown for a valid selected option, that is,
        // an option different from the first one: "-- Pick a Color --"
        return $('select option:selected[value!=""]').length;
    }

    function enableDisableButtons() {

        // Let's clear the result container used for AJAX requests
        $("#result").fadeOut('slow');

        // If at least 1 option was selected, enable buttons; otherwise,
        // disable them
        if (numberOfColorsSelected() > 0) {
            $("#submit-normal, #submit-ajax").prop('disabled', false);
        }
        else {
            $("#submit-normal, #submit-ajax").prop('disabled', true);
        }
    }

    // Setting the background-color of each select option
    // according to the color name
    $("select option").each(function () {
        // Color is the text of each option in the dropdown
        var color = $(this).text();

        // Setting the background-color = color and the font color = White
        $(this).css({ 'background-color': color, color: 'White' });

        // If color is too bright, let's change the font color to Black
        if (color == "Yellow" || color == "White" || color == "Pink") {
            $(this).css('color', 'Black');
        }
    });

    $("#submit-ajax").click(function () {

        var selectedColors = [];

        // For each select HTML element/dropdown,
        // push its selected value into selectedColors
        $('select option:selected').each(function () {
            selectedColors.push($(this).val());
        });

        $.ajax({
            type: "POST",
            url: "/Home/TestArrayPost",
            dataType: "html",
            traditional: true,
            data: { selectedColors: selectedColors },
            success: function (response) {

                $("#result").html(response).fadeIn();

                // Hiding the GO back button...
                $("#result").find("#go-back").hide();

            },
            error: function (xhr, textStatus, exceptionThrown) {
                $('#result').html(exceptionThrown);
            }
        });
    });

});
