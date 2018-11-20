using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wmaud_webapi.Models
{
    public class obtAF
    {
        public string dataAF(int alm_codigo, int categoriaCod)
        {
            var modelAF = new SEIEntities();
            List<string> resAF = new List<string>();

            if (alm_codigo == 0)
            {
                foreach (var art in modelAF.ACFI_articulo)
                {
                    var queryEquipos = (from equipo in modelAF.ACFI_equipos
                                            join almacen in modelAF.ACFI_almacen on equipo.alm_codigo equals almacen.alm_codigo
                                            join articulos in modelAF.ACFI_articulo on equipo.art_codigo equals articulos.art_codigo
                                            join categoria in modelAF.ACFI_categoria on articulos.cat_codigo equals categoria.cat_codigo
                                            where equipo.art_codigo == art.art_codigo
                                            group equipo.alm_codigo by new
                                            {
                                                alm_codigo = almacen.alm_codigo,
                                                alm_nombre = almacen.alm_nombre,
                                                equipo_codigo = articulos.art_codigo,
                                                art_nombre = articulos.art_nombre,
                                                cat_codigo = categoria.cat_codigo,
                                                cat_nombre = categoria.cat_nombre
                                            }
                                                into equip
                                                orderby equip.Key.alm_codigo ascending
                                                select new
                                                {
                                                    alm_codigo = equip.Key.alm_codigo,
                                                    alm_nombre = equip.Key.alm_nombre,
                                                    equipo_codigo = equip.Key.equipo_codigo,
                                                    art_nombre = equip.Key.art_nombre,
                                                    cat_codigo = equip.Key.cat_codigo,
                                                    cat_nombre = equip.Key.cat_nombre,
                                                    cant = equip.Count()
                                                }
                                            );

                    foreach (var resultequipos in queryEquipos)
                    {
                        resAF.Add(JsonConvert.SerializeObject(new
                            {
                                alm_codigo = resultequipos.alm_codigo,
                                alm_nombre = resultequipos.alm_nombre,
                                cat_codigo = resultequipos.cat_codigo,
                                cat_nombre = resultequipos.cat_nombre,
                                art_codigo = resultequipos.equipo_codigo,
                                art_nombre = resultequipos.art_nombre,
                                cantidad = resultequipos.cant
                            }
                        ));
                    }
                }                
            }
            else if (categoriaCod == 0)
            {
                foreach (var art in modelAF.ACFI_articulo)
                {
                    var queryEquipos = (from equipo in modelAF.ACFI_equipos
                                            join almacen in modelAF.ACFI_almacen on equipo.alm_codigo equals almacen.alm_codigo
                                            join articulos in modelAF.ACFI_articulo on equipo.art_codigo equals articulos.art_codigo
                                            join categoria in modelAF.ACFI_categoria on articulos.cat_codigo equals categoria.cat_codigo
                                            where equipo.alm_codigo == alm_codigo
                                            where equipo.art_codigo == art.art_codigo
                                            group equipo.alm_codigo by new
                                            {
                                                alm_codigo = almacen.alm_codigo,
                                                alm_nombre = almacen.alm_nombre,
                                                equipo_codigo = articulos.art_codigo,
                                                art_nombre = articulos.art_nombre,
                                                cat_codigo = categoria.cat_codigo,
                                                cat_nombre = categoria.cat_nombre
                                            }
                                                into equip
                                                orderby equip.Key.alm_codigo ascending
                                                select new
                                                {
                                                    alm_codigo = equip.Key.alm_codigo,
                                                    alm_nombre = equip.Key.alm_nombre,
                                                    equipo_codigo = equip.Key.equipo_codigo,
                                                    art_nombre = equip.Key.art_nombre,
                                                    cat_codigo = equip.Key.cat_codigo,
                                                    cat_nombre = equip.Key.cat_nombre,
                                                    cant = equip.Count()
                                                }
                                            );

                    foreach (var resultequipos in queryEquipos)
                    {
                        resAF.Add(JsonConvert.SerializeObject(new
                            {
                                alm_codigo = resultequipos.alm_codigo,
                                alm_nombre = resultequipos.alm_nombre,
                                cat_codigo = resultequipos.cat_codigo,
                                cat_nombre = resultequipos.cat_nombre,
                                art_codigo = resultequipos.equipo_codigo,
                                art_nombre = resultequipos.art_nombre,
                                cantidad = resultequipos.cant
                            }
                        ));
                    }
                }
            }
            else
            {
                foreach (var art in modelAF.ACFI_articulo)
                {
                    var queryEquipos = (from equipo in modelAF.ACFI_equipos
                                            join almacen in modelAF.ACFI_almacen on equipo.alm_codigo equals almacen.alm_codigo
                                            join articulos in modelAF.ACFI_articulo on equipo.art_codigo equals articulos.art_codigo
                                            join categoria in modelAF.ACFI_categoria on articulos.cat_codigo equals categoria.cat_codigo
                                            where equipo.alm_codigo == alm_codigo
                                            where equipo.art_codigo == art.art_codigo
                                            where articulos.cat_codigo == categoriaCod
                                            group equipo.alm_codigo by new
                                            {
                                                alm_codigo = almacen.alm_codigo,
                                                alm_nombre = almacen.alm_nombre,
                                                equipo_codigo = articulos.art_codigo,
                                                art_nombre = articulos.art_nombre,
                                                cat_codigo = categoria.cat_codigo,
                                                cat_nombre = categoria.cat_nombre
                                            } 
                                            into equip
                                            orderby equip.Key.alm_codigo ascending
                                            select new
                                            {
                                                alm_codigo = equip.Key.alm_codigo,
                                                alm_nombre = equip.Key.alm_nombre,
                                                equipo_codigo = equip.Key.equipo_codigo,
                                                art_nombre = equip.Key.art_nombre,
                                                cat_codigo = equip.Key.cat_codigo,
                                                cat_nombre = equip.Key.cat_nombre,
                                                cant = equip.Count()
                                            }
                                        );

                    foreach (var resultequipos in queryEquipos)
                    {
                        resAF.Add(JsonConvert.SerializeObject(new
                            {
                                alm_codigo = resultequipos.alm_codigo,
                                alm_nombre = resultequipos.alm_nombre,
                                cat_codigo = resultequipos.cat_codigo,
                                cat_nombre = resultequipos.cat_nombre,
                                art_codigo = resultequipos.equipo_codigo,
                                art_nombre = resultequipos.art_nombre,
                                cantidad = resultequipos.cant
                            }
                        ));
                    }
                }
            }

            string json = JsonConvert.SerializeObject(resAF, Newtonsoft.Json.Formatting.None);
            string resultado = json.Replace("\\", "");
            resultado = resultado.Replace("[\"", "[");
            resultado = resultado.Replace("}\",\"{", "},{");

            return resultado.Replace("\"]", "]");
        }
    }
}