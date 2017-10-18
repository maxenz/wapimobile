using System;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Threading.Tasks;
using wApiMobile.Utils;
using System.IO;
using wApiMobile.Models;
using wApiMobile.Classes;
using System.Data;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace wApiMobile.Controllers
{
    public class ActionsController : Controller
    {

        [HttpPost]
        public string setLlegadaMovil(string licencia, string movil, int viajeID)
        {
            try
            {
                StoreProcedureManager spManager = new StoreProcedureManager(Helper.getConnectionStringBySerial(licencia), "@execRdo", "@execMsg");
                spManager.configure("sp_SetLlegada");
                spManager.SqlCommand.Parameters.Add("@viajeId", SqlDbType.BigInt, 8).Value = viajeID;
                spManager.SqlCommand.Parameters.Add("@movil", SqlDbType.VarChar, 10).Value = movil;
                spManager.SqlCommand.Parameters.Add("@latitud", SqlDbType.Decimal).Value = 0;
                spManager.SqlCommand.Parameters.Add("@longitud", SqlDbType.Decimal).Value = 0;
                spManager.SqlCommand.Parameters.Add("@usuarioId", SqlDbType.BigInt, 8).Value = 0;
                spManager.SqlCommand.Parameters.Add("@terminalId", SqlDbType.BigInt, 8).Value = 0;
                spManager.SqlCommand.Parameters.Add(spManager.ResultCodeParameter, SqlDbType.TinyInt).Value = 0;
                spManager.SqlCommand.Parameters.Add(spManager.ResultMessageParameter, SqlDbType.VarChar, 100).Value = "";
                spManager.SqlCommand.ExecuteNonQuery();
                spManager.setResultado("La llegada se dio correctamente");
                spManager.cerrarConexion();
                return JsonConvert.SerializeObject(spManager.Resultado);
            }
            catch
            {
                return null;
            }

        }

        [HttpPost]
        public string setSalidaMovil(string licencia, string movil, string viajeID)
        {
            try
            {
                StoreProcedureManager spManager = new StoreProcedureManager(Utils.Helper.getConnectionStringBySerial(licencia), "@execRdo", "@execMsg");
                spManager.configure("sp_SetSalida");
                spManager.SqlCommand.Parameters.Add("@viajeId", SqlDbType.BigInt, 8).Value = viajeID;
                spManager.SqlCommand.Parameters.Add("@movil", SqlDbType.VarChar, 10).Value = movil;
                spManager.SqlCommand.Parameters.Add("@latitud", SqlDbType.Decimal).Value = 0;
                spManager.SqlCommand.Parameters.Add("@longitud", SqlDbType.Decimal).Value = 0;
                spManager.SqlCommand.Parameters.Add("@usuarioId", SqlDbType.BigInt, 8).Value = 0;
                spManager.SqlCommand.Parameters.Add("@terminalId", SqlDbType.BigInt, 8).Value = 0;
                spManager.SqlCommand.Parameters.Add(spManager.ResultCodeParameter, SqlDbType.TinyInt).Value = 0;
                spManager.SqlCommand.Parameters.Add(spManager.ResultMessageParameter, SqlDbType.VarChar, 100).Value = "";
                spManager.SqlCommand.ExecuteNonQuery();
                spManager.setResultado("La salida se dio correctamente");
                spManager.cerrarConexion();
                return JsonConvert.SerializeObject(spManager.Resultado);
            }
            catch
            {
                return null;
            }
        }

        [HttpPost]
        public string setFinalServicio(long reportNumber, string licencia, string movil, string viajeID, int motivoID, int diagnosticoID, string observaciones, string copago, string derivationTime)
        {
            try
            {

                // --> Envio de Audio 
                var uploadPath = System.Web.HttpContext.Current.Server.MapPath("~/Uploads");
                Directory.CreateDirectory(uploadPath);

                var file = System.Web.HttpContext.Current.Request.Files.Count > 0 ? System.Web.HttpContext.Current.Request.Files[0] : null;

                if (file != null && file.ContentLength > 0)
                {
                    FtpManager.Upload(file, uploadPath, licencia, movil, viajeID, "Audios");
                }

                StoreProcedureManager spManager = new StoreProcedureManager(Utils.Helper.getConnectionStringBySerial(licencia), "@execRdo", "@execMsg");
                spManager.configure("sp_SetFinalV2");
                spManager.SqlCommand.Parameters.Add("@viajeId", SqlDbType.BigInt, 8).Value = viajeID;
                spManager.SqlCommand.Parameters.Add("@movil", SqlDbType.VarChar, 10).Value = movil;
                spManager.SqlCommand.Parameters.Add("@diagnosticoId", SqlDbType.BigInt, 8).Value = diagnosticoID;
                spManager.SqlCommand.Parameters.Add("@motivoNoRealizacionId", SqlDbType.BigInt, 8).Value = motivoID;
                spManager.SqlCommand.Parameters.Add("@cosNoCobrado", SqlDbType.TinyInt).Value = copago;
                spManager.SqlCommand.Parameters.Add("@horEspera", SqlDbType.Int).Value = Utils.Helper.getHoursFromTime(derivationTime);
                spManager.SqlCommand.Parameters.Add("@minEspera", SqlDbType.Int).Value = Utils.Helper.getMinutesFromTime(derivationTime);
                spManager.SqlCommand.Parameters.Add("@observaciones", SqlDbType.VarChar, 260).Value = observaciones;
                spManager.SqlCommand.Parameters.Add("@latitud", SqlDbType.Decimal).Value = 0;
                spManager.SqlCommand.Parameters.Add("@longitud", SqlDbType.Decimal).Value = 0;
                spManager.SqlCommand.Parameters.Add("@usuarioId", SqlDbType.BigInt, 8).Value = 0;
                spManager.SqlCommand.Parameters.Add("@terminalId", SqlDbType.BigInt, 8).Value = 0;
                spManager.SqlCommand.Parameters.Add(spManager.ResultCodeParameter, SqlDbType.TinyInt).Value = 0;
                spManager.SqlCommand.Parameters.Add(spManager.ResultMessageParameter, SqlDbType.VarChar, 100).Value = "";
                spManager.SqlCommand.ExecuteNonQuery();
                spManager.setResultado("El servicio se ha finalizado correctamente.");
                spManager.cerrarConexion();

                return JsonConvert.SerializeObject(spManager.Resultado);

            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new Resultado(500, string.Format("No se pudo finalizar el servicio. Error: {0}", ex.Message)));
            }

        }

        [HttpPost]
        public string setCancelacionServicio(string licencia, string movil, string viajeID, string observaciones)
        {
            try
            {
                StoreProcedureManager spManager = new StoreProcedureManager(Utils.Helper.getConnectionStringBySerial(licencia), "@execRdo", "@execMsg");
                spManager.configure("sp_SetCancelacion");
                spManager.SqlCommand.Parameters.Add("@viajeId", SqlDbType.BigInt, 8).Value = viajeID;
                spManager.SqlCommand.Parameters.Add("@movil", SqlDbType.VarChar, 10).Value = movil;
                spManager.SqlCommand.Parameters.Add("@observaciones", SqlDbType.VarChar, 260).Value = observaciones;
                spManager.SqlCommand.Parameters.Add("@latitud", SqlDbType.Decimal).Value = 0;
                spManager.SqlCommand.Parameters.Add("@longitud", SqlDbType.Decimal).Value = 0;
                spManager.SqlCommand.Parameters.Add("@usuarioId", SqlDbType.BigInt, 8).Value = 0;
                spManager.SqlCommand.Parameters.Add("@terminalId", SqlDbType.BigInt, 8).Value = 0;
                spManager.SqlCommand.Parameters.Add(spManager.ResultCodeParameter, SqlDbType.TinyInt).Value = 0;
                spManager.SqlCommand.Parameters.Add(spManager.ResultMessageParameter, SqlDbType.VarChar, 100).Value = "";
                spManager.SqlCommand.ExecuteNonQuery();
                spManager.setResultado("El servicio se ha cancelado correctamente.");
                spManager.cerrarConexion();
                return JsonConvert.SerializeObject(spManager.Resultado);
            }
            catch
            {
                return null;
            }
        }

    }
}
