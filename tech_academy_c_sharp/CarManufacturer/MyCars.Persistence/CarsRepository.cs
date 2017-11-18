using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCars.Persistence
{
    public class CarsRepository
    {
        public static List<DTO.CarCopy> GetCars()
        {
            var db = new MyCarsEntities();
            var dbCars = db.Cars.ToList();

            var dtoCars = new List<DTO.CarCopy>();

            foreach (var dbCar in dbCars)
            {
                var dtoCar = new DTO.CarCopy()
                {
                    CarId = dbCar.CarId,
                    Make = dbCar.Make,
                    Model = dbCar.Model,
                    Color = dbCar.Color,
                    Year = dbCar.Year
                };

                dtoCars.Add(dtoCar);
            }

            return dtoCars;
        }

        public static void AddCar(DTO.CarCopy newCar)
        {
            if (!validNewCar(newCar))
                throw new Exception("Invalid car for database insertion.");

            Car dbOrder = new Car()
            {
                CarId = newCar.CarId,
                Make = newCar.Make,
                Model = newCar.Model,
                Color = newCar.Color,
                Year = newCar.Year
            };

            using (var db = new MyCarsEntities())
            {
                try
                {
                    db.Cars.Add(dbOrder);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    // Log the exception.
                    throw ex;
                }
            }
        }

        public static void RemoveCar(Guid carId)
        {
            try
            {
                var db = new MyCarsEntities();
                var dbCar = db.Cars.SingleOrDefault(o => o.CarId == carId);
                if (dbCar != null)
                {
                    db.Cars.Remove(dbCar);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private static bool validNewCar(DTO.CarCopy newCar)
        {
            if (emptyString(newCar.Color))
                return false;
            if (emptyString(newCar.Make))
                return false;
            if (emptyString(newCar.Model))
                return false;
            if (newCar.Year <= 0)
                return false;
   
            return true;
        }

        private static bool emptyString(string Value) { return (Value.Trim().Length == 0); }
    }
}
