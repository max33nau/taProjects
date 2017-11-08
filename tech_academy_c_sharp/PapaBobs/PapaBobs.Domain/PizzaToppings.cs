using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaBobs.Domain
{
    public static class PizzaToppings
    {

        public static List<PizzaTopping> getToppings()
        {
            List<PizzaTopping> Toppings = new List<PizzaTopping>()
            {
                new PizzaTopping() { Topping = DTO.Enums.Topping.Sausage, Price = 2 },
                new PizzaTopping() { Topping = DTO.Enums.Topping.Pepperoni, Price = 1.50 },
                new PizzaTopping() { Topping = DTO.Enums.Topping.Onions, Price = 1 },
                new PizzaTopping() { Topping = DTO.Enums.Topping.Green_Peppers, Price = 1 }
            };

            return Toppings;
        }

    }

    public class PizzaTopping
    {
        public Enum Topping { get; set; }
        public double Price { get; set; }
    }
}
