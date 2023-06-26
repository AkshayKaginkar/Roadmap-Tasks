using Session2.Models;

namespace Session2.Services
{
    public interface IPizzaService
    {
        void AddPizza(Pizza pizza);
        void DeletePizza(Pizza pizza);
        void EditPizza(Pizza pizza);
        List<PizzaListVM> GetAllPizzas();
        Pizza GetPizzaById(int id);
    }
}