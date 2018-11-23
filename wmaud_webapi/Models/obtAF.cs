using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;

namespace wmaud_webapi.Models{
    //Clase encargada de realizar las transacciones con la base de datos SQL SERVER mediante el objeto
    //Entity Data Model conectado a la base de datos que contiene los datos de conexion y las clases
    //para realizar las consultas
    public class obtAF{
        //Funcion encargada de realizar las consultas a la base de datos
        //Recibe como variable alm_codig que corresponde al codigo de el almacen y categoriaCod que corresponde al codigo de la categoria
        //Si alm_codigo y categoriaCod son igual a 0 se realiza la busqueda para todos los almacenes y categorias
        //Si alm_codigo es distinto de 0 y categoriaCod es igual a 0 se realiza la busqueda por el codigo de almacen y por todas las categorias
        //Si alm_codigo y categoriaCod son distintos de 0 se realiza la busqueda por codigo de almacen y por categoria
        public string dataAF(int alm_codigo, int categoriaCod){
            var modelAF = new SEIEntities();
            List<string> resAF = new List<string>();

            if (alm_codigo == 0){
                var queryEquipos = (from equipo in modelAF.ACFI_equipos
                                        join almacen in modelAF.ACFI_almacen on equipo.alm_codigo equals almacen.alm_codigo
                                        join articulos in modelAF.ACFI_articulo on equipo.art_codigo equals articulos.art_codigo
                                        join categoria in modelAF.ACFI_categoria on articulos.cat_codigo equals categoria.cat_codigo
                                        group equipo.alm_codigo by new{
                                            alm_codigo = almacen.alm_codigo,
                                            alm_nombre = almacen.alm_nombre,
                                            equipo_codigo = articulos.art_codigo,
                                            art_nombre = articulos.art_nombre,
                                            cat_codigo = categoria.cat_codigo,
                                            cat_nombre = categoria.cat_nombre
                                        }
                                        into equip
                                        orderby equip.Key.alm_codigo ascending
                                        select new{
                                            alm_codigo = equip.Key.alm_codigo,
                                            alm_nombre = equip.Key.alm_nombre,
                                            equipo_codigo = equip.Key.equipo_codigo,
                                            art_nombre = equip.Key.art_nombre,
                                            cat_codigo = equip.Key.cat_codigo,
                                            cat_nombre = equip.Key.cat_nombre,
                                            cant = equip.Count()
                                        }
                                    );

                foreach (var resultequipos in queryEquipos){
                    resAF.Add(JsonConvert.SerializeObject(new{
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
            else if (categoriaCod == 0){
                var queryEquipos = (from equipo in modelAF.ACFI_equipos
                                        join almacen in modelAF.ACFI_almacen on equipo.alm_codigo equals almacen.alm_codigo
                                        join articulos in modelAF.ACFI_articulo on equipo.art_codigo equals articulos.art_codigo
                                        join categoria in modelAF.ACFI_categoria on articulos.cat_codigo equals categoria.cat_codigo
                                        where equipo.alm_codigo == alm_codigo
                                        group equipo.alm_codigo by new{
                                            alm_codigo = almacen.alm_codigo,
                                            alm_nombre = almacen.alm_nombre,
                                            equipo_codigo = articulos.art_codigo,
                                            art_nombre = articulos.art_nombre,
                                            cat_codigo = categoria.cat_codigo,
                                            cat_nombre = categoria.cat_nombre
                                        }
                                        into equip
                                        orderby equip.Key.alm_codigo ascending
                                        select new{
                                            alm_codigo = equip.Key.alm_codigo,
                                            alm_nombre = equip.Key.alm_nombre,
                                            equipo_codigo = equip.Key.equipo_codigo,
                                            art_nombre = equip.Key.art_nombre,
                                            cat_codigo = equip.Key.cat_codigo,
                                            cat_nombre = equip.Key.cat_nombre,
                                            cant = equip.Count()
                                        }
                                    );

                foreach (var resultequipos in queryEquipos){
                    resAF.Add(JsonConvert.SerializeObject(new{
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
            else
            {
                var queryEquipos = (from equipo in modelAF.ACFI_equipos
                                        join almacen in modelAF.ACFI_almacen on equipo.alm_codigo equals almacen.alm_codigo
                                        join articulos in modelAF.ACFI_articulo on equipo.art_codigo equals articulos.art_codigo
                                        join categoria in modelAF.ACFI_categoria on articulos.cat_codigo equals categoria.cat_codigo
                                        where equipo.alm_codigo == alm_codigo
                                        where articulos.cat_codigo == categoriaCod
                                        group equipo.alm_codigo by new{
                                            alm_codigo = almacen.alm_codigo,
                                            alm_nombre = almacen.alm_nombre,
                                            equipo_codigo = articulos.art_codigo,
                                            art_nombre = articulos.art_nombre,
                                            cat_codigo = categoria.cat_codigo,
                                            cat_nombre = categoria.cat_nombre
                                        } 
                                        into equip
                                        orderby equip.Key.alm_codigo ascending
                                        select new{
                                            alm_codigo = equip.Key.alm_codigo,
                                            alm_nombre = equip.Key.alm_nombre,
                                            equipo_codigo = equip.Key.equipo_codigo,
                                            art_nombre = equip.Key.art_nombre,
                                            cat_codigo = equip.Key.cat_codigo,
                                            cat_nombre = equip.Key.cat_nombre,
                                            cant = equip.Count()
                                        }
                                    );

                foreach (var resultequipos in queryEquipos){
                    resAF.Add(JsonConvert.SerializeObject(new{
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

            string json = JsonConvert.SerializeObject(resAF, Newtonsoft.Json.Formatting.None);
            string resultado = json.Replace("\\", "");
            resultado = resultado.Replace("[\"", "[");
            resultado = resultado.Replace("}\",\"{", "},{");

            return resultado.Replace("\"]", "]");
        }
        //Funcion encargada de buscar la cantidad se PDA que posee un lider ademas devuelte el total de las PDA disponibles en bodega
        //la busqueda se realiza en base al nombre de el almacen que corresponde al nombre de el lider espacio apellido paterno
        //la funcion sola hace la comparacion independiente de mayusculas o acentos que pueda contener el nombre
        public string GetXNombre(string nombre){

            var modelAF = new SEIEntities();
            List<string> resAF = new List<string>();

            int codAlmacen = 0;
            //Debido a que linq no interpreta la comparacion de acentos para buscar el almacen primero se listan y se realiza el recorrido
            //por cada uno comparando el nombre para poder obtener el codigo de el almacen y asi realizar la condicion en la consulta en base al codigo
            foreach (var almacenList in modelAF.ACFI_almacen){
                if (String.Compare(nombre, almacenList.alm_nombre, CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreCase) == 0){
                    codAlmacen = (int) almacenList.alm_codigo;
                }
            }

            var queryEquipos = (from equipo in modelAF.ACFI_equipos
                                join almacen in modelAF.ACFI_almacen on equipo.alm_codigo equals almacen.alm_codigo
                                join articulos in modelAF.ACFI_articulo on equipo.art_codigo equals articulos.art_codigo
                                join categoria in modelAF.ACFI_categoria on articulos.cat_codigo equals categoria.cat_codigo
                                where equipo.alm_codigo == codAlmacen
                                where articulos.cat_codigo == 4
                                group equipo.alm_codigo by new{
                                    alm_codigo = almacen.alm_codigo,
                                    alm_nombre = almacen.alm_nombre,
                                    cat_codigo = categoria.cat_codigo,
                                    cat_nombre = categoria.cat_nombre
                                }
                                into equip
                                orderby equip.Key.alm_codigo ascending
                                select new{
                                    alm_codigo = equip.Key.alm_codigo,
                                    alm_nombre = equip.Key.alm_nombre,
                                    cat_codigo = equip.Key.cat_codigo,
                                    cat_nombre = equip.Key.cat_nombre,
                                    cant = equip.Count()
                                }
                    );

            var queryDisponibles = (from equipo in modelAF.ACFI_equipos
                                join almacen in modelAF.ACFI_almacen on equipo.alm_codigo equals almacen.alm_codigo
                                join articulos in modelAF.ACFI_articulo on equipo.art_codigo equals articulos.art_codigo
                                join categoria in modelAF.ACFI_categoria on articulos.cat_codigo equals categoria.cat_codigo
                                where equipo.alm_codigo == 24
                                where articulos.cat_codigo == 4
                                group equipo.alm_codigo by new{
                                    alm_codigo = almacen.alm_codigo,
                                    alm_nombre = almacen.alm_nombre,
                                    cat_codigo = categoria.cat_codigo,
                                    cat_nombre = categoria.cat_nombre
                                }
                                    into equip
                                    orderby equip.Key.alm_codigo ascending
                                    select new{
                                        alm_codigo = equip.Key.alm_codigo,
                                        alm_nombre = equip.Key.alm_nombre,
                                        cat_codigo = equip.Key.cat_codigo,
                                        cat_nombre = equip.Key.cat_nombre,
                                        cant = equip.Count()
                                    }
                    );

            foreach (var resultDisponibles in queryDisponibles){
                foreach (var resultequipos in queryEquipos){
                    resAF.Add(JsonConvert.SerializeObject(new{
                        alm_codigo = resultequipos.alm_codigo,
                        alm_nombre = resultequipos.alm_nombre,
                        cat_codigo = resultequipos.cat_codigo,
                        cat_nombre = resultequipos.cat_nombre,
                        cantidad = resultequipos.cant,
                        enBodega= resultDisponibles.cant
                    }
                    ));
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