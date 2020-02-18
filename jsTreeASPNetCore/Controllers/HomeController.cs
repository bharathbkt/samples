using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using jsTreeASPNetCore.Models;
using Newtonsoft.Json;

namespace jsTreeASPNetCore.Controllers
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
            List<TreeViewNode> nodes = new List<TreeViewNode>();

            nodes.Add(new TreeViewNode() { id = "101", parent = "#", text = "Simple root node" });
            nodes.Add(new TreeViewNode() { id = "102", parent = "#", text = "Root with children" });
            nodes.Add(new TreeViewNode() { id = "103", parent = "102", text = "Child 1" });
            nodes.Add(new TreeViewNode() { id = "104", parent = "102", text = "Child 2" });
            nodes.Add(new TreeViewNode() { id = "105", parent = "102", text = "Child 3" });
            nodes.Add(new TreeViewNode() { id = "106", parent = "105", text = "Child 4" });

            //Serialize to JSON string.
            ViewBag.Json = JsonConvert.SerializeObject(nodes);
            return View();
        }

        [HttpPost]
        public ActionResult Index(string selectedItems)
        {
            List<TreeViewNode> items = JsonConvert.DeserializeObject<List<TreeViewNode>>(selectedItems);
            return RedirectToAction("Index");
        }
    }
}
