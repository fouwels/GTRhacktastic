using System.Collections.Generic;
using Findler.Templates.JsonTemplates.Projects;

namespace Findler.Templates
{
    public class PersonReportCard
    {
        public List<Project> projects = new List<Project>();
        public string firstname { get; set; }
        public string lastname { get; set; }
    }
}