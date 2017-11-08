using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaBobs.Domain
{
    public class PizzaDetails
    {
        public List<PizzaSize> Sizes { get; private set; }
        public List<PizzaCrust> Crusts { get; private set; }
        public List<PizzaTopping> Toppings { get; private set; }

        public PizzaDetails()
        {
            Sizes = new List<PizzaSize>()
            {
                new PizzaSize()
                { SizeType = DTO.Enums.SizeType.Small, Price = 12,
                  Size = new Size() { Circumfrence = 12, Unit = "inch" }
                },
                new PizzaSize() { SizeType = DTO.Enums.SizeType.Medium, Price = 14,
                    Size = new Size() { Circumfrence = 14, Unit = "inch" }
                },
                new PizzaSize() { SizeType = DTO.Enums.SizeType.Large, Price = 16,
                    Size = new Size() { Circumfrence = 16, Unit = "inch" }
                }
            };

            Crusts = new List<PizzaCrust>()
            {
                new PizzaCrust() { Crust = DTO.Enums.Crust.Regular, Price = 0 },
                new PizzaCrust() { Crust = DTO.Enums.Crust.Thin, Price = 0 },
                new PizzaCrust() { Crust = DTO.Enums.Crust.Thick, Price = 2 }
            };

            Toppings = PizzaToppings.getToppings();
        }
    }


    public class PizzaSize
    {
        public Enum SizeType { get; set; }
        public double Price { get; set; }
        public Size Size { get; set;  }
    }

    public class Size
    {
        public int Circumfrence { get; set; }
        public string Unit { get; set;  }
    }

    public class PizzaCrust
    {
        public Enum Crust { get; set; }
        public double Price { get; set; }
    }

    
}
