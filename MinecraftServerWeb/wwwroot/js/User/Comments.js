function addComment(postId) {
    var token = $('input[name="__RequestVerificationToken"]').val();
    var content = $("#CommentForm_" + postId).val();
    $.ajax({
        type: "POST",
        url: '/Comments/AddComment/',
        data: {
            postId:postId,
            content: content,
            __RequestVerificationToken: token
        },
        success: function(data) {
            console.log(data);
            window.location.reload();
        }
    });
}

function DeleteComment(url) {
    var token = $('input[name="__RequestVerificationToken"]').val();
    Swal.fire({
        title: `Czy na pewno chcesz usunąć komentarz?`,
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
                success: function () {
                    Swal.fire(
                        '',
                        `Komentarz został usunięty!`,
                        'success'
                    ).then(
                        function () {
                            location.reload();
                        });
                }
            });
        }
    });
}