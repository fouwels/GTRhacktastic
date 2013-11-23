using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Findler.Templates.JsonTemplates.Projects;

namespace Findler.Templates
{
    public class PersonReportCard
    {
        public string firstname { get; set; }
        public string lastname { get; set; }

        public List<Project> projects = new List<Project>();

    }
}
