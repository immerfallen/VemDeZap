using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VemDeZap.Infra.Migrations
{
    public partial class AjustadoEnvio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Envio_Campanha_CampanhaId",
                table: "Envio");

            migrationBuilder.DropForeignKey(
                name: "FK_Envio_Contato_ContatoId",
                table: "Envio");

            migrationBuilder.DropForeignKey(
                name: "FK_Envio_Grupo_GrupoId",
                table: "Envio");

            migrationBuilder.DropIndex(
                name: "IX_Envio_CampanhaId",
                table: "Envio");

            migrationBuilder.DropIndex(
                name: "IX_Envio_ContatoId",
                table: "Envio");

            migrationBuilder.DropIndex(
                name: "IX_Envio_GrupoId",
                table: "Envio");

            migrationBuilder.DropColumn(
                name: "CampanhaId",
                table: "Envio");

            migrationBuilder.DropColumn(
                name: "ContatoId",
                table: "Envio");

            migrationBuilder.DropColumn(
                name: "GrupoId",
                table: "Envio");

            migrationBuilder.AddColumn<Guid>(
                name: "IdCampanha",
                table: "Envio",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdContato",
                table: "Envio",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdGrupo",
                table: "Envio",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Envio_IdCampanha",
                table: "Envio",
                column: "IdCampanha");

            migrationBuilder.CreateIndex(
                name: "IX_Envio_IdContato",
                table: "Envio",
                column: "IdContato");

            migrationBuilder.CreateIndex(
                name: "IX_Envio_IdGrupo",
                table: "Envio",
                column: "IdGrupo");

            migrationBuilder.AddForeignKey(
                name: "FK_Envio_Campanha_IdCampanha",
                table: "Envio",
                column: "IdCampanha",
                principalTable: "Campanha",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Envio_Contato_IdContato",
                table: "Envio",
                column: "IdContato",
                principalTable: "Contato",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Envio_Grupo_IdGrupo",
                table: "Envio",
                column: "IdGrupo",
                principalTable: "Grupo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Envio_Campanha_IdCampanha",
                table: "Envio");

            migrationBuilder.DropForeignKey(
                name: "FK_Envio_Contato_IdContato",
                table: "Envio");

            migrationBuilder.DropForeignKey(
                name: "FK_Envio_Grupo_IdGrupo",
                table: "Envio");

            migrationBuilder.DropIndex(
                name: "IX_Envio_IdCampanha",
                table: "Envio");

            migrationBuilder.DropIndex(
                name: "IX_Envio_IdContato",
                table: "Envio");

            migrationBuilder.DropIndex(
                name: "IX_Envio_IdGrupo",
                table: "Envio");

            migrationBuilder.DropColumn(
                name: "IdCampanha",
                table: "Envio");

            migrationBuilder.DropColumn(
                name: "IdContato",
                table: "Envio");

            migrationBuilder.DropColumn(
                name: "IdGrupo",
                table: "Envio");

            migrationBuilder.AddColumn<Guid>(
                name: "CampanhaId",
                table: "Envio",
                type: "char(36)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ContatoId",
                table: "Envio",
                type: "char(36)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GrupoId",
                table: "Envio",
                type: "char(36)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Envio_CampanhaId",
                table: "Envio",
                column: "CampanhaId");

            migrationBuilder.CreateIndex(
                name: "IX_Envio_ContatoId",
                table: "Envio",
                column: "ContatoId");

            migrationBuilder.CreateIndex(
                name: "IX_Envio_GrupoId",
                table: "Envio",
                column: "GrupoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Envio_Campanha_CampanhaId",
                table: "Envio",
                column: "CampanhaId",
                principalTable: "Campanha",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Envio_Contato_ContatoId",
                table: "Envio",
                column: "ContatoId",
                principalTable: "Contato",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Envio_Grupo_GrupoId",
                table: "Envio",
                column: "GrupoId",
                principalTable: "Grupo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
