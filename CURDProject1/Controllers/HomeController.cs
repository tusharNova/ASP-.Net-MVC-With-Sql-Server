using CURDProject1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
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
			sqlconnection.ConnectionString = "Server=DESKTOP-UAD5JOD;Database=dbtest1;Trusted_Connection=True;MultipleActiveResultSets=True;Encrypt=False";
			sqlconnection.Open();
			SqlCommand cmd = new SqlCommand();
			cmd = sqlconnection.CreateCommand();
			SqlDataReader res;
			cmd.CommandText = "INSERT INTO personTable(Name,Mobile,Address ,City ) VALUES(' " + p.Name + "','" + p.Mobile + "' ,'" + p.Address + "' ,'" + p.City + "')";
			res = cmd.ExecuteReader();
			sqlconnection.Close();
			return Json(new {massge = "Data received successfully" });
		}
		public IActionResult AllPerson()
		{

			SqlConnection sqlconnection = new SqlConnection();
			sqlconnection.ConnectionString = "Server=DESKTOP-UAD5JOD;Database=dbtest1;Trusted_Connection=True;MultipleActiveResultSets=True;Encrypt=False";
			sqlconnection.Open();
			SqlCommand cmd = new SqlCommand();
			cmd = sqlconnection.CreateCommand();
			SqlDataReader res;
			cmd.CommandText = "select * from personTable;";
			res = cmd.ExecuteReader();
			DataTable dt = new DataTable();
			dt.Load(res);
			sqlconnection.Close();

			Person[] p = new Person[dt.Rows.Count];
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				p[i] = new Person();
				p[i].Id = Convert.ToInt32(dt.Rows[i]["id"].ToString());
				p[i].Name = dt.Rows[i]["Name"].ToString();
				p[i].Mobile = dt.Rows[i]["Mobile"].ToString();
				p[i].Address = dt.Rows[i]["Address"].ToString();
				p[i].City = dt.Rows[i]["City"].ToString();
			}
			return View(p);
		}

		public IActionResult UpdatePerson()
		{
			return View();
		}
		public IActionResult DeletePerson(int id)
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
