using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509.Qualified;

namespace HutInTheWoods.Data
{
    public static class DataRepositoryExtensions
    {
        public static string GetStringOrDefault(this MySqlDataReader reader, string columnName)
        {
           return IsNotNull(reader, columnName) ? reader.GetString(columnName) : string.Empty;
        }

        public static int? GetIntOrDefault(this MySqlDataReader reader, string columnName)
        {
           return IsNotNull(reader, columnName) ? reader.GetInt32(columnName) : default(int?);
        }

        public static double? GetDoubleOrDefault(this MySqlDataReader reader, string columnName)
        {
            return IsNotNull(reader, columnName) ? reader.GetDouble(columnName) : default(double?);
        }

        public static byte? GetByteOrDefault(this MySqlDataReader reader, string columnName)
        {
            return IsNotNull(reader, columnName) ? reader.GetByte(columnName) : default(byte?);
        }

        public static DateTime? GetDateTimeOrDefault(this MySqlDataReader reader, string columnName)
        {
            return IsNotNull(reader, columnName) ? reader.GetDateTime(columnName) : default(DateTime?);
        }

        private static bool IsNotNull(MySqlDataReader reader, string columnName)
        {
            return !reader.IsDBNull(reader.GetOrdinal(columnName));
        }

    }
}
