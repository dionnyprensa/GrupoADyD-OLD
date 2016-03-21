using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GrupoADyD.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string Hometown { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<DetailedSale> DetailedSale { get; set; }

        public ApplicationDbContext() : base("GrupoADyD"/*, throwIfV1Schema: false*/)
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ApplicationDbContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin>().HasKey(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });

            modelBuilder.Entity<DetailedSale>()
                .HasRequired(d => d.Sale)
                .WithRequiredPrincipal(d => d.DetailedSale);

            modelBuilder.Entity<Product>()
                .Property(p => p.RowVersion)
                .IsConcurrencyToken();

            modelBuilder.Entity<Sale>()
                .Property(p => p.RowVersion)
                .IsConcurrencyToken();

            modelBuilder.Entity<Client>()
                .Property(p => p.RowVersion)
                .IsConcurrencyToken();
            //modelBuilder.Entity<Sale>()
            //    .HasRequired(c => c.Sales)
            //    .WithRequired(s => s.Client);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}