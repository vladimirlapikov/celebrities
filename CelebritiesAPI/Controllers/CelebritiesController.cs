using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.IO;
using System.Web.Http;
using CelebBLL;
using CelebritiesDAL;
using System.Net.Http;
using System.Net;

namespace CelebritiesAPI.Controllers
{
    [RoutePrefix("Home/api/celebrities")]
    public class CelebritiesController : ApiController
    {
        private readonly ICelebCRUD _celebCrud;

        public CelebritiesController() { }

        public CelebritiesController(ICelebCRUD celebCrud)
        {
            _celebCrud = celebCrud;   
        }

        public List<Celebrity> GetAllCelebrities() {
            // for checking puropose delete after has crud buttons

            // DELETE
            //_celebCrud.Delete(3);

            //UPDATE
            //Celebrity celebrity = new Celebrity();
            //celebrity.ID = 3;
            //celebrity.Name = "Arnold";
            //celebrity.Age = 55;
            //celebrity.Country = "Austria";
            //_celebCrud.Update(celebrity);

            //CREATE
            //Celebrity celebrity = new Celebrity();
            //celebrity.Name = "Arnold";
            //celebrity.Age = 55;
            //celebrity.Country = "Austria";
            //_celebCrud.Create(celebrity);

            return _celebCrud.GetAllCelebrities();
        }

        public HttpResponseMessage Post([FromBody]Celebrity c)
        {
            _celebCrud.Create(c);
            var message = Request.CreateResponse(HttpStatusCode.Created, c);
            message.Headers.Location = new Uri(Request.RequestUri + c.ID.ToString());
            return message;
        }

        public HttpResponseMessage Put([FromBody]Celebrity c)
        {
            try
            {
                _celebCrud.Update(c);
                if (c == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Celeb Not Found");
                }
                return Request.CreateResponse(HttpStatusCode.OK, "Celeb Updated Successfully");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage Delete(int id)
        {
            try
            {
                _celebCrud.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, "Celeb Deleted Successfully");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }

}