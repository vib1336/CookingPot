// Show comment form
function showCommentBox() {
    $('#commentForm').show();
    $([document.documentElement, document.body]).animate({
        scrollTop: $("#commentForm").offset().top
    }, 2000);
}
// Post comment ajax
function postComment(recipeId, currentUserId) {
    var token = $("#commentForm input[name=__RequestVerificationToken]").val();
    var comment = $("#commentForm div.form-group textarea").val();
    var json = { recipeId: recipeId, currentUserId: currentUserId, comment: comment };

    $.ajax({
        url: "/Comments/Comment",
        method: "POST",
        data: JSON.stringify(json),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        headers: { 'X-CSRF-TOKEN': token },
        success: function (data) {
            let div = document.createElement('div');
            let span = document.createElement('span');
            span.innerHTML = `<i class="fas fa-calendar"></i> ${data.createdOn} | <i class="fas fa-user"></i> ${data.shortUsername}`;
            let br = document.createElement('br');
            let p = document.createElement('p');
            p.textContent = data.content;
            let hr = document.createElement('hr');
            div.appendChild(span);
            div.appendChild(br);
            div.appendChild(p);
            div.appendChild(hr);
            document.getElementById('commentsSection').appendChild(div);
            document.querySelector('#commentForm div.form-group textarea').value = '';
        }

    });
}

$(document).ready(function () {
    setTimeout(function () {
        $('#tempData').hide();
    }, 3000);
});

// Send vote ajax
function sendVote(recipeId, isUpVote) {
    var token = $("#votesForm input[name=__RequestVerificationToken]").val();
    var json = { recipeId: recipeId, isUpVote: isUpVote };
    $.ajax({
        url: "/api/votes",
        method: "POST",
        data: JSON.stringify(json),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        headers: { 'X-CSRF-TOKEN': token },
        success: function (data) {
            if (data['hasUserVoted']) {
                alert('You have already voted!');
            }

            document.getElementById('positiveVotes').innerHTML = data.positiveVotes;
            document.getElementById('negativeVotes').innerHTML = data.negativeVotes;
        }
    });
}

// Delete comment ajax
function deleteComment(divCommentId, commentId) {
    var token = $("#deleteCommentForm input[name=__RequestVerificationToken]").val();
    var json = { commentId: commentId };
    $.ajax({
        url: "/Comments/DeleteComment",
        method: "POST",
        data: JSON.stringify(json),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        headers: { 'X-CSRF-TOKEN': token },
        success: function (data) {
            $(`#${divCommentId}`).remove();
        }
    });
}
