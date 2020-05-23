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

        // GET: Login
        [HttpGet]
        public ActionResult LoginCli(int? c)
        {
            if (c != null)
            {
                return View();

            }
            return PartialView();
        }
        [HttpPost]
        public ActionResult AutorizarCli(ent.ClienteE clientes)
        {
            using (db.InventarioPOOEntities datos = new db.InventarioPOOEntities())
            {
                var clientedetalle = datos.Cliente.Where(e => e.nombre.Equals(clientes.nombre) && e.numero_tarjeta.Equals(clientes.numero_tarjeta)).FirstOrDefault();
                if (clientedetalle == null)
                {
                    clientes.MensajeError = "Usuario o Contraseña Incorrectos";
                    return View("LoginCli", clientes);
                }
                else
                {
                    Session["sesionCli"] = "Activa";
                    Session["id_cli"] = clientedetalle.id_cli;
                    Session["nombre"] = clientedetalle.nombre;
                    Session["apellido"] = clientedetalle.apellido;
                    Session["ID_clasi"] = clientedetalle.ID_clasi;
                    Session["numero_tarjeta"] = clientedetalle.numero_tarjeta;
                    return RedirectToAction("Index", "Empleados");

                }
            }


        }
        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index","Empleados");
        }


    }
}