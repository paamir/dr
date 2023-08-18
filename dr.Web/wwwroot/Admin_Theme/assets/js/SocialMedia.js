$('#MainModal').on('shown.bs.modal', function () {
    var logoClassFa = document.getElementById("LogoClassFa").value;
    document.getElementById("LogoClassFa").addEventListener("keyup",
        function () {
            $("#Logo").removeClass(`fa-${logoClassFa}`);
            $("#Logo").addClass(`fa-${this.value}`);
            logoClassFa = this.value;
        });
});
    

//var logoClassFa = document.getElementById("LogoClassFa");
//if (COND) {
    
//}