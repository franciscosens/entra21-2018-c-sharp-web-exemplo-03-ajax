$(function() {
    $.ajax({
        url: "/funcionario/ObterTodosPorJSON",
        method: "get",
        success: function(resultado) {
            var registros = JSON.parse(resultado);
            for (var i = 0; i < registros.length; i++) {
                var nome = registros[i].Nome;
                var idade = registros[i].Idade;
                var salario = registros[i].Salario;
                $registro = "<tr>";
                $registro += "<td>" + nome + "</td>";
                $registro += "<td>" + idade + "</td>";
                $registro += "<td>" + salario + "</td>";
                $registro += "<td></td>";
                $registro += "</tr>";
                $("table").append($registro);


            }
        }
    });


    $("#modal-novo").on("click", function () {
        if ($("#modal-francisco").length == 0) {
            $.ajax({
                url: "/funcionario/cadastromodal",
                method: "get",
                success: function(data) {
                    $("body").append(data);
                    $("#modal-francisco").modal('show');
                }
            });
        } else {
            $("#modal-francisco").modal('show');
            limparCampos();
        }

    });

    $("body").on("click", "#modal-francisco-salvar", function () {
        $.ajax({
            url: '/funcionario/cadastro',
            method: 'post',
            data: {
                nome: $("#nome").val(),
                idade: $("#idade").val(),
                salario: $("#salario").val()
            },
            success: function (data) {
                var resultado = JSON.parse(data);
                limparCampos();
                $("#modal-francisco").modal('hide');
                adicionarLinhaTabela($("#nome").val(), $("#idade").val(), $("#salario").val(), resultado.id);
            }
        });
    });

    function adicionarLinhaTabela(nome, idade, salario, id) {
        $registro = "<tr>";
        $registro += "<td>" + nome + "</td>";
        $registro += "<td>" + idade + "</td>";
        $registro += "<td>" + salario + "</td>";
        $registro += "<td><a href=\"/funcionario/Editar?id=" + id + "\" >Editar</a></td>";
        $registro += "</tr>";
        $("table").append($registro);
    }

    function limparCampos() {
        $("#nome").val("");
        $("#idade").val("");
        $("#salario").val("");
    }
});