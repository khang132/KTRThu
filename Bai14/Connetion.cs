using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Bai14
{
    class Connect
    {
        public static string TenMay;
        public static string TenCSDL;
        public static string connectstring;
        public SqlConnection connect;
        public Connect()
        {

            connect = new SqlConnection(connectstring);
        }
        public Connect(string strcm)
        {
            connect = new SqlConnection(strcm);
        }
    }
}
