using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PIM_VIII.Migrations
{
    public partial class DataContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TB_ENDERECOS",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    logradouro = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    numero = table.Column<int>(type: "int", nullable: false),
                    cep = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    bairro = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cidade = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    estado = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ENDERECOS", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TB_TIPOS_TELEFONES",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tipo = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TIPOS_TELEFONES", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TB_PESSOAS",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cpf = table.Column<long>(type: "bigint", maxLength: 11, nullable: false),
                    enderecoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PESSOAS", x => x.id);
                    table.ForeignKey(
                        name: "FK_TB_PESSOAS_TB_ENDERECOS_enderecoId",
                        column: x => x.enderecoId,
                        principalTable: "TB_ENDERECOS",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TB_PESSOAS_TELEFONES",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    pessoaId = table.Column<int>(type: "int", nullable: true),
                    telefoneId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PESSOAS_TELEFONES", x => x.id);
                    table.ForeignKey(
                        name: "FK_TB_PESSOAS_TELEFONES_TB_PESSOAS_pessoaId",
                        column: x => x.pessoaId,
                        principalTable: "TB_PESSOAS",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TB_TELEFONES",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ddd = table.Column<int>(type: "int", nullable: false),
                    numero = table.Column<int>(type: "int", maxLength: 9, nullable: false),
                    tipoId = table.Column<int>(type: "int", nullable: true),
                    PessoaTelefoneid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TELEFONES", x => x.id);
                    table.ForeignKey(
                        name: "FK_TB_TELEFONES_TB_PESSOAS_TELEFONES_PessoaTelefoneid",
                        column: x => x.PessoaTelefoneid,
                        principalTable: "TB_PESSOAS_TELEFONES",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_TB_TELEFONES_TB_TIPOS_TELEFONES_tipoId",
                        column: x => x.tipoId,
                        principalTable: "TB_TIPOS_TELEFONES",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PESSOAS_cpf",
                table: "TB_PESSOAS",
                column: "cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_PESSOAS_enderecoId",
                table: "TB_PESSOAS",
                column: "enderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PESSOAS_TELEFONES_pessoaId",
                table: "TB_PESSOAS_TELEFONES",
                column: "pessoaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_TELEFONES_PessoaTelefoneid",
                table: "TB_TELEFONES",
                column: "PessoaTelefoneid");

            migrationBuilder.CreateIndex(
                name: "IX_TB_TELEFONES_tipoId",
                table: "TB_TELEFONES",
                column: "tipoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_TELEFONES");

            migrationBuilder.DropTable(
                name: "TB_PESSOAS_TELEFONES");

            migrationBuilder.DropTable(
                name: "TB_TIPOS_TELEFONES");

            migrationBuilder.DropTable(
                name: "TB_PESSOAS");

            migrationBuilder.DropTable(
                name: "TB_ENDERECOS");
        }
    }
}
