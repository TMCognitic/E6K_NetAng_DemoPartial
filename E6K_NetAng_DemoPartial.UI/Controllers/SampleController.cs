using E6K_NetAng_DemoPartial.Models.Entities;
using E6K_NetAng_DemoPartial.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace E6K_NetAng_DemoPartial.UI.Controllers
{
    public class SampleController : Controller
    {
        private readonly IPaysRepository _paysRepository;
        private readonly IVilleRepository _villeRepository;

        public SampleController(IPaysRepository paysRepository, IVilleRepository villeRepository)
        {
            _paysRepository = paysRepository;
            _villeRepository = villeRepository;
        }

        public IActionResult Index()
        {
            IEnumerable<Pays> pays = _paysRepository.Get().ToList();

            return View(pays);
        }

        public IActionResult Villes(string id)
        {
            IEnumerable<Ville> villes = _villeRepository.Get(id).ToList();
            return PartialView("_Villes", villes);
        }
    }
}
