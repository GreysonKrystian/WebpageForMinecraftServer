$(document).ready(function () {
    $("#UsersList").dataTable({
        "ajax": {
            "url": "/Admin/GetAllUsers/",
            "type": "GET"
        },
        "columnDefs": [
            {
                targets: 4,
                render: $.fn.dataTable.render.moment('YYYY-MM-DDTHH:mm:ss.SSSSSSS', 'hh:mm:ss DD/MM/YY')
            }],
        "columns": [
            { "data": "forumNickname", "width": "20%" },
            { "data": "serverNickname", "width": "20%" },
            { "data": "email", "width": "20%" },
            { "data": "rank", "width": "20%" },
            { "data": "dateCreated", "width": "20%" }
        ],
        "language": {
            "lengthMenu": "Wyświetl _MENU_ wyników na stronę",
            "zeroRecords": "Nie znaleziono pasujących wyników",
            "info": "Strona _PAGE_ z _PAGES_",
            "infoEmpty": "Wyniki niedostępne",
            "infoFiltered": "(przefiltrowano z _MAX_ wszystkich wyników)",
            "loadingRecords": "Ładowanie...",
            "search": "Wyszukaj:",
            "paginate": {
                "first": "Pierwsza",
                "last": "Ostatnia",
                "next": "Następna",
                "previous": "Poprzednia"
            },
            "aria": {
                "sortAscending": ": aktywuj, żeby posortować kolumny rosnąco",
                "sortDescending": ": aktywuj, żeby posortować kolumny malejąco"
            }
            
        }
    });
});