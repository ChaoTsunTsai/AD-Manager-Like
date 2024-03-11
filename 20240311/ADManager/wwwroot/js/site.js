// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Navbar content show and hide.
function showContent(id) {
    // 隱藏所有內容
    var contents = document.getElementsByClassName("content");
    for (var i = 0; i < contents.length; i++) {
        contents[i].classList.remove("active");
    }

    // 顯示指定ID的內容
    var content = document.getElementById(id);
    if (content) {
        content.classList.add("active");
    }
}

// Sidebar content show and hide.
function showSidebarContent(id) {
    // 隱藏所有內容
    var contents = document.getElementsByClassName("sidebar-content");
    for (var i = 0; i < contents.length; i++) {
        contents[i].classList.remove("sidebar-active");
    }

    // 顯示指定ID的內容
    var content = document.getElementById(id);
    if (content) {
        content.classList.add("sidebar-active");
    }
}

// Change sidebar <li> active appearence
function changeSidebarLi(id) {
    // 隱藏所有內容
    var contents = document.getElementsByClassName("sidebar-li");
    for (var i = 0; i < contents.length; i++) {
        contents[i].classList.remove("sidebar-li-active");
    }

    // 顯示指定ID的內容
    var content = document.getElementById(id);
    if (content) {
        content.classList.add("sidebar-li-active");
    }
}

// Change navbar <li> active appearence
function changeNavbarLi(id) {
    // 隱藏所有內容
    var contents = document.getElementsByClassName("navbar-li");
    for (var i = 0; i < contents.length; i++) {
        contents[i].classList.remove("navbar-li-active");
    }

    // 顯示指定ID的內容
    var content = document.getElementById(id);
    if (content) {
        content.classList.add("navbar-li-active");
    }
}

// Create user navbar active appearence
function showCreateUserNavbarA(id) {
    // 隱藏所有內容
    var contents = document.getElementsByClassName("create-user-nav-item");
    for (var i = 0; i < contents.length; i++) {
        contents[i].classList.remove("active");
    }

    // 顯示指定ID的內容
    var content = document.getElementById(id);
    if (content) {
        content.classList.add("active");
    }
}

// Create user navbar content show and hide
function showCreateUserContent(id) {
    // 隱藏所有內容
    var contents = document.getElementsByClassName("create-user-content");
    for (var i = 0; i < contents.length; i++) {
        contents[i].classList.remove("active");
    }

    // 顯示指定ID的內容
    var content = document.getElementById(id);
    if (content) {
        content.classList.add("active");
    }
}