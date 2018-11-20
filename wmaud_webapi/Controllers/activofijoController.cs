using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using wmaud_webapi.Models;

namespace wmaud_webapi.Controllers
{
    public class activofijoController : ApiController
    {
        //
        // GET: /activofijo/
        [Route("api/activofijo/")]
        public IHttpActionResult Get()
        {
            var obtenerAF = new obtAF();
            return Json(obtenerAF.dataAF(0,0));
        }
        [Route("api/activofijo/{codigo}")]
        public IHttpActionResult GetXCodigo(string codigo)
        {
            var obtenerAF = new obtAF();
            return Json(obtenerAF.dataAF(Int32.Parse(codigo),0));
        }
        [Route("api/activofijo/{codigo}/{categoria}")]
        public IHttpActionResult GetXCategoria(string codigo, string categoria)
        {
            var obtenerAF = new obtAF();
            return Json(obtenerAF.dataAF(Int32.Parse(codigo),Int32.Parse(categoria)));
        }
    }
}
