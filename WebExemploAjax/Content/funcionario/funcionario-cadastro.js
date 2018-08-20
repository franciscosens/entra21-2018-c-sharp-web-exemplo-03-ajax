$(function () {
    $("#salvar").on("click", function (e) {
        $.ajax({
            url: "/funcionario/cadastro",
            method: "POST",
            data: {
                nome: $("#nome").val(),
                idade: $("#idade").val(),
                salario: $("#salario").val()
            }
        });
    });
});