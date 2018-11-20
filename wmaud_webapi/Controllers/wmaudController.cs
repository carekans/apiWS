using System.Collections.Generic;
using System.Web.Http;
using System.Web.Mvc;
using wmaud_webapi.Models;

namespace wmaud_webapi.Controllers
{
    public class wmaudController : ApiController
    {
        //Api que expone los datos en formato json
        // GET: /wmaud/

        //Metodo Get que expone listado sin considerar filtros, 
        //no se deben indicar la fecha o si es recepcion o picking
        // /wmaud/
        [Route("api/wmaud/")]
        public IHttpActionResult Get()
        {
            string fechaInicio = null;
            string recepcion = null;
            var auditoria = new obtAuditorias();
            return Json(auditoria.dataAuditorias(fechaInicio,recepcion)); 
        }
        //Metodo Get que expone los datos correspondientes a la fecha que se entregue fecha que se entregue,
        //solo se debe entregar la fecha en la url en formato dd-mm-aaaa
        // /wmaud/{fecha}
        [Route("api/wmaud/{fechainicio}")]
        public IHttpActionResult GetXFecha(string fechaInicio)
        {
            string recepcion = null;
            var auditoria = new obtAuditorias();
            return Json(auditoria.dataAuditorias(fechaInicio.Replace("-", "/"),recepcion));
        }
        //Metodo Get que expone los datos que correspondientes segun la fecha entregada y si es recepcion o picking,
        //la fecha de ser en formato dd-mm-aaaa y el tipo recepcion debe ser tener la primera letra en mayusculas
        // /wmaud/{fecha}/{recepcion}
        [Route("api/wmaud/{fechainicio}/{recepcion}")]
        public IHttpActionResult GetXFechaXRecepcion(string fechaInicio, string recepcion)
        {
            var auditoria = new obtAuditorias();
            return Json(auditoria.dataAuditorias(fechaInicio.Replace("-", "/"),recepcion));
        }
    }
}
