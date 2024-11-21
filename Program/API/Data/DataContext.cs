using FilmAnmeldelseApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmAnmeldelseApi.Data
{
    // Datacontext kommunikere med databasen ved brug af NuGet pakkerne EF Core: Design, Sqlserver og tools
    // Contexten blev lavet med "database first approach". Derfor blev scaffolding brugt.
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        // Scaffolding tilføjede et s til alle DbSet properties, og den standard bliver fulgt i de manuelt skabet DbSet
        public DbSet<Anmeldelser> Anmeldelsers { get; set; }

        public DbSet<Direktør> Direktørs { get; set; }

        public DbSet<Film> Films { get; set; }

        public DbSet<Forfatter> Forfatters { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Kommentar> Kommentars { get; set; }

        public DbSet<Komponist> Komponists { get; set; }

        public DbSet<Producer> Producers { get; set; }

        public DbSet<Rolle> Rolles { get; set; }

        public DbSet<Skuespiller> Skuespillers { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<SkuespillerRolle> SkuespillerRolles { get; set; }

        /* På nær SkuespillerRolle, blev ingen join tabel lavet af scaffolding.
         * Derfor er de og deres fluent API levet i egen hånd deres.
         * Og Den fluent API der lavede dem i databasen uden en model, er fjernet*/
        public DbSet<FilmDirektør> FilmDirektørs { get; set; }

        public DbSet<FilmForfatter> FilmForfatters { get; set; }

        public DbSet<FilmGenre> FilmGenres { get; set; }
        
        public DbSet<FilmKomponist> FilmKomponists { get; set; }
        
        public DbSet<FilmProducer> FilmProducers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
            => optionsBuilder.UseSqlServer("Data Source=10.0.11.16;Initial Catalog=Filmanmeldelse;User ID=Remote;Password=remote;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anmeldelser>(entity =>
            {
                entity.HasKey(e => new { e.FilmId, e.AnmelderId }).HasName("PK__Anmeldel__20E4DA6C24B6FAD6");

                entity.ToTable("Anmeldelser");

                entity.Property(e => e.FilmId).HasColumnName("FilmID");
                entity.Property(e => e.AnmelderId).HasColumnName("AnmelderID");
                entity.Property(e => e.Anmeldsdato).HasDefaultValueSql("(getdate())");
                entity.Property(e => e.Begrundelse).HasMaxLength(1000);
                entity.Property(e => e.Titel).HasMaxLength(42);

                entity.HasOne(d => d.Anmelder).WithMany(p => p.Anmeldelsers)
                    .HasForeignKey(d => d.AnmelderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Anmeldels__Anmel__5441852A");

                entity.HasOne(d => d.Film).WithMany(p => p.Anmeldelsers)
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
            });

            modelBuilder.Entity<Forfatter>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Forfatte__3214EC27D59A45F7");

                entity.ToTable("Forfatter");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Fuldenavn)
                    .HasMaxLength(30);
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

                entity.HasOne(d => d.Anmeldelser).WithMany(p => p.Kommentars)
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

            modelBuilder.Entity<SkuespillerRolle>(entity =>
            {
                entity.HasKey(e => new { e.FilmId, e.Rollenavn, e.SkuespillerId }).HasName("PK__Skuespil__CA96AC10E2A1A6B6");

                entity.ToTable("SkuespillerRolle");

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

            //Alt herfra er lavet i hånden
            modelBuilder.Entity<FilmDirektør>(entity =>
            {
                entity.HasKey(e => new { e.FilmId, e.DirektørId });

                entity.ToTable("FilmDirektør");

                entity.Property(e => e.FilmId).HasColumnName("FilmID");
                entity.Property(e => e.DirektørId).HasColumnName("DirektørID");

                entity.HasOne(fd => fd.Film).WithMany(f => f.FilmDirektørs)
                .HasForeignKey(fd => fd.FilmId)
                .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(fd => fd.Direktør).WithMany(d => d.FilmDirektørs)
                .HasForeignKey(fd => fd.DirektørId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<FilmForfatter>(entity =>
            {
                entity.HasKey(e => new { e.FilmId, e.ForfatterId });

                entity.ToTable("FilmForfatter");

                entity.Property(e => e.FilmId).HasColumnName("FilmID");
                entity.Property(e => e.ForfatterId).HasColumnName("ForfatterID");

                entity.HasOne(ff => ff.Film).WithMany(f => f.FilmForfatters)
                .HasForeignKey(ff => ff.FilmId)
                .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(ff => ff.Forfatter).WithMany(f => f.FilmForfatters)
                .HasForeignKey(ff => ff.ForfatterId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<FilmGenre>(entity =>
            {
                entity.HasKey(fg => new { fg.FilmId, fg.Genre1 });

                entity.ToTable("FilmGenre");

                entity.Property(fg => fg.FilmId).HasColumnName("FilmID");
                entity.Property(fg => fg.Genre1).HasColumnName("Genre").HasMaxLength(15);

                entity.HasOne(fg => fg.Film).WithMany(f => f.FilmGenres)
                .HasForeignKey(fg => fg.FilmId)
                .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(fg => fg.Genre).WithMany(g => g.FilmGenres)
                .HasForeignKey(fg => fg.Genre1)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<FilmKomponist>(entity =>
            {
                entity.HasKey(fk => new { fk.FilmId, fk.KomponistId });

                entity.ToTable("FilmKomponist");

                entity.Property(fk => fk.FilmId).HasColumnName("FilmID");
                entity.Property(fk => fk.KomponistId).HasColumnName("KomponistID");

                entity.HasOne(fk => fk.Film).WithMany(f => f.FilmKomponists)
                .HasForeignKey(fk => fk.FilmId)
                .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(fk => fk.Komponist).WithMany(k => k.FilmKomponists)
                .HasForeignKey(fk => fk.KomponistId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<FilmProducer>(entity =>
            {
                entity.HasKey(fp => new { fp.FilmId, fp.ProducerId });

                entity.ToTable("FilmProducer");

                entity.Property(fp => fp.FilmId).HasColumnName("FilmID");
                entity.Property(fp => fp.ProducerId).HasColumnName("ProducerID");

                entity.HasOne(fp => fp.Film).WithMany(f => f.FilmProducers)
                .HasForeignKey(fp => fp.FilmId)
                .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(fp => fp.Producer).WithMany(p => p.FilmProducers)
                .HasForeignKey(fp => fp.ProducerId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });
        }
    }
}