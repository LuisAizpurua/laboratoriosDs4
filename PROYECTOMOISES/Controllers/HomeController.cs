using System;
using System.Data.SqlClient;
using System.Web.Mvc;
using PROYECTOMOISES.Models;

namespace PROYECTOMOISES.Controllers
{
    public class HomeController : Controller
    {
        static string conexio = "Data Source=.; Initial Catalog=Cajero; Integrated Security=true";

        public ActionResult Retirar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ingresar(Cuenta cuenta)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection conn = new SqlConnection(conexio))
                {
                    SqlCommand cmd = new SqlCommand("IngresarDinero", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@p_numero_cuenta", cuenta.NumeroCuenta);
                    cmd.Parameters.AddWithValue("@p_monto", cuenta.Monto);

                    try
                    {
                        conn.Open();
                        var rowsAffected = cmd.ExecuteNonQuery();
                        conn.Close();

                        if (rowsAffected > 0)
                        {
                            ViewBag.Message = "Ingreso realizado con éxito.";
                        }
                        else
                        {
                            ViewBag.ErrorMessage = "No se pudo realizar el ingreso. Verifique los datos.";
                        }
                    }
                    catch (Exception ex)
                    {
                        ViewBag.ErrorMessage = "Error: " + ex.Message;
                    }
                }
            }
            return View(cuenta);
        }

        [HttpPost]
        public ActionResult Retirar(Cuenta cuenta)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection conn = new SqlConnection(conexio))
                {
                    SqlCommand cmd = new SqlCommand("RetirarDinero", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@p_id_cuenta", cuenta.IdCuenta);
                    cmd.Parameters.AddWithValue("@p_monto_retirar", cuenta.Monto);

                    try
                    {
                        conn.Open();
                        var rowsAffected = cmd.ExecuteNonQuery();
                        conn.Close();

                        if (rowsAffected > 0)
                        {
                            ViewBag.Message = "Retiro realizado con éxito.";
                        }
                        else
                        {
                            ViewBag.ErrorMessage = "No se pudo realizar el retiro. Verifique los datos.";
                        }
                    }
                    catch (Exception ex)
                    {
                        ViewBag.ErrorMessage = "Error: " + ex.Message;
                    }
                }
            }
            return View(cuenta);
        }

        public ActionResult Consultar()
        {
            ViewBag.Message = "Consultar cuentas";
            return View();
        }

        public ActionResult Ingresar()
        {
            return View();
        }


    }
}
