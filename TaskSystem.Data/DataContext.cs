using Microsoft.EntityFrameworkCore;
using TaskManager.Data.Entities;

namespace TaskManager.Data
{
    public class DataContext : DbContext
    {
        private readonly string _connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\46727\Desktop\ec-utbildning\datalagring\TaskManager\TaskManager.Data\taskmanager_DB.mdf;Integrated Security=True;Connect Timeout=30";

        // Uncertain about these constructors
        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        // sets
        public DbSet<TaskItemEntity> Tasks { get; set; }
        public DbSet<CommentEntity> Comments { get; set; }
        public DbSet<StaffEntity> Staff { get; set; }
        public DbSet<StatusEntity> Status { get; set; }

        // Connecting to Db
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskItemEntity>()
                .HasOne(t => t.Supervisor)
                .WithMany(s => s.SupervisedTasks)
                .HasForeignKey(t => t.SupervisorId);
                //.OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TaskItemEntity>()
                .HasOne(t => t.Reportee)
                .WithMany(s => s.ReportedTasks)
                .HasForeignKey(t => t.ReporteeId);
                //.OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TaskItemEntity>()
                .HasMany(t => t.Comments)
                .WithOne(c => c.TaskItem)
                .HasForeignKey(c => c.TaskItemId);
                //.OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TaskItemEntity>()
                .HasOne(t => t.Status)
                .WithMany()
                .HasForeignKey(t => t.StatusId);
                //.OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StaffEntity>()
                .HasMany(s => s.SupervisedTasks)
                .WithOne(t => t.Supervisor)
                .HasForeignKey(t => t.SupervisorId);
                //.OnDelete(DeleteBehavior.SetNull);


            modelBuilder.Entity<StaffEntity>()
                .HasMany(s => s.ReportedTasks)
                .WithOne(t => t.Reportee)
                .HasForeignKey(t => t.ReporteeId);
                //.OnDelete(DeleteBehavior.NoAction);          
        }
    }
}
