
using Crud_Api_Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace AspWebApi_Crud.Controllers
{
    public class CrudApiController : ApiController
    {
        api_result_dbEntities4 db = new api_result_dbEntities4();

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetScanResult()
        {
            List<Result> list = db.Results.ToList();
            return Ok(list);
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetResultById(int id)
        {
            var res = db.Results.Where(model => model.Id == id).FirstOrDefault();
            return Ok(res);
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult RepoInsert(Result r)
        {
         
            db.Results.Add(r);
            db.SaveChanges();
            return Ok();
        }
        [System.Web.Http.HttpPut]
        public IHttpActionResult RepoUpdate(Result r)
        {
            db.Entry(r).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return Ok();
        }
        [System.Web.Http.HttpDelete]
        public IHttpActionResult RepoDelete(int id)
        {
            var emp = db.Results.Where(model => model.Id == id).FirstOrDefault();
            db.Entry(emp).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return Ok();
        }

        [System.Web.Http.HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }
    }
}