using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApp.model;

namespace FilmAnmeldelseApi.Data;
//TODO Hvorfor er der blevet lavet et nyt scaffolding af databasen
public partial class FilmAnmeldelseContext : DbContext
{
    public FilmAnmeldelseContext()
    {
    }

    public FilmAnmeldelseContext(DbContextOptions<FilmAnmeldelseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Anmeldelse> Anmeldelses { get; set; }

    public virtual DbSet<Direktør> Direktørs { get; set; }

    public virtual DbSet<Film> Films { get; set; }

    public virtual DbSet<Forfatter> Forfatters { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Kommentar> Kommentars { get; set; }

    public virtual DbSet<Komponist> Komponists { get; set; }

    public virtual DbSet<Producer> Producers { get; set; }

    public virtual DbSet<Rolle> Rolles { get; set; }

    public virtual DbSet<Skuespiller> Skuespillers { get; set; }

    public virtual DbSet<SkuespillerRolle> SkuespillerRolles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FilmAnmeldelse;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Anmeldelse>(entity =>
        {
            entity.HasKey(e => new { e.FilmId, e.AnmelderId }).HasName("PK__Anmeldel__20E4DA6C24B6FAD6");

            entity.ToTable("Anmeldelse");

            entity.HasIndex(e => e.AnmelderId, "IX_Anmeldelse_AnmelderID");

            entity.Property(e => e.FilmId).HasColumnName("FilmID");
            entity.Property(e => e.AnmelderId).HasColumnName("AnmelderID");
            entity.Property(e => e.Anmeldsdato).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Begrundelse).HasMaxLength(1000);
            entity.Property(e => e.Titel).HasMaxLength(42);

            entity.HasOne(d => d.Anmelder).WithMany(p => p.Anmeldelses)
                .HasForeignKey(d => d.AnmelderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Anmeldels__Anmel__5441852A");

            entity.HasOne(d => d.Film).WithMany(p => p.Anmeldelses)
                .HasForeignKey(d => d.FilmId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Anmeldels__FilmI__5535A963");
        });

        modelBuilder.Entity<Direktør>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Instrukt__3214EC278815F81A");

            entity.ToTable("Direktør");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Fuldenavn).HasMaxLength(64);
        });

        modelBuilder.Entity<Film>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Film__3214EC2746F236D8");

            entity.ToTable("Film");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Gennemsnitsanmeldelse).HasColumnType("decimal(2, 1)");
            entity.Property(e => e.Plakat).HasColumnType("image");
            entity.Property(e => e.Synopse).HasMaxLength(500);
            entity.Property(e => e.Titel).HasMaxLength(120);

            entity.HasMany(d => d.Direktørs).WithMany(p => p.Films)
                .UsingEntity<Dictionary<string, object>>(
                    "FilmDirektør",
                    r => r.HasOne<Direktør>().WithMany()
                        .HasForeignKey("DirektørId")
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    l => l.HasOne<Film>().WithMany()
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    j =>
                    {
                        j.HasKey("FilmId", "DirektørId");
                        j.ToTable("FilmDirektør");
                        j.HasIndex(new[] { "DirektørId" }, "IX_FilmDirektør_DirektørID");
                        j.IndexerProperty<int>("FilmId").HasColumnName("FilmID");
                        j.IndexerProperty<int>("DirektørId").HasColumnName("DirektørID");
                    });

            entity.HasMany(d => d.Forfatters).WithMany(p => p.Films)
                .UsingEntity<Dictionary<string, object>>(
                    "FilmForfatter",
                    r => r.HasOne<Forfatter>().WithMany()
                        .HasForeignKey("ForfatterId")
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    l => l.HasOne<Film>().WithMany()
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    j =>
                    {
                        j.HasKey("FilmId", "ForfatterId");
                        j.ToTable("FilmForfatter");
                        j.HasIndex(new[] { "ForfatterId" }, "IX_FilmForfatter_ForfatterID");
                        j.IndexerProperty<int>("FilmId").HasColumnName("FilmID");
                        j.IndexerProperty<int>("ForfatterId").HasColumnName("ForfatterID");
                    });

            entity.HasMany(d => d.Genres).WithMany(p => p.Films)
                .UsingEntity<Dictionary<string, object>>(
                    "FilmGenre",
                    r => r.HasOne<Genre>().WithMany()
                        .HasForeignKey("Genre")
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    l => l.HasOne<Film>().WithMany()
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    j =>
                    {
                        j.HasKey("FilmId", "Genre");
                        j.ToTable("FilmGenre");
                        j.HasIndex(new[] { "Genre" }, "IX_FilmGenre_Genre");
                        j.IndexerProperty<int>("FilmId").HasColumnName("FilmID");
                        j.IndexerProperty<string>("Genre").HasMaxLength(15);
                    });

            entity.HasMany(d => d.Komponists).WithMany(p => p.Films)
                .UsingEntity<Dictionary<string, object>>(
                    "FilmKomponist",
                    r => r.HasOne<Komponist>().WithMany()
                        .HasForeignKey("KomponistId")
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    l => l.HasOne<Film>().WithMany()
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    j =>
                    {
                        j.HasKey("FilmId", "KomponistId");
                        j.ToTable("FilmKomponist");
                        j.HasIndex(new[] { "KomponistId" }, "IX_FilmKomponist_KomponistID");
                        j.IndexerProperty<int>("FilmId").HasColumnName("FilmID");
                        j.IndexerProperty<int>("KomponistId").HasColumnName("KomponistID");
                    });

            entity.HasMany(d => d.Producers).WithMany(p => p.Films)
                .UsingEntity<Dictionary<string, object>>(
                    "FilmProducer",
                    r => r.HasOne<Producer>().WithMany()
                        .HasForeignKey("ProducerId")
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    l => l.HasOne<Film>().WithMany()
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    j =>
                    {
                        j.HasKey("FilmId", "ProducerId");
                        j.ToTable("FilmProducer");
                        j.HasIndex(new[] { "ProducerId" }, "IX_FilmProducer_ProducerID");
                        j.IndexerProperty<int>("FilmId").HasColumnName("FilmID");
                        j.IndexerProperty<int>("ProducerId").HasColumnName("ProducerID");
                    });
        });

        modelBuilder.Entity<Forfatter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Forfatte__3214EC27D59A45F7");

            entity.ToTable("Forfatter");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Fuldenavn).HasMaxLength(30);
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.Genre1).HasName("PK__Genre__F1410CF224D9D7C1");

            entity.ToTable("Genre");

            entity.HasIndex(e => e.Genre1, "UQ__Genre__F1410CF3E230D5EB").IsUnique();

            entity.Property(e => e.Genre1)
                .HasMaxLength(15)
                .HasColumnName("Genre");
        });

        modelBuilder.Entity<Kommentar>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Kommenta__3214EC2776F61ECF");

            entity.ToTable("Kommentar");

            entity.HasIndex(e => new { e.AnmeldelsensAnmelderId, e.AnmeldelsensFilmId }, "IX_Kommentar_AnmeldelsensAnmelderID_AnmeldelsensFilmID");

            entity.HasIndex(e => e.KommentatorId, "IX_Kommentar_kommentatorID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AnmeldelsensAnmelderId).HasColumnName("AnmeldelsensAnmelderID");
            entity.Property(e => e.AnmeldelsensFilmId).HasColumnName("AnmeldelsensFilmID");
            entity.Property(e => e.Kommentar1)
                .HasMaxLength(1000)
                .HasColumnName("Kommentar");
            entity.Property(e => e.KommentarDato).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.KommentatorId).HasColumnName("kommentatorID");

            entity.HasOne(d => d.Kommentator).WithMany(p => p.Kommentars)
                .HasForeignKey(d => d.KommentatorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Kommentar__komme__5CD6CB2B");

            entity.HasOne(d => d.Anmeldelse).WithMany(p => p.Kommentars)
                .HasForeignKey(d => new { d.AnmeldelsensAnmelderId, d.AnmeldelsensFilmId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Kommentar__5BE2A6F2");
        });

        modelBuilder.Entity<Komponist>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Komponis__3214EC2782083175");

            entity.ToTable("Komponist");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Fuldenavn).HasMaxLength(30);
        });

        modelBuilder.Entity<Producer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Producer__3214EC27038A45DF");

            entity.ToTable("Producer");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Fuldenavn).HasMaxLength(64);
        });

        modelBuilder.Entity<Rolle>(entity =>
        {
            entity.HasKey(e => new { e.FilmId, e.Rollenavn }).HasName("PK__Rolle__362D0EEF34CB2A50");

            entity.ToTable("Rolle");

            entity.Property(e => e.FilmId).HasColumnName("FilmID");
            entity.Property(e => e.Rollenavn).HasMaxLength(31);

            entity.HasOne(d => d.Film).WithMany(p => p.Rolles)
                .HasForeignKey(d => d.FilmId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Rolle__FilmID__5DCAEF64");
        });

        modelBuilder.Entity<Skuespiller>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Skuespil__3214EC27680C70A5");

            entity.ToTable("Skuespiller");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Fuldenavn).HasMaxLength(30);
        });

        modelBuilder.Entity<SkuespillerRolle>(entity =>
        {
            entity.HasKey(e => new { e.FilmId, e.Rollenavn, e.SkuespillerId }).HasName("PK__Skuespil__CA96AC10E2A1A6B6");

            entity.ToTable("SkuespillerRolle");

            entity.HasIndex(e => e.SkuespillerId, "IX_SkuespillerRolle_SkuespillerID");

            entity.Property(e => e.FilmId).HasColumnName("FilmID");
            entity.Property(e => e.Rollenavn).HasMaxLength(31);
            entity.Property(e => e.SkuespillerId).HasColumnName("SkuespillerID");
            entity.Property(e => e.RolleType).HasMaxLength(20);

            entity.HasOne(d => d.Skuespiller).WithMany(p => p.SkuespillerRolles)
                .HasForeignKey(d => d.SkuespillerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Skuespill__Skues__5EBF139D");

            entity.HasOne(d => d.Rolle).WithMany(p => p.SkuespillerRolles)
                .HasForeignKey(d => new { d.FilmId, d.Rollenavn })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SkuespillerRolle__5FB337D6");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC2750F10E59");

            entity.ToTable("User");

            entity.HasIndex(e => e.Brugernavn, "UQ__User__6BE4ADA0CFE63EE7").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Adgangskode).HasMaxLength(30);
            entity.Property(e => e.Billede).HasColumnType("image");
            entity.Property(e => e.Brugernavn).HasMaxLength(64);
            entity.Property(e => e.Oprettelsesdato).HasDefaultValueSql("(getdate())");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
