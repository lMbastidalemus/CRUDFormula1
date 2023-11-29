using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Piloto
    {

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.crudF1Entities context = new DL.crudF1Entities())
                {
                    var query = context.GetAllPiloto();
                    if (query != null)
                    {
                        result.Objects = new List<object>().ToList();

                        foreach (var obj in query)
                        {
                            ML.Piloto piloto = new ML.Piloto();
                            piloto.IdPiloto = obj.IdPiloto;
                            piloto.NombrePiloto = obj.NombrePiloto;
                            result.Objects.Add(piloto);
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
    }
}
