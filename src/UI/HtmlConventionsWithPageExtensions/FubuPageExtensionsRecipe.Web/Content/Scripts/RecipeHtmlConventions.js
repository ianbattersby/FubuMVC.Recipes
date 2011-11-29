$(function () {

    $('form').submit(function (event) {
        setSequentialIndicesForHiddenFields();
    });

    $('a.addItem').button();

    $('a.addItem').click(function (event) {
        event.preventDefault();

        var parentId = $(this).attr('rel');

        if (parentId.indexOf('_') == 0) {
            $('#' + parentId.substring(1)).dialog('open');
        } else {
            var input = $(this).siblings('input');
            var text = input.val();

            if (text != '') {
                $(this).siblings('ul').append('<li>' + text + '</li>');

                var name = input.attr('name');
                $(this).parent().append('<input type="hidden" name="' + name + '" value="' + text + '" />');
            } else {
                alert("You must enter a value for '" + parentId + "'");
            }
        }
    });
});

function setSequentialIndicesForHiddenFields() {
    var hiddenGroups = $('div.hasHiddenGroup');

    hiddenGroups.each(function () {
        var hiddenFields = $(this).children('input[type=hidden]');

        hiddenFields.each(function (index) {
            var name = $(this).attr('name') + '[' + index + ']';
            $(this).attr('name', name);
        });
    });

    $('*[name=Authors]').attr('name', ' ');
}