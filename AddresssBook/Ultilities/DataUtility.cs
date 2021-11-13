using Microsoft.Extensions.Configuration;
using Npgsql;
using System;

namespace AddresssBook.Ultilities
{
    public static class DataUtility
    {
        public static string GetConectionString(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("AddressBookCS");

            var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");

            return string.IsNullOrEmpty(databaseUrl) ? connectionString : BuildConnectionString(databaseUrl);
        }

        public static string BuildConnectionString(string databaseUrl)
        {
            var databaseUri = new Uri(databaseUrl);
            var userInfo = databaseUri.UserInfo.Split(':');

            var builder = new NpgsqlConnectionStringBuilder
            {
                Host = databaseUri.Host,
                Port = databaseUri.Port,
                Username = userInfo[0],
                Password = userInfo[1],
                Database = databaseUri.LocalPath.TrimStart('/'),
                SslMode = SslMode.Prefer,
                TrustServerCertificate = true

            };

            return builder.ToString();
        }
    }
}
