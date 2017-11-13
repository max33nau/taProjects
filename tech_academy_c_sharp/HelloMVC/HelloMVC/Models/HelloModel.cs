using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloMVC.Models
{
    public class HelloModel
    {
        public static List<Car> GetCars()
        {
            List<Car> cars = new List<Car>()
            {
                new Car { Id = 1, Make = "BMW", Model ="528i"},
                new Car { Id = 2, Make = "Hyandai", Model="Elantra"}
            };

            return cars;
        }


    }

    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }

    }
}