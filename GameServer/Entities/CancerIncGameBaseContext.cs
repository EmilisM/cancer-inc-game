using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GameServer.Entities
{
    public sealed class CancerIncGameBaseContext : DbContext
    {
        private static CancerIncGameBaseContext _instance;
        private static readonly object Padlock = new object();

        private readonly string _connectionString;

        public static CancerIncGameBaseContext GetInstance()
        {
            lock (Padlock)
            {
                if (_instance == null)
                {
                    _instance = new CancerIncGameBaseContext(
                        AppConfiguration.Configuration.GetConnectionString("Default"));
                }
            }

            return _instance;
        }

        private CancerIncGameBaseContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbSet<Class> Class { get; set; }
        public DbSet<Enemy> Enemy { get; set; }
        public DbSet<EnemyType> EnemyType { get; set; }
        public DbSet<Tower> Tower { get; set; }
        public DbSet<TowerAttackType> TowerAttackType { get; set; }
        public DbSet<Type> Type { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }

            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Enemy>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Hp).HasColumnName("HP");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EnemyType>(entity =>
            {
                entity.HasKey(e => new { e.EnemyId, e.TypeId })
                    .HasName("PK__EnemyTyp__D40CFBEB2DAB0999");

                entity.Property(e => e.EnemyId).HasColumnName("EnemyID");

                entity.Property(e => e.TypeId).HasColumnName("TypeID");
            });

            modelBuilder.Entity<Tower>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.Effect)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TowerAttackType>(entity =>
            {
                entity.HasKey(e => new { e.TowerId, e.AttackTypeId })
                    .HasName("PK__TowerAtt__C5B1B866E8ABA969");

                entity.Property(e => e.TowerId).HasColumnName("TowerID");

                entity.Property(e => e.AttackTypeId).HasColumnName("AttackTypeID");
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });
        }
    }
}