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
        //Metodo Get que expone los datos de Actifo fijo sin filtros
        // api/activofijo
        [Route("api/activofijo/")]
        public IHttpActionResult Get()
        {
            var obtenerAF = new obtAF();
            return Json(obtenerAF.dataAF(0,0));
        }
        //Metodo Get que expone los datos filtrados por codigo de almacen
        //api/activofijo/{codigo_almacen}
        [Route("api/activofijo/{codigo}")]
        public IHttpActionResult GetXCodigo(string codigo)
        {
            var obtenerAF = new obtAF();
            return Json(obtenerAF.dataAF(Int32.Parse(codigo),0));
        }
        //Metodo Get que expone los datos filtrados por codigo de almacen y codigo de categoria
        //api/activofijo/{codigo_almacen}/{codigo_categoria}
        [Route("api/activofijo/{codigo}/{categoria}")]
        public IHttpActionResult GetXCategoria(string codigo, string categoria)
        {
            var obtenerAF = new obtAF();
            return Json(obtenerAF.dataAF(Int32.Parse(codigo),Int32.Parse(categoria)));
        }
        [Route("api/activofijo/getxnombre/{nombre}")]
        public IHttpActionResult GetXNombre(string nombre)
        {
            var obtenerAF = new obtAF();
            return Json(obtenerAF.GetXNombre(nombre));
        }
    }
}
