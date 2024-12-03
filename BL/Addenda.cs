using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Addenda
    {
        public static ML.Result Add(ML.Adenda adenda)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.Cer_AddendasEntities context = new DL.Cer_AddendasEntities())
                {
                    DL.Addenda adendaBD = new DL.Addenda();
                    adendaBD.IdAddenda = adenda.IdAdenda;
                    adendaBD.nombreAddenda = adenda.NombreAddenda;
                    adendaBD.XML = adenda.XML;
                    adendaBD.FechaModificacion = Convert.ToDateTime(adenda.FechaModificacion);
                    adendaBD.Usuario = adenda.Usuario;
                    adendaBD.Estado = adenda.Estado;

                    context.Addendas.Add(adendaBD);

                    int filasAfectadas = context.SaveChanges();

                    if (filasAfectadas > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al insertar";
                    }

                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

        public static ML.Result Update(ML.Adenda adenda)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.Cer_AddendasEntities context = new DL.Cer_AddendasEntities())
                {
                    var getById = (from aden in context.Addendas
                                   where aden.IdAddenda == adenda.IdAdenda
                                   select aden).SingleOrDefault();
                    DL.Addenda adendaBD = getById;
                    //adendaBD.IdAddenda = adenda.IdAdenda;
                    adendaBD.nombreAddenda = adenda.NombreAddenda;
                    adendaBD.XML = adenda.XML;
                    adendaBD.FechaModificacion = Convert.ToDateTime(adenda.FechaModificacion);
                    adendaBD.Usuario = adenda.Usuario;
                    adendaBD.Estado = adenda.Estado;

                    int filasAfectadas = context.SaveChanges();

                    if (filasAfectadas > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al actualizar";
                    }

                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.Cer_AddendasEntities context = new DL.Cer_AddendasEntities())
                {
                    var query = (from adenda in context.Addendas
                                 select adenda).ToList();

                    if (query.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (var item in query)
                        {
                            ML.Adenda adenda = new ML.Adenda();
                            adenda.IdAdenda = item.IdAddenda;
                            adenda.NombreAddenda = item.nombreAddenda;
                            adenda.XML = item.XML;
                            adenda.FechaModificacion = item.FechaModificacion.ToString();
                            adenda.Usuario = item.Usuario;
                            adenda.Estado = item.Estado.Value;

                            result.Objects.Add(adenda);
                        }

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al obtener los datos";
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

        public static ML.Result GetById(int IdAddenda)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.Cer_AddendasEntities context = new DL.Cer_AddendasEntities())
                {
                    var query = (from adenda in context.Addendas
                                 where adenda.IdAddenda == IdAddenda
                                 select adenda).SingleOrDefault();

                    if (query != null)
                    {

                        ML.Adenda adenda = new ML.Adenda();
                        adenda.IdAdenda = query.IdAddenda;
                        adenda.NombreAddenda = query.nombreAddenda;
                        adenda.XML = query.XML;
                        adenda.FechaModificacion = query.FechaModificacion.ToString();
                        adenda.Usuario = query.Usuario;
                        adenda.Estado = query.Estado.Value;

                        result.Object = adenda;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al obtener los datos";
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

        public static ML.Result Delete(int IdAddenda)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.Cer_AddendasEntities context = new DL.Cer_AddendasEntities())
                {
                    var query = (from aden in context.Addendas
                                 where aden.IdAddenda == IdAddenda
                                 select aden).SingleOrDefault();

                    context.Addendas.Remove(query);

                    int filasAfectadas = context.SaveChanges();

                    if(filasAfectadas > 0)
                    {
                        result.Correct = true;
                    } else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo eliminar";
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }
    }
}
