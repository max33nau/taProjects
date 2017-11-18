using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCars.Domain
{
    public class CarsManager
    {
        public static List<DTO.CarCopy> GetCars()
        {
            var cars = Persistence.CarsRepository.GetCars();
            return cars;
        }

        public static void AddCar(DTO.CarCopy car)
        {
            Persistence.CarsRepository.AddCar(car);
        }


        public static void RemoveCar(string carId)
        {
            try
            {
                Persistence.CarsRepository.RemoveCar(Guid.Parse(carId));
            } catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
