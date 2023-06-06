using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SerijeWebAPP.Models
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        
        public DbSet<Serija> Serija { get; set; }
     
        public DbSet<Kategorija> Kategorija { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<Kategorija>().HasData(
                new Kategorija() { Id = 1, Naziv = "Drama" },
                new Kategorija() { Id = 2, Naziv = "Horror" },
                new Kategorija() { Id = 3, Naziv = "Fantasy" },
                new Kategorija() { Id = 4, Naziv = "SF" },
                new Kategorija(){ Id = 5, Naziv = "Ljubavna"},
                new Kategorija() { Id = 6, Naziv = "Komedija"}
                );

           
            builder.Entity<Serija>().HasData(
           new Serija() { Id = 1, Naziv = "Breaking Bad", StreamingServis = "Netflix", BrojSezona = 5, PotrebnoVrijeme = 56, Preporuka = true, SlikaUrl = "https://conversationsabouther.net/wp-content/uploads/2014/10/Breaking-Bad.jpg", KategorijaId = 1 },
          new Serija() { Id = 2, Naziv = "Supernatural", StreamingServis = "Amazon Prime", BrojSezona = 15, PotrebnoVrijeme = 204, Preporuka = false, SlikaUrl = "https://m.media-amazon.com/images/M/MV5BNzRmZWJhNjUtY2ZkYy00N2MyLWJmNTktOTAwY2VkODVmOGY3XkEyXkFqcGdeQXVyMTkxNjUyNQ@@._V1_FMjpg_UX1000_.jpg", KategorijaId = 1 },
          new Serija() { Id = 3, Naziv = "The office", StreamingServis = "Netflix", BrojSezona = 9, PotrebnoVrijeme = 74, Preporuka = true, SlikaUrl = "https://image.tmdb.org/t/p/w500/5uwetbr0X8BPRy3Wmh63S9EhsiY.jpg", KategorijaId = 6 },
          new Serija() { Id = 4, Naziv = "The Last of Us", StreamingServis = "HBO max", BrojSezona = 1, PotrebnoVrijeme = 10, Preporuka = true, SlikaUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR-Zt4Hcs0H9jo63wCEBLA6VRMBse2xrPwayg&usqp=CAU", KategorijaId = 1 }
               );


        }
    }
}
