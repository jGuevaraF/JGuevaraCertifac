using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using ML;

namespace SL.Controllers
{
    public class AddendaController : ApiController
    {
        [Route("api/GetAll")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            ML.Result result = BL.Addenda.GetAll();

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }

        [Route("api/GetById/{IdAddenda}")]
        [HttpGet]
        public IHttpActionResult GetById(int IdAddenda)
        {
            ML.Result result = BL.Addenda.GetById(IdAddenda);

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }

        [Route("api/Add")]
        [HttpPost]
        public IHttpActionResult Add([FromBody]ML.Adenda adenda)
        {
            ML.Result result = BL.Addenda.Add(adenda);

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }

        [Route("api/Update")]
        [HttpPut]
        public IHttpActionResult Update([FromBody] ML.Adenda adenda)
        {
            ML.Result result = BL.Addenda.Update(adenda);

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }

        [Route("api/Delete/{IdAddenda}")]
        [HttpDelete]
        public IHttpActionResult Add(int IdAddenda)
        {
            ML.Result result = BL.Addenda.Delete(IdAddenda);

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }





        [Route("api/AddByList")]
        [HttpPost]
        public IHttpActionResult AddByList([FromBody] List<ML.Adenda> listaAddenda)
        {

            ML.Result result = new ML.Result();
            try
            {
                foreach (var item in listaAddenda)
                {
                    result = BL.Addenda.Add(item);
                }
                return Content(HttpStatusCode.OK, result);

            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                return Content(HttpStatusCode.BadRequest, result);

            }

        }


        [Route("api/DeleteByList")]
        [HttpPost]
        public IHttpActionResult DeleteByList([FromBody] List<int> listaAddenda)
        {

            ML.Result result = new ML.Result();
            try
            {
                foreach (var item in listaAddenda)
                {
                    result = BL.Addenda.Delete(item);
                }
                return Content(HttpStatusCode.OK, result);

            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                return Content(HttpStatusCode.BadRequest, result);

            }

        }
    }
}
