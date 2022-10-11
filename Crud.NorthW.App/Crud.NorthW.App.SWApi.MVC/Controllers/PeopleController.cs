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
        public async Task<ActionResult> Index()
        {
            var url = "https://swapi.dev/api/people";
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

        [HttpGet]
        public async Task<ActionResult> NextPage(string nextPageUrl)
        {
            var url = nextPageUrl;
            var httpClient = new HttpClient();
            var jsonPeopleResponse = await httpClient.GetStringAsync(url);
            PeopleListView peopleViewList = JsonConvert.DeserializeObject<PeopleListView>(jsonPeopleResponse);
            ViewBag.NextPage = peopleViewList.next;
            ViewBag.PreviousPage = peopleViewList.previous;
            return View(peopleViewList.results);
        }

        [HttpPost]
        public void PaginaSig(string nextPageUrl)
        {
            var url = nextPageUrl;
        }

        public ActionResult PreviousPage(string previousPageUrl)
        {
            return RedirectToAction("Index", new { url = previousPageUrl });
        }


    }
}