$(document).ready(function () {
    $('#Categories').change(function () {
        let categoryId = $('#Categories').val();
        if ($('#Categories').attr('name') !== 'admin') {
            window.location.href = "/catalog/index/" + categoryId
        } else {
            window.location.href = "/Administrator/index/" + categoryId
        }
    });
});