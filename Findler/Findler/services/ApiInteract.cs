using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Findler.Services;
using Findler.Templates;
using Findler.Templates.JsonTemplates.PeopleByProjectID;
using Findler.Templates.JsonTemplates.Projects;
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
            //sort the clusterf*ck of queried data 

            var register = new Dictionary<string, PersonReportCard>();


            var decodedResultsProjects = JsonConvert.DeserializeObject<JsonTemplate_projects>(await HttpGet("http://gtr.rcuk.ac.uk/gtr/api/projects?q=" + searchParam));

            foreach (var localProject in decodedResultsProjects.project)
            {

                var DecodedResultsPersons = JsonConvert.DeserializeObject<JsonTemplate_peopleByProjectID>(await HttpGet("http://gtr.rcuk.ac.uk/gtr/api/projects/" + localProject.id + "/persons"));

                foreach (var localPerson in DecodedResultsPersons.person)
                {
                    if (!register.ContainsKey(localPerson.id))
                    {
                        register.Add(localPerson.id, new PersonReportCard());
                    }
                    //ADD ALL THE THINGS
                    register[localPerson.id].firstname = localPerson.firstName;
                    register[localPerson.id].lastname = localPerson.surname;
                    register[localPerson.id].projects.Add(localProject);
                }

                

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
