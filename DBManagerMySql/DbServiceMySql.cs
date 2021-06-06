using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBManagerMySql
{

    public class DbServiceMySql
    {
        public static int DB2I(object value)
        {
            if (Convert.IsDBNull(value)) return 0;
            try
            {
                return Convert.ToInt32(value);
            }
            catch
            {
                return 0;
            }

        }
        public static Int16 DB2I16(object value)
        {
            if (Convert.IsDBNull(value)) return 0;
            try
            {
                return Convert.ToInt16(value);
            }
            catch
            {
                return 0;
            }

        }

        public static TimeSpan DB2TIME(object value)
        {
            if (Convert.IsDBNull(value)) return new TimeSpan(0);
            try
            {
                string[] Time = value.ToString().Split(':');
                return new TimeSpan(Convert.ToInt32(Time[0]), Convert.ToInt32(Time[1]), Convert.ToInt32(Time[2]));
            }
            catch
            {
                return new TimeSpan(0);
            }

        }

        public static decimal DB2D(object value)
        {
            if (Convert.IsDBNull(value)) return 0;
            try
            {
                return Convert.ToDecimal(value);
            }
            catch
            {
                return 0;
            }

        }
        public static bool DB2B(object value)
        {
            try
            {
                return Convert.ToBoolean(value);
            }
            catch
            {
                return false;
            }

        }
        public static DateTime? DB2DTN(object value)
        {
            if (Convert.IsDBNull(value)) return null;
            try
            {
                return Convert.ToDateTime(value);
            }
            catch
            {
                return null;
            }

        }

        public static bool IsNull(object value)
        {
            return Convert.IsDBNull(value);
        }

        public static DateTime DB2DT(object value)
        {
            if (Convert.IsDBNull(value)) return DateTime.Now;
            try
            {
                return Convert.ToDateTime(value);
            }
            catch
            {
                return DateTime.Now;
            }

        }
        public static string Bool2String(bool value)
        {
            return value ? "True" : "False";
        }

        private string ConnectionString { get; set; }
        public DbServiceMySql(string sConnectionString)
        {

            ConnectionString = sConnectionString;
        }

        public string TestConnessione()
        {
            try
            {
                MySqlConnection con = new MySqlConnection(ConnectionString);
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
            catch(MySqlException Ex)
            {
                return Ex.ToString();
            }
            return string.Empty;
        }

        public QueryReader GetReader(string squery)
        {
            return new QueryReader(ConnectionString, squery);
        }
        public object GetScalar(string squery)
        {
            using(MySqlConnection con = new MySqlConnection(ConnectionString))
            {
                try
                {
                    MySqlCommand myCommand = new MySqlCommand(squery, con);
                    con.Open();
                    return myCommand.ExecuteScalar();
                }
                catch
                {
                    return null;
                }


            }
            return null;
        }

        public QueryReaderWithParameter GetReaderWithParameter(string squery)
        {
            return new QueryReaderWithParameter(ConnectionString, squery);
        }

        public DBInsertUpdate GetDBInsertUpdate(string squery)
        {
            return new DBInsertUpdate(ConnectionString, squery);
        }
    }


    public class QueryReader : IDisposable
    {
        public MySqlDataReader dr;
        MySqlConnection connection;
        public QueryReader(string ConnectionString,string query)
        {
            try
            {
                connection = new MySqlConnection(ConnectionString);
                MySqlCommand myCommand = new MySqlCommand(query, connection);
                connection.Open();
                dr = myCommand.ExecuteReader();
            }catch(Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }

        public void Dispose()
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                if (dr != null)
                    dr.Dispose();
                connection.Close();
            }
        }
    }

    public class QueryReaderWithParameter : IDisposable
    {
        private MySqlCommand dtc;
        public MySqlDataReader dr;
        MySqlConnection connection;
        public QueryReaderWithParameter(string ConnectionString, string query)
        {
            try
            {
                connection = new MySqlConnection(ConnectionString);
                dtc = new MySqlCommand(query, connection);
                connection.Open();
                
            }
            catch(Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }

        public void SetValue(string Key, object value)
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                dtc.Parameters.AddWithValue("@" + Key, value);
            }
        }

        public void Start()
        {
            try
            {
                dr = dtc.ExecuteReader();
            }catch(Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }


        public void Dispose()
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                if (dtc != null)
                    dtc.Dispose();
                connection.Close();
            }
        }


    }

    public class DBInsertUpdate : IDisposable
    {
        private MySqlCommand dtc;
        MySqlConnection connection;

        public DBInsertUpdate(string ConnectionString, string query)
        {
            try
            {
                connection = new MySqlConnection(ConnectionString);
                dtc = new MySqlCommand(query, connection);
                connection.Open();
            }
            catch
            {

            }
        }
        public long InsertUpdateRecord()
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    dtc.ExecuteNonQuery();
                    dtc.Parameters.Clear();
                    long ret = dtc.LastInsertedId;
                    return ret;

                }
                catch(Exception Ex)
                {
                    dtc.Parameters.Clear();
                    return (long)0;
                }
            }
            return 0;

        }
        public void SetValue(string Key,object value)
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                dtc.Parameters.AddWithValue("@" + Key, value);
            }
        }


        public void Dispose()
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                if (dtc != null)
                    dtc.Dispose();
                connection.Close();
            }
        }
    }


}
