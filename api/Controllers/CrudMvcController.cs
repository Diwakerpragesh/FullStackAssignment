
using Crud_Api_Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace AspWebApi_Crud.Controllers
{
    public class CrudMvcController : Controller
    {
        // GET: CrudMvc
        HttpClient client = new HttpClient();
        public ActionResult Index()
        {
            List<Result> repo_list = new List<Result>();
            client.BaseAddress = new Uri("http://localhost:62685/api/CrudApi");
            var response = client.GetAsync("CrudApi");
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<Result>>();
                display.Wait();
                repo_list = display.Result;
            }

            return View(repo_list);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Result r)
        {
            client.BaseAddress = new Uri("http://localhost:62685/api/CrudApi");
            var response = client.PostAsJsonAsync<Result>("CrudApi", r);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View("Create");
        }
        public ActionResult Details(int id)
        {
            Result r = null;
            client.BaseAddress = new Uri("http://localhost:62685/api/CrudApi");
            var response = client.GetAsync("CrudApi?id=" + id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Result>();
                display.Wait();
                r = display.Result;
            }
            return View(r);
        }
        public ActionResult Edit(int id)
        {
            Result r = null;
            client.BaseAddress = new Uri("http://localhost:62685/api/CrudApi");
            var response = client.GetAsync("CrudApi?id=" + id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Result>();
                display.Wait();
                r = display.Result;
            }
            return View(r);
        }
        [HttpPost]
        public ActionResult Edit(Result r)
        {
            client.BaseAddress = new Uri("http://localhost:62685/api/CrudApi");
            var response = client.PutAsJsonAsync<Result>("CrudApi", r);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View("Edit");
        }
        public ActionResult Delete(int id)
        {
            Result r = null;
            client.BaseAddress = new Uri("http://localhost:62685/api/CrudApi");
            var response = client.GetAsync("CrudApi?id=" + id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Result>();
                display.Wait();
                r = display.Result;
            }
            return View(r);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            client.BaseAddress = new Uri("http://localhost:62685/api/CrudApi");
            var response = client.DeleteAsync("CrudApi/" + id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View("Delete");
        }


    }
}