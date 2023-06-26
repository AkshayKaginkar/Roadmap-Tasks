using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Session2.Models;
using Session2.Services;
using System.Data;

namespace Session2.Controllers
{
    public class PizzaController : Controller
    {
        readonly IPizzaService _pizzaService;

        public PizzaController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }
        public IActionResult Index()
        {
            List<PizzaListVM> pizzalist = _pizzaService.GetAllPizzas();
            return View(pizzalist);
        }

        [Route("Pizza/Details/{id}")]
        public IActionResult Details(int id)
        {
            Pizza pizza = _pizzaService.GetPizzaById(id);
            return View(pizza);
        }

        [HttpGet]
        public ActionResult AddPizza()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPizza(Pizza pizza) 
        {
            _pizzaService.AddPizza(pizza);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Pizza/Edit/{id:int}")]
        public ActionResult EditPizza(int id)
        {
            Pizza pizza = _pizzaService.GetPizzaById(id);
            return View(pizza);
        }

        [HttpPost]
        [Route("Pizza/Edit/{id:int}")]
        public ActionResult EditPizza(Pizza pizza)
        {
            _pizzaService.EditPizza(pizza);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Pizza/Delete/{id:int}")]        
        public ActionResult DeletePizza(int id)
        {
            Pizza pizza = _pizzaService.GetPizzaById(id);
            return View(pizza);
        }

        [HttpPost]
        [Route("Pizza/Delete/{id:int}")]
        public ActionResult DeletePizza(Pizza pizza)
        {
            _pizzaService.DeletePizza(pizza);
            return RedirectToAction("Index");
        }

    }
}
