

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
        $('#loading-overlay').show(); 
        $.ajax({
            type: "POST",
            url: "/Socio/Create",
            dataType: "json",
            data: formData,
            processData: false,
            contentType: false,
            success: function (data) {
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
                            //Caso se pretanda adicionar os dependentes
                            if (result.isConfirmed) {
                                abrirModalAgregado(data.novoSocioId);
                                
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
        });
    }
}

function abrirModalAgregado(id) {
    
    $.ajax({
        url: "/Agregado/Criar",
        type: "GET",
        success: function (response) {
            $('#modalContainer').html(response);
            $('#adicionarAgregado').modal('show');
            $('#SocioId').val(id);
        },
        error: function (result) {
            alert("Ocorreu um erro.");
        }
    });
}

function abrirModalPagamento(id) {

    $.ajax({
        url: "/Pagamento/Criar",
        type: "GET",
        success: function (response) {
            $('#modalContainer').html(response);
            $('#modalPagamento').modal('show');
            $('#SocioId').val(id);
        },
        error: function (result) {
            alert("Ocorreu um erro.");
        }
    });
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




///----AGREGADO--
function AdicionarAgregado() {
    if (!ValidarAgregado()) {
        return;
    }
    else {
        $('#loading-overlay').show();
        $.ajax({
            type: "POST",
            url: "/Agregado/Criar",
            data: {
                Nome: $("#nomeAgregado").val(),
                BI: $("#biAgregado").val(),
                Genero: $("#generoAgregado").val(),
                DataNascimento: $("#dataNascimentoAgregado").val(),
                Nacionalidade: $("#nacionalidadeAgregado").val(),
                RelacaoId: $("#relacaoAgregado").val(),
                SocioId: $("#SocioId").val(),
                DataCriacao: $("#dataCriacaoAgregado").val(),
                Status: $("#statusAgregado").val()
            },
            success: function (result) {
                if (result.substring(0, 1) == "x") {
                    Notificar("error", "Erro!", result);
                    return false;
                }
                Notificar("success", "Sucesso!", result);
                $("#nomeAgregado").val("");
                $("#biAgregado").val("");
                $("#dataNascimentoAgregado").val("");
                $("#nacionalidadeAgregado").val("");
            },
            error: function (result) {
                Notificar("error", "Erro!", result);

            }
        });
    }

}
function ValidarAgregado() {
    if ($("#nomeAgregado").val() == "") {
        $("#nomeAgregado").focus();
        NotificarErro("error", "Erro!", "O Nome do Agregado deve ser preenchido.");
        return false;
    }
    else {
        if ($("#biAgregado").val() == "") {
            $("#biAgregado").focus();
            NotificarErro("error", "Erro!", "O BI do Agregado deve ser preenchido.");
            return false;
        }
        else {
            if ($("#dataNascimentoAgregado").val() == "") {
                $("#dataNascimentoAgregado").focus();
                NotificarErro("error", "Erro!", "A Data de Nascimento deve ser preenchida.");
                return false;
            }
            else {
                if ($("#nacionalidadeAgregado").val() == "") {
                    $("#nacionalidadeAgregado").focus();
                    NotificarErro("error", "Erro!", "A Nacionalidade do Agregado deve ser preenchida.");
                    return false;
                }
            }
        }
    }
    return true;
}




///---- USUARIO--
function CadastrarUsuario() {
    if (!ValidarUsuario()) {
        return;
    }
    else {
        $('#loading-overlay').show();
        var url = '@Url.Action("Criar","Usuario", new { area = "Admin"})';
        $.ajax({
            type: 'POST',
            url: '/Admin/Usuario/Criar',
            data: {
                Nome: $("#nome").val(),
                Login: $("#nomeDeUsuario").val(),
                Senha: $("#password1").val(),
                Email: $("#email").val(),
                Perfil: $("#perfil").val(),
                DataCriacao: $("#dataCriacao").val(),
                Status: $("#status").val()
            },
            success: function (result) {
                if (result.substring(0, 1) == "x") {
                    Notificar("error", "Erro!", result);
                    return false;
                }
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
                        window.location = "/Admin/Usuario/Index";
                    });
                }, 2500);
            },
            error: function (result) {
                Notificar("error", "Erro!", result);

            }
        });
    }

}
function ValidarUsuario() {
    if ($("#nome").val() == "") {
        $("#nome").focus();
        NotificarErro("error", "Erro!", "O Nome do completo deve ser preenchido.");
        return false;
    }
    else {
        if ($("#nomeDeUsuario").val() == "") {
            $("#nomeDeUsuario").focus();
            NotificarErro("error", "Erro!", "O Nome de Usuário deve ser preenchido.");
            return false;
        }
        else {
            if ($("#email").val() == "") {
                $("#email").focus();
                NotificarErro("error", "Erro!", "É necessário fornecer um email.");
                return false;
            }
            else {
                if ($("#password1").val() == "") {
                    $("#password1").focus();
                    NotificarErro("error", "Erro!", "É necessário criar uma password.");
                    return false;
                }
                else {
                    if ($("#password2").val() == "") {
                        $("#password2").focus();
                        NotificarErro("error", "Erro!", "Repita a password.");
                        return false;
                    }
                    else {
                        if ($("#password1").val() != $("#password2").val()) {
                            NotificarErro("error", "Erro!", "Dados da password diferentes.");
                            return false;
                        }
                    }
                }
            }
        }
    }
    return true;
}


///----LOGIN--
function EfetuarLogin() {
    if (!ValidarLogin()) {
        return;
    }
    else {
        $('#loading-overlay').show();
        $.ajax({
            type: "POST",
            url: "/Acesso/Login",
            data: {
                Login: $("#userName").val(),
                Senha: $("#password").val()
            },
            success: function (result) {
                if (result.substring(0, 1) == "x") {
                    Notificar("error", "Erro!", result);
                    return false;
                }
            },
            error: function (result) {
                Notificar("error", "Erro!", result);

            }
        });
    }
}
function ValidarLogin() {
    if ($("#userName").val() == "") {
        $("#userName").focus();
        NotificarErro("error", "Erro!", "O Nome de Usuásrio deve ser preenchido.");
        return false;
    }
    else {
        if ($("#password").val() == "") {
            $("#password").focus();
            NotificarErro("error", "Erro!", "Insira a password do usuário.");
            return false;
        }
    }
    return true;
}


//--------------------------------------------
//------------PAGAMENTO-----------------------

//---------------Adicionar----

var idSocio = $("#SocioId").val();
function SetSocioPagamento(socioId) {
    $("#SocioId").val(socioId);
}
function AdicionarPagamento() {

    if (!ValidarModalPagamento()) {
        return;
    }
    else {
        $('#loading-overlay').show();
        $.ajax({
            type: "POST",
            url: "/Pagamento/Criar",
            data: {
                Recibo: $("#Recibo").val(),
                Descricao: $("#Descricao").val(),
                Valor: $("#Valor").val(),
                DataPagamento: $("#DataPagamento").val(),
                SocioId: $("#SocioId").val(),
                TipoPagamentoId: $("#tipoPagamento").val()
            },
            success: function (result) {
                if (result.substring(0, 1) == "x") {
                    Notificar("error", "Erro!", result);
                    return false;
                }
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
                        window.location = "/Socio/Details/"+idSocio;
                    });
                }, 2500);


                $("#Recibo").val("");
                $("#Descricao").val("");
                $("#Valor").val("");
                $("#DataPagamento").val("");
            },
            error: function (result) {
                Notificar("error", "Erro!", result);
            }
        });
    }
}

function ValidarModalPagamento() {
    if ($("#Recibo").val() == "") {
        $("#Recibo").focus();
        NotificarErro("error", "Erro!", "O Número do Recíbo deve ser preenchido.");
        return false;
    }
    else {
        if ($("#Valor").val() == "") {
            $("#Valor").focus();
            NotificarErro("error", "Erro!", "O Valor do Pagamento deve ser preenchido.");
            return false;
        }
        else {
            if ($("#DataPagamento").val() == "") {
                $("#DataPagamento").focus();
                NotificarErro("error", "Erro!", "É necessário preencher a Data do Pagamento.");
                return false;
            }
        }
    }
    return true;
}


//----------------Registar Pagamento------------
function RegistarPagamento() {

    var saldoSelecionado = $('#tabelaSaldo input[name="opcaoSaldo"]:checked').closest('tr');
    var saldoId = saldoSelecionado.find('td:eq(0)').text();
    var dataPagamento = saldoSelecionado.find('td:eq(1)').text();
    var recibo = saldoSelecionado.find('td:eq(2)').text();
    var valorSaldo = parseFloat(saldoSelecionado.find('td:eq(3)').text());
    var pagamentoId = saldoSelecionado.find('td:eq(4)').text();


    var itemSelecionado = $('#tabelaItem input[name="opcaoItem"]:checked').closest('tr');
    var itemId = itemSelecionado.find('td:eq(0)').text();
    var descricao = itemSelecionado.find('td:eq(1)').text();
    var mes = itemSelecionado.find('td:eq(2)').text();
    var valorItem = parseFloat(itemSelecionado.find('td:eq(3)').text());

    if (valorSaldo < valorItem) {
        NotificarErro("error", "Erro", "O saldo selecionado ( " + valorSaldo + ") é inferior ao item que pretende pagar ( " + valorItem + " ) .");
        return;
    }
    else {
        $('#loading-overlay').show();
        $.ajax({
            url: '/Pagamento/Efectuar-Pagamento',
            type: 'POST',
            data: {
                DataInsercao: dataPagamento,
                PagamentoId: pagamentoId,
                ItemId: itemId,
                DataCriacao: $("#dataCriacao").val(),
                Status: $("#Status").val(),
                idSaldo: saldoId,
                saldoValor: valorSaldo,
                itemValor: valorItem,
                socioId: $("#idSocio").val(),
                recibo: recibo
            },
            success: function (result) {
                if (result.substring(0, 1) == "x") {
                    Notificar("error", "Erro!", result);
                    return false;
                }

                var id = $('#idSocio').val();
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
                        window.location = "/Pagamento/Efectuar-Pagamento/" + id;
                    });
                }, 2500);
            },
            error: function (result) {
                Notificar("error", "Erro!", result);
            }
        });
    }
}
 
function UnirRecibo(){
    var idsSelecionados = [];

    //Iterar sobbre as linhas da tabela
    $('#tabelaSaldo tbody tr').each(function () {
        //Verificar se o checkbox esta selecionado
        if ($(this).find('.checkboxRegisto').is(':checked')) {
            //Pegar o ID da lina atual e adicionar no array
            var idRegisto = $(this).find('td:eq(0)').text();
            idsSelecionados.push(idRegisto);
        }
    });
    if (idsSelecionados.length <= 1) {
        NotificarErro("error", "Erro!", "Por favor, selecione dois ou mais registos para unir.");
        return;
    }
    //Enviar para controller
    $('#loading-overlay').show();
    $.ajax({
        url: '/Pagamento/Unir-Recibo',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(idsSelecionados),
        success: function (result) {
            if (result.substring(0, 1) == "x") {
                Notificar("error", "Erro!", result);
                return false;
            }

            var id = $('#idSocio').val();
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
                    window.location = "/Pagamento/Unir-Recibo/" + id;
                });
            }, 2500);
        },
        error: function (result) {
            Notificar("error", "Erro!", result);
        }
    });
}

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
        $('#loading-overlay').show(); 
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
    
    $('#loading-overlay').show(); 
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
    $('#loading-overlay').show(); 
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
        $('#loading-overlay').show(); 
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

    $('#loading-overlay').show(); 
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
    $('#loading-overlay').show();
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


/*-----------Tipo de Item -----------------*/

//----------Adicionar----//
function AdicionarTipoItem() {
    if ($("#Nome").val() == "") {
        NotificarErro("error", "Erro!", "O Nome do Tipo deve ser preenchido.");
    }
    else {
        $('#loading-overlay').show(); 
        $.ajax({
            type: "POST",
            url: "/TipoItem/Criar",
            data: {
                Descricao: $("#Nome").val(),
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
            },
            error: function (result) {
                Notificar("error", "Erro!", result);

            }
        });
    }
}

//-----------------Editar-------
function SetTipoItemEditar(tipoItemId, nomeTipoItem, dataCriacao, dataAtualizacao) {
    $("#tipoItemId").val(tipoItemId);
    $("#nomeTipoItem").val(nomeTipoItem);
    $("#dataCriacao").val(dataCriacao);
    $("#dataAtualizacao").val(dataAtualizacao);
}
function EditarTipoItem() {

    if ($("#nomeTipoItem").val() == "") {
        NotificarErro("error", "Erro!", "O Nome do Tipo deve ser preenchido.");
        return;
    }

    $('#loading-overlay').show();
    $.ajax({
        type: "POST",
        url: "/TipoItem/Editar",
        data: {
            id: $("#tipoItemId").val(),
            Descricao: $("#nomeTipoItem").val(),
            dataCriacao: $("#dataCriacao").val(),
            dataAtualizacao: $("#dataAtualizacao").val()
        },
        success: function (result) {
            if (result.substring(0, 1) == "x") {
                Notificar("error", "Erro!", result);
                return false;
            }
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
                    window.location = "/TipoItem/Index";
                });
            }, 2500);
        },
        error: function (result) {
            Notificar("error", "Erro!", result);
        }
    });
}

/*------------------Eliminar-------*/
function SetTipoItemEliminar(tipoItemId, nomeTipoItem) {

    $("#id").val(tipoItemId);

    $("#nome").text(nomeTipoItem);
}
function EliminarTipoItem() {
    $('#loading-overlay').show();
    $.ajax({
        type: "POST",
        url: "/TipoItem/Deletar",
        data: {
            id: $("#id").val()
        },
        success: function (result) {
            if (result.substring(0, 1) == "x") {
                Notificar("error", "Erro!", result);
                return false;
            }
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
                    window.location = "/TipoItem/Index";
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
        $('#loading-overlay').show(); 
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


/*------------PERIODO-------------*/

//------------------Adicionar----
function AdicionarPeriodo() {
    if ($("#ano").val() == "") {
        NotificarErro("error", "Erro!", "O Ano do Período deve ser preenchido.");
    }
    else {
        $('#loading-overlay').show();
        $.ajax({
            type: "POST",
            url: "/Periodo/CriarPerioEItem",
            data: {
                Ano: $("#ano").val(),
                DataInicio: $("#dataInicial").val(),
                DataFim: $("#dataFinal").val()
            },
            success: function (result) {
                if (result.substring(0, 1) == "x") {
                    Notificar("error", "Erro!", result);
                    return false;
                }
                Notificar("success", "Sucesso!", result);
                $("#dataInicial").val("");
                $("#dataFinal").val("");
            },
            error: function (result) {
                Notificar("error", "Erro!", result);

            }
        });
    }

}


/*---------Relacao-------------*/
//-----------------Adicionar----
function AdicionarRelacao() {
    if ($("#Nome").val() == "") {
        NotificarErro("error", "Erro!", "O Nome da Relação deve ser preenchido.");
    }
    else {
        $('#loading-overlay').show();
        $.ajax({
            type: "POST",
            url: "/Relacao/Criar",
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
function SetRelacao(relacaoId, nomeRelacao, dataCriacao, dataAtualizacao) {
    $("#relacaoId").val(relacaoId);
    $("#nomeRelacao").val(nomeRelacao);
    $("#dataCriacao").val(dataCriacao);
    $("#dataAtualizacao").val(dataAtualizacao);
}
function EditarRelacao() {

    if ($("#nomeRelacao").val() == "") {
        NotificarErro("error", "Erro!", "O Nome da Relação deve ser preenchido.");
        return;
    }

    $('#loading-overlay').show();
    $.ajax({
        type: "POST",
        url: "/Relacao/Editar",
        data: {
            relacaoId: $("#relacaoId").val(),
            Nome: $("#nomeRelacao").val(),
            dataCriacao: $("#dataCriacao").val(),
            dataAtualizacao: $("#dataAtualizacao").val()
        },
        success: function (result) {
            if (result.substring(0, 1) == "x") {
                Notificar("error", "Erro!", result);
                return false;
            }
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
                    window.location = "/Relacao/Index";
                });
            }, 2500);
        },
        error: function (result) {
            Notificar("error", "Erro!", result);
        }
    });
}

/*-----------------Eliminar-------*/
function SetRelacaoEliminar(relacaoId, nomeRelacao) {
    $("#id").val(relacaoId);
    $("#nome").text(nomeRelacao);
}

function EliminarRelacao() {
    $('#loading-overlay').show();
    $.ajax({
        type: "POST",
        url: "/Relacao/Deletar",
        data: {
            id: $("#id").val()
        },
        success: function (result) {
            if (result.substring(0, 1) == "x") {
                Notificar("error", "Erro!", result);
                return false;
            }
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
                    window.location = "/Relacao/Index";
                });
            }, 2500);
        },
        error: function (result) {
            Notificar("error", "Erro!", result);
        }
    });
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
