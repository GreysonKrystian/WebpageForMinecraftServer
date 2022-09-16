function UnbanConfirmation(nickname, url) {
    var token = $('input[name="__RequestVerificationToken"]').val();
    Swal.fire({
        title: `Czy chcesz usunąć blokadę użytkownika ${nickname}?`,
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Cofnij blokadę',
        cancelButtonText: 'Anuluj'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: "POST",
                data: {
                    __RequestVerificationToken: token
                },
                success: function() {
                    Swal.fire(
                        'Sukces',
                        `Użytkownik ${nickname} został odblokowany`,
                        'success'
                    ).then(
                        function() {
                            location.reload();
                        });
                }
            });
        }
    });
}