

$(document).ready(function () {
    $('#myDataTable').DataTable({
        "language": {
            "url": "/js/pt-PT.json"
        }
    });
    table.buttons().container()
        .appendTo('#myDataTable_erapper .col-md-6:eq(0)');
});


//------Script do btnTopo para regressar no topo da página
document.addEventListener("DOMContentLoaded", function () {
    var irAoTopoBtn = document.getElementById("irAoTopoBtn");

    window.onscroll = function () {
        scrollFunction();
    };

    function scrollFunction() {
        var meioDaPagina = window.innerHeight / 2;
        if (document.body.scrollTop > meioDaPagina || document.documentElement.scrollTop > meioDaPagina) {
            irAoTopoBtn.style.display = "block";
        }
        else {
            irAoTopoBtn.style.display = "none";
        }
    }
    irAoTopoBtn.onclick = function () {
        document.body.scrollTop = 0;
        document.documentElement.scrollTop = 0;
    };
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
    $('#loading-overlay').show();    
    setTimeout(function () {
        $('#loading-overlay').hide();        
        Notificacao("" + icone, "" + cabecalho, "" + resultado);
    }, 2500);
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
function NotificarErro(icone, titulo, mensagem) {
    Swal.fire({
        icon: icone,
        title: titulo,
        text: mensagem,
        showConfirmButton: false,
        iconSize: "10px",
        timer: 2500
    });
}



/*---------------------------------------------*/
/*-----------------SOCIO----------------------*/

/*---Notificação com botão---*/
const swalSocio1 = Swal.mixin({
    customClass: {
        confirmButton: "btn btn-success sweetAlertButtonMargin",
        denyButton: "btn btn-primary"
    },
    buttonsStyling: false
});



function AdicionarSocio() {

    var Nome = $("#Nome").val();
    var BI = $("#BI").val();
    var Genero = $("#Genero").val();
    var DataNascimento = $("#DataNascimento").val();
    var fotoInput = document.getElementById('Foto');
    var fotoArquivo = fotoInput.files[0];
    var EstadoCivil = $("#EstadoCivil").val();
    var Habilitacoes = $("#Habilitacoes").val();
    var Nacionalidade = $("#Nacionalidade").val();
    var Profissao = $("#Profissao").val();
    var NomeDoPai = $("#NomeDoPai").val();
    var NomeDaMae = $("#NomeDaMae").val();
    var Endereco = $("#Endereco").val();
    var Telefone = $("#Telefone").val();
    var Email = $("#Email").val();
    var Funcao = $("#Funcao").val();
    var Departamento = $("#Departamento").val();
    var OrganismoId = $("#organismo").val();
    var LocalDeTrabalho = $("#LocalDeTrabalho").val();
    var EstadoSocio = $("#EstadoDoSocio").val();
    var CategoriaSocioId = $("#Categoria").val();
    var BairroId = $("#bairro").val();
    var DataCraicao = $("#DataCriacao").val();
    var Status = $("#Status").val();

    var formData = new FormData();
    formData.append('Nome', Nome);
    formData.append('BI', BI);
    formData.append('Genero', Genero);
    formData.append('DataNascimento', DataNascimento);
    formData.append('Foto', fotoArquivo);
    formData.append('EstadoCivil', EstadoCivil);
    formData.append('Habilitacoes', Habilitacoes);
    formData.append('Nacionalidade', Nacionalidade);
    formData.append('Profissao', Profissao);
    formData.append('NomeDoPai', NomeDoPai);
    formData.append('NomeDaMae', NomeDaMae);
    formData.append('Endereco', Endereco);
    formData.append('Telefone', Telefone);
    formData.append('Email', Email);
    formData.append('Funcao', Funcao);
    formData.append('Departamento', Departamento);
    formData.append('OrganismoId', OrganismoId);
    formData.append('LocalDeTrabalho', LocalDeTrabalho);
    formData.append('EstadoSocio', EstadoSocio);
    formData.append('CategoriaSocioId', CategoriaSocioId);
    formData.append('BairroId', BairroId);
    formData.append('DataCriacao', DataCraicao);
    formData.append('Status', Status);

     
    if (!validarFormSocio()) {
        return;
    }

    else {
        $.ajax({
            type: "POST",
            url: "/Socio/Create",
            dataType: "json",
            data: formData,
            processData: false,
            contentType: false,
            success: function (data) {
                $('#loading-overlay').show();
                setTimeout(function () {
                    $('#loading-overlay').hide();
                    Swal.fire({
                        icon: "success",
                        title: "Sucesso!",
                        text: data.mensagem,
                        showConfirmButton: false,
                        allowOutsideClick: false,
                        iconSize: "10px",
                        timer: 2500
                    }).then((result) => {
                        swalSocio1.fire({
                            title: "",
                            text: "Pretende cadastrar o agregado do Sócio que acabou de ragistar?",
                            icon: "question",
                            allowOutsideClick: false,
                            showDenyButton: true,
                            confirmButtonText: "Sim, cadatrar",
                            denyButtonText: "Concluir",

                            //reverseButtons: true
                        }).then((result => {
                            if (result.isConfirmed) {

                                $('#adicionarAgregado').modal('show');
                            }
                            else if (result.isDenied) {
                                window.location = "/Socio/Index";
                                //window.location = "/Socio/Details/" + data.novoSocioId;
                            }
                        }));
                       
                    });
                }, 2500);
            },
            error: function (result) {
                Notificar("error", "Erro!", result);

            }
        })
    }
} 

function validarFormSocio() {
    if ($("#Nome").val() == "") {
        $("#Nome").focus();
        NotificarErro("error", "Erro!", "O Nome do Sócio deve ser preenchido.");
        return false;
    }
    else {
        if ($("#DataNascimento").val() == "") {
            $("#DataNascimento").focus();
            NotificarErro("error", "Erro", "A Data de Nascimento deve ser preenchida.");
            return false;
        }

        else {
            if ($("#Nacionalidade").val() == "") {
                $("#Nacionalidade").focus();
                NotificarErro("error", "Erro", "A Nacionalidade deve ser preenchida.");
                return false;
            }
            else {
                if ($("#Telefone").val() == "") {
                    $("#Telefone").focus();
                    NotificarErro("error", "Erro", "O Telefone deve ser preenchido.");
                    return false;
                }
                else {
                    if ($("#bairro").val() == "..Selecione um Bairro..") {
                        $("#bairro").focus();
                        NotificarErro("error", "Erro!", "É necessário selecionar um Bairro.");
                        return false;
                    }
                    else {
                        if ($("#organismo").val() == "..Selecione um Organismo..") {
                            $("#organismo").focus();
                            NotificarErro("error", "Erro!", "É necessário selecionar um Organismo.");
                            return false;
                        }
                        else {
                            if ($("#Categoria").val() == "..Selecione uma Categoria..") {
                                $("#Categoria").focus();
                                NotificarErro("error", "Erro!", "É necessário selecionar uma Categoria.");
                                return false;
                            }
                        }
                    }
                }
            }
        }        
    }
    return true;
}

function preencherSelectRelacao() {
    $.ajax({
        type: "GET",
        url: "/Agregado/ObterRelacao",
        success: function (data) {
            $('#relacaoAgregado').empty();
            $.each(data, function (index, relacao) {
                $('#relacaoAgregado').append($('<option>', {
                    value: relacao.Id,
                    text: relacao.Nome
                }));
            });
        },
        error: function (result) {
            Notificar("error", "Erro!", result);
        }
    });
}
$('#relacaoAgregado').on('shown.bs.modal', function () {
    debugger;
    preencherSelectRelacao();
});

$('#botaoAbrir').on('click', function () {

    $('#adicionarAgregado').modal('show');
    preencherSelectRelacao();
})



/*------------------------------------------*/
/*---------Bairro-----------*/

function NotificarBairro(icone, titulo, mensagem) {
    $('#loading-overlay').show();
    setTimeout(function () {
        $('#loading-overlay').hide();
        Swal.fire({
            icon: icone,
            title: titulo,
            text: mensagem,
            showConfirmButton: false,
            iconSize: "10px",
            timer: 2500
        }).then((result) => {
            window.location = "/Bairro/Index";
        });
    }, 2500);
}

//------------------Adicionar----
function AdicionarBairro() {
    if ($("#Nome").val() == "") {
        NotificarErro("error", "Erro!", "O Nome do Bairro deve ser preenchido.");
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
                NotificarBairro("success", "Sucesso!", result);
                $("#Nome").val("");
            },
            error: function (result) {
                Notificar("error", "Erro!", result);

            } 
        });
    }
    
}

//------------------Editar-------
function SetBairro(bairroId, municipioId,dataCriacao, nomeBairro) {
    $("#bairroId").val(bairroId);
    $("#municipioId").val(municipioId);
    $("#nomeBairro").val(nomeBairro);
    $("#dataCriacao").val(dataCriacao);
}
function EditarBairro() {
    
    if ($("#nomeBairro").val() == "") {
        NotificarErro("error", "Erro!", "O Nome do Bairro deve ser preenchido.");
        return;
    }
    
    $.ajax({
        type: "POST",
        url: "/Bairro/Edit",
        data: {
            bairroId: $("#bairroId").val(),
            municipioId: $("#municipioId").val(),
            Nome: $("#nomeBairro").val(),
            dataCriacao: $("#dataCriacao").val(),
            dataAtualizacao: $("#dataAtualizacao").val()
        },
        success: function (result) {
            if (result.substring(0, 1) == "x") {
                Notificar("error", "Erro!", result);
                return false;
            }
            NotificarBairro("success", "Sucesso!", result);
        },
        error: function (result) {
            Notificar("error", "Erro!", result);
        } 
    });
}

/*------------------Eliminar-------*/
function SetBairroEliminar(bairroId, nomeBairro) {

    $("#id").val(bairroId);

    $("#nome").text(nomeBairro);
}
function EliminarBairro() {
    $.ajax({
        type: "POST",
        url: "/Bairro/Delete",
        data: {
            id: $("#id").val()
        },
        success: function (result) {
            if (result.substring(0, 1) == "x") {
                Notificar("error", "Erro!", result);
                return false;
            }
            NotificarBairro("success", "Sucesso!", result);
        },
        error: function (result) {
            Notificar("error", "Erro!", result);
        }
    });
}



/*---------Municipio-------------*/
//-----------------Adicionar----
function AdicionarMunicipio() {
    if ($("#Nome").val() == "") {
        NotificarErro("error", "Erro!", "O Nome do Bairro deve ser preenchido.");
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

//-----------------Editar-------
function SetMunicipio(municipioId, nomeMunicipio, dataCriacao, dataAtualizacao) {
    $("#municipioId").val(municipioId);
    $("#nomeMunicipio").val(nomeMunicipio);
    $("#dataCriacao").val(dataCriacao);
    $("#dataAtualizacao").val(dataAtualizacao);
}
function EditarMunicipio() {

    if ($("#nomeMunicipio").val() == "") {
        NotificarErro("error", "Erro!", "O Nome do Município deve ser preenchido.");
        return;
    }

    $.ajax({
        type: "POST",
        url: "/Municipio/Edit",
        data: {
            municipioId: $("#municipioId").val(),
            Nome: $("#nomeMunicipio").val(),
            dataCriacao: $("#dataCriacao").val(),
            dataAtualizacao: $("#dataAtualizacao").val()
        },
        success: function (result) {
            if (result.substring(0, 1) == "x") {
                Notificar("error", "Erro!", result);
                return false;
            }
            $('#loading-overlay').show();
            setTimeout(function () {
                $('#loading-overlay').hide();
                Swal.fire({
                    icon: "success",
                    title: "Sucesso",
                    text: result,
                    showConfirmButton: false,
                    iconSize: "10px",
                    timer: 2500
                }).then((result) => {
                    window.location = "/Municipio/Index";
                });
            }, 2500);
        },
        error: function (result) {
            Notificar("error", "Erro!", result);
        }
    });
}

/*-----------------Eliminar-------*/
function SetMunicipioEliminar(municipioId, nomeMunicipio) {
    $("#id").val(municipioId);
    $("#nome").text(nomeMunicipio);
}
function EliminarMunicipio() {
    $.ajax({
        type: "POST",
        url: "/Municipio/Delete",
        data: {
            id: $("#id").val()
        },
        success: function (result) {
            if (result.substring(0, 1) == "x") {
                Notificar("error", "Erro!", result);
                return false;
            }
            $('#loading-overlay').show();
            setTimeout(function () {
                $('#loading-overlay').hide();
                Swal.fire({
                    icon: "success",
                    title: "Sucesso",
                    text: result,
                    showConfirmButton: false,
                    iconSize: "10px",
                    timer: 2500
                }).then((result) => {
                    window.location = "/Municipio/Index";
                });
            }, 2500);
        },
        error: function (result) {
            Notificar("error", "Erro!", result);
        }
    });
}

/*-----------Tipo de Pagamento -----------------*/

//----------Adicionar----
function AdicionarTipoPagamento() {
    if ($("#Nome").val() == "") {
        NotificarErro("error", "Erro!", "O Nome do Bairro deve ser preenchido.");
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



