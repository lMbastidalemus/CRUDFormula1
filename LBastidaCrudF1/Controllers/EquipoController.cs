using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL;

namespace LBastidaCrudF1.Controllers
{
    public class EquipoController : Controller
    {
        // GET: Equipo
        public ActionResult GetAll()
        {
            ML.Equipo equipo = new ML.Equipo();
            equipo.Equipos = new List<object>();
           
            ML.Result result = BL.Equipo.GetAll();
            equipo.Piloto = new ML.Piloto();
            equipo.Equipos = result.Objects;
            return View(equipo);
        }

        public ActionResult Form(int? IdEquipo)
        {
            ML.Equipo equipo = new ML.Equipo();
            equipo.Piloto = new ML.Piloto();
            ML.Result resultPiloto = BL.Piloto.GetAll();
          

            if (IdEquipo != null)
            {
                ML.Result result = BL.Equipo.GetById(IdEquipo.Value);
                if (result.Correct)
                {
                   
                    equipo = (ML.Equipo)result.Object;
                    equipo.Piloto.Pilotos = resultPiloto.Objects;
                }

            }
            else
            {
                equipo.Piloto.Pilotos = resultPiloto.Objects;
            }
            return View(equipo);

        }

        [HttpPost]
        public ActionResult Form(ML.Equipo equipo)
        {
            if(equipo.IdEquipo == 0)
            {
                ML.Result result = BL.Equipo.Add(equipo);
                if (result.Correct)
                {
                    ViewBag.Mensaje = "Agregado correctamente";
                }
                else
                {
                    ViewBag.Mensaje = "Error ";
                }
            }
            else
            {
                ML.Result result = BL.Equipo.Update(equipo);
                if (result.Correct)
                {
                    ViewBag.Mensaje = "Actualizado correctamente";
                }
                else
                {
                    ViewBag.Mensaje = "Error ";
                }
            }
            return PartialView("Modal");
        }

        public ActionResult Delete(int IdEquipo)
        {
            ML.Result result = BL.Equipo.Delete(IdEquipo);
            if (result.Correct)
            {
                ViewBag.Mensaje = "Eliminado correctamente";
            }
            else
            {
                ViewBag.Mensaje = "Error ";
            }
            return PartialView("Modal");
        }
    }
}