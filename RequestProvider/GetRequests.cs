using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.DBProvider;

namespace Tests.RequestProvider
{
    internal class GetRequests
    {
        public async Task<string> Send(DBReaderReturn dbrr, string response)
        {
            if (response.Contains("Tests"))
            {
                var message = await dbrr.ToJson("SELECT * FROM Tests");
                return message;
            }
            if (response.Contains("Questions"))
            {
               // var v = JsonConvert.DeserializeObject<ServiceGetTasks>(response);
                var message = await dbrr.ToJson($"SELECT * FROM Questions WHERE Test ='{null}'");
                return message;
            }
            if (response.Contains("Answers"))
            {
                var message = await dbrr.ToJson($"SELECT * FROM Answers WHERE Question ='{null}'");
                return message;
            }
           
            return null;
        }
    }
}
