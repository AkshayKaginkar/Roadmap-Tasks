using Session2.Models;

namespace Session2.Repositories
{
    public interface IPizzaRepository
    {
        void AddPizza(Pizza pizza);
        void DeletePizza(Pizza pizza);
        void EditPizza(Pizza pizza);
        List<Pizza> GetAllPizzas();
        Pizza GetPizzaById(int id);
    }
}