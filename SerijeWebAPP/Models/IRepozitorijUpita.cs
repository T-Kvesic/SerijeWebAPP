using SerijeWebAPP.Models;

namespace SerijeWebAPP.Models
{
    public interface IRepozitorijUpita
    {
       
        
        IEnumerable<Serija> PopisSerija(); // R - read
        void Create(Serija serija); // C - insert tj create
        void Delete(Serija serija); // D - delete
        void Update(Serija serija); //U - update
        int SljedeciId();
        int KategorijaSljedeciId();

        Serija DohvatiSerijuSIdom(int id);

       


        IEnumerable<Kategorija> PopisKategorija();
        void Create(Kategorija kategorija);
        void Delete(Kategorija kategorija);
        void Update(Kategorija kategorija);

        Kategorija DohvatiKategorijuSIdom(int id);


    }
}
