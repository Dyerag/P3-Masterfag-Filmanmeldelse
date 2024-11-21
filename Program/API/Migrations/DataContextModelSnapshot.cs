﻿// <auto-generated />
using System;
using FilmAnmeldelseApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FilmAnmeldelseApi.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FilmAnmeldelseApi.Models.Anmeldelser", b =>
                {
                    b.Property<int>("FilmId")
                        .HasColumnType("int")
                        .HasColumnName("FilmID");

                    b.Property<int>("AnmelderId")
                        .HasColumnType("int")
                        .HasColumnName("AnmelderID");

                    b.Property<DateOnly>("Anmeldsdato")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int>("Bedømmelse")
                        .HasColumnType("int");

                    b.Property<string>("Begrundelse")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Titel")
                        .HasMaxLength(42)
                        .HasColumnType("nvarchar(42)");

                    b.HasKey("FilmId", "AnmelderId")
                        .HasName("PK__Anmeldel__20E4DA6C24B6FAD6");

                    b.HasIndex("AnmelderId");

                    b.ToTable("Anmeldelser", (string)null);
                });

            modelBuilder.Entity("FilmAnmeldelseApi.Models.Direktør", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Fuldenavn")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id")
                        .HasName("PK__Instrukt__3214EC278815F81A");

                    b.ToTable("Direktør", (string)null);
                });

            modelBuilder.Entity("FilmAnmeldelseApi.Models.Film", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Aldersgrænse")
                        .HasColumnType("int");

                    b.Property<decimal>("Gennemsnitsanmeldelse")
                        .HasColumnType("decimal(2, 1)");

                    b.Property<byte[]>("Plakat")
                        .IsRequired()
                        .HasColumnType("image");

                    b.Property<TimeOnly>("Spilletid")
                        .HasColumnType("time");

                    b.Property<string>("Synopse")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Titel")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<DateOnly>("Udgivelsesdato")
                        .HasColumnType("date");

                    b.HasKey("Id")
                        .HasName("PK__Film__3214EC2746F236D8");

                    b.ToTable("Film", (string)null);
                });

            modelBuilder.Entity("FilmAnmeldelseApi.Models.FilmDirektør", b =>
                {
                    b.Property<int>("FilmId")
                        .HasColumnType("int")
                        .HasColumnName("FilmID");

                    b.Property<int>("DirektørId")
                        .HasColumnType("int")
                        .HasColumnName("DirektørID");

                    b.HasKey("FilmId", "DirektørId");

                    b.HasIndex("DirektørId");

                    b.ToTable("FilmDirektør", (string)null);
                });

            modelBuilder.Entity("FilmAnmeldelseApi.Models.FilmForfatter", b =>
                {
                    b.Property<int>("FilmId")
                        .HasColumnType("int")
                        .HasColumnName("FilmID");

                    b.Property<int>("ForfatterId")
                        .HasColumnType("int")
                        .HasColumnName("ForfatterID");

                    b.HasKey("FilmId", "ForfatterId");

                    b.HasIndex("ForfatterId");

                    b.ToTable("FilmForfatter", (string)null);
                });

            modelBuilder.Entity("FilmAnmeldelseApi.Models.FilmGenre", b =>
                {
                    b.Property<int>("FilmId")
                        .HasColumnType("int")
                        .HasColumnName("FilmID");

                    b.Property<string>("Genre1")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("Genre");

                    b.HasKey("FilmId", "Genre1");

                    b.HasIndex("Genre1");

                    b.ToTable("FilmGenre", (string)null);
                });

            modelBuilder.Entity("FilmAnmeldelseApi.Models.FilmKomponist", b =>
                {
                    b.Property<int>("FilmId")
                        .HasColumnType("int")
                        .HasColumnName("FilmID");

                    b.Property<int>("KomponistId")
                        .HasColumnType("int")
                        .HasColumnName("KomponistID");

                    b.HasKey("FilmId", "KomponistId");

                    b.HasIndex("KomponistId");

                    b.ToTable("FilmKomponist", (string)null);
                });

            modelBuilder.Entity("FilmAnmeldelseApi.Models.FilmProducer", b =>
                {
                    b.Property<int>("FilmId")
                        .HasColumnType("int")
                        .HasColumnName("FilmID");

                    b.Property<int>("ProducerId")
                        .HasColumnType("int")
                        .HasColumnName("ProducerID");

                    b.HasKey("FilmId", "ProducerId");

                    b.HasIndex("ProducerId");

                    b.ToTable("FilmProducer", (string)null);
                });

            modelBuilder.Entity("FilmAnmeldelseApi.Models.Forfatter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Fuldenavn")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id")
                        .HasName("PK__Forfatte__3214EC27D59A45F7");

                    b.ToTable("Forfatter", (string)null);
                });

            modelBuilder.Entity("FilmAnmeldelseApi.Models.Genre", b =>
                {
                    b.Property<string>("Genre1")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("Genre");

                    b.HasKey("Genre1")
                        .HasName("PK__Genre__F1410CF224D9D7C1");

                    b.HasIndex(new[] { "Genre1" }, "UQ__Genre__F1410CF3E230D5EB")
                        .IsUnique();

                    b.ToTable("Genre", (string)null);
                });

            modelBuilder.Entity("FilmAnmeldelseApi.Models.Kommentar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AnmeldelsensAnmelderId")
                        .HasColumnType("int")
                        .HasColumnName("AnmeldelsensAnmelderID");

                    b.Property<int>("AnmeldelsensFilmId")
                        .HasColumnType("int")
                        .HasColumnName("AnmeldelsensFilmID");

                    b.Property<string>("Kommentar1")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)")
                        .HasColumnName("Kommentar");

                    b.Property<DateOnly>("KommentarDato")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int>("KommentatorId")
                        .HasColumnType("int")
                        .HasColumnName("kommentatorID");

                    b.HasKey("Id")
                        .HasName("PK__Kommenta__3214EC2776F61ECF");

                    b.HasIndex("KommentatorId");

                    b.HasIndex("AnmeldelsensAnmelderId", "AnmeldelsensFilmId");

                    b.ToTable("Kommentar", (string)null);
                });

            modelBuilder.Entity("FilmAnmeldelseApi.Models.Komponist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Fuldenavn")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id")
                        .HasName("PK__Komponis__3214EC2782083175");

                    b.ToTable("Komponist", (string)null);
                });

            modelBuilder.Entity("FilmAnmeldelseApi.Models.Producer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Fuldenavn")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id")
                        .HasName("PK__Producer__3214EC27038A45DF");

                    b.ToTable("Producer", (string)null);
                });

            modelBuilder.Entity("FilmAnmeldelseApi.Models.Rolle", b =>
                {
                    b.Property<int>("FilmId")
                        .HasColumnType("int")
                        .HasColumnName("FilmID");

                    b.Property<string>("Rollenavn")
                        .HasMaxLength(31)
                        .HasColumnType("nvarchar(31)");

                    b.HasKey("FilmId", "Rollenavn")
                        .HasName("PK__Rolle__362D0EEF34CB2A50");

                    b.ToTable("Rolle", (string)null);
                });

            modelBuilder.Entity("FilmAnmeldelseApi.Models.Skuespiller", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Fuldenavn")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id")
                        .HasName("PK__Skuespil__3214EC27680C70A5");

                    b.ToTable("Skuespiller", (string)null);
                });

            modelBuilder.Entity("FilmAnmeldelseApi.Models.SkuespillerRolle", b =>
                {
                    b.Property<int>("FilmId")
                        .HasColumnType("int")
                        .HasColumnName("FilmID");

                    b.Property<string>("Rollenavn")
                        .HasMaxLength(31)
                        .HasColumnType("nvarchar(31)");

                    b.Property<int>("SkuespillerId")
                        .HasColumnType("int")
                        .HasColumnName("SkuespillerID");

                    b.Property<string>("RolleType")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("FilmId", "Rollenavn", "SkuespillerId")
                        .HasName("PK__Skuespil__CA96AC10E2A1A6B6");

                    b.HasIndex("SkuespillerId");

                    b.ToTable("SkuespillerRolle", (string)null);
                });

            modelBuilder.Entity("FilmAnmeldelseApi.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adgangskode")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<byte[]>("Billede")
                        .HasColumnType("image");

                    b.Property<string>("Brugernavn")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<DateOnly>("Oprettelsesdato")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasDefaultValueSql("(getdate())");

                    b.HasKey("Id")
                        .HasName("PK__User__3214EC2750F10E59");

                    b.HasIndex(new[] { "Brugernavn" }, "UQ__User__6BE4ADA0CFE63EE7")
                        .IsUnique();

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("FilmAnmeldelseApi.Models.Anmeldelser", b =>
                {
                    b.HasOne("FilmAnmeldelseApi.Models.User", "Anmelder")
                        .WithMany("Anmeldelsers")
                        .HasForeignKey("AnmelderId")
                        .IsRequired()
                        .HasConstraintName("FK__Anmeldels__Anmel__5441852A");

                    b.HasOne("FilmAnmeldelseApi.Models.Film", "Film")
                        .WithMany("Anmeldelsers")
                        .HasForeignKey("FilmId")
                        .IsRequired()
                        .HasConstraintName("FK__Anmeldels__FilmI__5535A963");

                    b.Navigation("Anmelder");

                    b.Navigation("Film");
                });

            modelBuilder.Entity("FilmAnmeldelseApi.Models.FilmDirektør", b =>
                {
                    b.HasOne("FilmAnmeldelseApi.Models.Direktør", "Direktør")
                        .WithMany("FilmDirektørs")
                        .HasForeignKey("DirektørId")
                        .IsRequired();

                    b.HasOne("FilmAnmeldelseApi.Models.Film", "Film")
                        .WithMany("FilmDirektørs")
                        .HasForeignKey("FilmId")
                        .IsRequired();

                    b.Navigation("Direktør");

                    b.Navigation("Film");
                });

            modelBuilder.Entity("FilmAnmeldelseApi.Models.FilmForfatter", b =>
                {
                    b.HasOne("FilmAnmeldelseApi.Models.Film", "Film")
                        .WithMany("FilmForfatters")
                        .HasForeignKey("FilmId")
                        .IsRequired();

                    b.HasOne("FilmAnmeldelseApi.Models.Forfatter", "Forfatter")
                        .WithMany("FilmForfatters")
                        .HasForeignKey("ForfatterId")
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("Forfatter");
                });

            modelBuilder.Entity("FilmAnmeldelseApi.Models.FilmGenre", b =>
                {
                    b.HasOne("FilmAnmeldelseApi.Models.Film", "Film")
                        .WithMany("FilmGenres")
                        .HasForeignKey("FilmId")
                        .IsRequired();

                    b.HasOne("FilmAnmeldelseApi.Models.Genre", "Genre")
                        .WithMany("FilmGenres")
                        .HasForeignKey("Genre1")
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("FilmAnmeldelseApi.Models.FilmKomponist", b =>
                {
                    b.HasOne("FilmAnmeldelseApi.Models.Film", "Film")
                        .WithMany("FilmKomponists")
                        .HasForeignKey("FilmId")
                        .IsRequired();

                    b.HasOne("FilmAnmeldelseApi.Models.Komponist", "Komponist")
                        .WithMany("FilmKomponists")
                        .HasForeignKey("KomponistId")
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("Komponist");
                });

            modelBuilder.Entity("FilmAnmeldelseApi.Models.FilmProducer", b =>
                {
                    b.HasOne("FilmAnmeldelseApi.Models.Film", "Film")
                        .WithMany("FilmProducers")
                        .HasForeignKey("FilmId")
                        .IsRequired();

                    b.HasOne("FilmAnmeldelseApi.Models.Producer", "Producer")
                        .WithMany("FilmProducers")
                        .HasForeignKey("ProducerId")
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("Producer");
                });

            modelBuilder.Entity("FilmAnmeldelseApi.Models.Kommentar", b =>
                {
                    b.HasOne("FilmAnmeldelseApi.Models.User", "Kommentator")
                        .WithMany("Kommentars")
                        .HasForeignKey("KommentatorId")
                        .IsRequired()
                        .HasConstraintName("FK__Kommentar__komme__5CD6CB2B");

                    b.HasOne("FilmAnmeldelseApi.Models.Anmeldelser", "Anmeldelser")
                        .WithMany("Kommentars")
                        .HasForeignKey("AnmeldelsensAnmelderId", "AnmeldelsensFilmId")
                        .IsRequired()
                        .HasConstraintName("FK__Kommentar__5BE2A6F2");

                    b.Navigation("Anmeldelser");

                    b.Navigation("Kommentator");
                });

            modelBuilder.Entity("FilmAnmeldelseApi.Models.Rolle", b =>
                {
                    b.HasOne("FilmAnmeldelseApi.Models.Film", "Film")
                        .WithMany("Rolles")
                        .HasForeignKey("FilmId")
                        .IsRequired()
                        .HasConstraintName("FK__Rolle__FilmID__5DCAEF64");

                    b.Navigation("Film");
                });

            modelBuilder.Entity("FilmAnmeldelseApi.Models.SkuespillerRolle", b =>
                {
                    b.HasOne("FilmAnmeldelseApi.Models.Skuespiller", "Skuespiller")
                        .WithMany("SkuespillerRolles")
                        .HasForeignKey("SkuespillerId")
                        .IsRequired()
                        .HasConstraintName("FK__Skuespill__Skues__5EBF139D");

                    b.HasOne("FilmAnmeldelseApi.Models.Rolle", "Rolle")
                        .WithMany("SkuespillerRolles")
                        .HasForeignKey("FilmId", "Rollenavn")
                        .IsRequired()
                        .HasConstraintName("FK__SkuespillerRolle__5FB337D6");

                    b.Navigation("Rolle");

                    b.Navigation("Skuespiller");
                });

            modelBuilder.Entity("FilmAnmeldelseApi.Models.Anmeldelser", b =>
                {
                    b.Navigation("Kommentars");
                });

            modelBuilder.Entity("FilmAnmeldelseApi.Models.Direktør", b =>
                {
                    b.Navigation("FilmDirektørs");
                });

            modelBuilder.Entity("FilmAnmeldelseApi.Models.Film", b =>
                {
                    b.Navigation("Anmeldelsers");

                    b.Navigation("FilmDirektørs");

                    b.Navigation("FilmForfatters");

                    b.Navigation("FilmGenres");

                    b.Navigation("FilmKomponists");

                    b.Navigation("FilmProducers");

                    b.Navigation("Rolles");
                });

            modelBuilder.Entity("FilmAnmeldelseApi.Models.Forfatter", b =>
                {
                    b.Navigation("FilmForfatters");
                });

            modelBuilder.Entity("FilmAnmeldelseApi.Models.Genre", b =>
                {
                    b.Navigation("FilmGenres");
                });

            modelBuilder.Entity("FilmAnmeldelseApi.Models.Komponist", b =>
                {
                    b.Navigation("FilmKomponists");
                });

            modelBuilder.Entity("FilmAnmeldelseApi.Models.Producer", b =>
                {
                    b.Navigation("FilmProducers");
                });

            modelBuilder.Entity("FilmAnmeldelseApi.Models.Rolle", b =>
                {
                    b.Navigation("SkuespillerRolles");
                });

            modelBuilder.Entity("FilmAnmeldelseApi.Models.Skuespiller", b =>
                {
                    b.Navigation("SkuespillerRolles");
                });

            modelBuilder.Entity("FilmAnmeldelseApi.Models.User", b =>
                {
                    b.Navigation("Anmeldelsers");

                    b.Navigation("Kommentars");
                });
#pragma warning restore 612, 618
        }
    }
}
