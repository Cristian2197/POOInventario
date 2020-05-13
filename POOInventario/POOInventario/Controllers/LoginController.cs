using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using ent = Capa_de_Entidades;
using dom = Dominio;
using System.IO;
using db = Capa_Datos;
using System.Linq.Expressions;

namespace POOInventario.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Login(int? c)
        {
            if (c!=null)
            {
                return View();

            }
            return PartialView();
        }
        [HttpPost]
        public ActionResult Autorizar(ent.RolE roles)
        {
            using (db.InventarioPOOEntities datos = new db.InventarioPOOEntities()) 
            {
                var roldetalle = datos.Rol.Where(e => e.Usuario.Equals(roles.Usuario) && e.Contraseña.Equals(roles.Contraseña)).FirstOrDefault();
                if (roldetalle==null)
                {
                    roles.MensajeError = "Usuario o Contraseña Incorrectos";
                    return View("Login",roles);
                }
                else
                {
                    Session["sesionRol"] = "Activa";
                    Session["id_rol"] = roldetalle.id_rol;
                    Session["Usuario"] = roldetalle.Usuario;
                    Session["Contraseña"] = roldetalle.Contraseña;
                    return RedirectToAction("Index", "Empleados");

                }
            }
           
            
        }
    }
}