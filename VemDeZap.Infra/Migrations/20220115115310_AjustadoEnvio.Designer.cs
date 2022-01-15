﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VemDeZap.Infra.Repositories.Base;

namespace VemDeZap.Infra.Migrations
{
    [DbContext(typeof(VemDeZapContext))]
    [Migration("20220115115310_AjustadoEnvio")]
    partial class AjustadoEnvio
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("VemDeZap.Domain.Entities.Campanha", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("IdUsuario")
                        .HasColumnType("char(36)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(150) CHARACTER SET utf8mb4")
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Campanha");
                });

            modelBuilder.Entity("VemDeZap.Domain.Entities.Contato", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("IdUsuario")
                        .HasColumnType("char(36)");

                    b.Property<int>("Nicho")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(150) CHARACTER SET utf8mb4")
                        .HasMaxLength(150);

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Contato");
                });

            modelBuilder.Entity("VemDeZap.Domain.Entities.Envio", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Enviado")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid?>("IdCampanha")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("IdContato")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("IdGrupo")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("IdCampanha");

                    b.HasIndex("IdContato");

                    b.HasIndex("IdGrupo");

                    b.ToTable("Envio");
                });

            modelBuilder.Entity("VemDeZap.Domain.Entities.Grupo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("IdUsuario")
                        .HasColumnType("char(36)");

                    b.Property<int>("Nicho")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(150) CHARACTER SET utf8mb4")
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Grupo");
                });

            modelBuilder.Entity("VemDeZap.Domain.Entities.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(200) CHARACTER SET utf8mb4")
                        .HasMaxLength(200);

                    b.Property<string>("PrimeiroNome")
                        .IsRequired()
                        .HasColumnType("varchar(150) CHARACTER SET utf8mb4")
                        .HasMaxLength(150);

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("varchar(36) CHARACTER SET utf8mb4")
                        .HasMaxLength(36);

                    b.Property<string>("UltimoNome")
                        .IsRequired()
                        .HasColumnType("varchar(150) CHARACTER SET utf8mb4")
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("VemDeZap.Domain.Entities.Campanha", b =>
                {
                    b.HasOne("VemDeZap.Domain.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario");
                });

            modelBuilder.Entity("VemDeZap.Domain.Entities.Contato", b =>
                {
                    b.HasOne("VemDeZap.Domain.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario");
                });

            modelBuilder.Entity("VemDeZap.Domain.Entities.Envio", b =>
                {
                    b.HasOne("VemDeZap.Domain.Entities.Campanha", "Campanha")
                        .WithMany()
                        .HasForeignKey("IdCampanha");

                    b.HasOne("VemDeZap.Domain.Entities.Contato", "Contato")
                        .WithMany()
                        .HasForeignKey("IdContato");

                    b.HasOne("VemDeZap.Domain.Entities.Grupo", "Grupo")
                        .WithMany()
                        .HasForeignKey("IdGrupo");
                });

            modelBuilder.Entity("VemDeZap.Domain.Entities.Grupo", b =>
                {
                    b.HasOne("VemDeZap.Domain.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario");
                });
#pragma warning restore 612, 618
        }
    }
}
