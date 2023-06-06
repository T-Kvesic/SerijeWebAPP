using Microsoft.EntityFrameworkCore;
using SerijeWebAPP.Models;
using TomislavKvesicWebAPP.Models;

namespace TomislavKvesicWebAPP.Models
{
    public class RepozitorijUpita : IRepozitorijUpita
    {
        private readonly AppDbContext _appDbContext;
        public RepozitorijUpita(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Create(Serija serija)
        {
            _appDbContext.Add(serija);
            _appDbContext.SaveChanges();
        }

        public void Delete(Serija serija)
        {
            _appDbContext.Serija.Remove(serija);
            _appDbContext.SaveChanges();
        }

        public Serija DohvatiSerijuSIdom(int id)
        {
            return _appDbContext.Serija
                .Include(k => k.Kategorija)
                .FirstOrDefault(f => f.Id == id);
        }

        public int KategorijaSljedeciId()
        {
            int zadnjiId = _appDbContext.Kategorija
               .Count();

            int sljedeciId = zadnjiId + 1;
            return sljedeciId;
        }
        public IEnumerable<Serija> PopisSerija()
        {

            return _appDbContext.Serija.Include(k => k.Kategorija);
        }

        public int SljedeciId()
        {
            int zadnjiId = _appDbContext.Serija
                .Include(k => k.Kategorija)
                .Max(x => x.Id);

            int sljedeciId = zadnjiId + 1;
            return sljedeciId;
        }

        public void Update(Serija igra)
        {
            _appDbContext.Serija.Update(igra);
            _appDbContext.SaveChanges();
        }




        public void Create(Kategorija kategorija)
        {
            _appDbContext.Add(kategorija);
            _appDbContext.SaveChanges();
        }

       

        public void Delete(Kategorija kategorija)
        {
            _appDbContext.Kategorija.Remove(kategorija);
            _appDbContext.SaveChanges();
        }

        
        

        public Kategorija DohvatiKategorijuSIdom(int id)
        {
            return _appDbContext.Kategorija.Find(id);
        }

        

       

        public IEnumerable<Kategorija> PopisKategorija()
        {
            return _appDbContext.Kategorija;
        }

        

      

        public void Update(Kategorija kategorija)
        {
            _appDbContext.Kategorija.Update(kategorija);
            _appDbContext.SaveChanges();
        }

        



            }
        } 
