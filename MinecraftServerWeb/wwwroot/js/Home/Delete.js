function DeletePost(postTitle, url) {
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