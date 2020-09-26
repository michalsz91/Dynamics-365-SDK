using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;

namespace Dynamics_365_SDK
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SDK"].ConnectionString;

            CrmServiceClient client = new CrmServiceClient(connectionString);

            var query = new QueryByAttribute("account")
            {
                ColumnSet = new ColumnSet("name", "address1_city", "emailaddress1")
            };
            query.AddAttributeValue("address1_city", "Warszawa");
            var response = client.RetrieveMultiple(query);

            foreach(var entity in response.Entities)
            {
                Console.WriteLine("Id: {0},", entity["accountid"]);
                Console.WriteLine("Name: {0},", entity["name"]);
                Console.WriteLine("City: {0}\n", entity["address1_city"]);
            }
        }
    }
}
