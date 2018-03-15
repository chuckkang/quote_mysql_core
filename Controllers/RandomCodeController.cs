
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace mvc_quoting_core.Controllers
{
	public class RandomCodeController : Controller{

		[HttpGet]
		[Route("random")]
		public IActionResult Index()
		{	string rndCode ="string value here";
			ViewData["rndCode"]="this is the value";
			return View();
		}
	
		[HttpGet]
		[Route("random/code")]
		public JsonResult Code()
		{
			Guid g = Guid.NewGuid();
			string GuidString = Convert.ToBase64String(g.ToByteArray());
			GuidString = GuidString.Replace("=", "");
			GuidString = GuidString.Replace("+", "");
			Console.WriteLine (GuidString);
			return Json(GuidString);
		}
	}
}