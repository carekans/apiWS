using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wmaud_webapi.Models
{
    //Clase encargada de realizar las transacciones con la base de datos SQL SERVER mediante el objeto
    //Entity Data Model conectado a la base de datos que contiene los datos de conexion y las clases
    //para realizar las consultas
    public class obtAuditorias
    {
        //Funcion que realiza las consultas a la base de datos con linq query.
        //si la fecha es nula y la recepcion tambien realiza la consulta de todos los datos existentes en las tablas.
        //si la fecha es valida y la recepcion nula busca los datos correspondientes en esa fecha .
        //si la fecha es valida y la recepcion es valida realiza la busqueda por fecha y por recepcion.
        //Las consultas se realizan en el siguiente orden busca primero en la tabla USUARIO_AUDITORIA
        //y en base a la los resultados busca las coincidencias en la tabla CAPTURAS_AUDITORIAS.
        //Luego retorna un string en formato JSON
        public string dataAuditorias(string fechaInicio, string recepcion)
        {
            var model = new WMAUDEntities();
            List<string> res = new List<string>();

            if (string.IsNullOrEmpty(fechaInicio))
            {
                foreach (var resultAU in model.USUARIO_AUDITORIA)
                {
                    string codigoLocal = resultAU.CODIGO_LOCAL;
                    var query = (from ca in model.CAPTURAS_AUDITORIA
                                 where ca.CODIGO_LOCAL == codigoLocal
                                 select new
                                 {
                                     correlativo = ca.CORRELATIVO,
                                     tag_error = ca.TAG_ERROR,
                                     barra_error = ca.BARRA_ERROR,
                                     observacion = ca.OBSERVACION,
                                     nombre_foto = ca.NOMBRE_FOTO,
                                     tag_corregido = ca.TAG_CORREGIDO,
                                     user_error = ca.USER_ERROR
                                 });
                    foreach (var resultCA in query)
                    {
                        res.Add(JsonConvert.SerializeObject(new
                        {
                            FechaProceso = resultAU.FECHA_PROCESO,
                            NombreUsuario = resultAU.NOMBRE_USUARIO,
                            Turno = resultAU.TURNO,
                            Preparacion = resultAU.RECEPCION,
                            Correlativo = resultCA.correlativo,
                            TagError = resultCA.tag_error,
                            UserError = resultCA.user_error,
                            BarraError = resultCA.barra_error,
                            Observacion = resultCA.observacion,
                            NombreFoto = resultCA.nombre_foto,
                            TagCorregido = resultCA.tag_corregido
                        }));
                    }
                }
            }
            else if (string.IsNullOrEmpty(recepcion))
            {
                var queryUA = (from ua in model.USUARIO_AUDITORIA
                             where ua.FECHA_PROCESO == fechaInicio
                             select new
                             {
                                 NOMBRE_USUARIO = ua.NOMBRE_USUARIO,
                                 FECHA_PROCESO = ua.FECHA_PROCESO,
                                 TURNO = ua.TURNO,
                                 CODIGO_LOCAL = ua.CODIGO_LOCAL,
                                 RECEPCION = ua.RECEPCION
                             });

                foreach (var resultAU in queryUA)
                {
                    string codigoLocal = resultAU.CODIGO_LOCAL;
                    var query = (from ca in model.CAPTURAS_AUDITORIA
                                 where ca.CODIGO_LOCAL == codigoLocal
                                 select new
                                 {
                                     correlativo = ca.CORRELATIVO,
                                     tag_error = ca.TAG_ERROR,
                                     barra_error = ca.BARRA_ERROR,
                                     observacion = ca.OBSERVACION,
                                     nombre_foto = ca.NOMBRE_FOTO,
                                     tag_corregido = ca.TAG_CORREGIDO,
                                     user_error = ca.USER_ERROR
                                 });
                    foreach (var resultCA in query)
                    {
                        res.Add(JsonConvert.SerializeObject(new
                        {
                            FechaProceso = resultAU.FECHA_PROCESO,
                            NombreUsuario = resultAU.NOMBRE_USUARIO,
                            Turno = resultAU.TURNO,
                            Preparacion = resultAU.RECEPCION,
                            Correlativo = resultCA.correlativo,
                            TagError = resultCA.tag_error,
                            UserError = resultCA.user_error,
                            BarraError = resultCA.barra_error,
                            Observacion = resultCA.observacion,
                            NombreFoto = resultCA.nombre_foto,
                            TagCorregido = resultCA.tag_corregido
                        }));
                    }
                }
            }
            else
            {
                var queryUA = (from ua in model.USUARIO_AUDITORIA
                               where ua.FECHA_PROCESO == fechaInicio
                               where ua.RECEPCION == recepcion
                               select new
                               {
                                   NOMBRE_USUARIO = ua.NOMBRE_USUARIO,
                                   FECHA_PROCESO = ua.FECHA_PROCESO,
                                   TURNO = ua.TURNO,
                                   CODIGO_LOCAL = ua.CODIGO_LOCAL,
                                   RECEPCION = ua.RECEPCION
                               });

                foreach (var resultAU in queryUA)
                {
                    string codigoLocal = resultAU.CODIGO_LOCAL;
                    var query = (from ca in model.CAPTURAS_AUDITORIA
                                 where ca.CODIGO_LOCAL == codigoLocal
                                 select new
                                 {
                                     correlativo = ca.CORRELATIVO,
                                     tag_error = ca.TAG_ERROR,
                                     barra_error = ca.BARRA_ERROR,
                                     observacion = ca.OBSERVACION,
                                     nombre_foto = ca.NOMBRE_FOTO,
                                     tag_corregido = ca.TAG_CORREGIDO,
                                     user_error = ca.USER_ERROR
                                 });
                    foreach (var resultCA in query)
                    {
                        res.Add(JsonConvert.SerializeObject(new
                        {
                            FechaProceso = resultAU.FECHA_PROCESO,
                            NombreUsuario = resultAU.NOMBRE_USUARIO,
                            Turno = resultAU.TURNO,
                            Preparacion = resultAU.RECEPCION,
                            Correlativo = resultCA.correlativo,
                            TagError = resultCA.tag_error,
                            UserError = resultCA.user_error,
                            BarraError = resultCA.barra_error,
                            Observacion = resultCA.observacion,
                            NombreFoto = resultCA.nombre_foto,
                            TagCorregido = resultCA.tag_corregido
                        }));
                    }
                }
            }

            string json = JsonConvert.SerializeObject(res,Newtonsoft.Json.Formatting.None);
            string resultado = json.Replace("\\","");
            resultado = resultado.Replace("[\"", "[");
            resultado = resultado.Replace("}\",\"{", "},{");

            return resultado.Replace("\"]", "]");
        }
    }
}