using ClientSearch.DAL;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientSearch.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string searchString, int? page, string currentFilter)
        {
            DataLoader dataLoader = new DataLoader();
            var clientsList = dataLoader.GetClients();
            var clientList = clientsList.Where(s => !string.IsNullOrEmpty(s.email) && !string.IsNullOrEmpty(s.mobile)); // handles empty fields in API

            if (!String.IsNullOrEmpty(searchString))
            {
                clientsList = clientList.Where(s => s.email.Contains(searchString)
                                       || s.mobile.Contains(searchString)).ToList(); //handles searching for user input
            }

            if (searchString != null) 
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            //paging display
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(clientsList.ToPagedList(pageNumber, pageSize));
        }

    }
}
