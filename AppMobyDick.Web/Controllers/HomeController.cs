using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using AppMobyDick.Web.Models;

namespace AppMobyDick.Web.Controllers
{
    public class HomeController : Controller
    {
        private const string Map = @"c:\tmp\MobyDick.xml";
        public IActionResult Index()
        {
            XElement xElement = XElement.Load(Map);

            var words = (from c in xElement.Elements("word")select c).Take(10);

            List<MobyDickVM> retList = words.Select(item => new MobyDickVM {word = item.Attribute("text")?.Value, count = item.Attribute("count")?.Value}).ToList();
            return View(retList);
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
