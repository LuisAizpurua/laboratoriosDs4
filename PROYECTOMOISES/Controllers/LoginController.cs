using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;
using PROYECTOMOISES.Models;

namespace PROYECTOMOISES.Controllers
{
    public class LoginController : Controller
    {
        static string conexio = "Data Source=DESKTOP-FMFL8H9; Initial Catalog=Cajero; Integrated Security=true";

        public ActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registrar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection conn = new SqlConnection(conexio))
                {
                    SqlCommand cmd = new SqlCommand("RegistrarUsuario", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@p_nombre", usuario.Nombre);
                    cmd.Parameters.AddWithValue("@p_apellido", usuario.Apellido);
                    cmd.Parameters.AddWithValue("@p_correo", usuario.Correo);
                    cmd.Parameters.AddWithValue("@p_contrasena", usuario.Contrasena);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        ViewBag.ErrorMessage = "Ocurrió un error: " + ex.Message;
                        return View(usuario);
                    }
                }

                return RedirectToAction("Retirar", "Home");
            }

            return View(usuario);
        }

        public ActionResult Seccion()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Seccion(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection conn = new SqlConnection(conexio))
                {
                    SqlCommand cmd = new SqlCommand("LoginUsuario", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@p_correo", usuario.Correo);
                    cmd.Parameters.AddWithValue("@p_contrasena", usuario.Contrasena);

                    try
                    {
                        conn.Open();
                        var result = cmd.ExecuteScalar();
                        conn.Close();

                        if (result != null)
                        {
                            return RedirectToAction("Retirar", "Home");
                        }
                        else
                        {
                            ViewBag.ErrorMessage = "Correo o contraseña incorrectos.";
                            return View(usuario);
                        }
                    }
                    catch (Exception ex)
                    {
                        ViewBag.ErrorMessage = "Ocurrió un error: " + ex.Message;
                        return View(usuario);
                    }
                }
            }

            return View(usuario);
        }
    }
}
