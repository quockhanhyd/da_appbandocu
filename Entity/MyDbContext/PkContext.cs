using Microsoft.EntityFrameworkCore;

namespace DA_AppBanDoCu.Entity.MyDbContext
{
    public class PkContext : DbContext
    {
        public PkContext() : base()
        {
        }

        public DbSet<CartEntity> Carts { get; set; }
        public DbSet<CategoryEntity> Categorys { get; set; }
        public DbSet<ChatEntity> Chats { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<OrderDetailEntity> OrderDetails { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<ProductFavoriteEntity> ProductFavorites { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<UserAddressEntity> UserAddresses { get; set; }
        public DbSet<UserEntity> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;database=DA_AppBanDoCu;user=root;password=123456",
                new MySqlServerVersion(new Version(8, 0, 37)));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartEntity>(e =>
            {
                e.HasKey(ex => ex.CartID);
                e.Property(ex => ex.CartID).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<CategoryEntity>(e =>
            {
                e.HasKey(ex => ex.CategoryID);
                e.Property(ex => ex.CategoryID).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<ChatEntity>(e =>
            {
                e.HasKey(ex => ex.ChatID);
                e.Property(ex => ex.ChatID).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<OrderDetailEntity>(e =>
            {
                e.HasKey(ex => ex.ID);
                e.Property(ex => ex.ID).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<OrderEntity>(e =>
            {
                e.HasKey(ex => ex.OrderID);
                e.Property(ex => ex.OrderID).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<ProductEntity>(e =>
            {
                e.HasKey(ex => ex.ProductID);
                e.Property(ex => ex.ProductID).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<ProductFavoriteEntity>(e =>
            {
                e.HasKey(ex => ex.ProductFavoriteID);
                e.Property(ex => ex.ProductFavoriteID).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<RoleEntity>(e =>
            {
                e.HasKey(ex => ex.RoleID);
                e.Property(ex => ex.RoleID).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<UserEntity>(e =>
            {
                e.HasKey(ex => ex.UserID);
                e.Property(ex => ex.UserID).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<UserAddressEntity>(e =>
            {
                e.HasKey(ex => ex.UserAddressID);
                e.Property(ex => ex.UserAddressID).ValueGeneratedOnAdd();
            });
            //modelBuilder.Entity<ExamCateEntity>().HasMany(e => e.Examinations).WithOne(e => e.ExamCate).HasForeignKey(e => e.ExamCateID).IsRequired();
            //modelBuilder.Entity<MedicineCateEntity>().HasMany(e => e.Medicines).WithOne(e => e.MedicineCate).HasForeignKey(e => e.MedicineCateID).IsRequired();
            //modelBuilder.Entity<UserEntity>().HasOne(e => e.Role).WithMany(e => e.Users).IsRequired();
            //modelBuilder.Entity<UserEntity>().HasOne(e => e.Position).WithMany(e => e.Users).IsRequired();
            //modelBuilder.Entity<UserEntity>().HasOne(e => e.Specialist).WithMany(e => e.Users).IsRequired();
            //modelBuilder.Entity<UserEntity>().HasOne(e => e.Clinic).WithMany(e => e.Users).IsRequired();
            //modelBuilder.Entity<ExamResultEntity>().HasOne(e => e.Patient);
            //modelBuilder.Entity<ExamResultEntity>().HasOne(e => e.ExamSchedule);
            //modelBuilder.Entity<ExamResultEntity>().HasMany(e => e.ExamResultDetails);
            //modelBuilder.Entity<ExamResultEntity>().HasMany(e => e.ExamResultMedicines);
            //modelBuilder.Entity<ExamResultDetailEntity>().HasOne(e => e.Examination);
            //modelBuilder.Entity<ExamResultMedicineEntity>().HasOne(e => e.Medicine);

            base.OnModelCreating(modelBuilder);
        }
    }
}
