$(function () {

    $.get("/mapa/dropdownlistsurdo", function (dados) {
        console.log(dados);
        var options = {
            data: dados,
            list: {
                match: {
                    enabled: true
                }
            },
            theme: "square"
        };

        $("#surdoNome").easyAutocomplete(options);
    });
});
$("#btnIncluirMapaSurdo").click(function () {
    //if ($("#SelectIdSurdo option:selected").val() == "") {
    //    alert('Selecione um surdo!');
    //}
    console.log($("#surdoNome").val());
    if ($("#surdoNome").val() == "") {
        alert('Selecione um surdo!');
    }
    else {
        console.log()
        var idmapa = $("#IdMapa").val();
        console.log(idmapa);
        var idselectsurdo = $("#surdoNome").val();
        console.log(idselectsurdo);
        $.post("/mapa/IncluirSurdoMapaJson", { IdMapa: idmapa, SelectIdSurdo: idselectsurdo }, function (data) {
            $.get("/mapa/_listasurdomapa", { id: idmapa }, function (data) {
                $("#dvListaSurdoMapa").html(data);
            });
            $.get("/mapa/dropdownlistsurdo", function (dados) {
                console.log(dados);
                var options = {
                    data: dados,
                    list: {
                        match: {
                            enabled: true
                        }
                    },
                    theme: "square"
                };

                $("#surdoNome").easyAutocomplete(options);
            });
            $("#surdoNome").val("");
        });
    }
});
$(".btnExcluirSurdoMapa").click(function () {
    var idmapa = $("#IdMapa").val();
    var btnidsurdo = $(".btnExcluirSurdoMapa");
    var idsurdo = btnidsurdo.data("id");
    

    $.post("/mapa/ExcluirSurdoMapa", { idsurdo: idsurdo }, function (data) {
        $.get("/mapa/_listasurdomapa", { id: idmapa }, function (data) {
            $("#dvListaSurdoMapa").html(data);
        });
    });
    
});