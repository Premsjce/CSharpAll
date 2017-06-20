using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICall
{
    class MainClass
    {
        static void Main(string[] args)
        {
            //string endPoint = @"http:\\myRestService.com\api\";
            string endPoint = "https://quickbooks.api.intuit.com/v3/company/<realmID>/query?query=select_statement";

            //string endPointFull = @"https://quickbooks.api.intuit.com/v3/company/1234/query?query=SELECT%20FROM%20Customer%20WHERE%20Metadata.LastUpdatedTime%20%3E+%272011-08-10T10%3A20%3A30-0700%27";
            var client = new RestClient(endPoint);
            var json = client.MakeRequest();
        }
    }
}
