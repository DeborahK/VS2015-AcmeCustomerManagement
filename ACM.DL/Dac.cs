using System;
using System.Data;
using System.Data.SqlClient;

namespace ACM.DL
{
    /// <summary>
    /// Data access component.
    /// </summary>
    public static class Dac
    {
        #region ExecuteDataTable
        // <summary>
        // Retrieves a DataTable using a stored procedure
        // </summary>
        // <param name="storedProcedureName">Name of the stored 
        // procedure to execute</param>
        // <returns></returns>
        // <remarks></remarks>
        public static DataTable ExecuteDataTable(string storedProcedureName)
        {
            return ExecuteDataTable(storedProcedureName, null);
        }

        // <summary>
        // Retrieves a DataTable using a stored procedure with parameters
        // </summary>
        // <param name="storedProcedureName">Name of the stored 
        // procedure to execute</param>
        // <param name="arrParam">Parameters required by the stored 
        // procedure</param>
        // <returns>DataTable containing the result</returns>
        // <remarks></remarks>
        public static DataTable ExecuteDataTable(string storedProcedureName, params SqlParameter[] parameterArray)
        {
            DataTable dt=new DataTable();

            // Open the connection
            using (SqlConnection cnn = new SqlConnection(Properties.Settings.Default.ACMConnectionString) )
            {
                cnn.Open();

                // Define the command
                using (SqlCommand cmd= new SqlCommand() )
                {
                    cmd.Connection = cnn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = storedProcedureName;

                    // Handle the parameters
                    if (parameterArray != null)
                    {
                        foreach (SqlParameter param in parameterArray)
                            cmd.Parameters.Add(param);
                    }

                    // Define the data adapter and fill the dataset
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }

            }
            return dt;
        }
        #endregion

        #region ExecuteNonQuery
        /// <summary>
        /// Executes a stored procedure that does not return a dataTable and returns the
        /// first output parameter.
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure to execute</param>
        /// <param name="parameterArray">Parameters required by the stored procedure</param>
        /// <returns>First output parameter</returns>
        public static int ExecuteNonQuery(string storedProcedureName, params SqlParameter[] parameterArray)
        {
            int retVal=0;
            SqlParameter firstOutputParameter = null;

            // Open the connection
            using (SqlConnection cnn = new SqlConnection(Properties.Settings.Default.ACMConnectionString))
            {
                cnn.Open();


                // Define the command
                using (SqlCommand cmd= new SqlCommand() )
                {
                    cmd.Connection = cnn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = storedProcedureName;

                    // Handle the parameters
                    if (parameterArray != null)
                    {
                        foreach (SqlParameter param in parameterArray)
                        {
                            cmd.Parameters.Add(param);
                            if (firstOutputParameter == null && 
                                    param.Direction==ParameterDirection.Output &&
                                    param.SqlDbType == SqlDbType.Int)
                                firstOutputParameter = param;
                        }
                    }

                    // Execute the stored procedure
                    cmd.ExecuteNonQuery();

                    // Return the first output parameter value
                    if (firstOutputParameter != null)
                        retVal = (int)firstOutputParameter.Value;
                }
            }
            return retVal;
        }

        #endregion

        #region Parameter
        // <summary>
        // Creates a Parameter
        // </summary>
        // <param name="parameterName">Name of the parameter</param>
        // <param name="parameterValue">Value of the parameter</param>
        // <returns>SqlParameter object</returns>
        // <remarks>The parameter name should be the same as the
        // proeprty name</remarks>
        public static SqlParameter Parameter(string parameterName, object parameterValue)
        {
            return Parameter(parameterName, parameterValue, false);
        }

        // <summary>
        // Creates a Parameter
        // </summary>
        // <param name="parameterName">Name of the parameter</param>
        // <param name="parameterValue">Value of the parameter</param>
        // <param name="isOutput">True if the parameter should be an output parameter</param>
        // <returns>SqlParameter object</returns>
        // <remarks>The parameter name should be the same as the
        // proeprty name</remarks>
        public static SqlParameter Parameter(string parameterName, object parameterValue, bool isOutput)
        {
            SqlParameter param = new SqlParameter();

            // Set the name
            param.ParameterName = parameterName;

            // Set the value
            param.Value = parameterValue ?? DBNull.Value;

            // Set the direction
            if (isOutput)
                param.Direction = ParameterDirection.Output;

            return param;
        }
    #endregion

    }
}
