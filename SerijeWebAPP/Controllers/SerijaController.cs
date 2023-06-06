using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SerijeWebAPP.Models;
using SerijeWebAPP.Models;
using SerijeWebAPP.Models;

namespace SerijeWebAPP.Controllers
{
    public class SerijaController : Controller
    {
        private readonly IRepozitorijUpita _repozitorijUpita;
        public SerijaController(IRepozitorijUpita repozitorijUpita)
        {
            _repozitorijUpita = repozitorijUpita;
        }

        public IActionResult Index()
        {
            return View(_repozitorijUpita.PopisSerija());
        }


        public IActionResult Create()
        {
            ViewData["KategorijaId"] = new SelectList(_repozitorijUpita.PopisKategorija(), "Id", "Naziv");
            int sljedeciId = _repozitorijUpita.SljedeciId();
            Serija serija = new Serija() { Id = sljedeciId };
            return View(serija);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Naziv,StreamingServis,BrojSezona,PotrebnoVrijeme,Preporuka,SlikaUrl,KategorijaId")] Serija serija)
        {
            ModelState.Remove("Kategorija");//uklanjanje veze

            if (ModelState.IsValid)
            {
                _repozitorijUpita.Create(serija);
                return RedirectToAction("Index"); // ako je sve ok, tu završava metoda 
            }
            //ako je doslo do greške sljedeci dio se izvrsava
            ViewData["KategorijaId"] = new SelectList(_repozitorijUpita.PopisKategorija(), "Id", "Naziv", serija.KategorijaId);
            return View(serija);

        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            if (id < 1)
            {
                return NotFound();
            }

            Serija serija = _repozitorijUpita.DohvatiSerijuSIdom(id);

            if (serija == null) { return NotFound(); }

            ViewData["KategorijaId"] = new SelectList(_repozitorijUpita.PopisKategorija(), "Id", "Naziv", serija.KategorijaId);
            return View(serija);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, [Bind("Id,Naziv,StreamingServis,BrojSezona,PotrebnoVrijeme,Preporuka,SlikaUrl,KategorijaId")] Serija serija)
        {
            if (id != serija.Id)
            {
                return NotFound();
            }

            ModelState.Remove("Kategorija");

            if (ModelState.IsValid)
            {
                _repozitorijUpita.Update(serija);
                return RedirectToAction("Index");
            }
            //ako je doslo do greške sljedeci dio se izvrsava
            ViewData["KategorijaId"] = new SelectList(_repozitorijUpita.PopisKategorija(), "Id", "Naziv", serija.KategorijaId);
            return View(serija);

        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id < 1)
            {
                return NotFound();
            }

            var serija = _repozitorijUpita.DohvatiSerijuSIdom(Convert.ToInt16(id));

            if (serija == null)
            {
                return NotFound();
            }

            return View(serija);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var serija = _repozitorijUpita.DohvatiSerijuSIdom(id);
            _repozitorijUpita.Delete(serija);
            return RedirectToAction("Index");

        }

        //Trazilica
        public ActionResult SearchIndex(string SerijaZanr, string searchString)
        {
            var zanr = new List<string>();

            var zanrUpit = _repozitorijUpita.PopisKategorija();

            ViewData["SerijaZanr"] = new SelectList(_repozitorijUpita.PopisKategorija(), "Naziv", "Naziv", zanrUpit);

            var serija = _repozitorijUpita.PopisSerija();

            if (!String.IsNullOrWhiteSpace(searchString))
            {
                serija = serija.Where(s => s.Naziv.Contains(searchString, StringComparison.OrdinalIgnoreCase)); // StringComparison.OrdinalIgnoreCase ignorira velika-mala slova 
            }

            if (string.IsNullOrWhiteSpace(SerijaZanr))
                return View(serija);
            else
            {
                return View(serija.Where(x => x.Kategorija.Naziv == SerijaZanr));
            }

        }


    }
}