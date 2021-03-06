﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Routing;

namespace CarFinderApp.Models
{
    [RoutePrefix("api/cars")]
    public class CarsController : ApiController
    {
        ApplicationDbContext db = new ApplicationDbContext();

        [Route("GetYears")]
        public async Task<List<string>> GetYears()
        {
            return await db.GetYears();
        }

        [Route("GetMakes")]
        public async Task<List<string>> GetMakes(int year)
        {
            return await db.GetMakes(year);
        }

        [Route("GetModels")]
        public async Task<List<string>> GetModels(int year, string make)
        {
            return await db.GetModels(year, make);
        }
        [Route("GetTrims")]
        public async Task<List<string>> GetTrims(int year, string make, string model)
        {
            return await db.GetTrims(year, make, model);
        }
        [Route("GetCars")]
        public async Task<List<Car>> GetCars(int year, string make, string model, string trim)
        {
            return await db.GetCars(year, make, model, trim);
        }
    }
}
