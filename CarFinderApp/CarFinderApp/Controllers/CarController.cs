using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarFinderApp.Models;
using System.Threading.Tasks;
using System.Net.Http;
using Bing;
using Newtonsoft.Json;

namespace CarFinderApp.Controllers
{
    public class CarController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Car
        //By default, the year will be set to 2000
        public async Task<ActionResult> Index(int year=2000)
        {
            
            var cars = await db.GetCars(year, "", "", "", "", false, null, null);
            ViewBag.year = new SelectList(await db.GetYears(), year);
            return View(cars);
        }

        // GET: Car/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarViewModel carVM = new CarViewModel();
            carVM.Car = db.Cars.Find(id);

            if (carVM.Car == null)
            {
                return HttpNotFound();
            }

            HttpResponseMessage response;
            string content = "";

            carVM.Recalls = "";
            carVM.Image = "";


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://nhtsa.gov/");

                try
                {
                    response = await client.GetAsync("webapi/api/Recalls/vehicle/modelyear/" + carVM.Car.model_year
                        + "/make/" + carVM.Car.make + "/model/" + carVM.Car.model_name + "?format=json");
                    content = await response.Content.ReadAsStringAsync();
                }
                catch (Exception e)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            }
            carVM.Recalls = JsonConvert.DeserializeObject(content);

            var image = new BingSearchContainer(new Uri("https://api.datamarket.azure.com/Bing/search/"));

            image.Credentials = new NetworkCredential("bing", "c1QJ7Ffy25Q/DUgEN7vfAFhk38Q0Zu+MSY0fpu71oKg");

            var marketData = image.Composite("image", carVM.Car.model_year + " " + carVM.Car.make + " " + carVM.Car.model_name + " " + carVM.Car.model_trim,
                null, null, null, null, null, null, null, null, null, null, null, null, null).Execute();
            carVM.Image = marketData.First().Image.First().MediaUrl;

            return View(carVM);

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public async Task<ActionResult> ViewData(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarViewModel carVM = new CarViewModel();
            carVM.Car = db.Cars.Find(id);

            if (carVM.Car == null)
            {
                return HttpNotFound();
            }

            HttpResponseMessage response;
            string content = "";

            carVM.Recalls = "";
            carVM.Image = "";


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://nhtsa.gov/");

                try
                {
                    response = await client.GetAsync("webapi/api/Recalls/vehicle/modelyear/" + carVM.Car.model_year
                        + "/make/" + carVM.Car.make + "/model/" + carVM.Car.model_name + "?format=json");
                    content = await response.Content.ReadAsStringAsync();
                }
                catch (Exception e)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            }
            carVM.Recalls = JsonConvert.DeserializeObject(content);

            var image = new BingSearchContainer(new Uri("https://api.datamarket.azure.com/Bing/search/"));

            image.Credentials = new NetworkCredential("bing", "c1QJ7Ffy25Q/DUgEN7vfAFhk38Q0Zu+MSY0fpu71oKg");

            var marketData = image.Composite("image", carVM.Car.model_year + " " + carVM.Car.make + " " + carVM.Car.model_name + " " + carVM.Car.model_trim,
                null, null, null, null, null, null, null, null, null, null, null, null, null).Execute();
            carVM.Image = marketData.First().Image.First().MediaUrl;

            

            return PartialView("_Data",carVM);
        }

       
    }
}
