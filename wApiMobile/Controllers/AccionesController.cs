using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wApiMobile.Models;

namespace wApiMobile.Controllers
{
    public class AccionesController : Controller
    {
        private string cnnApp = ConfigurationManager.ConnectionStrings["cnnShaman"].ConnectionString;

        [HttpPost]
        public string setLlegadaMovil(string movil, string viajeID)
        {

            string resultado = "";
            SqlConnection sqlConn = new SqlConnection(cnnApp);
            try
            {

                sqlConn.Open();
                SqlCommand cmd = new SqlCommand("sp_SetLlegada", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@viajeId", SqlDbType.BigInt, 8).Value = viajeID;
                cmd.Parameters.Add("@movil", SqlDbType.VarChar, 10).Value = movil;
                cmd.Parameters.Add("@latitud", SqlDbType.Decimal).Value = 0;
                cmd.Parameters.Add("@longitud", SqlDbType.Decimal).Value = 0;
                cmd.Parameters.Add("@usuarioId", SqlDbType.BigInt, 8).Value = 0;
                cmd.Parameters.Add("@terminalId", SqlDbType.BigInt, 8).Value = 0;

                cmd.Parameters.Add("@execRdo", SqlDbType.TinyInt).Value = 0;
                cmd.Parameters["@execRdo"].Direction = ParameterDirection.InputOutput;
                cmd.Parameters.Add("@execMsg", SqlDbType.VarChar, 100).Value = "";
                cmd.Parameters["@execMsg"].Direction = ParameterDirection.InputOutput;

                cmd.ExecuteNonQuery();

                int codStore = Convert.ToInt32(cmd.Parameters[6].Value);
                string msgStore = cmd.Parameters[7].Value.ToString();

                if (msgStore == "") msgStore = "La llegada se dio correctamente.";

                resultado = JsonConvert.SerializeObject(new Resultado(codStore, msgStore));

            }
            catch (Exception ex)
            {
                resultado = JsonConvert.SerializeObject(new Resultado(1, ex.Message));
            }
            finally
            {
                sqlConn.Close();
            }

            return resultado;

        }

        [HttpPost]
        public string setSalidaMovil(string movil, string viajeID)
        {

            string resultado = "";
            SqlConnection sqlConn = new SqlConnection(cnnApp);
            try
            {

                sqlConn.Open();
                SqlCommand cmd = new SqlCommand("sp_SetSalida", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@viajeId", SqlDbType.BigInt, 8).Value = viajeID;
                cmd.Parameters.Add("@movil", SqlDbType.VarChar, 10).Value = movil;
                cmd.Parameters.Add("@latitud", SqlDbType.Decimal).Value = 0;
                cmd.Parameters.Add("@longitud", SqlDbType.Decimal).Value = 0;
                cmd.Parameters.Add("@usuarioId", SqlDbType.BigInt, 8).Value = 0;
                cmd.Parameters.Add("@terminalId", SqlDbType.BigInt, 8).Value = 0;

                cmd.Parameters.Add("@execRdo", SqlDbType.TinyInt).Value = 0;
                cmd.Parameters["@execRdo"].Direction = ParameterDirection.InputOutput;
                cmd.Parameters.Add("@execMsg", SqlDbType.VarChar, 100).Value = "";
                cmd.Parameters["@execMsg"].Direction = ParameterDirection.InputOutput;

                cmd.ExecuteNonQuery();

                int codStore = Convert.ToInt32(cmd.Parameters[6].Value.ToString());
                string msgStore = cmd.Parameters[7].Value.ToString();

                if (msgStore == "") msgStore = "La salida se dio correctamente";

                resultado = JsonConvert.SerializeObject(new Resultado(codStore, msgStore));

            }
            catch (Exception ex)
            {
                resultado = JsonConvert.SerializeObject(new Resultado(1, ex.Message));
            }
            finally
            {
                sqlConn.Close();

            }

            return resultado;
        }

        [HttpPost]
        public string setFinalServicio(string movil, string viajeID, int motivoID, int diagnosticoID, string observaciones)
        {

            string resultado = "";
            SqlConnection sqlConn = new SqlConnection(cnnApp);
            try
            {

                sqlConn.Open();
                SqlCommand cmd = new SqlCommand("sp_SetFinal", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@viajeId", SqlDbType.BigInt, 8).Value = viajeID;
                cmd.Parameters.Add("@movil", SqlDbType.VarChar, 10).Value = movil;
                cmd.Parameters.Add("@diagnosticoId", SqlDbType.BigInt, 8).Value = diagnosticoID;
                cmd.Parameters.Add("@motivoNoRealizacionId", SqlDbType.BigInt, 8).Value = motivoID;
                cmd.Parameters.Add("@observaciones", SqlDbType.VarChar, 260).Value = observaciones;
                cmd.Parameters.Add("@latitud", SqlDbType.Decimal).Value = 0;
                cmd.Parameters.Add("@longitud", SqlDbType.Decimal).Value = 0;
                cmd.Parameters.Add("@usuarioId", SqlDbType.BigInt, 8).Value = 0;
                cmd.Parameters.Add("@terminalId", SqlDbType.BigInt, 8).Value = 0;

                cmd.Parameters.Add("@execRdo", SqlDbType.TinyInt).Value = 0;
                cmd.Parameters["@execRdo"].Direction = ParameterDirection.InputOutput;
                cmd.Parameters.Add("@execMsg", SqlDbType.VarChar, 100).Value = "";
                cmd.Parameters["@execMsg"].Direction = ParameterDirection.InputOutput;

                cmd.ExecuteNonQuery();

                int codStore = Convert.ToInt32(cmd.Parameters[9].Value.ToString());
                string msgStore = cmd.Parameters[10].Value.ToString();

                if (msgStore == "") msgStore = "El servicio se finalizó correctamente";

                resultado = JsonConvert.SerializeObject(new Resultado(codStore, msgStore));

            }
            catch (Exception ex)
            {
                resultado = JsonConvert.SerializeObject(new Resultado(1, ex.Message));
            }
            finally
            {
                sqlConn.Close();
            }            

            return resultado;
        }

        [HttpPost]
        public string setCancelacionServicio(string movil, string viajeID, string observaciones)
        {

            string resultado = "";
            SqlConnection sqlConn = new SqlConnection(cnnApp);
            try
            {

                sqlConn.Open();
                SqlCommand cmd = new SqlCommand("sp_SetCancelacion", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@viajeId", SqlDbType.BigInt, 8).Value = viajeID;
                cmd.Parameters.Add("@movil", SqlDbType.VarChar, 10).Value = movil;
                cmd.Parameters.Add("@observaciones", SqlDbType.VarChar).Value = observaciones;
                cmd.Parameters.Add("@latitud", SqlDbType.Decimal).Value = 0;
                cmd.Parameters.Add("@longitud", SqlDbType.Decimal).Value = 0;
                cmd.Parameters.Add("@usuarioId", SqlDbType.BigInt, 8).Value = 0;
                cmd.Parameters.Add("@terminalId", SqlDbType.BigInt, 8).Value = 0;

                cmd.Parameters.Add("@execRdo", SqlDbType.TinyInt).Value = 0;
                cmd.Parameters["@execRdo"].Direction = ParameterDirection.InputOutput;
                cmd.Parameters.Add("@execMsg", SqlDbType.VarChar, 100).Value = "";
                cmd.Parameters["@execMsg"].Direction = ParameterDirection.InputOutput;

                cmd.ExecuteNonQuery();

                int codStore = Convert.ToInt32(cmd.Parameters[7].Value.ToString());
                string msgStore = cmd.Parameters[8].Value.ToString();

                if (msgStore == "") msgStore = "El servicio se canceló correctamente";

                resultado = JsonConvert.SerializeObject(new Resultado(codStore, msgStore));

            }
            catch (Exception ex)
            {
                resultado = JsonConvert.SerializeObject(new Resultado(1, ex.Message));
            }
            finally
            {
                sqlConn.Close();

            }

            return resultado;


        }




    }
}
