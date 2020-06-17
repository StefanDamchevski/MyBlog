function ValidateCommentField() {
    let comment = document.getElementById("comment").value;
    if (comment == null || comment == " ") {
        alert("Input field is required")
        return false;
    } else {
        return true;
    }
}