$(document).ready(function () {
    $("#UsersList").dataTable({
        "data": window.Users,
        "pagingType": "simple",
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
                                <a class="btn btn-outline-secondary" onclick="ManageUser('${data}','${row.forumNickname}')">
                                Zarządzaj Użytkownikiem 
                                </a>
                            </div>`;
                    } else {
                        return`
                            <div class="row">
                                <a class="btn btn-outline-success">
                                Obecnie Zalogowany 
                                </a>
                            </div>`;
                    }
                }
            }
        ],
        "language": {
            "lengthMenu": '<span class="text-body">Wyświetl  _MENU_  wyników na stronę </span>',
            "zeroRecords": '<span class="text-body">Nie znaleziono pasujących wyników</span>',
            "info": '<span class="text-body">Strona _PAGE_ z _PAGES_</span>',
            "infoEmpty": '<span class="text-body">Wyniki niedostępne</span>',
            "infoFiltered": '<span class="text-body">(przefiltrowano z _MAX_ pozycji)</span>',
            "loadingRecords": '<span class="text-body">Ładowanie...</span>',
            "search": '<span class="text-body"> Wyszukaj:</span>',
            "paginate": {
                "first": '<span class="text-body"> Pierwsza strona</span>',
                "last": '<span class="text-body"> Ostatnia strona</span>',
                "next": '<span class="text-body"> Następna strona</span>',
                "previous": '<span class="text-body"> Poprzednia strona</span>',
            },
            "aria": {
                "sortAscending": ':<span class="text-body"> aktywuj, żeby posortować kolumny rosnąco" </span>',
                "sortDescending": ': <span class="text-body"> aktywuj, żeby posortować kolumny malejąco </span>'
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
            <a id="InfoButton" class="btn btn-outline-info me-3" href="/Admin/AccountInfo/${id}"> Informacje </a>
            <a id="MuteButton" class="btn btn-outline-warning me-3" href="/Admin/MuteAccount/${id}"> Wyciszenie </a>
            <a id="BanButton" class="btn btn-outline-danger" href="/Admin/LockAccount/${id}"> Blokada </a>
        `,
    });
}