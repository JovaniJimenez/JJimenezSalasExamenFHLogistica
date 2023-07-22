using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }
       [HttpGet]
        public ActionResult GetAll()
        {
            //  ML.Departamento departamento = new ML.Departamento();
            ML.Result result = BL.Usuario.GetUsuario();
            ML.Usuario usuario = new ML.Usuario();
            if (result.Correct)
            {
                usuario.Usuarios = result.Objects;
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al hacer la consulta de Usuarios" + result.ErrorMessage;
            }
            return View(usuario);

        }

        [HttpGet]
        public ActionResult GetAllAsignaciones()
        {
            //  ML.Departamento departamento = new ML.Departamento();
            ML.Result result = BL.Usuario.GetUsuarioaAsiganciones();
            ML.Asignacion asignacion = new ML.Asignacion();
            if (result.Correct)
            {
                asignacion.Asignaciones = result.Objects;
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al hacer la consulta de Usuarios" + result.ErrorMessage;
            }
            return View(asignacion);

        }

    }
}
