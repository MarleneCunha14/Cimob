﻿// <auto-generated />
using Cimob.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Cimob.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Cimob.Models.AjudaAutenticacao", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Controlador");

                    b.Property<string>("Descricao");

                    b.Property<string>("Metodo");

                    b.HasKey("Id");

                    b.ToTable("AjudaAutenticacao");
                });

            modelBuilder.Entity("Cimob.Models.Candidatura.Candidatura", b =>
                {
                    b.Property<int>("CandidaturaId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<int>("ConcursoId");

                    b.Property<string>("Curso");

                    b.Property<DateTime>("DataCandidatura");

                    b.Property<int>("EstadoCandidaturaId");

                    b.Property<string>("Genero");

                    b.Property<string>("Localidade");

                    b.Property<string>("Morada");

                    b.Property<string>("Telemovel");

                    b.Property<int>("UserId");

                    b.HasKey("CandidaturaId");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("ConcursoId");

                    b.HasIndex("EstadoCandidaturaId");

                    b.ToTable("Candidatura");
                });

            modelBuilder.Entity("Cimob.Models.Candidatura.Concurso", b =>
                {
                    b.Property<int>("ConcursoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao");

                    b.Property<int>("EscolaID");

                    b.Property<string>("Nome");

                    b.Property<int>("PaisId");

                    b.Property<DateTime>("Prazo");

                    b.Property<int>("TipoConcursoId");

                    b.Property<int?>("TipoDeUserId");

                    b.Property<int>("TipoDeUtilizadorId");

                    b.HasKey("ConcursoId");

                    b.HasIndex("EscolaID");

                    b.HasIndex("TipoConcursoId");

                    b.HasIndex("TipoDeUserId");

                    b.ToTable("Concurso");
                });

            modelBuilder.Entity("Cimob.Models.Candidatura.Entrevista", b =>
                {
                    b.Property<int>("EntrevistaId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<int>("CandidaturaId");

                    b.Property<DateTime>("Data");

                    b.Property<int>("EstadoId");

                    b.Property<DateTime>("Hora");

                    b.Property<bool>("jaFoiFeita");

                    b.HasKey("EntrevistaId");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("CandidaturaId");

                    b.ToTable("Entrevista");
                });

            modelBuilder.Entity("Cimob.Models.Candidatura.Escola", b =>
                {
                    b.Property<int>("EscolaId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao");

                    b.Property<string>("Imagem");

                    b.Property<string>("Nome");

                    b.Property<string>("Pais");

                    b.Property<string>("Url");

                    b.HasKey("EscolaId");

                    b.ToTable("Escola");
                });

            modelBuilder.Entity("Cimob.Models.Candidatura.EstadoCandidatura", b =>
                {
                    b.Property<int>("EstadoCandidaturaId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("NomeEstado");

                    b.HasKey("EstadoCandidaturaId");

                    b.ToTable("EstadoCandidatura");
                });

            modelBuilder.Entity("Cimob.Models.Candidatura.Pais", b =>
                {
                    b.Property<int>("PaisId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("NomePais");

                    b.HasKey("PaisId");

                    b.ToTable("Pais");
                });

            modelBuilder.Entity("Cimob.Models.Candidatura.TipoConcurso", b =>
                {
                    b.Property<int>("TipoConcursoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao");

                    b.Property<string>("Imagem");

                    b.Property<string>("Nome");

                    b.HasKey("TipoConcursoId");

                    b.ToTable("TipoConcurso");
                });

            modelBuilder.Entity("Cimob.Models.Contactos.Contacto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Assunto")
                        .IsRequired();

                    b.Property<string>("Descriçao")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Contacto");
                });

            modelBuilder.Entity("Cimob.Models.PontosInteresse.PontoInteresse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("PontoInteresse");
                });

            modelBuilder.Entity("Cimob.Models.Utilizadores.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("DataNascimento");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<int>("EscolaId");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Nome");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<int>("PaisId");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<int>("TipoDeUserId");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("EscolaId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("PaisId");

                    b.HasIndex("TipoDeUserId");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Cimob.Models.Utilizadores.TipoDeUser", b =>
                {
                    b.Property<int>("TipoDeUserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("nomeTipo");

                    b.HasKey("TipoDeUserId");

                    b.ToTable("TipoDeUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Cimob.Models.Candidatura.Candidatura", b =>
                {
                    b.HasOne("Cimob.Models.Utilizadores.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("Cimob.Models.Candidatura.Concurso", "Concurso")
                        .WithMany()
                        .HasForeignKey("ConcursoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Cimob.Models.Candidatura.EstadoCandidatura", "EstadoCandidatura")
                        .WithMany()
                        .HasForeignKey("EstadoCandidaturaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Cimob.Models.Candidatura.Concurso", b =>
                {
                    b.HasOne("Cimob.Models.Candidatura.Escola", "Escola")
                        .WithMany()
                        .HasForeignKey("EscolaID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Cimob.Models.Candidatura.TipoConcurso", "TipoConcurso")
                        .WithMany()
                        .HasForeignKey("TipoConcursoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Cimob.Models.Utilizadores.TipoDeUser", "TipoDeUser")
                        .WithMany()
                        .HasForeignKey("TipoDeUserId");
                });

            modelBuilder.Entity("Cimob.Models.Candidatura.Entrevista", b =>
                {
                    b.HasOne("Cimob.Models.Utilizadores.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("Cimob.Models.Candidatura.Candidatura", "Candidatura")
                        .WithMany()
                        .HasForeignKey("CandidaturaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Cimob.Models.Utilizadores.ApplicationUser", b =>
                {
                    b.HasOne("Cimob.Models.Candidatura.Escola", "Escola")
                        .WithMany()
                        .HasForeignKey("EscolaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Cimob.Models.Candidatura.Pais", "Pais")
                        .WithMany()
                        .HasForeignKey("PaisId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Cimob.Models.Utilizadores.TipoDeUser", "TipoDeUser")
                        .WithMany()
                        .HasForeignKey("TipoDeUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Cimob.Models.Utilizadores.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Cimob.Models.Utilizadores.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Cimob.Models.Utilizadores.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Cimob.Models.Utilizadores.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
