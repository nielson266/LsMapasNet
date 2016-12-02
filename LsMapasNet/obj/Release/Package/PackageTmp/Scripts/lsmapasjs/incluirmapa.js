$(function () {

    $.get("/lsmapas/mapa/dropdownlistsurdo", function (dados) {
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
        var idmapa = $("#IdMapa").val();
        var idselectsurdo = $("#surdoNome").val();
        $.post("/lsmapas/mapa/IncluirSurdoMapaJson", { IdMapa: idmapa, SelectIdSurdo: idselectsurdo }, function (data) {
            $.get("/lsmapas//mapa/_listasurdomapa", { id: idmapa }, function (data) {
                $("#dvListaSurdoMapa").html(data);
            });
            $.get("/lsmapas/mapa/dropdownlistsurdo", function (dados) {
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
//$(".btnExcluirSurdoMapa a").on("click", function (event) {
//    alert('Click on')
//    console.log($(this).text() + ' on' );
//});

//$(".btnExcluirSurdoMapa a").click(function () {
//    var idmapa = $("#IdMapa").val();
//    var btnidsurdo = $(".btnExcluirSurdoMapa");
//    var idsurdo = btnidsurdo.data("id");
    
//    console.log("Click");

//    $.post("/mapa/ExcluirSurdoMapa", { idsurdo: idsurdo }, function (data) {
//        $.get("/mapa/_listasurdomapa", { id: idmapa }, function (data) {
//            $("#dvListaSurdoMapa").html(data);
//        });
//    });
    
//});