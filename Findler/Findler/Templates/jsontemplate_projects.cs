using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Findler.Templates.JsonTemplates.Projects
{
    public class OtherAttributes
    {
    }

    public class Link
    {
        public string href { get; set; }
        public string rel { get; set; }
        public long? start { get; set; }
        public long? end { get; set; }
        public OtherAttributes otherAttributes { get; set; }
    }

    public class Links
    {
        public List<Link> link { get; set; }
    }

    public class Identifier
    {
        public string value { get; set; }
        public string type { get; set; }
    }

    public class Identifiers
    {
        public List<Identifier> identifier { get; set; }
    }

    public class Project
    {
        public Links links { get; set; }
        public object ext { get; set; }
        public string id { get; set; }
        public string href { get; set; }
        public object created { get; set; }
        public object updated { get; set; }
        public Identifiers identifiers { get; set; }
        public string title { get; set; }
        public object status { get; set; }
        public object grantCategory { get; set; }
        public string abstractText { get; set; }
        public string techAbstractText { get; set; }
        public object potentialImpact { get; set; }
        public object start { get; set; }
        public object end { get; set; }
    }

    public class JsonTemplate_projects
    {
        public object links { get; set; }
        public object ext { get; set; }
        public int page { get; set; }
        public int size { get; set; }
        public int totalPages { get; set; }
        public int totalSize { get; set; }
        public List<Project> project { get; set; }
    }
}
