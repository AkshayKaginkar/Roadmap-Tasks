using Session2.Context;
using Session2.Models;

namespace Session2.Repositories
{
    public class PizzaRepository : IPizzaRepository
    {
        readonly ApplicationDbContext _applicationDbContext;

        public PizzaRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public void AddPizza(Pizza pizza)
        {
            _applicationDbContext.Pizzas.Add(pizza);
            _applicationDbContext.SaveChanges();
        }

        public void DeletePizza(Pizza pizza)
        {
            _applicationDbContext.Pizzas.Remove(pizza);
            _applicationDbContext.SaveChanges();
        }

        public void EditPizza(Pizza pizza)
        {
            _applicationDbContext.Pizzas.Update(pizza);
            _applicationDbContext.SaveChanges();
        }

        public List<Pizza> GetAllPizzas()
        {
            return _applicationDbContext.Pizzas.ToList();
        }

        public Pizza GetPizzaById(int id)
        {
            return _applicationDbContext.Pizzas.FirstOrDefault(p => p.Id == id);
        }
    }
}
