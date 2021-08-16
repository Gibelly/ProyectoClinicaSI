﻿function patients_search() {

    const search = document.getElementById("txt-search").value;
    const currentURL = window.location.href.substring(
        window.location.href.lastIndexOf('/') + 1).split("?")[0];

    window.location = `${currentURL}?search=${search}`;

}

function usuarioMalo() {

    alert("Usuario no registrado");
}

const patients_input_search = document.getElementsById("txt-search");

patients_input_search.addEventListener("keyup", function (event) {
    if (event.keyCode === 13) {
        event.preventDefault();
        patients_search();

    }
});