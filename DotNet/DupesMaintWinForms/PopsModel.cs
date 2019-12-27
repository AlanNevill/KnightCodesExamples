namespace DupesMaintWinForms
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PopsModel : DbContext
    {
        public PopsModel()
            : base(@"Data Source=(localDB)\MSSQLLocalDB;Initial Catalog=pops;Integrated Security=True")
        {
        }

        public virtual DbSet<CheckSum> CheckSums { get; set; }
        public virtual DbSet<CheckSumDup> CheckSumDups { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CheckSum>()
                .Property(e => e.SHA)
                .IsUnicode(false);

            modelBuilder.Entity<CheckSum>()
                .Property(e => e.Folder)
                .IsUnicode(false);

            modelBuilder.Entity<CheckSum>()
                .Property(e => e.TheFileName)
                .IsUnicode(false);

            modelBuilder.Entity<CheckSum>()
                .Property(e => e.FileExt)
                .IsUnicode(false);

            modelBuilder.Entity<CheckSum>()
                .Property(e => e.Notes)
                .IsUnicode(false);

            modelBuilder.Entity<CheckSumDup>()
                .Property(e => e.SHA)
                .IsUnicode(false);

            modelBuilder.Entity<CheckSumDup>()
                .Property(e => e.ToDelete)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
