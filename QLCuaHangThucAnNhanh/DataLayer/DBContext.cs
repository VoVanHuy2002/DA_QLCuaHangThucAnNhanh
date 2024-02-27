using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DataLayer
{
    public partial class DBContext : DbContext
    {
        public DBContext()
            : base("name=DBContext")
        {
        }

        public virtual DbSet<customer> customers { get; set; }
        public virtual DbSet<food> foods { get; set; }
        public virtual DbSet<order_items> order_items { get; set; }
        public virtual DbSet<order> orders { get; set; }
        public virtual DbSet<role> roles { get; set; }
        public virtual DbSet<table_order> table_order { get; set; }
        public virtual DbSet<user_account> user_account { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<customer>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .Property(e => e.status)
                .IsUnicode(false);

            modelBuilder.Entity<food>()
                .Property(e => e.status)
                .IsUnicode(false);

            modelBuilder.Entity<table_order>()
                .Property(e => e.available)
                .IsUnicode(false);

            modelBuilder.Entity<table_order>()
                .Property(e => e.status)
                .IsUnicode(false);

            modelBuilder.Entity<user_account>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<user_account>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<user_account>()
                .Property(e => e.status)
                .IsUnicode(false);

            modelBuilder.Entity<user_account>()
                .HasMany(e => e.orders)
                .WithOptional(e => e.user_account)
                .HasForeignKey(e => e.employe_id);
        }
    }
}
