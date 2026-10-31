// Small client-side helper: hide success/error alerts automatically after 5 seconds
document.addEventListener("DOMContentLoaded", function () {
    setTimeout(function () {
        document.querySelectorAll(".alert").forEach(function (el) {
            el.classList.remove("show");
            setTimeout(function () { el.remove(); }, 300);
        });
    }, 5000);
});
