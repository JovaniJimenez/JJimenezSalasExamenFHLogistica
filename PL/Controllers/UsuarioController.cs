using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class UsuarioController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetAll()
        {
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

        [HttpGet]
        public ActionResult GetAllEquipos()
        {
            ML.Result result = BL.Usuario.GetEquipos();
            ML.Equipo equipo = new ML.Equipo();
            if (result.Correct)
            {
                equipo.Equipos = result.Objects;
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al hacer la consulta de Usuarios" + result.ErrorMessage;
            }
            return View(equipo);

        }



        [HttpPost]
        public ActionResult Form(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            //add o update
            if (usuario.IdUsuario == 0)
            {
                //add
                result = BL.Usuario.AddUsuario(usuario);
                if (result.Correct)
                {
                    ViewBag.Message = "Se inserto correctamente el Usuario";
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al insertar el Usuario" + result.ErrorMessage;
                }


            }
            else
            {
                result = BL.Usuario.UpdateUsuario(usuario);
                if (result.Correct)
                {
                    ViewBag.Message = "Se Actualizo correctamente el Usuario";
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al actualizo el Usuario" + result.ErrorMessage;
                }
                //update


            }
            return View("Modal");

        }
        [HttpGet]
        public ActionResult Form(int? idUsuario)
        {
            ML.Result resultAre = BL.Usuario.GetSupervisor();
            ML.Usuario usuario = new ML.Usuario();
            usuario.Supervisor = new ML.Supervisor();

            if (resultAre.Correct)
            {
                usuario.Supervisor.Supervisores = resultAre.Objects;
            }




            if (idUsuario == null)
            {
                return View(usuario);

            }
            else
            {


                ML.Result result = BL.Usuario.GetByIdUsuario(idUsuario.Value);


                if (result.Correct)
                {
                    usuario = (ML.Usuario)result.Object;
                    usuario.Supervisor.Supervisores = resultAre.Objects;
                    return View(usuario);

                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al hacer la consulta de Usuario " + result.ErrorMessage;
                    return View("Modal");
                }




            }
        }





        [HttpPost]
        public ActionResult GetEquipoSinAsignar(ML.Asignacion asignacion)
        {

            ML.Result result = new ML.Result();

            if (asignacion.IdAsignacion == 0)
            {
                    result = BL.Usuario.AddUsuarioEquipo(asignacion);
                    if (result.Correct)
                    {
                        ViewBag.Message = "Se Asigno correctamente el Equipo al usuario";
                    }
                    else
                    {
                        ViewBag.Message = "Ocurrio un error al Asignar --  El Motivo es el Usuario ya tiene un Equipo Asignado";
                    }

                
               


            }
            return View("Modal");
        }
        [HttpGet]
        public ActionResult GetEquipoSinAsignar(int? idAsignacion, int IdUsuario)
        {
            ML.Result resultAre = BL.Usuario.GetEquipoSinAsignar();
            ML.Asignacion asignacion = new ML.Asignacion();
            asignacion.Equipo = new ML.Equipo();
            asignacion.Usuario = new ML.Usuario();
            asignacion.Usuario.IdUsuario=IdUsuario; 

            if (resultAre.Correct)
            {

                asignacion.Equipo.Equipos = resultAre.Objects;
            }




            if (idAsignacion == null)
            {

                return View(asignacion);

            }
           


                return View(asignacion);


            }

        [HttpGet]
        public ActionResult DeleteAsignacion(int IdAsignacion)
        {
            if(IdAsignacion > 0)
            {
                BL.Usuario.DeleteAsignacion(IdAsignacion);
                ViewBag.Message = "Se Elimino la Asignacion del equipo al usuario" ;


                return View("Modal");
            }
            else
            {
                return View();
            }
        }


    }


  

}

