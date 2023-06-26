using AutoMapper;
using Session2.Models;
using Session2.Repositories;

namespace Session2.Services
{
    public class PizzaService : IPizzaService
    {
        readonly IPizzaRepository _pizzaRepository;
        readonly IMapper _mapper;
        public PizzaService(IPizzaRepository pizzaRepository,IMapper mapper)
        {

            _pizzaRepository = pizzaRepository;
            _mapper = mapper;

        }
        public void AddPizza(Pizza pizza)
        {
            _pizzaRepository.AddPizza(pizza);
        }

        public void DeletePizza(Pizza pizza)
        {
            _pizzaRepository.DeletePizza(pizza);
        }

        public void EditPizza(Pizza pizza)
        {
            _pizzaRepository.EditPizza(pizza);
        }

        public List<PizzaListVM> GetAllPizzas()
        {
            List<PizzaListVM> pizzalist =  _mapper.Map<List<PizzaListVM>>(_pizzaRepository.GetAllPizzas());
            return pizzalist;
        }

        public Pizza GetPizzaById(int id)
        {
           return _pizzaRepository.GetPizzaById(id);
        }
    }
}
