$(function () {
    $("#DatePicker").datepicker({
            format: "dd-mm-yyyy",
            startDate: "new Date()",
            autoclose: true,
            todayHighlight: true,
            language: 'pl'
        });
})