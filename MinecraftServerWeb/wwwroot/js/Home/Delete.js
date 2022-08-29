function DeletePost(postTitle, url) {
    var token = $('input[name="__RequestVerificationToken"]').val();
    Swal.fire({
        title: `Czy na pewno chcesz usunąć post o nazwie ${postTitle}?`,
        text: "Tej operacji nie będzie można cofnąć!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Potwierdź',
        cancelButtonText: 'Anuluj'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: "DELETE",
                data: {
                    __RequestVerificationToken: token
                },
                success: function() {
                    Swal.fire(
                        'Sukces',
                        `Post o nazwie: ${postTitle} został usunięty`,
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