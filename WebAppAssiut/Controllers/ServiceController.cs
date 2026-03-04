using Microsoft.AspNetCore.Mvc;
using WebAppAssiut.Repository;

namespace WebAppAssiut.Controllers
{
	public class ServiceController : Controller
	{
		private readonly IService service;

		public ServiceController(IService service)
		{
			this.service = service;
		}
		public IActionResult Index()
		{
			ViewData["Id"] = service.Id;
			return View();
		}
	}
}
