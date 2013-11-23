using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Findler.Services;
using Newtonsoft.Json;

namespace Findler.Services
{
    class ApiInteract
    {
        public async Task<string> ApiSearch(string searchParam)
        {
            return await HttpGet("http://gtr.rcuk.ac.uk/gtr/api/projects?q=" + searchParam);
        }

        public async Task<object> GetPeople(string searchParam)
        {
            var decodedResults = JsonConvert.DeserializeObject<Templates.JsonTemplate_projects>(await HttpGet("http://gtr.rcuk.ac.uk/gtr/api/projects?q=" + searchParam));

            foreach (var project in decodedResults.project)
            {
                
            }

            return new object();
        }

        private async Task<string> HttpGet(string urlIn)
        {
            var request = (HttpWebRequest)WebRequest.Create(urlIn);
            request.Accept = "application/json";

            var response = await request.GetResponseAsync();

            string temp;

            using (var stream = response.GetResponseStream())
            using (var reader = new StreamReader(stream))
                temp = reader.ReadToEnd();
            return temp;
        }

    }
}
