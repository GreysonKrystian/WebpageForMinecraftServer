$(function() {
    $('#TimePicker').timepicker({
        timeFormat: 'HH:mm',
        interval: 30,
        minTime: '00:00',
        maxTime: '23:59',
        defaultTime: '00',
        startTime: '00:00',
        dynamic: false,
        dropdown: true,
        scrollbar: true
    });
})