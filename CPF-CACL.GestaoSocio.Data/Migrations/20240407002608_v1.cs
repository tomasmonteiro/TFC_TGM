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
                    Nome = table.Column<string>(type: "varchar(7)", nullable: false),
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
                name: "EstadoSolicitacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Estado = table.Column<string>(type: "varchar(10)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoSolicitacao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Municipio",
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
                    table.PrimaryKey("PK_Municipio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organismo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(60)", nullable: false),
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
                    Nome = table.Column<string>(type: "varchar(13)", nullable: false),
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
                    Codigo = table.Column<string>(type: "varchar(10)", nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "varchar(7)", nullable: false),
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
                    Nome = table.Column<string>(type: "varchar(7)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relacao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoApoio",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tipo = table.Column<string>(type: "varchar(20)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoApoio", x => x.Id);
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
                name: "TipoDeclaracao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tipo = table.Column<string>(type: "varchar(25)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDeclaracao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoEmolumento",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(5)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEmolumento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoPagamento",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(17)", nullable: false),
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
                    Nome = table.Column<string>(type: "varchar(20)", nullable: false),
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
                    Nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    Login = table.Column<string>(type: "varchar(10)", nullable: false),
                    Senha = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "varchar(60)", nullable: true),
                    Perfil = table.Column<string>(type: "varchar(13)", nullable: false),
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
                    Nome = table.Column<string>(type: "varchar(40)", nullable: false),
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
                    Nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    Quantidade = table.Column<byte>(type: "tinyint", nullable: false),
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
                name: "Fornecedor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "varchar(10)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(60)", nullable: false),
                    NIF = table.Column<string>(type: "varchar(15)", nullable: true),
                    Telefone = table.Column<string>(type: "varchar(12)", nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", nullable: true),
                    Endereco = table.Column<string>(type: "varchar(50)", nullable: true),
                    BairroId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fornecedor_Bairro_BairroId",
                        column: x => x.BairroId,
                        principalTable: "Bairro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Socio",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "varchar(10)", nullable: false),
                    EstadoCivil = table.Column<string>(type: "varchar(10)", nullable: false),
                    Habilitacoes = table.Column<string>(type: "varchar(13)", nullable: true),
                    NomeDoPai = table.Column<string>(type: "varchar(50)", nullable: false),
                    NomeDaMae = table.Column<string>(type: "varchar(50)", nullable: false),
                    LocalDeTrabalho = table.Column<string>(type: "varchar(20)", nullable: true),
                    Funcao = table.Column<string>(type: "varchar(30)", nullable: true),
                    Departamento = table.Column<string>(type: "varchar(30)", nullable: true),
                    OrganismoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EstadoSocio = table.Column<string>(type: "varchar(8)", nullable: false),
                    CategoriaSocioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    BI = table.Column<string>(type: "varchar(14)", nullable: true),
                    CaminhoFoto = table.Column<string>(type: "varchar(200)", nullable: true),
                    Genero = table.Column<string>(type: "char(1)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "date", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(12)", nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", nullable: true),
                    BairroId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Endereco = table.Column<string>(type: "varchar(50)", nullable: true)
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
                    Valor = table.Column<decimal>(type: "money", nullable: false),
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
                    Descricao = table.Column<string>(type: "varchar(50)", nullable: false),
                    Valor = table.Column<decimal>(type: "money", nullable: false),
                    EstadoApoio = table.Column<string>(type: "varchar(9)", nullable: false),
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
                    Nome = table.Column<string>(type: "varchar(50)", nullable: false),
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
                name: "Emolumento",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "varchar(10)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(5)", nullable: false),
                    Valor = table.Column<decimal>(type: "money", nullable: false),
                    Estado = table.Column<string>(type: "varchar(9)", nullable: false),
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
                    table.PrimaryKey("PK_Emolumento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emolumento_Periodo_PeriodoId",
                        column: x => x.PeriodoId,
                        principalTable: "Periodo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Emolumento_Socio_SocioId",
                        column: x => x.SocioId,
                        principalTable: "Socio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Emolumento_TipoEmolumento_TipoItemId",
                        column: x => x.TipoItemId,
                        principalTable: "TipoEmolumento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pagamento",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Recibo = table.Column<string>(type: "varchar(10)", nullable: false),
                    Valor = table.Column<decimal>(type: "money", nullable: false),
                    Estado = table.Column<string>(type: "varchar(10)", nullable: false),
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
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: true),
                    EstadoPedido = table.Column<string>(type: "varchar(10)", nullable: false),
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
                    Descricao = table.Column<string>(type: "varchar(50)", nullable: false),
                    DataAtribuicao = table.Column<DateTime>(type: "date", nullable: false),
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
                name: "SolicitacaoApoio",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Mensagem = table.Column<string>(type: "varchar(50)", nullable: true),
                    UrlAnexo = table.Column<string>(type: "varchar(50)", nullable: true),
                    SocioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoApoioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EstadoSolicitacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitacaoApoio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SolicitacaoApoio_EstadoSolicitacao_EstadoSolicitacaoId",
                        column: x => x.EstadoSolicitacaoId,
                        principalTable: "EstadoSolicitacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SolicitacaoApoio_Socio_SocioId",
                        column: x => x.SocioId,
                        principalTable: "Socio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SolicitacaoApoio_TipoApoio_TipoApoioId",
                        column: x => x.TipoApoioId,
                        principalTable: "TipoApoio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SolicitacaoDeclaracao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SocioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoDeclaracaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EstadoSolicitacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitacaoDeclaracao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SolicitacaoDeclaracao_EstadoSolicitacao_EstadoSolicitacaoId",
                        column: x => x.EstadoSolicitacaoId,
                        principalTable: "EstadoSolicitacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SolicitacaoDeclaracao_Socio_SocioId",
                        column: x => x.SocioId,
                        principalTable: "Socio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SolicitacaoDeclaracao_TipoDeclaracao_TipoDeclaracaoId",
                        column: x => x.TipoDeclaracaoId,
                        principalTable: "TipoDeclaracao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioSocio",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SocioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioSocio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioSocio_Socio_SocioId",
                        column: x => x.SocioId,
                        principalTable: "Socio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsuarioSocio_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Despesa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Valor = table.Column<decimal>(type: "money", nullable: false),
                    EstadoDespesa = table.Column<string>(type: "varchar(8)", nullable: false),
                    ApoioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FornecedorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_Despesa_Fornecedor_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Fornecedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemApoio",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Valor = table.Column<decimal>(type: "money", nullable: false),
                    Quantidade = table.Column<byte>(type: "tinyint", nullable: false),
                    ApoioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ForneceorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BeneficioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                name: "PagamentoEmolumento",
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
                    table.PrimaryKey("PK_PagamentoEmolumento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PagamentoEmolumento_Emolumento_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Emolumento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PagamentoEmolumento_Pagamento_PagamentoId",
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
                    Recibo = table.Column<string>(type: "varchar(10)", nullable: false),
                    Valor = table.Column<decimal>(type: "money", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "datetime", nullable: false),
                    Estado = table.Column<string>(type: "varchar(10)", nullable: false),
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
                name: "IX_Despesa_FornecedorId",
                table: "Despesa",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Emolumento_Codigo",
                table: "Emolumento",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Emolumento_PeriodoId",
                table: "Emolumento",
                column: "PeriodoId");

            migrationBuilder.CreateIndex(
                name: "IX_Emolumento_SocioId",
                table: "Emolumento",
                column: "SocioId");

            migrationBuilder.CreateIndex(
                name: "IX_Emolumento_TipoItemId",
                table: "Emolumento",
                column: "TipoItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedor_BairroId",
                table: "Fornecedor",
                column: "BairroId");

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedor_Codigo",
                table: "Fornecedor",
                column: "Codigo",
                unique: true);

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
                name: "IX_PagamentoEmolumento_ItemId",
                table: "PagamentoEmolumento",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_PagamentoEmolumento_PagamentoId",
                table: "PagamentoEmolumento",
                column: "PagamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoApoio_SocioId",
                table: "PedidoApoio",
                column: "SocioId");

            migrationBuilder.CreateIndex(
                name: "IX_Periodo_Codigo",
                table: "Periodo",
                column: "Codigo",
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
                name: "IX_Socio_Codigo",
                table: "Socio",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Socio_OrganismoId",
                table: "Socio",
                column: "OrganismoId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitacaoApoio_EstadoSolicitacaoId",
                table: "SolicitacaoApoio",
                column: "EstadoSolicitacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitacaoApoio_SocioId",
                table: "SolicitacaoApoio",
                column: "SocioId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitacaoApoio_TipoApoioId",
                table: "SolicitacaoApoio",
                column: "TipoApoioId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitacaoDeclaracao_EstadoSolicitacaoId",
                table: "SolicitacaoDeclaracao",
                column: "EstadoSolicitacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitacaoDeclaracao_SocioId",
                table: "SolicitacaoDeclaracao",
                column: "SocioId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitacaoDeclaracao_TipoDeclaracaoId",
                table: "SolicitacaoDeclaracao",
                column: "TipoDeclaracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_PerfilUsuarioId",
                table: "Usuario",
                column: "PerfilUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioSocio_SocioId",
                table: "UsuarioSocio",
                column: "SocioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioSocio_UsuarioId",
                table: "UsuarioSocio",
                column: "UsuarioId");
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
                name: "PagamentoEmolumento");

            migrationBuilder.DropTable(
                name: "PedidoApoio");

            migrationBuilder.DropTable(
                name: "ProjectoSocio");

            migrationBuilder.DropTable(
                name: "Saldo");

            migrationBuilder.DropTable(
                name: "SolicitacaoApoio");

            migrationBuilder.DropTable(
                name: "SolicitacaoDeclaracao");

            migrationBuilder.DropTable(
                name: "UsuarioSocio");

            migrationBuilder.DropTable(
                name: "Relacao");

            migrationBuilder.DropTable(
                name: "Apoio");

            migrationBuilder.DropTable(
                name: "Beneficio");

            migrationBuilder.DropTable(
                name: "Fornecedor");

            migrationBuilder.DropTable(
                name: "Emolumento");

            migrationBuilder.DropTable(
                name: "Projecto");

            migrationBuilder.DropTable(
                name: "Pagamento");

            migrationBuilder.DropTable(
                name: "TipoApoio");

            migrationBuilder.DropTable(
                name: "EstadoSolicitacao");

            migrationBuilder.DropTable(
                name: "TipoDeclaracao");

            migrationBuilder.DropTable(
                name: "TipoBeneficio");

            migrationBuilder.DropTable(
                name: "Periodo");

            migrationBuilder.DropTable(
                name: "TipoEmolumento");

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
