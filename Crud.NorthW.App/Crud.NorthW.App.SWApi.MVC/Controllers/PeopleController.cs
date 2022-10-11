using Crud.NorthW.App.SWApi.MVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Crud.NorthW.App.SWApi.MVC.Controllers
{
    public class PeopleController : Controller
    {
        // GET: People
        public async Task<ActionResult> Index(string NextOrPreviousURL)
        {
            var url = (NextOrPreviousURL == null) ? "https://swapi.dev/api/people" : NextOrPreviousURL;
            var httpClient = new HttpClient();
            var jsonPeopleResponse = await httpClient.GetStringAsync(url);
            PeopleListView peopleViewList = JsonConvert.DeserializeObject<PeopleListView>(jsonPeopleResponse);
            ViewBag.NextPage = peopleViewList.next;
            ViewBag.PreviousPage = peopleViewList.previous;
            return View(peopleViewList.results);
        }

        public async Task<ActionResult> PeopleSingle()
        {
            var url = "https://swapi.dev/api/people/1";
            var httpClient = new HttpClient();
            var jsonPeopleResponse = await httpClient.GetStringAsync(url);
            PeopleView peopleView = JsonConvert.DeserializeObject<PeopleView>(jsonPeopleResponse);
            return View(peopleView);
        }

        [HttpPost]
        public ActionResult NextPage()
        {
            var nextPageUrl = HttpContext.Request.Form["nextPageUrl"];
            return RedirectToAction("Index", new { NextOrPreviousURL = nextPageUrl });
        }

        [HttpPost]
        public ActionResult PreviousPage()
        {
            var previousPageUrl = HttpContext.Request.Form["previousPageUrl"];
            return RedirectToAction("Index", new { NextOrPreviousURL = previousPageUrl });
        }


    }
}