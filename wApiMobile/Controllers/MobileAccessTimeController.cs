using System;
using System.Data;
using System.Net;
using System.Web.Http;
using wApiMobile.Classes;
using wApiMobile.Models;
using wApiMobile.Utils;

namespace wApiMobile.Controllers
{
	public class MobileAccessTimeController : ApiController
	{
		public Resultado Post(MobileAccessTime mobileAccessTime)
		{
			try
			{
				string license = Helper.getValueFromQueryString("licencia");
				StoreProcedureManager spManager = new StoreProcedureManager(Helper.getConnectionStringBySerial(license), "@execRdo", "@execMsg");
				spManager.configure("sp_SetFichada");
				spManager.SqlCommand.Parameters.Add("@legajo", SqlDbType.VarChar, 10).Value = mobileAccessTime.Legajo;
				spManager.SqlCommand.Parameters.Add("@numDoc", SqlDbType.BigInt).Value = mobileAccessTime.DNI;
				spManager.SqlCommand.Parameters.Add("@movil", SqlDbType.VarChar, 10).Value = mobileAccessTime.Movil;
				spManager.SqlCommand.Parameters.Add("@tipomov", SqlDbType.TinyInt).Value = mobileAccessTime.TipoMovimiento;
				spManager.SqlCommand.Parameters.Add("@nroTelefono", SqlDbType.VarChar, 30).Value = mobileAccessTime.Telefono;
				spManager.SqlCommand.Parameters.Add("@latitud", SqlDbType.Decimal).Value = mobileAccessTime.Latitud;
				spManager.SqlCommand.Parameters.Add("@longitud", SqlDbType.Decimal).Value = mobileAccessTime.Longitud;
				spManager.SqlCommand.Parameters.Add("@usuarioId", SqlDbType.BigInt).Value = 0;
				spManager.SqlCommand.Parameters.Add("@terminalId", SqlDbType.Decimal).Value = 0;
				spManager.SqlCommand.Parameters.Add(spManager.ResultCodeParameter, SqlDbType.TinyInt).Value = 0;
				spManager.SqlCommand.Parameters.Add(spManager.ResultMessageParameter, SqlDbType.VarChar, 100).Value = "";
				spManager.SqlCommand.ExecuteNonQuery();
				spManager.cerrarConexion();
				return new Resultado((int) HttpStatusCode.OK, "La fichada se realizó correctamente");
			}
			catch (Exception ex)
			{
				return new Resultado((int) HttpStatusCode.InternalServerError, string.Format("No se pudo realizar la fichada: {0}", ex.Message));
			}
		}
	}
}
