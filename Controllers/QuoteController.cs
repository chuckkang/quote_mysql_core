using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using DbConnection;

namespace mvc_quoting_core.Controllers
{
	public class QuoteController : Controller
	{	
		[HttpGet]
		[Route("quote"), Route("quote/index")]
		public IActionResult Index(string message)
		{	ViewData["Message"] = message;

			List<Dictionary<string, object>> quotes = new List<Dictionary<string, object>>(DbConnector.Query("Select * from quotes ORDER BY created_at desc"));
			ViewBag.allQuotes = quotes;

			return View();
		}

		[HttpPost]
		[Route("quote/addquote")]
		public IActionResult AddQuote(string name, string quote)
		{
			//DBConnector is a static method
			Console.WriteLine($"insert -- name: {name}, quote: {quote}---------------------------");
			DbConnector.Execute($"INSERT INTO quotes (username, quote) VALUES ('{name}', '{quote}');");
			
			return RedirectToAction("Index");
		}

		[HttpGet]
		[Route("quote/delete/{id}")]
		public IActionResult DeletePost(int id)
		{	
			DbConnector.Execute($"DELETE FROM quotes WHERE quoteid = {id}");
			ViewBag.Message = "Your quote has been deleted";
			return RedirectToAction("Index", new { message = "Your quote has been deleted"});
		}
		public IActionResult Error()
		{
			return View();
		}
	}
}