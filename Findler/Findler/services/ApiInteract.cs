using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Findler.Templates;
using Findler.Templates.JsonTemplates.PeopleByProjectID;
using Findler.Templates.JsonTemplates.Projects;
using Newtonsoft.Json;

namespace Findler.Services
{
    internal class ApiInteract
    {
        public async Task<string> ApiSearch(string searchParam)
        {
            return await HttpGet("http://gtr.rcuk.ac.uk/gtr/api/projects?q=" + searchParam);
        }

        public async Task<Dictionary<string, PersonReportCard>> GetPeople(string searchParam)
        {
            //process the mess of queried data 

            var register = new Dictionary<string, PersonReportCard>();

            var decodedResultsProjects = JsonConvert.DeserializeObject<JsonTemplate_projects>(await HttpGet("http://gtr.rcuk.ac.uk/gtr/api/projects?q=" + searchParam));

            foreach (Project localProject in decodedResultsProjects.project)
            {
                var decodedResultsPersons = JsonConvert.DeserializeObject<JsonTemplate_peopleByProjectID>( await HttpGet("http://gtr.rcuk.ac.uk/gtr/api/projects/" + localProject.id + "/persons"));

                foreach (Person localPerson in decodedResultsPersons.person)
                {
                    if (!register.ContainsKey(localPerson.id))
                    {
                        register.Add(localPerson.id, new PersonReportCard());
                    }
                    //ADD ALL THE THINGS
                    register[localPerson.id].firstname = localPerson.firstName;
                    register[localPerson.id].lastname = localPerson.surname;
                    register[localPerson.id].projects.Add(localProject); //TODO Make work, not return null <- lolwut?
                }
            }

            return register;
        }

        private async Task<string> HttpGet(string urlIn)
        {
            var request = (HttpWebRequest) WebRequest.Create(urlIn);
            request.Accept = "application/json";

            WebResponse response = await request.GetResponseAsync();

            string temp;

            using (Stream stream = response.GetResponseStream())
            using (var reader = new StreamReader(stream))
                temp = reader.ReadToEnd();
            return temp;
        }
    }
}