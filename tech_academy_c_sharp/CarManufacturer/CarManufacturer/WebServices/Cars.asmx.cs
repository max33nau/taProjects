using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace CarManufacturer.WebServices
{
    /// <summary>
    /// Summary description for Cars
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Cars : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public Response Get()
        {
            var json = new System.Web.Script.Serialization.JavaScriptSerializer();
            try
            {
                var cars = MyCars.Domain.CarsManager.GetCars();
                var response = new Response();
                response.data = json.Serialize(cars);
                response.error = null;
                return response;
            } catch (Exception ex)
            {
                var response = new Response();
                response.data = null;
                response.error = new Error() { Code = 404, Message = ex.Message };
                return response;
            }

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public Response Add(String make, String model, int year, String color)
        {
            var json = new System.Web.Script.Serialization.JavaScriptSerializer();
            try
            {
                var newCar = new MyCars.DTO.CarCopy()
                {
                    Make = make, Color = color, Model = model, Year = year,
                    CarId = Guid.NewGuid()
                };
                MyCars.Domain.CarsManager.AddCar(newCar);
                Response response = new Response();
                response.data = json.Serialize(newCar);
                response.error = null;
                return response;
            }  catch (Exception ex)
            {
                var response = new Response();
                response.data = null;
                response.error = new Error() { Code = 320, Message = ex.Message };
                return response;
            }

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public Response Remove(String carId)
        {
            var json = new System.Web.Script.Serialization.JavaScriptSerializer();
            try
            {
                MyCars.Domain.CarsManager.RemoveCar(carId);
                Response response = new Response();
                response.data = "Success in removing " + carId;
                response.error = null;
                return response;
            }
            catch (Exception ex)
            {
                var response = new Response();
                response.data = null;
                response.error = new Error() { Code = 320, Message = ex.Message };
                return response;
            }

        }

    }
}
