
using LOGIC;
using LOGIC;
using LOGIC.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace WEB.Controllers
{
    public class SalleController : Controller
    {
        private readonly UnitOfWork _Unit;
        public SalleController(IUnitOfWork unit)
        {
            _Unit = unit as UnitOfWork;
        }
        public IActionResult Index()
        {
            dynamic model = new ExpandoObject();
            model.Salle = _Unit.salleRepository.GetAllSalleTP();
            return View("salleDetailView",model);
        }
    }
}
