function addComment(postId) {
    var token = $('input[name="__RequestVerificationToken"]').val();
    var content = $("#CommentForm_" + postId).val();
    $.ajax({
        type: "POST",
        url: 'Announcement/AddComment/',
        data: {
            announcementId:postId,
            content: content,
            __RequestVerificationToken: token
        },
        success: function(data) {
            console.log(data);
            window.location.reload();
        }
    });
}
