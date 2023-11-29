using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Equipo
    {

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.crudF1Entities context = new DL.crudF1Entities())
                {
                    var query = context.GetAllEquipo();
                    if (query != null)
                    {
                        result.Objects = new List<object>().ToList();

                        foreach (var obj in query)
                        {
                            ML.Equipo equipo = new ML.Equipo();
                            equipo.IdEquipo = obj.IdEquipo;
                            equipo.Nombre = obj.Nombre;
                            equipo.NumeroPatrocionadores = obj.NumeroPatrocinadores;
                            equipo.NumeroPilotos = obj.NumeroPilotos;
                            equipo.Costo = obj.Costo.Value;
                            equipo.Piloto = new ML.Piloto();
                            equipo.Piloto.IdPiloto = obj.IdPiloto.Value;
                            equipo.Piloto.NombrePiloto = obj.NombrePiloto;
                            equipo.Piloto.ApellidoPaterno = obj.ApellidoPaterno;
                            equipo.Piloto.ApellidoMaterno = obj.ApellidoMaterno;
                            equipo.Piloto.Nacionalidad = obj.Nacionalidad;
                            result.Objects.Add(equipo);
                        }
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public static ML.Result GetById(int IdEquipo)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.crudF1Entities context = new DL.crudF1Entities())
                {
                    var obj = context.GetByIdEquipo(IdEquipo).SingleOrDefault();
                    if (obj != null)
                    {

                        ML.Equipo equipo = new ML.Equipo();
                        equipo.IdEquipo = obj.IdEquipo;
                        equipo.Nombre = obj.Nombre;
                        equipo.NumeroPatrocionadores = obj.NumeroPatrocinadores;
                        equipo.NumeroPilotos = obj.NumeroPilotos;
                        equipo.Costo = obj.Costo.Value;
                        equipo.Piloto = new ML.Piloto();
                        equipo.Piloto.IdPiloto = obj.IdPiloto.Value;
                        equipo.Piloto.NombrePiloto = obj.NombrePiloto;
                        equipo.Piloto.ApellidoPaterno = obj.ApellidoPaterno;
                        equipo.Piloto.ApellidoMaterno = obj.ApellidoMaterno;
                        equipo.Piloto.Nacionalidad = obj.Nacionalidad;
                        result.Object = equipo;
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public static ML.Result Add(ML.Equipo equipo)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.crudF1Entities context = new DL.crudF1Entities())
                {
                    var query = context.AddEquipo(equipo.Nombre, equipo.NumeroPatrocionadores, equipo.NumeroPilotos, equipo.Piloto.IdPiloto, equipo.Costo);
                    if (query >0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
               
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public static ML.Result Update(ML.Equipo equipo)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.crudF1Entities context = new DL.crudF1Entities())
                {
                    var query = context.UpdateEquipo(equipo.IdEquipo,equipo.Nombre, equipo.NumeroPatrocionadores, equipo.NumeroPilotos, equipo.Piloto.IdPiloto, equipo.Costo);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {

                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public static ML.Result Delete(int IdEquipo)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.crudF1Entities context = new DL.crudF1Entities())
                {
                    var query = context.DeleteEquipo(IdEquipo);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {

                result.ErrorMessage = ex.Message;
            }

            return result;
        }
    }
}
