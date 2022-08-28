function DeletePost(postTitle, url) {
    Swal.fire({
        title: `Czy na pewno chcesz usunąć post o nazwie ${postTitle}?`,
        text: "Tej operacji nie będzie można cofnąć!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success:
                    Swal.fire(
                        'Sukces',
                        `Post o nazwie: ${postTitle} został usunięty`,
                        'success'
                    )
            });
        }
    });
}