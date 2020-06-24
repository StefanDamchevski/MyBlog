function ValidateCommentField() {
    let comment = document.getElementById("comment").value;
    if (comment == null || comment == " ") {
        alert("Input field is required")
        return false;
    } else {
        return true;
    }
}

function AddLike(blogId) {
    axios.post('/BlogLike/AddLike', {
        Id: blogId
    })
        .then(function (response) {
            let btnRemoveDislike = document.getElementById("btnRemoveDislike");

            if (!btnRemoveDislike.classList.contains("displayNone")) {
                DecrementEngagementCount("blogDislikesCount");
                SwitchDisplay("btnAddDislike", "btnRemoveDislike");
            }

            IncrementEngagementCount("blogLikesCount");
            SwitchDisplay("btnRemoveLike", "btnAddLike");
        })
        .catch(function (error) {
            console.log(error);
        });
}

function RemoveLike(blogId) {
    axios.post('/BlogLike/RemoveLike', {
        Id: blogId
    })
        .then(function (response) {
            DecrementEngagementCount("blogLikesCount");
            SwitchDisplay("btnAddLike", "btnRemoveLike");
        })
        .catch(function (error) {
            console.log(error);
        });
}

function AddDislike(blogId) {
    axios.post('/BlogLike/AddDislike', {
        Id: blogId
    })
        .then(function (response) {
            let btnRemoveLike = document.getElementById("btnRemoveLike");

            if (!btnRemoveLike.classList.contains("displayNone")) {
                DecrementEngagementCount("blogLikesCount");
                SwitchDisplay("btnAddLike", "btnRemoveLike");
            }

            IncrementEngagementCount("blogDislikesCount");
            SwitchDisplay("btnRemoveDislike", "btnAddDislike");
        })
        .catch(function (error) {
            console.log(error);
        });
}

function RemoveDislike(blogId) {
    axios.post('/BlogLike/RemoveDislike', {
        Id: blogId
    })
        .then(function (response) {
            DecrementEngagementCount("blogDislikesCount");
            SwitchDisplay("btnAddDislike", "btnRemoveDislike");
        })
        .catch(function (error) {
            console.log(error);
        });
}

function IncrementEngagementCount(elementId) {
    let likeCounter = document.getElementById(elementId);
    likeCounter.innerHTML = parseInt(likeCounter.innerHTML) + 1;
}

function DecrementEngagementCount(elementId) {
    let likeCounter = document.getElementById(elementId);
    likeCounter.innerHTML = parseInt(likeCounter.innerHTML) - 1;
}

function SwitchDisplay(showElement, hideElemet) {
    let showEl = document.getElementById(showElement);
    let hideEl = document.getElementById(hideElemet);

    showEl.classList.remove("displayNone");
    hideEl.classList.add("displayNone");
}