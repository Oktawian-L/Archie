using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoldAPI.Data
{
    public class Db
    {
        public string ConnectionString
        {
            get
            {
                //string tcpAddress = ConfigurationManager.AppSettings["sa_host"];
                //string dbPassword = ConfigurationManager.AppSettings["sa_password"];

                return "Server=sqldb,1433;Initial Catalog=archie;Database=archie;User Id=sa;Password=5uP3RC0mpl3Xp@55w0rD";
            }
        }

        private void Provision(string text)
        {
            var connectionString = ConnectionString;
            Console.WriteLine("Dostalen connection stringa");
            using (var connection = System.Data.SqlClient.SqlClientFactory.Instance.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                var command = connection.CreateCommand();
                command.CommandText = text;
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Create()
        {
            string provision = @"
IF NOT EXISTS(SELECT * from sys.databases WHERE name = 'Votes')
BEGIN
    CREATE DATABASE Votes;
end
            ";
            Console.WriteLine("Tworze baza");
            string table = @"
IF NOT EXISTS(select * from sys.objects where type ='U' and name = 'votes') 
begin 
CREATE TABLE votes.dbo.votes (id VARCHAR(255) NOT NULL PRIMARY KEY, vote VARCHAR(255) NOT NULL); 
end 

            ";

            try
            {
                this.Provision(provision);
                this.Provision(table);
            }
            catch (Exception e)
            {
                throw new Exception("Connecting to: " + ConnectionString, e);
            }
        }
    }
 
}
