using System;
using System.Data;
using System.Data.SqlClient;
using wApiMobile.Models;

namespace wApiMobile.Classes
{
    public class StoreProcedureManager
    {
        private SqlConnection SqlConn;
        public SqlCommand SqlCommand;
        private string ConnString;
        public string ResultCodeParameter;
        public string ResultMessageParameter;
        public Resultado Resultado;

        public StoreProcedureManager(string cnnString, string resultCodeParameter, string resultMessageParameter)
        {
            ConnString = cnnString;
            SqlConn = new SqlConnection(ConnString);
            ResultCodeParameter = resultCodeParameter;
            ResultMessageParameter = resultMessageParameter;
        }

        public void configure(string storeProcedureName) {
            SqlCommand = new SqlCommand(storeProcedureName, SqlConn);
            SqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlConn.Open();
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public void ejecutarStoreProcedure()
        {
            try
            {
                SqlCommand.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                throw;
            }


        }

        public void setResultado(string okMessage)
        {
            Resultado = new Resultado(Convert.ToInt32(getParameterValue(ResultCodeParameter))
                , getParameterValue(ResultMessageParameter));

            if (Resultado.Message == "") Resultado.Message = okMessage;

        }

        private string getParameterValue(string param)
        {
            return SqlCommand.Parameters[param].Value.ToString();
        }

        public void cerrarConexion()
        {
            try
            {
                SqlConn.Close();
            }
            catch (SqlException)
            {
                throw;
            }
        }
        

    }
}