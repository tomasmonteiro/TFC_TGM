using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPF_CACL.GestaoSocio.Data.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriaSocio",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    Quota = table.Column<decimal>(type: "smallmoney", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaSocio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fornecedor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cod = table.Column<string>(type: "varchar(10)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(150)", nullable: false),
                    NIF = table.Column<string>(type: "varchar(15)", nullable: true),
                    Endereco = table.Column<string>(type: "varchar(300)", nullable: true),
                    Telefone = table.Column<string>(type: "varchar(12)", nullable: false),
                    Email = table.Column<string>(type: "varchar(300)", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Municipio",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organismo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organismo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PerfilUsuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerfilUsuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Periodo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cod = table.Column<string>(type: "varchar(10)", nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "varchar(20)", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "date", nullable: false),
                    DataFim = table.Column<DateTime>(type: "date", nullable: false),
                    UltimoDiaUtil = table.Column<DateTime>(type: "date", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Periodo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Relacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(30)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relacao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoBeneficio",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoBeneficio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(50)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoPagamento",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPagamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoProjecto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoProjecto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bairro",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    MunicipioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bairro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bairro_Municipio_MunicipioId",
                        column: x => x.MunicipioId,
                        principalTable: "Municipio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(150)", nullable: false),
                    Login = table.Column<string>(type: "varchar(100)", nullable: false),
                    Senha = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "varchar(300)", nullable: true),
                    Perfil = table.Column<string>(type: "varchar(20)", nullable: false),
                    PerfilUsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_PerfilUsuario_PerfilUsuarioId",
                        column: x => x.PerfilUsuarioId,
                        principalTable: "PerfilUsuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Beneficio",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    TipoBeneficioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beneficio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Beneficio_TipoBeneficio_TipoBeneficioId",
                        column: x => x.TipoBeneficioId,
                        principalTable: "TipoBeneficio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projecto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    DataLancamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoProjectoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projecto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projecto_TipoProjecto_TipoProjectoId",
                        column: x => x.TipoProjectoId,
                        principalTable: "TipoProjecto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Socio",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cod = table.Column<string>(type: "varchar(10)", nullable: false),
                    EstadoCivil = table.Column<string>(type: "varchar(20)", nullable: false),
                    Profissao = table.Column<string>(type: "varchar(100)", nullable: true),
                    Habilitacoes = table.Column<string>(type: "varchar(20)", nullable: true),
                    Nacionalidade = table.Column<string>(type: "varchar(20)", nullable: false),
                    NomeDoPai = table.Column<string>(type: "varchar(150)", nullable: false),
                    NomeDaMae = table.Column<string>(type: "varchar(150)", nullable: false),
                    LocalDeTrabalho = table.Column<string>(type: "varchar(100)", nullable: true),
                    Funcao = table.Column<string>(type: "varchar(100)", nullable: true),
                    Departamento = table.Column<string>(type: "varchar(100)", nullable: true),
                    OrganismoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EstadoSocio = table.Column<string>(type: "varchar(10)", nullable: false),
                    CategoriaSocioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    Nome = table.Column<string>(type: "varchar(150)", nullable: false),
                    BI = table.Column<string>(type: "varchar(14)", nullable: true),
                    CaminhoFoto = table.Column<string>(type: "varchar(1000)", nullable: true),
                    Genero = table.Column<string>(type: "varchar(9)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "date", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(12)", nullable: false),
                    Email = table.Column<string>(type: "varchar(300)", nullable: true),
                    BairroId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Endereco = table.Column<string>(type: "varchar(300)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Socio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Socio_Bairro_BairroId",
                        column: x => x.BairroId,
                        principalTable: "Bairro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Socio_CategoriaSocio_CategoriaSocioId",
                        column: x => x.CategoriaSocioId,
                        principalTable: "CategoriaSocio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Socio_Organismo_OrganismoId",
                        column: x => x.OrganismoId,
                        principalTable: "Organismo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Capital",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BeneficioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoriaSocioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Valor = table.Column<decimal>(type: "smallmoney", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Capital", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Capital_Beneficio_BeneficioId",
                        column: x => x.BeneficioId,
                        principalTable: "Beneficio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Capital_CategoriaSocio_CategoriaSocioId",
                        column: x => x.CategoriaSocioId,
                        principalTable: "CategoriaSocio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Apoio",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataApoio = table.Column<DateTime>(type: "date", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(300)", nullable: false),
                    Valor = table.Column<decimal>(type: "smallmoney", nullable: false, defaultValue: 0m),
                    EstadoApoio = table.Column<string>(type: "varchar(300)", nullable: false),
                    SocioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apoio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Apoio_Socio_SocioId",
                        column: x => x.SocioId,
                        principalTable: "Socio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Apoio_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Dependente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(150)", nullable: false),
                    BI = table.Column<string>(type: "varchar(14)", nullable: true),
                    Genero = table.Column<string>(type: "varchar(9)", nullable: false),
                    Nacionalidade = table.Column<string>(type: "varchar(20)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "date", nullable: false),
                    SocioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RelacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dependente_Relacao_RelacaoId",
                        column: x => x.RelacaoId,
                        principalTable: "Relacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dependente_Socio_SocioId",
                        column: x => x.SocioId,
                        principalTable: "Socio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cod = table.Column<string>(type: "varchar(10)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(50)", nullable: false),
                    Valor = table.Column<decimal>(type: "smallmoney", nullable: false),
                    Estado = table.Column<string>(type: "varchar(30)", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "date", nullable: true),
                    TipoItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SocioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PeriodoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Item_Periodo_PeriodoId",
                        column: x => x.PeriodoId,
                        principalTable: "Periodo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Item_Socio_SocioId",
                        column: x => x.SocioId,
                        principalTable: "Socio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Item_TipoItem_TipoItemId",
                        column: x => x.TipoItemId,
                        principalTable: "TipoItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pagamento",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Recibo = table.Column<string>(type: "varchar(50)", nullable: false),
                    Valor = table.Column<decimal>(type: "smallmoney", nullable: false),
                    Estado = table.Column<string>(type: "varchar(20)", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SocioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoPagamentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagamento_Socio_SocioId",
                        column: x => x.SocioId,
                        principalTable: "Socio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pagamento_TipoPagamento_TipoPagamentoId",
                        column: x => x.TipoPagamentoId,
                        principalTable: "TipoPagamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pagamento_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PedidoApoio",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(300)", nullable: true),
                    EstadoPedido = table.Column<string>(type: "varchar(50)", nullable: false),
                    SocioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoApoio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidoApoio_Socio_SocioId",
                        column: x => x.SocioId,
                        principalTable: "Socio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectoSocio",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: false),
                    DataAtribuicao = table.Column<DateTime>(type: "datetime", nullable: false),
                    SocioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectoSocio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectoSocio_Projecto_ProjectoId",
                        column: x => x.ProjectoId,
                        principalTable: "Projecto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectoSocio_Socio_SocioId",
                        column: x => x.SocioId,
                        principalTable: "Socio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Despesa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Total = table.Column<decimal>(type: "money", nullable: false),
                    ApoioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EstadoDespesa = table.Column<string>(type: "varchar(20)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Despesa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Despesa_Apoio_ApoioId",
                        column: x => x.ApoioId,
                        principalTable: "Apoio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemApoio",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Valor = table.Column<decimal>(type: "smallmoney", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    BeneficioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApoioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ForneceorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemApoio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemApoio_Apoio_ApoioId",
                        column: x => x.ApoioId,
                        principalTable: "Apoio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemApoio_Beneficio_BeneficioId",
                        column: x => x.BeneficioId,
                        principalTable: "Beneficio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemApoio_Fornecedor_ForneceorId",
                        column: x => x.ForneceorId,
                        principalTable: "Fornecedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemPagamento",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataInsercao = table.Column<DateTime>(type: "datetime", nullable: false),
                    PagamentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPagamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemPagamento_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemPagamento_Pagamento_PagamentoId",
                        column: x => x.PagamentoId,
                        principalTable: "Pagamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Saldo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Recibo = table.Column<string>(type: "varchar(50)", nullable: false),
                    Valor = table.Column<decimal>(type: "smallmoney", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "datetime", nullable: false),
                    Estado = table.Column<string>(type: "varchar(20)", nullable: false),
                    SocioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PagamentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saldo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Saldo_Pagamento_PagamentoId",
                        column: x => x.PagamentoId,
                        principalTable: "Pagamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Saldo_Socio_SocioId",
                        column: x => x.SocioId,
                        principalTable: "Socio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apoio_SocioId",
                table: "Apoio",
                column: "SocioId");

            migrationBuilder.CreateIndex(
                name: "IX_Apoio_UsuarioId",
                table: "Apoio",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Bairro_MunicipioId",
                table: "Bairro",
                column: "MunicipioId");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficio_TipoBeneficioId",
                table: "Beneficio",
                column: "TipoBeneficioId");

            migrationBuilder.CreateIndex(
                name: "IX_Capital_BeneficioId",
                table: "Capital",
                column: "BeneficioId");

            migrationBuilder.CreateIndex(
                name: "IX_Capital_CategoriaSocioId",
                table: "Capital",
                column: "CategoriaSocioId");

            migrationBuilder.CreateIndex(
                name: "IX_Dependente_RelacaoId",
                table: "Dependente",
                column: "RelacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Dependente_SocioId",
                table: "Dependente",
                column: "SocioId");

            migrationBuilder.CreateIndex(
                name: "IX_Despesa_ApoioId",
                table: "Despesa",
                column: "ApoioId");

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedor_Cod",
                table: "Fornecedor",
                column: "Cod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Item_Cod",
                table: "Item",
                column: "Cod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Item_PeriodoId",
                table: "Item",
                column: "PeriodoId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_SocioId",
                table: "Item",
                column: "SocioId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_TipoItemId",
                table: "Item",
                column: "TipoItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemApoio_ApoioId",
                table: "ItemApoio",
                column: "ApoioId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemApoio_BeneficioId",
                table: "ItemApoio",
                column: "BeneficioId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemApoio_ForneceorId",
                table: "ItemApoio",
                column: "ForneceorId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPagamento_ItemId",
                table: "ItemPagamento",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPagamento_PagamentoId",
                table: "ItemPagamento",
                column: "PagamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamento_Recibo",
                table: "Pagamento",
                column: "Recibo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pagamento_SocioId",
                table: "Pagamento",
                column: "SocioId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamento_TipoPagamentoId",
                table: "Pagamento",
                column: "TipoPagamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamento_UsuarioId",
                table: "Pagamento",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoApoio_SocioId",
                table: "PedidoApoio",
                column: "SocioId");

            migrationBuilder.CreateIndex(
                name: "IX_Periodo_Cod",
                table: "Periodo",
                column: "Cod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projecto_TipoProjectoId",
                table: "Projecto",
                column: "TipoProjectoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectoSocio_ProjectoId",
                table: "ProjectoSocio",
                column: "ProjectoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectoSocio_SocioId",
                table: "ProjectoSocio",
                column: "SocioId");

            migrationBuilder.CreateIndex(
                name: "IX_Saldo_PagamentoId",
                table: "Saldo",
                column: "PagamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Saldo_SocioId",
                table: "Saldo",
                column: "SocioId");

            migrationBuilder.CreateIndex(
                name: "IX_Socio_BairroId",
                table: "Socio",
                column: "BairroId");

            migrationBuilder.CreateIndex(
                name: "IX_Socio_CategoriaSocioId",
                table: "Socio",
                column: "CategoriaSocioId");

            migrationBuilder.CreateIndex(
                name: "IX_Socio_Cod",
                table: "Socio",
                column: "Cod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Socio_OrganismoId",
                table: "Socio",
                column: "OrganismoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_PerfilUsuarioId",
                table: "Usuario",
                column: "PerfilUsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Capital");

            migrationBuilder.DropTable(
                name: "Dependente");

            migrationBuilder.DropTable(
                name: "Despesa");

            migrationBuilder.DropTable(
                name: "ItemApoio");

            migrationBuilder.DropTable(
                name: "ItemPagamento");

            migrationBuilder.DropTable(
                name: "PedidoApoio");

            migrationBuilder.DropTable(
                name: "ProjectoSocio");

            migrationBuilder.DropTable(
                name: "Saldo");

            migrationBuilder.DropTable(
                name: "Relacao");

            migrationBuilder.DropTable(
                name: "Apoio");

            migrationBuilder.DropTable(
                name: "Beneficio");

            migrationBuilder.DropTable(
                name: "Fornecedor");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Projecto");

            migrationBuilder.DropTable(
                name: "Pagamento");

            migrationBuilder.DropTable(
                name: "TipoBeneficio");

            migrationBuilder.DropTable(
                name: "Periodo");

            migrationBuilder.DropTable(
                name: "TipoItem");

            migrationBuilder.DropTable(
                name: "TipoProjecto");

            migrationBuilder.DropTable(
                name: "Socio");

            migrationBuilder.DropTable(
                name: "TipoPagamento");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Bairro");

            migrationBuilder.DropTable(
                name: "CategoriaSocio");

            migrationBuilder.DropTable(
                name: "Organismo");

            migrationBuilder.DropTable(
                name: "PerfilUsuario");

            migrationBuilder.DropTable(
                name: "Municipio");
        }
    }
}
