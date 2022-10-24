using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Weather.Entities;
using Library.Request.Helper;
using Microsoft.AspNetCore.Mvc;


namespace LM3.MVC.Factory.Controllers
{
    public class WeatherController : Controller
    {
        public async Task<IActionResult> Index()
        {

            ViewBag.Msn = "hOLA MUNDO";


            IEnumerable<WeatherForecast> wea = await HttpRequestHelper.GetMethod<IEnumerable<WeatherForecast>>("MyCloudSchool", "/weatherforecast");

            if (wea !=null)
            {
                ViewBag.list = wea.ToList();
            }
            else
            {
                ViewBag.list = null;
            }

            return  View();
        }
    }
}

