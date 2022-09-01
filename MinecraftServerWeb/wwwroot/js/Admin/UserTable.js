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
            { "data": "forumNickname", "width": "15%" },
            { "data": "serverNickname", "width": "15%" },
            { "data": "email", "width": "20%" },
            { "data": "rank", "width": "10%" },
            { "data": "dateCreated", "width": "15%" },
            {
                "data": "id", "width": "10%", "render": function(data) {
                    return `
                        <div class="row">
                            <a class="btn btn-danger" href="/Admin/LockAccount/${data}"> Blokada </a>
                            <a class="btn btn-warning mt-2" href="/Admin/MuteAccount/${data}"> Wyciszenie </a>
                            <a class="btn btn-info mt-2" href="/Admin/AccountInfo/${data}"> Informacje </a>
                        </div>`;
                }
            }
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