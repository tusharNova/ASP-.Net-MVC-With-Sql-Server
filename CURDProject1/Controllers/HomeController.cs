using CURDProject1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace CURDProject1.Controllers
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
		public IActionResult SavePerson(Person p)
		{
			SqlConnection sqlconnection = new SqlConnection();
			sqlconnection.ConnectionString = "Server=localhost;Database=CRUD_project1;User Id=sa;Password=april@131211;";
			sqlconnection.Open();
			SqlCommand cmd = new SqlCommand();
			cmd = sqlconnection.CreateCommand();
			SqlDataReader res;
			cmd.CommandText = "Insert into values(null,' " + p.Name + "','" + p.Mobile + "' ,'" + p.Address + "' ,'" + p.City + "')";
			res = cmd.ExecuteReader();
			sqlconnection.Close();
			return Json(new {massge = "Data received successfully" });
		}
		public IActionResult AllPerson()
		{
			return View();
		}


		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
