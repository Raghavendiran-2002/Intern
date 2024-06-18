document.getElementById('updateCommentForm').addEventListener('submit', function(event) {
    event.preventDefault();

    const commentId = document.getElementById('commentId').value;
    const commentBody = document.getElementById('commentBody').value;
    const responseDiv = document.getElementById('response');

    fetch(`https://dummyjson.com/comments/${commentId}`, {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ body: commentBody })
    })
    .then(res => res.json())
    .then(data => {
        responseDiv.className = 'success';
        responseDiv.textContent = 'Comment updated successfully!';
        responseDiv.style.display = 'block';
        console.log(data);
    })
    .catch(error => {
        responseDiv.className = 'error';
        responseDiv.textContent = 'Error updating comment!';
        responseDiv.style.display = 'block';
        console.error('Error:', error);
    });
});
