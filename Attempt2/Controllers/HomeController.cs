using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Attempt2.Models;
using System.Data.SqlClient;

namespace Attempt2.Controllers
{

    // attempting changes on local clone
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
       // private string dbConnection = "Database=master;Server=LAPTOP-B57TLJ6S\\SCHEDULER;" +
         //   "Integrated Security=True;connect timeout = 60";
         private string dbConnection = "Database=master;Server=DESKTOP-KKOGS2A\\SQLEXPRESS;" +
           "Integrated Security=True;connect timeout = 60";
        List<string> times = new List<string>();
        List<string> days = new List<string>();

        //adding to test branch use

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Page2()
        {
            return View();
        }

        public IActionResult UniqueCode()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // sending Creator Information to the database and returning unique code page
        public IActionResult Page3(InfoModel im)
        {
            // take unique code and connect to DB and check if it has been taken, if not add, if so try again

            // connect to the DB
            SqlConnection conn = new SqlConnection(dbConnection);
            conn.Open();

            // create a command
            string query = "INSERT INTO [dbo].[Creator_Info]([fname],[email],[reason]) VALUES (@fname, @email, @reason);";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@fname", im.FirstName);
            cmd.Parameters.AddWithValue("@email", im.Email);
            cmd.Parameters.AddWithValue("@reason", im.Desrcription);

            // query the DB
            cmd.ExecuteNonQuery();

            query = "INSERT INTO [dbo].[Users_Availability] VALUES(@uniquecode, (select userid from [dbo].[Creator_Info] where fname = @fname and email = @email and reason = @reason))";
            cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@uniquecode", im.UniqueCode);
            cmd.Parameters.AddWithValue("@fname", im.FirstName);
            cmd.Parameters.AddWithValue("@email", im.Email);
            cmd.Parameters.AddWithValue("@reason", im.Desrcription);

            // query the DB
            cmd.ExecuteNonQuery();

            // close the database
            conn.Close();

            RetrieveTimes();

            foreach (var item in times)
            {
                Console.WriteLine(item);
            }

            return View();
        }



        private void RetrieveTimes()
        {
            SqlConnection conn = new SqlConnection(dbConnection);
            conn.Open();

            // create a command
            string query = "SELECT [timeid],[time10] FROM [master].[dbo].[Time_10];";
            SqlCommand cmd = new SqlCommand(query, conn);

            SqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                var item = dataReader.GetValue(1);
                Console.WriteLine(item);
                Console.WriteLine(item.GetType());
                times.Add(item.ToString());
            }
        }
        // sending Creator Information to the database and returning unique code page
        public IActionResult Page4(DaysChecked d)
        {
            // take unique code and connect to DB and check if it has been taken, if not add, if so try again
            UserDaysChecked(d);

            ViewBag.message = "Controller to View";

            foreach (var item in d.daysAvaiable)
            {
                Console.WriteLine(item);
            }
            return View();
        }

        private void UserDaysChecked(DaysChecked d)
        {

            if (d.monday)
                days.Add("Monday");
            if (d.tuesday)
                days.Add("Tuesday");
            if (d.wednesday)
                days.Add("Wednesday");
            if (d.thursday)
                days.Add("Thursday");
            if (d.friday)
                days.Add("Friday");
            if (d.saturday)
                days.Add("Saturday");
            if (d.sunday)
                days.Add("Sunday");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private void DBConnect()
        {

        }
    }
}
