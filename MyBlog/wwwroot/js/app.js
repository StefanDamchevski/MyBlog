window.onscroll = function () { Sticky() };

var navbar = document.getElementById("navBar");

var sticky = navbar.offsetTop;

function Sticky() {
    if (window.pageYOffset >= sticky) {
        navbar.classList.add("sticky")
    } else {
        navbar.classList.remove("sticky");
    }
}