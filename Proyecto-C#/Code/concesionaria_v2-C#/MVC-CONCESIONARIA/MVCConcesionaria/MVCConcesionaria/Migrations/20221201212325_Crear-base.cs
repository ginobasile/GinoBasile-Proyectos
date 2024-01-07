using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCConcesionaria.Migrations
{
    public partial class Crearbase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VentaAuto_Autos_autoID",
                table: "VentaAuto");

            migrationBuilder.DropForeignKey(
                name: "FK_VentaAuto_Persona_clientePersonaId",
                table: "VentaAuto");

            migrationBuilder.DropForeignKey(
                name: "FK_VentaCamioneta_Camionetas_camionetaID",
                table: "VentaCamioneta");

            migrationBuilder.DropForeignKey(
                name: "FK_VentaCamioneta_Persona_clientePersonaId",
                table: "VentaCamioneta");

            migrationBuilder.DropForeignKey(
                name: "FK_VentaMoto_Persona_clientePersonaId",
                table: "VentaMoto");

            migrationBuilder.DropForeignKey(
                name: "FK_VentaMoto_Motos_motoID",
                table: "VentaMoto");

            migrationBuilder.DropIndex(
                name: "IX_VentaMoto_clientePersonaId",
                table: "VentaMoto");

            migrationBuilder.DropIndex(
                name: "IX_VentaMoto_motoID",
                table: "VentaMoto");

            migrationBuilder.DropIndex(
                name: "IX_VentaCamioneta_camionetaID",
                table: "VentaCamioneta");

            migrationBuilder.DropIndex(
                name: "IX_VentaCamioneta_clientePersonaId",
                table: "VentaCamioneta");

            migrationBuilder.DropIndex(
                name: "IX_VentaAuto_autoID",
                table: "VentaAuto");

            migrationBuilder.DropIndex(
                name: "IX_VentaAuto_clientePersonaId",
                table: "VentaAuto");

            migrationBuilder.DropColumn(
                name: "clientePersonaId",
                table: "VentaMoto");

            migrationBuilder.DropColumn(
                name: "motoID",
                table: "VentaMoto");

            migrationBuilder.DropColumn(
                name: "camionetaID",
                table: "VentaCamioneta");

            migrationBuilder.DropColumn(
                name: "clientePersonaId",
                table: "VentaCamioneta");

            migrationBuilder.DropColumn(
                name: "autoID",
                table: "VentaAuto");

            migrationBuilder.DropColumn(
                name: "clientePersonaId",
                table: "VentaAuto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "clientePersonaId",
                table: "VentaMoto",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "motoID",
                table: "VentaMoto",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "camionetaID",
                table: "VentaCamioneta",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "clientePersonaId",
                table: "VentaCamioneta",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "autoID",
                table: "VentaAuto",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "clientePersonaId",
                table: "VentaAuto",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VentaMoto_clientePersonaId",
                table: "VentaMoto",
                column: "clientePersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_VentaMoto_motoID",
                table: "VentaMoto",
                column: "motoID");

            migrationBuilder.CreateIndex(
                name: "IX_VentaCamioneta_camionetaID",
                table: "VentaCamioneta",
                column: "camionetaID");

            migrationBuilder.CreateIndex(
                name: "IX_VentaCamioneta_clientePersonaId",
                table: "VentaCamioneta",
                column: "clientePersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_VentaAuto_autoID",
                table: "VentaAuto",
                column: "autoID");

            migrationBuilder.CreateIndex(
                name: "IX_VentaAuto_clientePersonaId",
                table: "VentaAuto",
                column: "clientePersonaId");

            migrationBuilder.AddForeignKey(
                name: "FK_VentaAuto_Autos_autoID",
                table: "VentaAuto",
                column: "autoID",
                principalTable: "Autos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VentaAuto_Persona_clientePersonaId",
                table: "VentaAuto",
                column: "clientePersonaId",
                principalTable: "Persona",
                principalColumn: "PersonaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VentaCamioneta_Camionetas_camionetaID",
                table: "VentaCamioneta",
                column: "camionetaID",
                principalTable: "Camionetas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VentaCamioneta_Persona_clientePersonaId",
                table: "VentaCamioneta",
                column: "clientePersonaId",
                principalTable: "Persona",
                principalColumn: "PersonaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VentaMoto_Persona_clientePersonaId",
                table: "VentaMoto",
                column: "clientePersonaId",
                principalTable: "Persona",
                principalColumn: "PersonaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VentaMoto_Motos_motoID",
                table: "VentaMoto",
                column: "motoID",
                principalTable: "Motos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
