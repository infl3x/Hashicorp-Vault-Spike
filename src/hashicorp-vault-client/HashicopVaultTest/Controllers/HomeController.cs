using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HashicopVaultTest.Models;
using Microsoft.Extensions.Configuration;

namespace HashicopVaultTest.Controllers
{
	public class HomeController : Controller
	{
		private readonly IConfiguration configuration;

		public HomeController(IConfiguration configuration)
		{
			this.configuration = configuration;
		}

		public IActionResult Index()
		{
			return View(new HomeModel
			{
				VaultStartupConfiguration = configuration.GetSection("vault-startup").GetChildren().Select(s => new KeyValuePair<string, string>(s.Key, s.Value))
			});
		}

	}
}
