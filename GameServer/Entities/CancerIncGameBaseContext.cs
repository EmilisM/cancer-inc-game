using Microsoft.EntityFrameworkCore;

namespace GameServer.Entities
{
    public sealed class CancerIncGameBaseContext : DbContext
    {
        private static CancerIncGameBaseContext _instance;
        private static readonly object _padlock = new object();

        public static CancerIncGameBaseContext GetInstance()
        {
            lock (_padlock)
            {
                if (_instance == null)
                {
                    _instance = new CancerIncGameBaseContext();
                }
            }

            return _instance;
        }

        public CancerIncGameBaseContext(DbContextOptions<CancerIncGameBaseContext> options)
            : base(options)
        {
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

            var configuration = 

            optionsBuilder.UseSqlServer();
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

                entity.HasOne(d => d.Enemy)
                    .WithMany(p => p.EnemyType)
                    .HasForeignKey(d => d.EnemyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EnemyType__Enemy__498EEC8D");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.EnemyType)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EnemyType__TypeI__4A8310C6");
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

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Tower)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK__Tower__ClassID__40F9A68C");
            });

            modelBuilder.Entity<TowerAttackType>(entity =>
            {
                entity.HasKey(e => new { e.TowerId, e.AttackTypeId })
                    .HasName("PK__TowerAtt__C5B1B866E8ABA969");

                entity.Property(e => e.TowerId).HasColumnName("TowerID");

                entity.Property(e => e.AttackTypeId).HasColumnName("AttackTypeID");

                entity.HasOne(d => d.AttackType)
                    .WithMany(p => p.TowerAttackType)
                    .HasForeignKey(d => d.AttackTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TowerAtta__Attac__44CA3770");

                entity.HasOne(d => d.Tower)
                    .WithMany(p => p.TowerAttackType)
                    .HasForeignKey(d => d.TowerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TowerAtta__Tower__43D61337");
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