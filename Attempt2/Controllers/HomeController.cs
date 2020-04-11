using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Attempt2.Models;

namespace Attempt2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Page2(InfoModel im)

           
        {
            return View(im);
        }

        public IActionResult UniqueCode()
        {


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Page3()
        {
            LinkedList<InfoModel> dm = new LinkedList<InfoModel>();
            InfoModel temp = new InfoModel();
            temp.Day = "Sunday";
            dm.AddFirst(temp);

            temp = new InfoModel();
            temp.Day = "Saturday";
            dm.AddFirst(temp);

            temp = new InfoModel();
            temp.Day = "Friday";
            dm.AddFirst(temp);

            temp = new InfoModel();
            temp.Day = "Thursday";
            dm.AddFirst(temp);

            temp = new InfoModel();
            temp.Day = "Wednesday";
            dm.AddFirst(temp);

            temp = new InfoModel();
            temp.Day = "Tuesday";
            dm.AddFirst(temp);

            temp = new InfoModel();
            temp.Day = "Monday";
            dm.AddFirst(temp);

            

            ViewBag.LLDayModel = dm;

            return View();
        }

        public IActionResult Page4(InfoModel DM)
        {

            

            return View(DM);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
