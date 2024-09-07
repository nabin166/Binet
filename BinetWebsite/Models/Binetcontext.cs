using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Data;

namespace BinetWebsite.Models
{
    public partial class Binetcontext : DbContext
    {
        public Binetcontext() : base() { }


        public Binetcontext(DbContextOptions<Binetcontext> options) : base(options)
        {
        }
        public virtual DbSet<Contactpage> Contactpages { get; set; }
        public virtual DbSet<jobApply> JobApplies  { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-SC4NGQA\\SQLEXPRESS;Database=Binetwebsite;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=false;");
            }

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            OnModelCreatingPartial(modelBuilder);
        }


        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);



    }
}
