$(document).ready(function () {
    $("#UsersList").dataTable({
        "data": window.Users,
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
                "data": "id", "width": "10%", "render": function (data, type, row, meta) {
                    if (window.CurrentUserId !== data) {
                        return `
                            <div class="row">
                                <a class="btn btn-secondary" onclick="ManageUser('${data}','${row.forumNickname}')">
                                Zarządzaj Użytkownikiem 
                                </a>
                            </div>`;
                    } else {
                        return`
                            <div class="row">
                                <a class="btn btn-success">
                                Obecnie Zalogowany 
                                </a>
                            </div>`;
                    }
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

function ManageUser(id, name) {
    window.Swal.fire({
        title: "Wybierz operację dla użytkownika: " + name,
        icon: 'question',
        showCloseButton: true,
        showConfirmButton: false,
        html: ` 
            <a id="InfoButton" class="btn btn-info me-3" href="/Admin/LockAccount/${id}"> Informacje </a>
            <a id="InfoButton" class="btn btn-warning me-3" href="/Admin/MuteAccount/${id}"> Wyciszenie </a>
            <a id="InfoButton" class="btn btn-danger" href="/Admin/AccountInfo/${id}"> Blokada </a>
        `,
    });
}