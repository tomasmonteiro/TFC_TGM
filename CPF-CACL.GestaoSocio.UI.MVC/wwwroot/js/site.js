
$(document).ready(function () {
    $('#myDataTable').DataTable({
        "language": {
            "url": "/js/pt-PT.json" 
        }

    });

    table.buttons().container()
        .appendTo('#myDataTable_wrapper .col-md-6:eq(0)');
});

//----------Círculo de carregamento (Spinner)------//
function iniciarProcesso() {
    $('#loading-overlay').show();
    setTimeout(function () {
        $('#loading-overlay').hide();
    }, 2000);
}
//-------Notificar ------------------
function Notificar(icone, cabecalho, resultado ) {
    //window.location = "/Bairro/Index";

    $('#loading-overlay').show();
    setTimeout(function () {
        $('#loading-overlay').hide();
        Notificacao("" + icone, "" + cabecalho, "" + resultado);
    }, 4000);
}
//-------SweetAlert2-----------------
function Notificacao(icone, titulo, mensagem) {
    Swal.fire({
        icon: icone,
        title: titulo,
        text: mensagem,
        showConfirmButton: false,
        iconSize: "10px",
        timer: 2500
    });
}

/*-------Bairro-----------*/

//-------Adicionar----
function AdicionarBairro() {
    if ($("#Nome").val() == "") {
        Notificar("error", "Erro", "O nome é obrigatório!");
    }
    else {
        $.ajax({
            type: "POST",
            url: "/Bairro/Create",
            data: {
                nome: $("#Nome").val(),
                municipioId: $("#municipioId").val(),
                dataCriacao: $("#dataCriacao").val()
            },
            success: function (result) {
                if (result.substring(0, 1) == "x") {
                    Notificar("error", "Erro!", result);
                    return false;
                }
                Notificar("success", "Sucesso!", result);
                $("#Nome").val("");
            },
            error: function (result) {
                Notificar("error", "Erro!", result);

            } 
        });
    }
    
}
//---------Editar-------
function EditarBairro() {
    if ($("#Nome").val() == "") {
        Notificar("error", "Erro", "O Nome do Bairro deve ser preenchido.");
        return;
    }
    $.ajax({
        type: "POST",
        url: "/Bairro/Edit",
        data: {
            bairroId: $("#bairroId").val(),
            Nome: $("#Nome").val(),
            dataAtualizacao: $("#dataAtualizacao").val()
        },
        success: function (result) {
            if (result.substring(0, 1) == "x") {
                Notificar("error", "Erro!", result);
                return false;
            }
            Notificar("success", "Sucesso!", result);
        },
        error: function (result) {
            Notificar("error", "Erro!", result);

        } 
    });
}


/*---------Municipio-------------*/

//---------Adicionar----
function AdicionarMunicipio() {
    if ($("#Nome").val() == "") {
        $.notify("O nome é obrigatório!", "error");
    }
    else {
        $.ajax({
            type: "POST",
            url: "/Municipio/Create",
            data: {
                nome: $("#Nome").val()
            },
            success: function (result) {
                if (result.substring(0, 1) == "x") {
                    Notificar("error", "Erro!", result);
                    return false;
                }
                Notificar("success", "Sucesso!", result);
                $("#Nome").val("");
            },
            error: function (result) {
                Notificar("error", "Erro!", result);

            }
        });
    }

}

/*-----------Tipo de Pagamento -----------------*/

//----------Adicionar----
function AdicionarTipoPagamento() {
    if ($("#Nome").val() == "") {
        Notificar("error", "Erro!", "O nome é obrigatório!");
    }
    else {
        $.ajax({
            type: "POST",
            url: "/TipoPagamento/Create",
            data: {
                nome: $("#Nome").val(),
                dataCriacao: $("#dataCriacao").val(),
                status: $("#status").val()
            },
            success: function (result) {
                if (result.substring(0, 1) == "x") {
                    Notificar("error", "Erro!", result);
                    return false;
                }
                Notificar("success", "Sucesso!", result);
                $("#Nome").val("");
                //window.location = "/TipoPagamento/Index/";
            },
            error: function (result) {
                Notificar("error", "Erro!", result);

            }
        });
    }

}





//Script para abrir a Modall

$(function () {
    var PlaceHolderElement = $('#PlaceHolderHere');
    $('button[data-toggle="ajax-modal"]').click(function (event) {

        var url = $(this).data('url');
        $.get(url).done(function (data) {
            PlaceHolderElement.html(data);
            PlaceHolderElement.find('.modal').modal('show');
        })
    })

});

//Preencher o Select de Bairros com base no Município selecionado
$(document).on('change', '#municipio', function carregarBairros() {
    var municipioId = document.getElementById("municipio").value;

    //Usar AJAX para chamar o método no controlador 
    $.ajax({
        url: '/Socio/GetBairrosByMunicipio',
        type: 'GET',
        data: { municipioId: municipioId },
        success: function (data) {
            //Limpar o dropDown atual
            $('#bairro').empty();

            //Preencher o dropDown
            $.each(data, function (index, bairro) {
                $('#bairro').append($('<option>', {
                    value: bairro.id,
                    text: bairro.nome
                }));
            });
        },
        error: function (error) {
               console.log(error);
        }
    });
});




//Usando JsGrid para Tabelas

$(function () {
    $("#jsGrid1").jsGrid({
        height: "100%",
        width: "100%",

        sorting: true,
        paging: true,

        data: db.clients,

        fields: [
            { name: "Name", type: "text", width: 150 },
            { name: "Age", type: "number", width: 50 },
            { name: "Address", type: "text", width: 200 },
            { name: "Country", type: "select", items: db.countries, valueField: "Id", textField: "Name" },
            { name: "Married", type: "checkbox", title: "Is Married" }
        ]
    });
});



