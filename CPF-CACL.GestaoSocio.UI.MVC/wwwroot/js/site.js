

$(document).ready(function () {
    $('#myDataTable').DataTable({
        "language": {
            "url": "/js/pt-PT.json"
        }
    });
    table.buttons().container()
        .appendTo('#myDataTable_erapper .col-md-6:eq(0)');
});

$(document).ready(function () {
    var selectedValues = [];

    $("#btnAdicionar").click(function () {
        $('#loading-overlay').show();
        $.ajax({
            url: "/Apoio/GetValorCapital",
            type: "GET",
            data: {
                benefiioId: $('#beneficioId').val(),
                socioId: $('#socioId').val()
            },
            success: function (response) {
                $("#valorCapital").val(response);
                var capital = $("#valorCapital").val();
                var valorInserido = $("#Valor").val();

                var capitalC = parseFloat(capital);
                var valorInseridoC = parseFloat(valorInserido);
                if (capital == 0 || capital == null) {
                    Notificar("error", "Erro!", "A categoria do sócio não possui cobertura para este benefício.");
                    return;
                }
                else {
                    if (valorInseridoC > capitalC) {
                        Notificar("error", "Erro!", "O valor inserido excede o limite do plafound do caital do Sócio.");
                        return;
                    }
                    else {

                        $('#loading-overlay').hide();
                        var selectedElement = document.getElementById("beneficioId");
                        var selectedIndex = selectedElement.selectedIndex;



                        var usuarioId = $("#usuarioId").val();
                        var beneficioId = $("#beneficioId").val();
                        var fornecedorId = $("#fornecedor").val();
                        var socioId = $("#socioId").val();
                        var nomeBeneficio = selectedElement.options[selectedIndex].text;
                        var descricao = $("#Descricao").val();
                        var valor = $("#Valor").val();
                        var dataApoio = $("#DataApoio").val();


                        var newRow = "<tr>" +
                            "<td style='display:none'>" + usuarioId + "</td>" +
                            "<td style='display:none'>" + beneficioId + "</td>" +
                            "<td style='display:none'>" + fornecedorId + "</td>" +
                            "<td  style='display:none'>" + socioId + "</td>" +
                            "<td>" + nomeBeneficio + "</td>" +
                            "<td   style='display:none'>" + descricao + "</td>" +
                            "<td>" + valor + "</td>" +
                            "<td>" + dataApoio + "</td>" +
                            "<td class='text-right'><button class='btn btn-danger removeRow'>Remover</button></td>" +
                            "</tr>";
                        $("#tbItemApoio tbody").append(newRow);

                        $("#Descricao").prop('disabled', true);
                        $("#DataApoio").prop('disabled', true);
                        $("#valorCapital").val("");
                        $("#Valor").val("");
                    }
                }
            },
            error: function (result) {
                Notificar("error", "Erro!", "Ocorreu um erro.");
            }
        });


    });

    $("#tbItemApoio").on('click', '.removeRow', function () {
        $(this).closest('tr').remove();
    });

    $("#concluir").click(function () {

        $('#loading-overlay').show(); 

        var dataToSend = [];
        $("#tbItemApoio tbody tr").each(function () {
            var row = $(this);
            var rowData = {
                usuarioId:  row.find("td:eq(0)").text(),
                beneficioId: row.find("td:eq(1)").text(),
                fornecedorId: row.find("td:eq(2)").text(),
                socioId: row.find("td:eq(3)").text(),
                descricao: row.find("td:eq(5)").text(),
                valor: row.find("td:eq(6)").text(),
                dataApoio: row.find("td:eq(7)").text()

            };
            dataToSend.push(rowData);
        });

        $.ajax({
            type: 'POST',
            url: '/Apoio/Criar',
            contentType: "application/json",
            data: JSON.stringify(dataToSend),
            success: function (result) {
                if (result.substring(0, 1) == "x") {
                    Notificar("error", "Erro!", result);
                    return false;
                }
                Notificar("success", "Sucesso!", result);
                $("#Valor").val("");
                $("#Descricao").val("");
                $("#Descricao").prop('disabled', false);
                $("#DataApoio").prop('disabled', false);

                $("#tbItemApoio tbody").empty();

            },
            error: function (result) {
                Notificar("error", "Erro!", result);
            }
        });
    });
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

    $('#loading-overlay').hide();
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
        url: "/Dependente/Criar",
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
            url: "/Dependente/Criar",
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


//----- BENEFICIO

///----Adicionar--

function AdicionarBeneficio() {
    if (!ValidarBeneficio()) {
        return;
    }
    else {
        $('#loading-overlay').show();
        $.ajax({
            type: "POST",
            url: "/Beneficio/Criar",
            data: {
                Nome: $("#nome").val(),
                TipoBeneficioId: $("#tipoId").val(),
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
                        title: "Sucesso!",
                        text: result,
                        showConfirmButton: false,
                        timer: 2500
                    }).then((result) => {
                        window.location = "/Beneficio/Index";
                    });
                }, 2500);
            },
            error: function (result) {
                Notificar("error", "Erro!", result);
            }
        });
    }
}
function ValidarBeneficio() {
    if ($("#nome").val() == "") {
        $("#nome").focus();
        NotificarErro("error", "Erro!", "O Nome do Benefício deve ser preenchido.");
        return false;
    }
    return true;
}


//----- CAPITAL

///----Adicionar--

function AdicionarCapital() {
    if (!ValidarCapital()) {
        return;
    }
    else {
        $('#loading-overlay').show();
        $.ajax({
            type: "POST",
            url: "/Capital/Criar",
            data: {
                Valor: $("#valor").val(),
                BeneficioId: $("#beneficioId").val(),
                CategoriaSocioId: $("#categoriaId").val(),
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
                        title: "Sucesso!",
                        text: result,
                        showConfirmButton: false,
                        timer: 2500
                    }).then((result) => {
                        window.location = "/Capital/Index";
                    });
                }, 2500);
            },
            error: function (result) {
                Notificar("error", "Erro!", result);
            }
        });
    }
}
function ValidarCapital() {
    if ($("#valor").val() == "") {
        $("#valor").focus();
        NotificarErro("error", "Erro!", "O Valor do Capital deve ser preenchido.");
        return false;
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
                        title: result,
                        showConfirmButton: false,
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

//-----PESQUISAR SOCIO
function pesquisarSocio() {
    Swal.fire({
        title: 'Digite o código do Sócio:',
        input: 'text',
        showCancelButton: true,
        confirmButtonText: 'Pesquisar',
        cancelButtonText: 'Cancelar',
        showLoaderOnConfirm: true,
        preConfirm: (valor) => {
            return new Promise(resolve => {
                setTimeout(() => {
                    resolve(fetch(`/Socio/Pesquisar?codigo=${encodeURIComponent(valor)}`)
                        .then(response => {
                            if (!response.ok) {
                                throw new Error(response.statusText)
                            }
                            return response.json()
                        })
                        .catch(error => {
                            Swal.showValidationMessage('A pesquisa falhou!')
                        }));
                }, 1000);
            });
        },
        allowOutsideClick: false,
    }).then((result) => {
        if (result.isConfirmed) {
            if (result.value.socioId) {
                window.location = "/Socio/Details/" + result.value.socioId;
            }
            else {
                Swal.fire({
                    title: 'Erro!',
                    text: `${result.value}`,
                    icon: 'error'
                });
            }
        }
    })
}

//-----PESQUISAR SOCIO PARA ATRIBUIR APOIO
function pesquisarPAApoio() {

    Swal.fire({
        title: 'Digite o código do Sócio para atribuir o Apoio:',
        input: 'text',
        showCancelButton: true,
        confirmButtonText: 'Pesquisar',
        cancelButtonText: 'Cancelar',
        showLoaderOnConfirm: true,
        preConfirm: (valor) => {
            return new Promise(resolve => {
                setTimeout(() => {
                    resolve(fetch(`/Socio/Pesquisar?codigo=${encodeURIComponent(valor)}`)
                        .then(response => {
                            if (!response.ok) {
                                throw new Error(response.statusText)
                            }
                            return response.json()
                        })
                        .catch(error => {
                            Swal.showValidationMessage('A pesquisa falhou!')
                        }));
                }, 1000);
            });
        },
        allowOutsideClick: false,
    }).then((result) => {
        if (result.isConfirmed) {
            if (result.value.socioId) {
                window.location = "/Apoio/Criar/" + result.value.socioId;
            }
            else {
                Swal.fire({
                    title: 'Erro!',
                    text: `${result.value}`,
                    icon: 'error'
                });
            }
        }
    })
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


///----FORNECEDOR--
function AdicionarFornecedor() {
    if (!ValidarFornecedor()) {
        return;
    }
    else {
        $('#loading-overlay').show();
        $.ajax({
            type: "POST",
            url: "/Admin/Fornecedor/Criar",
            data: {
                Nome: $("#Nome").val(),
                NIF: $("#NIF").val(),
                Endereco: $("#Endereco").val(),
                Telefone: $("#Telefone").val(),
                Email: $("#Email").val(),
                BairroId: $("#bairroId").val(),
                DataCriacao: $("#DataCriacao").val(),
                Status: $("#Status").val()
            },
            success: function (result) {
                if (result.substring(0, 1) == "x") {
                    Notificar("error", "Erro!", result);
                    return false;
                }
                Notificar("success", "Sucesso!", result);
                $("#Nome").val("");
                $("#NIF").val("");
                $("#Endereco").val("");
                $("#Telefone").val("");
                $("#Email").val("");
            },
            error: function (result) {
                Notificar("error", "Erro!", result);
            }
        });
    }
}
function ValidarFornecedor() {
    if ($("#Nome").val() == "") {
        $("#Nome").focus();
        NotificarErro("error", "Erro!", "O Nome do Fornecedor deve ser preenchido.");
        return false;
    }
    else {
        if ($("#Telefone").val() == "") {
            $("#Telefone").focus();
            NotificarErro("error", "Erro!", "O Telefone do Fornecedor deve ser preenchido.");
            return false;
        }
    }
    return true;
}



//---- APOIOS -----

//------------------Editar-------
function SetApoioEditar(apoioId, socioId, descricao, valor, dataApoio, estado, dataCriacao, status) {
    $("#idEdit").val(apoioId);
    $("#socioId").val(socioId);
    $("#descricaoEdit").val(descricao);
    $("#valorEdit").val(valor);
    $("#dataApoioEdit").val(dataApoio);
    $("#estadoEdit").val(estado);
    $("#dataCriacaoEdit").val(dataCriacao);
    $("#statusEdit").val(status);
}
function EditarApoio() {

    if (!ValidarModalEditar()) {
        return;
    }
    else {
        $('#loading-overlay').show();
        $.ajax({
            type: "POST",
            url: "/Apoio/Editar",
            data: {
                Id: $("#idEdit").val(),
                Descricao: $("#descricaoEdit").val(),
                DataApoio: $("#dataApoioEdit").val(),
                Valor: $("#valorEdit").val(),
                Estado: $("#estadoEdit").val(),
                SocioId: $("#socioId").val(),
                UsuarioId: $("#usuarioEdit").val(),
                DataCriacao: $("#dataCriacaoEdit").val(),
                Status: $("#statusEdit").val()
            },
            success: function (result) {
                if (result.substring(0, 1) == "x") {
                    NotificarErro("error", "Erro!", result);
                    return false;
                }
                setTimeout(function () {
                    $('#loading-overlay').hide();
                    Swal.fire({
                        icon: "success",
                        title: "Sucesso!",
                        text: result,
                        showConfirmButton: false,
                        timer: 2500
                    }).then((result) => {
                        window.location = "/Apoio/Index";
                    });
                }, 2500);
            },
            error: function (result) {
                NotificarErro("error", "Erro!", result);
            }
        });
    }
}
function ValidarModalEditar() {
    if ($("#descricaoEdit").val() == "") {
        $("#descricaoEdit").focus();
        NotificarErro("error", "Erro!", "A Descrição do Apoio deve ser preenchida.");
        return false;
    }
    else {
        if ($("#valorEdit").val() == "") {
            $("#valorEdit").focus();
            NotificarErro("error", "Erro!", "O Valor do Apoio deve ser preenchido.");
            return false;
        }
        else {
            if ($("#dataApoioEdit").val() == "") {
                $("#dataApoioEdit").focus();
                NotificarErro("error", "Erro!", "A Data do Apoio deve ser preenchida.");
                return false;
            }
        }
    }
    return true;
}
/*------------------Inativar-------*/
function SetApoioInativar(apoioId) {

    $("#idInativar").val(apoioId);
}
function InativarApoio() {
    $('#loading-overlay').show();
    $.ajax({
        type: "POST",
        url: "/Apoio/Inativar",
        data: {
            id: $("#idInativar").val()
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
                    title: result,
                    showConfirmButton: false,
                    timer: 2500
                }).then((result) => {
                    window.location = "/Apoio/Index";
                });
            }, 2500);
        },
        error: function (result) {
            Swal.fire({
                icon: "error",
                title: "Erro!",
                text: result,
                showConfirmButton: false,
                iconSize: "10px",
                timer: 2500
            });
        }
    });
}

/*------------------Eliminar-------*/
function SetApoioEliminar(apoioId) {
    $("#idEliminar").val(apoioId);
}
function EliminarBeneficio() {
    $('#loading-overlay').show();
    $.ajax({
        type: "POST",
        url: "/Apoio/Eliminar",
        data: {
            id: $("#idEliminar").val()
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
                    title: result,
                    showConfirmButton: false,
                    timer: 2500
                }).then((result) => {
                    window.location = "/Apoio/Index";
                });
            }, 2500);
        },
        error: function (result) {
            Swal.fire({
                icon: "error",
                title: "Erro!",
                text: result,
                showConfirmButton: false,
                iconSize: "10px",
                timer: 2500
            });
        }
    });
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


//---------Registar Pagamento------------
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


//Preencher o Select de Beneficios com base no Tipo de Beneficio selecionado
$(document).on('change', '#tipoBeneficio', function carregarBeneficios() {
    var tipoBeneficioId = document.getElementById("tipoBeneficio").value;

    //Usar AJAX para chamar o método no controlador
    $.ajax({
        url: '/Apoio/GetBeneficioPorTipo',
        type: 'GET',
        data: { tipoId: tipoBeneficioId },
        success: function (data) {
            //Limpar o dropDown atual
            $('#beneficioId').empty();

            //Preencher o dropDown
            $.each(data, function (index, beneficio) {
                $('#beneficioId').append($('<option>', {
                    value: beneficio.id,
                    text: beneficio.nome
                }));
            });
        },
        error: function (error) {
            console.log(error);
        }
    });
});


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