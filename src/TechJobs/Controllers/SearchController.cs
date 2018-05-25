using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results

        public IActionResult Results(string searchType, string searchTerm)
        {
            ViewBag.columns = ListController.columnChoices;
            if (searchType == "all")
            {
                List<Dictionary<string, string>> jobMatches = JobData.FindByValue(searchTerm);
                ViewBag.jobs = jobMatches;
            }
            else
            {
                List<Dictionary<string, string>> jobMatches = JobData.FindByColumnAndValue(searchType, searchTerm);
                ViewBag.jobs = jobMatches;
            }

            return View("Index");

        }
    }
}
